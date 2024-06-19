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
    public class Product : BaseEntity , ITraceableEntity
    {
        public string Name { get; protected set; }
        public Color Color { get; protected set; }
        public string Description { get; protected set; }
        public Money Price { get; protected set; }
        public Dimensions Dimensions { get;protected set; }

        /// <summary>
        /// For Relations
        /// </summary>
        private readonly List<Image.Image> _images;




        /// <summary>
        /// To Expose relarions as readonly 
        /// </summary>
        public IReadOnlyCollection<Image.Image> Images => _images.AsReadOnly();


        private Product(string name , Color color , string des , Money price , Dimensions dimensions)
        {
            Name = name;
            Color = color;
            Description = des;
            Price = price;
            Dimensions = dimensions;
            _images = new List<Image.Image>();
        }

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
        public  void AddImage(Image.Image image) => _images.Add(image);
        public void RemoveImage(Image.Image image) => _images.Remove(image);
        public void ClearImages() => _images.Clear();



    }
}
