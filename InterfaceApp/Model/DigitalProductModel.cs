namespace InterfaceApp.Models;

public class DigitalProductModel : IDigitalProductModel
{
    public string Title { get; set; } = string.Empty;

    public bool HasOrderBeenCompleted { get; private set; }

    public int TotalRemainingDownloads { get; private set; } = 5;

    public void ShipItem(CustomerModel customer)
    {
        if(HasOrderBeenCompleted == false)
        {
            Console.WriteLine($"Emailing the { Title } order for the customer {customer.Email}");
            TotalRemainingDownloads -= 1;

            if(TotalRemainingDownloads < 1)
            {
                HasOrderBeenCompleted = true;
                TotalRemainingDownloads = 0;
            }
        }
    }
}
