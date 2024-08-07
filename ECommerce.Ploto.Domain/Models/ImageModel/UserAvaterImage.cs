﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.Image
{
    public class UserAvaterImage : Image
    {
        public Guid? UserId { get; protected set; }
        public User? User { get; set; }


        private UserAvaterImage()
        {
            base.ContentType = "image/png";
        }


        private UserAvaterImage(byte[] file, string contentType, User user) : base(file, contentType)
        {
            User = user;
        }

        public static UserAvaterImage Create(User user, byte[] file, string contentType)
        {
            return new UserAvaterImage(file, contentType, user);
        }

        public  void Update(byte[] file)
        {
           base.File = file;
        }

    }
}
