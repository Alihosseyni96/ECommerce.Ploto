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
    public class Role : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        private Role( string name)
        {
            Name = name;
        }

        private Role(Guid id , string name)
        {
            base.Id = id;
            Name = name;
        }

        /// <summary>
        /// too Add Role in role list of a user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="systemRoleNames"></param>
        /// <returns></returns>
        /// <exception cref="InvalidRoleNameEsception"></exception>
        public static Role AddRole(string name, Role[] systemRoleNames)
        {
            if (!systemRoleNames.Select(r => r.Name).Contains(name))
                throw new InvalidRoleNameEsception();

            return new Role(name);
        }

        /// <summary>
        /// to create role in database with seed
        /// </summary>
        /// <returns></returns>
        public static Role Create(Guid id , string name)
        {
            return new Role(id , name); 
        }
    }
}
