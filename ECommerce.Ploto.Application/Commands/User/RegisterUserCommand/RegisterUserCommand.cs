using ECommerce.Ploto.Domain.Models.Cart;
using ECommerce.Ploto.Domain.Models.User.ValueObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Commands.User.RegisterUserCommand
{
    public record RegisterUserCommand : IRequest
    {
        public string FirtsName { get;  set; }
        public string LastName { get;  set; }
        public string PhoneNumber { get;  set; }
        public string Number { get;  set; }
        public string CityCode { get;  set; }
        public string City { get;  set; }
        public string Avenue { get;  set; }
        public int HouseNO { get;  set; }



        //[JsonIgnore]
        //public byte[]? Avatar { get;  set; }

    }
}
