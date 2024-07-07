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
        private List<UserRole.UserRole>? _userRoles;


        /// <summary>
        /// backing Feild
        /// </summary>
        public IReadOnlyCollection<UserRole.UserRole>? UserRoles => _userRoles?.AsReadOnly();


        private Role(Guid id , string name)
        {
            base.Id = id;
            Name = name;
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
