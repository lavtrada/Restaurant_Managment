using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Areas.User.Models;

public class UserModel
{
    public int UserID { get; set; }
    [Required]
    [DisplayName("User Name")]
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    [Required]
    [DisplayName("User Password")]
    public string UserPassword { get; set; }
    // public bool IsAdmin { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}