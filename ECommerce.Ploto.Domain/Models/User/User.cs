﻿using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Models.Cart;
using ECommerce.Ploto.Domain.Models.User.ValueObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.User
{
    public class User : BaseEntity , IAggregateRoot
    {
        public Name Name { get; set; }
        public string PhoneNumber { get;protected set; }
        public HomeNumber HomeNumber { get; set; }
        public Address Address { get; set; }
        public Cart.Cart Cart { get; protected set; }


        private User(Name name , string phoneNumber , HomeNumber homeNumber , Address address)
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
            
            if (this.Cart is  null)
            {
               return ECommerce.Ploto.Domain.Models.Cart.Cart.Create();
            }
            return this.Cart;
        }
        
    }
}
