using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02_OOP
{
    internal class StudentQ2
    {
        public int Id { get; set; }

        public DateTime Birthdate { set; get; }

        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;
                int age = now.Year - Birthdate.Year;
                if (now.Month < Birthdate.Month || (now.Month == Birthdate.Month && now.Day < Birthdate.Day))
                {
                    age--;
                }
                return age;
            }
        }
        public int NumberofCourses { get; set; }
        public int TotalHours { get; set; }
        public double GPA
        {
            get
            {
                if (TotalHours == 0)
                {
                    return 0;
                }
                return (double)NumberofCourses / TotalHours;
            }
        }

    }
}
