using InterfaceApp;
using InterfaceApp.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var physicalProducts = AddSampleData();

        CustomerModel customer = GetCustomerModel();

        foreach(var product in physicalProducts)
        {
            product.ShipItem(customer);
        }

        Console.ReadLine();

    }

    private static List<PhysicalProductModel> AddSampleData()
    {
        List<PhysicalProductModel> result = new();

        result.Add(new PhysicalProductModel { Title = "Mobile phone" });
        result.Add(new PhysicalProductModel { Title = "TV" });
        result.Add(new PhysicalProductModel { Title = "Washing machine" });

        return result;
    }

    private static CustomerModel GetCustomerModel()
    {
        return new CustomerModel {
            FirstName = "Zahir",
            LastName = "Hussain",
            City = "Chennai",
            Email = "zahir@dotnet.com"
        };
    }
}