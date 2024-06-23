using ECommerce.Ploto.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Ploto.Common.Dommin.Base;

namespace ECommerce.Ploto.Domain.Models.Product.ValueObject;

public class Dimensions : BaseValueObject
{
    public double Length { get; }
    public double Height { get; }
    public double Width { get; }


    private readonly double InvalidDimensionSize = 0;
    protected Dimensions(double length, double width, double height)
    {
        ValidateDomensions(length, width, height);
        Length = length;
        Height = height;
        Width = width;
    }
    protected Dimensions()
    {
        
    }

    private void ValidateDomensions(double length, double width, double height)
    {
        if (Length <= InvalidDimensionSize || Height <= InvalidDimensionSize || Width <= InvalidDimensionSize)
            throw new DimensionSizeException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Length;
        yield return Height;
        yield return Width;
    }
}
