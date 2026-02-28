using Assignment_01_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02_OOP
{
    internal class Cinema
    {
        private Ticket[] _tickets = new Ticket[20];

        public Ticket this[int index]
        {
            get
            {
                if (index >= 0 && index < _tickets.Length)
                {
                    return _tickets[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (index >= 0 && index < _tickets.Length)
                {
                    _tickets[index] = value;
                }

            }


        }

        public Ticket GetMovieName(string movieName)
        {
            foreach (Ticket t in _tickets)
            {
                if (t != null && t.MovieName == movieName)
                {
                    return t;
                }
            }
            return null;

        }

        public bool AddTicket(Ticket t)
        {
            for (int i = 0; i < _tickets.Length; i++)
            {
                if (_tickets[i] == null)
                {
                    _tickets[i] = t;
                    return true;
                }
            }
            return false;
        }
    }

}
