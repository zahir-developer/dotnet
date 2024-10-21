namespace InterfaceApp.Models;

public interface IDigitalProductModel : IProductModel
{
    int TotalRemainingDownloads { get; }    
}
