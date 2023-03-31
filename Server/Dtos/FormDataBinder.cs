using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;
using System.Text.Json;

namespace SunLight.Dtos;

internal class FormDataBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        var valueResult = bindingContext.ValueProvider.GetValue("request_data");
        if (valueResult == ValueProviderResult.None)
        {
            var message =
                bindingContext.ModelMetadata.ModelBindingMessageProvider.MissingBindRequiredValueAccessor(bindingContext
                    .FieldName);
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, message);
            return;
        }

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(valueResult.FirstValue!));

        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            };
            var model = await JsonSerializer.DeserializeAsync(ms, bindingContext.ModelType, options);
            bindingContext.Result = ModelBindingResult.Success(model);
        }
        catch (Exception ex)
        {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex.Message);
        }
    }
}