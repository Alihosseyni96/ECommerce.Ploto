using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Exceptions;

namespace ECommerce.Ploto.Domain.Models.User.ValueObject;

public class Name :BaseValueObject
{
    public string FirtsName { get;protected set; }
    public string LastName { get;protected set; }

    public Name(string fName , string lName)
    {
        FirtsName = fName;
        LastName = lName;
    }
    protected Name() { }

    public static Name Create(string fName , string lName)
    {
        Validation(fName, lName);
        return new Name(fName , lName);
    }

    private static void Validation(string fName , string lName)
    {
        if (string.IsNullOrEmpty(fName) || string.IsNullOrEmpty(lName))
            throw new UserNameValidationException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirtsName;
        yield return LastName;
    }
}
