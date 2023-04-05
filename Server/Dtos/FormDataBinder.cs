using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SunLight.Dtos;

internal class FormDataBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

        if (bindingContext.HttpContext.Request.ContentType?.Contains("multipart/form-data") == true)
        {
            var valueResult = bindingContext.ValueProvider.GetValue("request_data");
            if (valueResult == ValueProviderResult.None)
            {
                var message =
                    bindingContext.ModelMetadata.ModelBindingMessageProvider.MissingBindRequiredValueAccessor(
                        bindingContext
                            .FieldName);
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, message);
                return;
            }

            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(valueResult.FirstValue!));

            try
            {
                var model = await JsonSerializer.DeserializeAsync(ms, bindingContext.ModelType, jsonOptions);
                bindingContext.Result = ModelBindingResult.Success(model);
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex.Message);
            }
        }
        else
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
                var model = JsonSerializer.Deserialize(content, bindingContext.ModelType);
                bindingContext.Result = ModelBindingResult.Success(model);
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex.Message);
            }
        }
    }
}