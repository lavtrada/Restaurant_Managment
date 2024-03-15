﻿using System.Data;
using System.Data.SqlClient;
using FoodApp.Bal;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Areas.Restaurant.Controllers
{
    [Area("Restaurant")]
    public class RestaurantController:Controller
    {
        private readonly RestaurantBal _restaurantBal = new();

        #region SELECT ALL RESTAURANT
        public IActionResult Index()
        {
            var restaurant = _restaurantBal.SelectAllRestaurants();
            return View(restaurant);
        }
        #endregion

        #region InsertRestaurant

        public IActionResult Add_Edit(int RestraurantID)
        {
            if (RestraurantID != 0)
            {
                return View("Add_Edit",_restaurantBal.SelectRestaurantByID(RestraurantID));
            }
            else
            {
                return View("Add_Edit");
            }
        }

        #endregion

        #region SaveData

        [HttpPost]
        public IActionResult Save(Models.Restaurant restaurant)
        {
            if (restaurant.RestaurantID == 0)
            {
                _restaurantBal.InsertRestaurant(restaurant);
            }
            else
            {
                _restaurantBal.UpdateRestaurant(restaurant);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Restaurant

        public IActionResult Delete(int RestaurantID)
        {
            _restaurantBal.DeleteRestaurantByID(RestaurantID);
            return RedirectToAction("Index");
        }

        #endregion
    }
}