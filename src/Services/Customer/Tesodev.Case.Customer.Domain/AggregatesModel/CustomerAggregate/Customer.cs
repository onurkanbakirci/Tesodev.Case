using Tesodev.Case.Customer.Domain.SeedWork;
namespace Tesodev.Case.Customer.Domain.AggregatesModel.CustomerAggregate;
public class Customer : Entity, IAggregateRoot
{
    private string _name;
    private string _email;
    public CustomerAddress Address { get; private set; }

    public Customer()
    {
    }

    public Customer(string name, string email)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name));

        if (string.IsNullOrEmpty(email))
            throw new ArgumentNullException(nameof(email));

        _name = name;
        _email = email;
    }

    public Customer SetCustomerAddress(string addressLine, string city, string country, int cityCode)
    {
        Address = new CustomerAddress(Id, addressLine, city, country, cityCode);
        return this;
    }

    public string GetName() => _name;
    public string GetEmail() => _email;
}