namespace OdeToFood.Migrations {
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDB> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            ContextKey = "OdeToFood.Models.OdeToFoodDB";
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDB context) {
            //  This method will be called after migrating to the latest version.

            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Punjab Tadka", City = "Chd", Country = "India" },
                new Restaurant { Name = "Shere-e-punjab", City = "Chd", Country = "India" },
                new Restaurant { Name = "Shahi Nawab", City = "Bengaluru", Country = "India" },
                new Restaurant {
                    Name = "Al Cuisine",
                    City = "Delhi",
                    Country = "India",
                    Reviews = new List<RestaurantReview> {
                        new RestaurantReview {Rating = 4, Body="Nice Place to hangout.", ReviewerName = "Rajat Malhotra" },
                        new RestaurantReview {Rating = 3, Body="New place to try.", ReviewerName = "Leo Messi" }
                    }
                }   
            );
        }
    }
}
