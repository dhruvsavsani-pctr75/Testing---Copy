using System;
using System.Collections.Generic;

namespace WebApp.Entities.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public bool? Status { get; set; }

    public DateTime Createdtime { get; set; }

    public DateTime Lastmodifiedtime { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public bool? Isfirsttime { get; set; }

    public virtual User? CreatedbyNavigation { get; set; }

    public virtual ICollection<User> InverseCreatedbyNavigation { get; set; } = new List<User>();

    public virtual ICollection<User> InverseModifiedbyNavigation { get; set; } = new List<User>();

    public virtual ICollection<Job> JobCreatedbyNavigations { get; set; } = new List<Job>();

    public virtual ICollection<Job> JobModifiedbyNavigations { get; set; } = new List<Job>();

    public virtual ICollection<Jobapplication> JobapplicationCreatedbyNavigations { get; set; } = new List<Jobapplication>();

    public virtual ICollection<Jobapplication> JobapplicationModifiedbyNavigations { get; set; } = new List<Jobapplication>();

    public virtual ICollection<Jobapplication> JobapplicationUsers { get; set; } = new List<Jobapplication>();

    public virtual User? ModifiedbyNavigation { get; set; }

    public virtual Role Role { get; set; } = null!;
}
