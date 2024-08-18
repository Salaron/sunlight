using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Server.Endpoints.SourceGenerators;

[Generator]
public class ApiEndpointSourceGenerator : ISourceGenerator
{
    private const string AttributeName = "EndpointAttribute";

    public void Execute(GeneratorExecutionContext context)
    {
        var routeMapCode = new List<string>();
        var actionRegisterCode = new List<string>();
        var endpointMapCode = new List<string>();

        foreach (var classSymbol in GetActions(context))
        {
            var apiAttribute = classSymbol.GetAttributes().First(attr => attr.AttributeClass?.Name == AttributeName);

            var baseType = classSymbol.BaseType!;
            var requestType = baseType.TypeArguments[0].ToDisplayString();
            var responseType = baseType.TypeArguments[1].ToDisplayString();

            var routePath = apiAttribute.ConstructorArguments[0].Value.ToString();
            var usedInAPi = apiAttribute.ConstructorArguments[1].Value!.ToString().ToLower();
            var ignoreVersion = apiAttribute.ConstructorArguments[2].Value.ToString().ToLower();
            var codeCheckMode = (XCodeCheck)apiAttribute.ConstructorArguments[3].Value!; // TODO: remove cast

            var split = routePath.Split('/');
            var module = split.First();
            var action = string.Empty;
            if (split.Length == 2)
                action = split.Skip(1).First();

            routeMapCode.Add(
                $@"routeBuilder.MapPost(""/main.php/{routePath}"", (HttpContext ctx, [FromBody] {requestType} request) => ctx.RequestServices.GetService<ActionWrapper<{requestType}, {responseType}>>().Execute(request))
                .WithTags(""{module}"")
                .WithMetadata(new EndpointMetadata(""{routePath}"", {usedInAPi}, {ignoreVersion}, Server.Common.XCodeCheck.{codeCheckMode}))
                .AddEndpointFilter<XCodeFilter>()
                .AddEndpointFilter<ClientVersionFilter>();");
            actionRegisterCode.Add($"serviceCollection.AddScoped<IAction<{requestType}, {responseType}>, {classSymbol}>();");
            if (usedInAPi == "true")
                actionRegisterCode.Add($"serviceCollection.AddKeyedScoped<IAction, {classSymbol}>(\"{module}/{action}\");");
            actionRegisterCode.Add($"serviceCollection.AddScoped<ActionWrapper<{requestType}, {responseType}>>();");
        }

        var sourceCode = $@"
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Server.Endpoints.Filters;

namespace Server.Endpoints;

public static class EndpointRegister
{{
    public static WebApplication MapEndpoints(this IEndpointRouteBuilder routeBuilder)
    {{
        {string.Join("\n" + "        ", routeMapCode)}

        return routeBuilder as WebApplication;
    }}

    public static void AddEndpoints(this IServiceCollection serviceCollection)
    {{
        {string.Join("\n" + "        ", actionRegisterCode)}
    }}
}}";

        context.AddSource("EndpointRegister.generated.cs", SourceText.From(sourceCode, Encoding.UTF8));
    }

    public void Initialize(GeneratorInitializationContext context)
    {
    }

    private IEnumerable<INamedTypeSymbol> GetActions(GeneratorExecutionContext context)
    {
        foreach (var syntaxTree in context.Compilation.SyntaxTrees)
        {
            var root = syntaxTree.GetRoot();
            var semanticModel = context.Compilation.GetSemanticModel(syntaxTree);

            var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
            foreach (var classDeclaration in classDeclarations)
            {
                var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration);
                if (classSymbol != null &&
                    classSymbol.GetAttributes().Any(attr => attr.AttributeClass?.Name == AttributeName))
                    yield return (INamedTypeSymbol)classSymbol;
            }
        }
    }
}