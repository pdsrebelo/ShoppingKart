using System.Collections.Generic;
using System.Data.Entity;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data
{
    // We can change this inheritance to DropCreateDatabaseIfModelChanges if needed
    public class CreateDatabase : DropCreateDatabaseAlways<ShoppingKartContext>
    {
        protected override void Seed(ShoppingKartContext context)
        {
            GetItems().ForEach(c => context.Items.Add(c));

            context.Commit();
        }

        private static List<Item> GetItems()
        {
            // Since Item.Id is an identity, we don't need to specify it
            return new List<Item>
            {
                new Item
                {
                    Name = "A",
                    Price = 5.00m,
                    Offer = new Offer
                    {
                        Quantity = 3,
                        Value = 13.00m
                    }
                },
                new Item
                {
                    Name = "B",
                    Price = 3.00m,
                    Offer = new Offer
                    {
                        Quantity = 2,
                        Value = 4.50m
                    }
                },
                new Item
                {
                    Name = "C",
                    Price = 2.00m
                },
                new Item
                {
                    Name = "D",
                    Price = 1.50m
                }
            };
        }
    }
}
