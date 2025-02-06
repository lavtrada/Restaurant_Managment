namespace FoodApp.Areas.OrderList.Models;

public class OrderList
{
    public int OrderListID { get; set; }
    public int UserID { get; set; }
    public int CartID { get; set; }
    public int ItemPrice { get; set; }
    public string ItemDescription { get; set; }
    public string ItemName { get; set; }
    public string RestaurantName { get; set; }
    public string RestaurantAddress { get; set; }
    public int Quantity { get; set; }
    public string Address { get; set; }
}