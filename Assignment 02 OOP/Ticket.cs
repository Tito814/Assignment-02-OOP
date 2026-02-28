using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01_OOP
{
    internal class Ticket
    {
        public static int TicketCounter = 0;

        public int TicketId { get; }

        private string _movieName;

        private TicketType _type;

        private SeatLocation _seat;

        private double _price;

        public string MovieName
        {
            get { return _movieName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _movieName = value;

                }

            }
        }
        public TicketType Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public SeatLocation Seat
        {
            get { return _seat; }
            set { _seat = value; }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
            }
        }

        public double PriceAfterTax => Price + (Price * 0.14);


        public Ticket(string movie, TicketType type, SeatLocation seat, double price)
        {
            TicketCounter++;

            TicketId = TicketCounter;

            MovieName = movie;
            Type = type;
            Seat = seat;
            Price = price;
        }

        public Ticket(string movie)
            : this(movie, TicketType.Standard, new SeatLocation('A', 1), 50)
        {
        }

        public static int GetTotalTicketsSold()
        {
            return TicketCounter;
        }

        public double CalcTotal(double taxPercent)
        {
            return Price + (Price * (taxPercent / 100));

        }

        public void ApplyDiscount(ref double discountPercent)
        {
            Console.WriteLine($"Before Discount : {discountPercent}");
            if (discountPercent > 0 && discountPercent <= Price)
            {
                Price -= discountPercent;

                discountPercent = 0;
            }
            Console.WriteLine($"After Discount : {discountPercent}");
            Console.WriteLine($"Movie : {MovieName}");
            Console.WriteLine($"Type  : {Type}");

        }

        public void TicketInfo()
        {
            Console.WriteLine($"Movie: {MovieName}");
            Console.WriteLine($"Type : {Type}");
            Console.WriteLine($"Seat : {Seat}");
            Console.WriteLine($"Price: {Price}");
        }

    }
}
