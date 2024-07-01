using ECommerce.Ploto.Common.Dommin.Exception.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Exceptions
{
    internal class InvalidRoleNameEsception : DomainException
    {
        public InvalidRoleNameEsception() : base("Selected Role Name is Not Valid")
        {
            
        }
    }
}
