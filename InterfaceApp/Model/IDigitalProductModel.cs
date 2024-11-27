namespace InterfaceApp.Models;

public interface IDigitalProductModel : IProductModel
{
    string EmailSubscriptionAddress { get; set; }    
}
