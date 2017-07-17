using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Models {
    public class RestaurantListViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Double? AverageRating { get; set; }
           
        public int? TotalReviews { get; set; }


    }
}