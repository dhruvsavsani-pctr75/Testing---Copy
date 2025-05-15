using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using pizzashop.Entity.CustomValidations;

namespace WebApp.Entities.ViewModels.JobApplication;

public class ApplyJobViewModel
{
    public int Id { get; set; } = 0;

    [Required(ErrorMessage = "Resume is required.")]
    [ResumeFileValidation]
    [MaxFileSize(8 * 1024 * 1024)]
    public IFormFile Resume { get; set; }
}
