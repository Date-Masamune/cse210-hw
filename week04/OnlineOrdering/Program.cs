using System;
using System.Globalization;

namespace OrderingSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Order 1 — USA customer
            var addr1 = new Address("123 Prairie Ln", "Lincoln", "NE", "USA");
            var cust1 = new Customer("Alex Morgan", addr1);
            var order1 = new Order(cust1);
            order1.AddProduct(new Product("Weather Station", "WX-900", 199.99m, 1));
            order1.AddProduct(new Product("Anemometer", "AN-120", 59.50m, 2));

            // Order 2 — International customer
            var addr2 = new Address("77 Storm Rd", "Calgary", "AB", "Canada");
            var cust2 = new Customer("Jordan Lee", addr2);
            var order2 = new Order(cust2);
            order2.AddProduct(new Product("Lightning Trigger", "LT-30", 129.00m, 1));
            order2.AddProduct(new Product("Camera Rain Cover", "RC-05", 24.95m, 3));
            order2.AddProduct(new Product("Tripod Straps", "TS-11", 9.99m, 2));

            PrintOrder(order1);
            Console.WriteLine(new string('-', 48));
            PrintOrder(order2);
        }

        private static void PrintOrder(Order order)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();

            var total = order.GetTotalPrice();
            Console.WriteLine($"Total Price: {total.ToString("C", CultureInfo.CurrentCulture)}");
        }
    }
}
