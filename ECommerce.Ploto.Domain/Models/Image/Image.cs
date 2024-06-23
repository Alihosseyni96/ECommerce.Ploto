using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Models.Product;
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
        public Product.Product Product { get; protected set; }

        public Guid UserId { get; protected set; }
        public User.User User { get; set; }

        private Image(byte[] file , Type type )
        {
            File = file;
            Type = type;
        }
        protected Image()
        {
            
        }
        public static Image Create(byte[] file , Type type )
        {
            return new  Image(file , type);
        }


    }
}
