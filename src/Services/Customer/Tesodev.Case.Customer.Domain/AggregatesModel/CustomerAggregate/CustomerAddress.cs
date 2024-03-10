using Tesodev.Case.Customer.Domain.SeedWork;

namespace Tesodev.Case.Customer.Domain.AggregatesModel.CustomerAggregate;

public class CustomerAddress : ValueObject
{
    public Guid CustomerId { get; private set; }
    public string AddressLine { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }
    public int CityCode { get; private set; }

    public CustomerAddress() { }

    public CustomerAddress(Guid customerId, string addressLine, string city, string country, int cityCode)
    {
        if (string.IsNullOrEmpty(addressLine))
            throw new ArgumentException("AddressLine must be not null or empty");

        if (string.IsNullOrEmpty(city))
            throw new ArgumentException("City must be not null or empty");

        if (string.IsNullOrEmpty(country))
            throw new ArgumentException("Country must be not null or empty");

        if (cityCode <= 0)
            throw new ArgumentException("CityCode must be greater than 0");

        CustomerId = customerId;
        AddressLine = addressLine;
        City = city;
        Country = country;
        CityCode = cityCode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        // Using a yield return statement to return each element one at a time
        yield return CustomerId;
        yield return AddressLine;
        yield return City;
        yield return Country;
        yield return CityCode;
    }
}