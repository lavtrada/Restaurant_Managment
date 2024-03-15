using Microsoft.Build.Framework;

namespace FoodApp.Areas.Restaurant.Models;

public class Restaurant
{
   public int RestaurantID { get; set; }
   public string RestaurantName { get; set; }
   public string RestaurantAddress { get; set; } 
   public String  RestaurantContact { get; set; }
}