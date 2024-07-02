using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Models.Cart;
using ECommerce.Ploto.Domain.Models.Image;
using ECommerce.Ploto.Domain.Models.User.ValueObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ECommerce.Ploto.Domain.Models.User
{
    public class User : BaseEntity, IAggregateRoot
    {
        public Name Name { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string Password { get; set; }
        public HomeNumber HomeNumber { get; protected set; }
        public Address Address { get; protected set; }
        public Cart.Cart? Cart { get; protected set; }
        public Guid? CartId { get; set; }

        public Guid? AvatarId { get; protected set; }
        public Image.UserAvaterImage? Avatar { get; protected set; }
        private List<Role.Role> _roles;


        /// <summary>
        /// backing Feild
        /// </summary>
        public IReadOnlyCollection<Role.Role> Roles => _roles.AsReadOnly();
        protected User()
        {

        }
        private User(Name name, string phoneNumber, HomeNumber homeNumber, Address address)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            HomeNumber = homeNumber;
            Address = address;
        }

        public static User Create(Name name, string phoneNumber, HomeNumber homeNumber, Address address)
        {
            return new User(name, phoneNumber, homeNumber, address);
        }

        public void Update(User user)
        {
            Name = user.Name;
            PhoneNumber = user.PhoneNumber;
            HomeNumber = user.HomeNumber;
            Address = user.Address;
        }

        public Cart.Cart CreateCart()
        {

            if (this.Cart is null)
            {
                return ECommerce.Ploto.Domain.Models.Cart.Cart.Create();
            }
            return this.Cart;
        }

        public void AddAvatar(byte[] avatar)
        {
            Avatar = Image.UserAvaterImage.Create(this, avatar, "application/octet-stream");
        }

        public void UpdateAvatar(byte[] file)
        {
            Avatar!.Update(file);
        }

        public void AddRole(Role.Role[] systemRoleNames, Role.Role[]? existedRoles = null, params string[] newRoels)
        {
            if (_roles is null)
            {
                _roles = new List<Role.Role>();
            }
            var toAdd = newRoels.Except(existedRoles.Select(r => r.Name)).ToArray();


            foreach (string name in toAdd)
            {
                _roles.Add(Role.Role.AddRole(name, systemRoleNames));
            }
        }


    }
}
