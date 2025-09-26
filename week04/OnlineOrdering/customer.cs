using System;

namespace OrderingSystem
{
    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name ?? string.Empty;
            _address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public string GetName() => _name;
        public Address GetAddress() => _address;
        public bool IsInUSA() => _address.IsInUSA();
    }
}
