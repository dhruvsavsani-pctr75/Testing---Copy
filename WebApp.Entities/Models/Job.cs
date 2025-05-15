using System;
using System.Collections.Generic;

namespace WebApp.Entities.Models;

public partial class Job
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? Location { get; set; }

    public string? Description { get; set; }

    public int NoOfApplicant { get; set; }

    public DateTime Createdtime { get; set; }

    public DateTime Lastmodifiedtime { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual User? CreatedbyNavigation { get; set; }

    public virtual ICollection<Jobapplication> Jobapplications { get; set; } = new List<Jobapplication>();

    public virtual User? ModifiedbyNavigation { get; set; }
}
