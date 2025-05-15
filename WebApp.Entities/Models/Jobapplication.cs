using System;
using System.Collections.Generic;

namespace WebApp.Entities.Models;

public partial class Jobapplication
{
    public int Id { get; set; }

    public int JobId { get; set; }

    public int UserId { get; set; }

    public string? Status { get; set; }

    public string? Resume { get; set; }

    public DateTime Createdtime { get; set; }

    public DateTime Lastmodifiedtime { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual User? CreatedbyNavigation { get; set; }

    public virtual Job Job { get; set; } = null!;

    public virtual User? ModifiedbyNavigation { get; set; }

    public virtual User User { get; set; } = null!;
}
