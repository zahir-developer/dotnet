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
            if(product is IDigitalProductModel digitalProduct)
            {
                Console.WriteLine($"For the product { product.Title } you have {digitalProduct.TotalRemainingDownloads}");
            }
            
        }

        Console.ReadLine();

    }

    private static List<IProductModel> AddSampleData()
    {
        List<IProductModel> result = new();

        result.Add(new PhysicalProductModel { Title = "Mobile phone" });
        result.Add(new PhysicalProductModel { Title = "TV" });

        //Digital Product
        result.Add(new DigitalProductModel { Title = "Windows OS" });
        result.Add(new DigitalProductModel { Title = "Office 365" });

        //Course Product
        result.Add(new CourseProductModel{ Title = ".Net C#"});

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