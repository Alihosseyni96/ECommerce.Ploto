using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Models.Image;
using ECommerce.Ploto.Domain.Models.Product.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.Product
{
    public class Product : BaseEntity , ITraceableEntity , IAggregateRoot
    {
        public string Name { get; protected set; }
        public Color Color { get; protected set; }
        public string Description { get; protected set; }
        public Money Price { get; protected set; }
        public Dimensions Dimensions { get;protected set; }


        /// <summary>
        /// For Relations
        /// </summary>
        private readonly List<Image.ProductImage> _images;
        private readonly List<CartItem.CartItem> _cartitems;





        /// <summary>
        /// BAcking Feild  
        /// </summary>
        public IReadOnlyCollection<Image.ProductImage> Images => _images.AsReadOnly();
        public IReadOnlyCollection<CartItem.CartItem> CartItems => _cartitems.AsReadOnly();

        // Protected constructor for ORM
        protected Product()
        {
            
        }

        // Private constructor for creating instances
        private Product(string name , Color color , string des , Money price , Dimensions dimensions)
        {
            Name = name;
            Color = color;
            Description = des;
            Price = price;
            Dimensions = dimensions;
            _images = new List<Image.ProductImage>();
            _cartitems = new List<CartItem.CartItem>();

        }

        // Static factory method for creating new instances
        public static Product Create(string name, Color color, string des, Money price, Dimensions dimensions)
        {
            return new Product(name, color, des, price, dimensions);
        }


        public void SetName(string name) => Name = name;
        public void SetColor (Color color) => Color = color;
        public void SetPrice (Money price) => Price = price;
        public void SetDescription (string description) => Description = description;
        public void Update(Product product)
        {
            Name = product.Name;
            Color = product.Color;
            Price = product.Price;
            Description = product.Description;
            Dimensions = product.Dimensions;
        }
        public  void AddImage(Image.ProductImage image) => _images.Add(image);
        public void RemoveImage(Image.ProductImage image) => _images.Remove(image);
        public void ClearImages() => _images.Clear();



    }
}
