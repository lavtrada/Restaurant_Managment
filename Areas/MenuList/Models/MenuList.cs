namespace FoodApp.Areas.MenuList.Models;

public class MenuList
{
    public int MenuID { get; set; }
    public int ItemID { get; set; }
    public int RestaurantID { get; set; }
    public string ItemName { get; set; } 
    public string ItemDescription { get; set; }
    public int ItemPrice { get; set; }
    public string RestaurantName { get; set; }
    public string RestaurantAddress { get; set; }
    public string CategoryName { get; set; }



}