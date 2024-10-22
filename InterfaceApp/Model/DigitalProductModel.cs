namespace InterfaceApp.Models;

public class DigitalProductModel : IDigitalProductModel
{
    public string Title { get; set; } = string.Empty;

    public bool HasOrderBeenCompleted { get; private set; }

    public string EmailSubscriptionAddress { get; set; }

    public DigitalProductModel(string emailId)
    {
        EmailSubscriptionAddress = emailId;
    }

    public void ShipItem(CustomerModel customer)
    {
        if (HasOrderBeenCompleted == false)
        {
            Console.WriteLine($"Emailing the {Title} order for the customer {EmailSubscriptionAddress}");
            customer.PurchaseDigitalProduct();

            if (customer.TotalRemainingDownloads < 1)
            {
                HasOrderBeenCompleted = true;
                //TotalRemainingDownloads = 0;
            }
        }
    }
}
