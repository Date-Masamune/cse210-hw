using System;

namespace OrderingSystem
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _state;
        private string _country;

        public Address(string street, string city, string state, string country)
        {
            _street = street ?? string.Empty;
            _city = city ?? string.Empty;
            _state = state ?? string.Empty;
            _country = country ?? string.Empty;
        }

        public bool IsInUSA()
        {
            var c = _country.Trim().ToLowerInvariant();
            return c == "usa" || c == "united states" || c == "united states of america" || c == "us";
        }

        public string ToMultiline()
        {
            return $"{_street}\n{_city}, {_state}\n{_country}";
        }
    }
}
