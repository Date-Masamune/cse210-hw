using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderingSystem
{
    public class Order
    {
        private Customer _customer;
        private readonly List<Product> _products = new List<Product>();

        public Order(Customer customer)
        {
            _customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }

        public void AddProduct(Product product)
        {
            if (product != null) _products.Add(product);
        }

        public string GetPackingLabel()
        {
            var lines = new List<string> { "Packing Label:" };
            foreach (var p in _products)
            {
                lines.Add($"• {p.GetName()} (ID: {p.GetProductId()})");
            }
            return string.Join("\n", lines);
        }

        public string GetShippingLabel()
        {
            var lines = new List<string>
            {
                "Shipping Label:",
                _customer.GetName(),
                _customer.GetAddress().ToMultiline()
            };
            return string.Join("\n", lines);
        }

        public decimal GetTotalPrice()
        {
            decimal productsTotal = _products.Aggregate(0m, (sum, p) => sum + p.GetTotalCost());
            decimal shipping = _customer.IsInUSA() ? 5m : 35m;
            return productsTotal + shipping;
        }
    }
}
