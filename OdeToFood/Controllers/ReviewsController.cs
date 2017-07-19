using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        [HttpGet]
        public ActionResult Edit(int? reviewId) {
            if (reviewId == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var review = _db.Reviews.Find(reviewId);
            if (review == null) {
                return HttpNotFound();
            }
            return View(review);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "ReviewerName")]RestaurantReview review) {
            if (ModelState.IsValid) {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Create(int restaurantId) {
            ViewBag.RestaurantId = restaurantId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview review) {
            if (ModelState.IsValid) {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }

        protected override void Dispose(bool disposing) {
            if (_db != null) {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}