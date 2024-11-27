namespace InterfaceApp.Models;

public class PhysicalProductModel : IProductModel
{
    public string Title { get; set; } = string.Empty;

    public bool HasOrderBeenCompleted { get; private set; }

    public void ShipItem(CustomerModel customer)
    {
        if(HasOrderBeenCompleted == false)
        {
            Console.WriteLine($"Shipping { Title } order has been completed for the customer {customer.FirstName}");
            HasOrderBeenCompleted = true;
        }
    }
}
