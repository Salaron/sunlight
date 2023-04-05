using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SunLight.Dtos;

internal class FormDataBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        
        if (!context.Metadata.IsComplexType)
            return null;

        return new FormDataBinder();
    }
}