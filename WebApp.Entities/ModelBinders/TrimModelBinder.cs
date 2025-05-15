using Microsoft.AspNetCore.Mvc.ModelBinding;


public class TrimModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (valueProviderResult != ValueProviderResult.None)
        {
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
            string value = valueProviderResult.FirstValue;

            if (value != null)
            {
                bindingContext.Result = ModelBindingResult.Success(value.Trim());
                return Task.CompletedTask;
            }
        }
        return Task.CompletedTask;
    }
}

