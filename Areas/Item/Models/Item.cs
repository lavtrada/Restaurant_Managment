namespace FoodApp.Areas.Item.Models;

public class Item
{
    public int ItemID { get; set; }
    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public Int64 ItemPrice { get; set; }
    public int CategoryID { get; set; }
    public string RestaurantName { get; set; }
    
    public string CategoryName { get; set; }

    public string RestaurantAddress { get; set; }

    public int RestaurantID { get; set; }
    public int UserID { get; set; }
    public int Quantity { get; set; }
    public string Address { get; set; }
}