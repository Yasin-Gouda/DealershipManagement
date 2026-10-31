
using DealershipManagement;

Dealership dealership = new Dealership();
bool isRunning = true;

while (isRunning)
{
    Console.WriteLine(
        "================================\r\n" +
        " VEHICLE DEALERSHIP MANAGEMENT\r\n" +
        "================================\r\n" +
        "1. Add Vehicle\r\n" +
        "2. Register Customer\r\n" +
        "3. View Vehicles\r\n" +
        "4. View Customers\r\n" +
        "5. Record Sale\r\n" +
        "0. Exit\r\n" +
        "================================");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddVehicle(dealership);
            break;

        case "2":
            RegisterCustomer(dealership);
            break;

        case "3":
            ViewVehicles(dealership);
            break;

        case "4":
            ViewCustomers(dealership);
            break;

        case "5":
            RecordSale(dealership);
            break;

        case "0":
            isRunning = false;
            Console.WriteLine("Exiting application...");
            break;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    if (isRunning)
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}

static void AddVehicle(Dealership dealership)
{
    try
    {
        Console.WriteLine("Enter Vehicle Id:");
        int id = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Vehicle Make:");
        string make = Console.ReadLine()!;

        Console.WriteLine("Enter Vehicle Model:");
        string model = Console.ReadLine()!;

        Console.WriteLine("Enter Vehicle Year:");
        int year = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Vehicle Price:");
        decimal price = decimal.Parse(Console.ReadLine()!);

        Vehicle vehicle = new Vehicle(id, make, model, year, price);
        dealership.AddVehicle(vehicle);

        Console.WriteLine("Vehicle added successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static void RegisterCustomer(Dealership dealership)
{
    try
    {
        Console.WriteLine("Enter Customer Id:");
        int id = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Customer Full Name:");
        string fullName = Console.ReadLine()!;

        Console.WriteLine("Enter Customer Phone Number:");
        string phoneNumber = Console.ReadLine()!;

        Console.WriteLine("Enter Customer Email:");
        string email = Console.ReadLine()!;

        Customer customer = new Customer(id, fullName, phoneNumber, email);
        dealership.AddCustomer(customer);

        Console.WriteLine("Customer registered successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static void ViewVehicles(Dealership dealership)
{
    var vehicles = dealership.GetAllVehicles();

    if (vehicles.Count == 0)
    {
        Console.WriteLine("No vehicles registered.");
        return;
    }

    Console.WriteLine("All Vehicles:");

    foreach (var vehicle in vehicles)
    {
        Console.WriteLine(
            $"Id: {vehicle.Id}, Make: {vehicle.Make}, Model: {vehicle.Model}, " +
            $"Year: {vehicle.Year}, Price: {vehicle.Price:C}, " +
            $"Available: {vehicle.IsAvailable}");
    }
}

static void ViewCustomers(Dealership dealership)
{
    var customers = dealership.GetAllCustomers();

    if (customers.Count == 0)
    {
        Console.WriteLine("No customers registered.");
        return;
    }

    Console.WriteLine("Registered Customers:");

    foreach (var customer in customers)
    {
        Console.WriteLine(
            $"Id: {customer.Id}, Name: {customer.FullName}, " +
            $"Phone: {customer.PhoneNumber}, Email: {customer.Email}");
    }
}

static void RecordSale(Dealership dealership)
{
    try
    {
        Console.WriteLine("Enter Sale Id:");
        int saleId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Customer Id:");
        int customerId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Vehicle Id:");
        int vehicleId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Sale Price:");
        decimal salePrice = decimal.Parse(Console.ReadLine()!);

        Sale sale = new Sale(saleId, customerId, vehicleId, salePrice);
        dealership.RecordSale(sale);

        Console.WriteLine("Sale recorded successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
