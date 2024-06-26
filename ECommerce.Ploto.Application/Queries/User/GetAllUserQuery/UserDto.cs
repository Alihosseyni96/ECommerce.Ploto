using ECommerce.Ploto.Domain.Models.User.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Queries.User.GetAllUserQuery
{
    internal class UserDto
    {
        public string FullName { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string HomeNumber { get; protected set; }
        public Address Address { get; protected set; }

    }
}
