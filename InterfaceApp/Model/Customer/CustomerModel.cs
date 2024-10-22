namespace InterfaceApp;

public class CustomerModel
{
    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string City { get; set; } = String.Empty;
    
    public int TotalRemainingDownloads { get; private set; } = 5;

    public void PurchaseDigitalProduct()
    {
        TotalRemainingDownloads -= 1;
    }

}
