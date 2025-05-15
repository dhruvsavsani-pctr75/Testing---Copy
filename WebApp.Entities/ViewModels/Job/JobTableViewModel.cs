namespace WebApp.Entities.ViewModels.Job;

public class JobTableViewModel
{
    public List<Models.Job> Jobs { get; set; } = new();
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public string SearchQuery { get; set; } = "";
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public DateTime FromDate { get; set; } = DateTime.MinValue;
    public DateTime ToDate { get; set; } = DateTime.Today;
}
