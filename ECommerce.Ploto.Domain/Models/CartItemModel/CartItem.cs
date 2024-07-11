using ECommerce.Ploto.Common.Dommin.Base;

namespace ECommerce.Ploto.Domain.Models
{
    public class CartItem : BaseEntity<Guid>
    {
        public int Count { get; protected set; }


        /// <summary>
        /// Realations
        /// </summary>
        public Guid ProductId { get; protected set; }
        public Product Product { get; protected set; }
        public Cart.Cart Cart { get; protected set; }
        public Guid CartId { get; set; }

        protected CartItem()
        {
            
        }
        private CartItem(Product product , int count)
        {
            Product = product;
            Count = count;
        }

    }
}
