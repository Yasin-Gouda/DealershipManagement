using System;
using System.Collections.Generic;
using System.Linq;

namespace DealershipManagement
{
    internal class Dealership
    {
        private List<Vehicle> _vehicles = new();
        private List<Customer> _customers = new();
        private List<Sale> _sales = new();

        public void AddVehicle(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);
            if (_vehicles.Exists(v => v.Id == vehicle.Id))
                throw new InvalidOperationException($"A vehicle with Id {vehicle.Id} already exists.");
            _vehicles.Add(vehicle);
        }

        public void AddCustomer(Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);
            if (_customers.Exists(c => c.Id == customer.Id))
                throw new InvalidOperationException($"A customer with Id {customer.Id} already exists.");
            _customers.Add(customer);
        }

        public Vehicle? GetVehicleById(int id)
        {
            return _vehicles.Find(v => v.Id == id);
        }

        public Customer? GetCustomerById(int id)
        {
            return _customers.Find(c => c.Id == id);
        }

        public void RecordSale(Sale sale)
        {
            ArgumentNullException.ThrowIfNull(sale);
            if (_sales.Exists(s => s.Id == sale.Id))
                throw new InvalidOperationException($"A sale with Id {sale.Id} already exists.");
            var vehicle = GetVehicleById(sale.VehicleId);
            if (vehicle == null)
                throw new InvalidOperationException($"Vehicle with Id {sale.VehicleId} does not exist.");
            if (!vehicle.IsAvailable)
                throw new InvalidOperationException($"Vehicle with Id {sale.VehicleId} is not available for sale.");
            var customer = GetCustomerById(sale.CustomerId);
            if (customer == null)
                throw new InvalidOperationException($"Customer with Id {sale.CustomerId} does not exist.");
            vehicle.MarkAsSold();
            _sales.Add(sale);
            
        }

        public Sale? GetSaleById(int id)
        {
            return _sales.Find(s => s.Id == id);
        }

        public List<Sale> GetAllSales()
        {
            return new List<Sale>(_sales);
        }

        public decimal GetTotalRevenue()
        {
            return _sales.Sum(s => s.SalePrice);
        }

        public List<Vehicle> GetAllVehicles()
        {
            return new List<Vehicle>(_vehicles);
        }

        public List<Customer> GetAllCustomers()
        {
            return new List<Customer>(_customers);
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            return _vehicles.Where(v => v.IsAvailable).ToList();
        }

        public void UpdateVehiclePrice(int vehicleId, decimal newPrice)
        {
            var vehicle = GetVehicleById(vehicleId);
            if (vehicle == null)
                throw new InvalidOperationException($"Vehicle with Id {vehicleId} does not exist.");
           
            vehicle.UpdatePrice(newPrice);
        }

        public void UpdateCustomerPhoneNumber(int customerId, string newPhoneNumber)
        {
            var customer = GetCustomerById(customerId);
            if (customer == null)
                throw new InvalidOperationException($"Customer with Id {customerId} Doesn't Exist");

            customer.UpdatePhoneNumber(newPhoneNumber);
        }

        public void UpdateCustomerEmail(int customerId, string newEmail)
        {
            var customer = GetCustomerById(customerId);
            if (customer == null)
                throw new InvalidOperationException($"Customer with Id {customerId} Doesn't Exist");

            customer.UpdateEmail(newEmail);
        }

        public void UpdateCustomerFullName(int customerId, string newFullName)
        {
            var customer = GetCustomerById(customerId);
            if (customer == null)
                throw new InvalidOperationException($"Customer with Id {customerId} Doesn't Exist");

            customer.UpdateFullName(newFullName);
        }



    }
}
