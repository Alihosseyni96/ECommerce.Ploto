using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Exceptions;

namespace ECommerce.Ploto.Domain.Models.User.ValueObject;

public class HomeNumber : BaseValueObject
{
    public string Number { get; protected set; }
    public string CityCode { get; protected set; }

    private HomeNumber(string number, string cityName)
    {
        Number = number;
        CityCode = cityName;

    }
    protected HomeNumber() { }

    private static readonly string[] CityCodes = new string[5] { "021", "063", "074", "054", "087" };
    private static readonly int NumberLenght = 9;
    public static HomeNumber Create(string number, string cityCode)
    {
        Validation(number, cityCode);
        return new HomeNumber(number, cityCode);
    }

    private static void Validation(string number, string cityCode)
    {
        if (CityCodes.Contains(cityCode)) throw new InvalidCityCodeException();

        if (number.Length != NumberLenght) throw new InvalidNumberLenghtException();

    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
        yield return CityCode;
    }
}
