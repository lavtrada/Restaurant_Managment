namespace FoodApp.Models;

public class Admin
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}