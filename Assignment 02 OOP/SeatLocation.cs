using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01_OOP
{
    internal struct SeatLocation
    {
        public char Row;
        public int Number;

        public SeatLocation(char row , int number)
        {
            Row = row;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Row}{Number}";
        }

    }
}
