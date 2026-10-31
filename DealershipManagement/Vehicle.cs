
using System;

namespace DealershipManagement
{
    internal class Vehicle
    {
        public int Id
        {
            get;
            init
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Id), "Id must be positive.");

                field = value;
            }
        }

        public string Make { get; }
        public string Model { get; }

        public int Year { get; }

        private decimal _price;

        public decimal Price
        {
            get => _price;
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Price), "Price cannot be negative.");

                _price = value;
            }
        }

        public bool IsAvailable { get; private set; } = true;

        public Vehicle(int id, string make, string model, int year, decimal price)
        {
            if (string.IsNullOrWhiteSpace(make))
                throw new ArgumentException("Make cannot be null or empty.", nameof(make));

            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model cannot be null or empty.", nameof(model));

            if (year < 1950 || year > DateTime.Now.Year + 1)
                throw new ArgumentOutOfRangeException(nameof(year));

            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Price = price;
        }

        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
        }

        public void MarkAsSold()
        {
            if (!IsAvailable)
                throw new InvalidOperationException("Vehicle is already sold.");

            IsAvailable = false;
        }

        public void MarkAsAvailable()
        {
            if (IsAvailable)
                throw new InvalidOperationException("Vehicle is already available.");

            IsAvailable = true;
        }
    }
}
