using ECommerce.Ploto.Common.Dommin.Base;

namespace ECommerce.Ploto.Domain.Models.User.ValueObject;

public class Address : BaseValueObject
{
    public string City { get;protected set; }
    public string Avenue { get; protected set; }
    public int HouseNO { get; protected set; }

    private Address(string city , string avenue  , int houseNo)
    {
        City = city;
        Avenue = avenue;
        HouseNO = houseNo;
    }

    public static Address Create(string city, string avenue, int houseNo)
    {
        return new Address(city, avenue, houseNo);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Avenue;
        yield return HouseNO;
    }
}
