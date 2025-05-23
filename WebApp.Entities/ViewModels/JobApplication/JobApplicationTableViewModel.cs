using WebApp.Entities.Models;

namespace WebApp.Entities.ViewModels.JobApplication;

public class JobApplicationTableViewModel
{
    public List<Jobapplication> JobApplications { get; set; } = new();
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 5;
    public string SearchQuery { get; set; } = "";
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public DateTime FromDate { get; set; } = DateTime.MinValue;
    public DateTime ToDate { get; set; } = DateTime.Now;
    public string Status { get; set; } = "All";

}
