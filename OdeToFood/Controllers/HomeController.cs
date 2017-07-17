using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers {
    public class HomeController : Controller {
        OdeToFoodDB _db = new OdeToFoodDB();

        public ActionResult Index(string searchTerm = null) {
            /*
            var restaurants = from r in _db.Restaurants
                              orderby r.Reviews.Average(rev => rev.Rating) descending
                              select new RestaurantListViewModel {
                                  Id = r.Id,
                                  Name = r.Name,
                                  City = r.City,
                                  Country = r.Country,
                                  TotalReviews = r.Reviews.Count,
                                  AverageRating = r.Reviews.Average(rev => rev.Rating)
                              };

            */

            var restaurants = _db.Restaurants
                              .OrderByDescending(r => r.Reviews.Average(rev => rev.Rating))
                              .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                              .Select(r => new RestaurantListViewModel {
                                  Id = r.Id,
                                  Name = r.Name,
                                  City = r.City,
                                  Country = r.Country,
                                  TotalReviews = r.Reviews.Count,
                                  AverageRating = (r.Reviews.Count > 0) ? 
                                  r.Reviews.Average(rev => rev.Rating) : 0.0
                              });

                return View(restaurants);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing) {
            if (_db != null) {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}