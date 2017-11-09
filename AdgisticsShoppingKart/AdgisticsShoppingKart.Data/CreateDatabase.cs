using System.Collections.Generic;
using System.Data.Entity;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data
{
    public class CreateDatabase : DropCreateDatabaseIfModelChanges<ShoppingKartEntities>
    {
        protected override void Seed(ShoppingKartEntities context)
        {
            GetItems().ForEach(c => context.Items.Add(c));

            context.Commit();
        }

        private static List<Item> GetItems()
        {
            return new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "A",
                    Value = 5.00m
                },
                new Item
                {
                    Id = 2,
                    Name = "B",
                    Value = 3.00m
                },
                new Item
                {
                    Id = 3,
                    Name = "C",
                    Value = 2.00m
                },
                new Item
                {
                    Id = 4,
                    Name = "D",
                    Value = 1.50m
                }
            };
        }
    }
}
