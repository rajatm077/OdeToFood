namespace OdeToFood.Migrations {
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDB> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDB context) {
            context.Restaurants.AddOrUpdate(
                r => r.Name,
                new Restaurant { Name = "JW Marriott", City = "Chandigarh", Country = "India" }
                );
        }
    }
}
