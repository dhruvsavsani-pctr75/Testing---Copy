using Microsoft.AspNetCore.Mvc;

public class TrimAttribute : ModelBinderAttribute
{
    public TrimAttribute() : base(typeof(TrimModelBinder)) { }
}
