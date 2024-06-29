using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Exceptions;
using ECommerce.Ploto.Domain.Models.Product;
using ECommerce.Ploto.Domain.Models.User;
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
        public string ContentType { get; protected set; }


        protected Image()
        {
            
        }

        protected Image(byte[] file, string contentType)
        {
            File = file;
            ContentType = contentType;
        }



    }
}
