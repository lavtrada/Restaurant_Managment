using System.Data;
using FoodApp.Areas.Restaurant.Models;
using FoodApp.Dal;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Bal;

public class RestaurantBal
{

    private RestaurantDal restaurantDal;

        public RestaurantBal()
        {
            restaurantDal = new RestaurantDal();
        }

        #region SelectAll

        public List<Restaurant> SelectAllRestaurants()
        {
            try
            {
                return restaurantDal.SelectAllRestaurants();
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region InsertRestaurant

        public bool InsertRestaurant(Restaurant restaurant)
        {
            try
            {
                return restaurantDal.InsertRestaurant(restaurant);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;

            }
        }
    #endregion

    #region SelectRestaurantByID

    public Restaurant SelectRestaurantByID(int RestaurantID)
    {
        try
        {
            return restaurantDal.SelectRestaurantByID(RestaurantID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region Update restaurant

    public bool UpdateRestaurant(Restaurant restaurant)
    {
        try
        {
            return restaurantDal.UpdateRestaurant(restaurant);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion

    #region Method : DeleteRestaurantByID

    public bool DeleteRestaurantByID(int RestaurantID)
    {
        try
        {
            return restaurantDal.DeleteRestaurantByID(RestaurantID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion
}