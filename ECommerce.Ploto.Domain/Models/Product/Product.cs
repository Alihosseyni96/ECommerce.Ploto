using ECommerce.Ploto.Common.Dommin.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.Product
{
    public class Product : BaseEntity , ITraceableEntity
    {
        public string Name { get; private set; }
        public Color Color { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal Tax { get;private set; }


        public Product(string name , Color color , string des , decimal price  , decimal tax)
        {
            Name = name;
            Color = color;
            Description = des;
            Price = price;
            Tax = tax;
        }

        public void SetName(string name) => Name = name;
        public void SetColor (Color color) => Color = color;
        public void SetPrice (decimal price) => Price = price;
        public void SetDescription (string description) => Description = description;
        public void SetTax (decimal tax) => Tax = tax;
        public void Update(Product product)
        {
            Name = product.Name;
            Color = product.Color;
            Price = product.Price;
            Tax = product.Tax;
            Description = product.Description;
        }




    }
}
