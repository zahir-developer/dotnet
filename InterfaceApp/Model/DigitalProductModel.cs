namespace InterfaceApp.Models;

public class DigitalProductModel : IDigitalProductModel
{
    public string Title { get; set; } = string.Empty;

    public bool HasOrderBeenCompleted { get; private set; }

    public int TotalMaxDownloads { get; private set; } = 5;

    public void ShipItem(CustomerModel customer)
    {
        if(HasOrderBeenCompleted == false)
        {
            Console.WriteLine($"Emailing the { Title } order for the customer {customer.Email}");
            TotalMaxDownloads -= 1;

            if(TotalMaxDownloads < 1)
            {
                HasOrderBeenCompleted = true;
                TotalMaxDownloads = 0;
            }
        }
    }
}
