using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.Cart
{
    public class Cart : BaseEntity , ITraceableEntity
    {
        public decimal TotalAmount { get; protected set; }
        public User.User User { get; protected set; }
        public Guid UserId { get; protected set; }
        private List<CartItem.CartItem> _cartItems;

        /// <summary>
        /// Backing Filed
        /// </summary>
        public IReadOnlyCollection<CartItem.CartItem> CartItems => _cartItems.AsReadOnly();

        protected Cart()
        {

        }
        public static Cart Create()
        {
            return new Cart();
        }
        public void AddItem (CartItem.CartItem cartItem)
        {
            if(_cartItems is null )
                _cartItems= new List<CartItem.CartItem>();

            _cartItems.Add(cartItem);
        }

        public void AddBulkItems(CartItem.CartItem[] cartItems)
        {
            if (_cartItems is null)
                _cartItems = new List<CartItem.CartItem>();

            _cartItems.AddRange(cartItems);
        }


    }
}
