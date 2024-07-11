using ECommerce.Ploto.Common.Dommin.Base;

namespace ECommerce.Ploto.Domain.Models.Cart
{
    public class Cart : BaseEntity<Guid>
    {
        public decimal TotalAmount { get; protected set; }
        public User User { get; protected set; }
        public Guid UserId { get; protected set; }
        private List<CartItem> _cartItems;

        /// <summary>
        /// Backing Filed
        /// </summary>
        public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly();

        protected Cart()
        {

        }
        public static Cart Create()
        {
            return new Cart();
        }
        public void AddItem (CartItem cartItem)
        {
            if(_cartItems is null )
                _cartItems= new List<CartItem>();

            _cartItems.Add(cartItem);
        }

        public void AddBulkItems(CartItem[] cartItems)
        {
            if (_cartItems is null)
                _cartItems = new List<CartItem>();

            _cartItems.AddRange(cartItems);
        }


    }
}
