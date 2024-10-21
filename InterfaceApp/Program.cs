using InterfaceApp;
using InterfaceApp.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Interface App, Reference: IAmTimCorey - https://www.youtube.com/watch?v=A7qwuFnyIpM");

        var physicalProducts = AddSampleData();

        CustomerModel customer = GetCustomerModel();

        foreach(var product in physicalProducts)
        {
            product.ShipItem(customer);
        }

        Console.ReadLine();

    }

    private static List<IProductModel> AddSampleData()
    {
        List<IProductModel> result = new();

        result.Add(new PhysicalProductModel { Title = "Mobile phone" });
        result.Add(new PhysicalProductModel { Title = "TV" });
        //
        result.Add(new DigitalProductModel { Title = "Windows OS" });



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