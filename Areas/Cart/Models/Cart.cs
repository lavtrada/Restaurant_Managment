namespace FoodApp.Areas.Cart.Models;

public class Cart:OrderList.Models.OrderList
{
    public int CartID { get; set; }
    public int ItemID { get; set; }
    public int ItemPrice { get; set; }
    public string ItemDescription { get; set; }
    public string ItemName { get; set; }
    public string RestaurantName { get; set; }
    public string RestaurantAddress { get; set; }
    public int Quantity { get; set; }
    public string Address { get; set; }
}