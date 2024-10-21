namespace InterfaceApp;
public interface IProductModel
{
    public string Title { get; set; }

    bool HasOrderBeenCompleted { get; }

    void ShitItem(CustomerModel customer);
}