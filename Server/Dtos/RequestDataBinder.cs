using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SunLight.Dtos;

internal class RequestDataBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        if (bindingContext.HttpContext.Request.ContentType?.Contains("multipart/form-data") == true)
        {
            await BindFromFormData(bindingContext);
            return;
        }

        if (bindingContext.HttpContext.Request.ContentType?.Contains("application/json") == true)
        {
            await BindFromJson(bindingContext);
            return;
        }

        bindingContext.Result = ModelBindingResult.Failed();
    }

    private async Task BindFromFormData(ModelBindingContext bindingContext)
    {
        var valueResult = bindingContext.ValueProvider.GetValue("request_data");
        if (valueResult == ValueProviderResult.None)
        {
            var message =
                bindingContext.ModelMetadata.ModelBindingMessageProvider.MissingBindRequiredValueAccessor(
                    bindingContext
                        .FieldName);
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, message);
        }

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(valueResult.FirstValue!));

        try
        {
            var model = await JsonSerializer.DeserializeAsync(ms, bindingContext.ModelType, JsonSerializerDefaultOptions.GetOptions());
            bindingContext.Result = ModelBindingResult.Success(model);
        }
        catch (Exception ex)
        {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex.Message);
        }
    }

    private async Task BindFromJson(ModelBindingContext bindingContext)
    {
        using var streamReader = new StreamReader(bindingContext.HttpContext.Request.Body);
        var content = await streamReader.ReadToEndAsync();
        if (content == string.Empty)
        {
            var message =
                bindingContext.ModelMetadata.ModelBindingMessageProvider.MissingBindRequiredValueAccessor(
                    bindingContext
                        .FieldName);
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, message);
            return;
        }
        
        try
        {
            var model = JsonSerializer.Deserialize(content, bindingContext.ModelType, JsonSerializerDefaultOptions.GetOptions());
            bindingContext.Result = ModelBindingResult.Success(model);
        }
        catch (Exception ex)
        {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex.Message);
        }
    }
}