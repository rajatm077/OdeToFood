using OdeToFood.Models;
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

            var reviews = _db.Reviews.Find(restaurantId);
            if (true) {

            }
            return View(reviews);
        }

        protected override void Dispose(bool disposing) {
            if (_db != null) {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}