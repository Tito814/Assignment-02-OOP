using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02_OOP
{
    internal static class BookingHelper
    {
        private static int counter = 0;
        public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
        {
            if (numberOfTickets >= 5)
            {
                return pricePerTicket * numberOfTickets * 0.9;
            }
            return pricePerTicket * numberOfTickets;
        }

        public static string GenerateBookingReference()
        {
            counter++;
            return $"BK-{counter}";

        }

    }
}
