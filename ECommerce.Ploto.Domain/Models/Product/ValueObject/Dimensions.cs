using ECommerce.Ploto.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.Product.ValueObject
{
    public class Dimensions
    {
        public double Length { get; }
        public double Height { get; }
        public double Width { get; }

        
        private readonly double InvalidDimensionSize = 0;
        public Dimensions(double length, double width , double height)
        {
            Length = length;
            Height = height;
            Width = width;
            ValidateDomensions();
        }

        private void ValidateDomensions()
        {
            if (Length <= InvalidDimensionSize || Height <= InvalidDimensionSize || Width <= InvalidDimensionSize)
                throw new DimensionSizeException();
        }
    }
}
