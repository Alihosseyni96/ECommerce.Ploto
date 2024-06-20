using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.User.ValueObject
{
    public class Address
    {
        public string City { get; set; }
        public string Avenue { get; set; }
        public int HouseNO { get; set; }

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
    }
}
