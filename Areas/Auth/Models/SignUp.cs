using System.ComponentModel.DataAnnotations;

namespace FoodApp.Areas.Auth.Models;

public class SignUp
{
    [Required] public string UserName { get; set; }
    [Required] public string Email { get; set; }

    [Required] public string Password { get; set; }

    // [Required] public string IsAdmin { get; set; }
    [Required] public DateTime CreatedAt { get; set; }
    [Required] public DateTime ModifiedAt { get; set; }

}