using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.CartItem
{
    public class CartItem : BaseEntity
    {
        public int Count { get; protected set; }


        /// <summary>
        /// Realations
        /// </summary>
        public Guid ProductId { get; protected set; }
        public Product.Product Product { get; protected set; }
        public Cart.Cart Cart { get; protected set; }
        public Guid CartId { get; set; }

        protected CartItem()
        {
            
        }
        private CartItem(Product.Product product , int count)
        {
            Product = product;
            Count = count;
        }

    }
}
