using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Areas.Auth.Models;

public class Auth
{
    public int UserID { get; set; }
    [Required]
    [DisplayName("User Name")]
    public string UserName { get; set; }
    [Required]
    [DisplayName("UserEmail")]
    public string UserEmail { get; set; }
    [Required]
    [DisplayName("User Password")]
    public string UserPassword { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
