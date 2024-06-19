using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Models.User.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.User
{
    public class User : BaseEntity , IAggregateRoot
    {
        public Name Name { get; set; }
        public string PhoneNumber { get;protected set; }

        public int MyProperty { get; set; }

    }
}
