namespace InterfaceApp.Models;

public class CourseProductModel : IProductModel
{
    public string Title { get; set; } = string.Empty;

    public bool HasOrderBeenCompleted { get; private set; }

    public void ShipItem(CustomerModel customer)
    {
        if(HasOrderBeenCompleted == false)
        {
            Console.WriteLine($"Adding Course { Title } for the customer {customer.FirstName}");
            HasOrderBeenCompleted = true;
        }
    }
}
