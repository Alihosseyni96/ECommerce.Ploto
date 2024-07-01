using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Exceptions;
using ECommerce.Ploto.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.Role
{
    public class Role : BaseEntity , IAggregateRoot
    {
        public string Name { get; private set; }
        private List<User.User> _users;
        

        /// <summary>
        /// Backing field
        /// </summary>
        public IReadOnlyCollection<User.User> Users => _users.AsReadOnly();
        private Role(string name)
        {
            Name = name;
            _users = new List<User.User>();
        }

        public static Role Create(string name, Role[] systemRoleNames)
        {
            if (!systemRoleNames.Select(r=> r.Name).Contains(name))
                throw new InvalidRoleNameEsception();

            return new Role(name);
        }
    }
}
