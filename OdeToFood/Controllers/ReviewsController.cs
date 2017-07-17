﻿using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers {
    public class ReviewsController : Controller {
        private OdeToFoodDB _db = new OdeToFoodDB();
        // GET: Reviews
        public ActionResult Index([Bind(Prefix = "id")] int restaurantId) {
            var restaurant = _db.Restaurants.Find(restaurantId);
            if (restaurant != null) {
                return View(restaurant);
            } else {
                return HttpNotFound(); 
            }
        }

        protected override void Dispose(bool disposing) {
            if (_db != null) {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}