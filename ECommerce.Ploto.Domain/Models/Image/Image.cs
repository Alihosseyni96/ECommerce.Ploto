﻿using ECommerce.Ploto.Common.Dommin.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.Image
{
    public class Image : BaseEntity
    {
        public byte[] File { get; protected set; }
        public Type Type { get;protected set; }

        public Guid ProductId { get; protected set; }

        public Image(byte[] file , Type type )
        {
            File = file;
            Type = type;
        }


    }
}
