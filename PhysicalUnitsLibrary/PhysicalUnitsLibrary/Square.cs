using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Converters;

namespace PhysicalUnitsLibrary
{
    public class Square: PhysicalUnit
    {
        public Square(double value, string dimension) : base(value, dimension)
        {
            ConverterForSquare converter = new ConverterForSquare();
            converter.ConvertToSi(this, dimension);
            Dimension = "m^2";
        }
        public Square() : base()
        {
            Dimension = "m";
        }

        public static Square operator +(Square square1, Square square2)
        {
            Square square = new Square();
            square.Value = square1.Value + square2.Value;
            return square;
        }

        public static Square operator -(Square square1, Square square2)
        {
            Square square = new Square();
            square.Value = square1.Value - square2.Value;
            return square;
        }

        public static NonDimensionalUnit operator /(Square square1, Square square2)
        {
            NonDimensionalUnit nonDimensionalUnit = new NonDimensionalUnit();
            nonDimensionalUnit.Value = square1.Value / square2.Value;
            return nonDimensionalUnit;
        }

        public static Distance operator /(Square square, Distance d)
        {
            Distance distance = new Distance();
            distance.Value = square.Value / d.Value;
            return distance;
        }

        public Distance Sqrt(Square S)
        {
            Distance distance = new Distance();
            distance.Value = Math.Sqrt(S.Value);
            return distance;
        }

        public Square Pow(Distance distance)
        {
            Square square = new Square();
            square.Value = Math.Pow(distance.Value, 2);
            return square;
        }

    }
}
