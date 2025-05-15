using System.ComponentModel.DataAnnotations;

namespace WebApp.Entities.ViewModels.Job;

public class AddJobViewModel
{
    public int? Id { get; set; } = 0;

    [Required(ErrorMessage = "Job title is required.")]
    [Trim]
    [MaxLength(100, ErrorMessage = "Title can't be longer then 100.")]
    public string Title { get; set; } = "";

    [Required(ErrorMessage = "Company name is required.")]
    [Trim]
    [MaxLength(150, ErrorMessage = "Companyname can't be longer then 100.")]
    public string CompanyName { get; set; } = "";

    [Required(ErrorMessage = "Description is required.")]
    [Trim]
    [MaxLength(150, ErrorMessage = "Description can't be longer then 100.")]
    public string Description { get; set; } = "";

    [Trim]
    public string? Location { get; set; }
}
