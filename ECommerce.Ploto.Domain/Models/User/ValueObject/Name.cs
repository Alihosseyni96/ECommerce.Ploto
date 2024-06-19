using ECommerce.Ploto.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.User.ValueObject
{
    public class Name
    {
        public string FirtsName { get;protected set; }
        public string LastName { get;protected set; }

        private Name(string fName , string lName)
        {
            FirtsName = fName;
            LastName = lName;
        }

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
    }
}
