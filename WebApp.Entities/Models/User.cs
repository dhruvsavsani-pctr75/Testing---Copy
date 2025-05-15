using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Entities.Models;

public class User
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Username { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    [Required]
    [ForeignKey("Role")]
    public int RoleId { get; set; } = 1;

    [Required]
    public DateTime Createdtime { get; set; } = DateTime.Now;

    [Required]
    public DateTime Lastmodifiedtime { get; set; } = DateTime.Now;

    [Required]
    public int? Createdby { get; set; } = 1;

    [Required]
    public int? Modifiedby { get; set; } = 1;

    [Required]
    public bool Isdeleted { get; set; } = false;
    public virtual Role Role { get; set; } = null!;
    public virtual User? CreatedbyNavigation { get; set; }
    public virtual ICollection<User> InverseCreatedbyNavigation { get; set; } = new List<User>();
    public virtual User? ModifiedbyNavigation { get; set; }
    public virtual ICollection<User> InverseModifiedbyNavigation { get; set; } = new List<User>();
}
