using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Common.Extensions;
using ECommerce.Ploto.Domain.Models.Cart;
using ECommerce.Ploto.Domain.Models.Image;
using ECommerce.Ploto.Domain.Models.Role;
using ECommerce.Ploto.Domain.Models.User.ValueObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ECommerce.Ploto.Domain.Models.User
{
    public class User : BaseEntity, IAggregateRoot
    {
        public Name Name { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string Password { get; protected set; }
        public HomeNumber HomeNumber { get; protected set; }
        public Address Address { get; protected set; }
        public Cart.Cart? Cart { get; protected set; }
        public Guid? CartId { get; protected set; }

        public Guid? AvatarId { get; protected set; }
        public Image.UserAvaterImage? Avatar { get; protected set; }

        public Guid RoleId { get; protected set; }
        public Role.Role Role { get; protected set; }



        #region Constructors
        /// <summary>
        /// constructor for ORM
        /// </summary>
        protected User()
        {

        }

        /// <summary>
        /// constructor for USer creation in application services
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="homeNumber"></param>
        /// <param name="address"></param>
        private User(Name name, string phoneNumber, string password, HomeNumber homeNumber, Address address)
        {
            Name = name;
            Password = password.ComputeSha256Hash();
            PhoneNumber = phoneNumber;
            HomeNumber = homeNumber;
            Address = address;
        }

        /// <summary>
        /// constructor to seed Data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="homeNumber"></param>
        /// <param name="address"></param>
        private User(Guid id, Name name, string phoneNumber, string password, HomeNumber homeNumber, Address address)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Password = password.ComputeSha256Hash();
            HomeNumber = homeNumber;

        }

        #endregion

        public static User Create(Name name, string phoneNumber, string password, HomeNumber homeNumber, Address address)
        {
            return new User(name, phoneNumber, password, homeNumber, address);
        }

        /// <summary>
        /// To Create int Seed 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="homeNumber"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static User Create(Guid id, Name name, string phoneNumber, string password, HomeNumber homeNumber, Address address)
        {
            return new User(id, name, phoneNumber, password, homeNumber, address);
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


        public void AddRole(Role.Role role)
        {
            if(this.RoleId == role.Id)
            {
                return;
            }

            this.Role = role;
        }


    }
}
