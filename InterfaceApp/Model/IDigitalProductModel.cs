namespace InterfaceApp.Models;

public interface IDigitalProductModel : IProductModel
{
    string Title { get; set; }

    bool HasOrderBeenCompleted { get; }

    int TotalMaxDownloads { get; }

    void ShipItem(CustomerModel customer);
    
}
