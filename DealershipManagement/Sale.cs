using System;
using System.Collections.Generic;
using System.Text;

namespace DealershipManagement
{
    internal class Sale
    {
        private decimal _salePrice;
        public decimal SalePrice
        {
            get => _salePrice;
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(SalePrice), "Sale price cannot be zero or negative.");
                _salePrice = value;
            }
        }

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

        public int CustomerId {
            get;
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(CustomerId), "Customer Id must be positive.");
                field = value;
            }
        }
        public int VehicleId {
            get;
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(VehicleId), "Vehicle Id must be positive."); 
                field = value;
            }
        }
        public DateTime SaleDate { get; private set; } = DateTime.Now;
    
        public Sale(int id, int customerId, int vehicleId, decimal salePrice)
        {
            Id = id;
            CustomerId = customerId;
            VehicleId = vehicleId;
            SalePrice = salePrice;
        }
    }
}
