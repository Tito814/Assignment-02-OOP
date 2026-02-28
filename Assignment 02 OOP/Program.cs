using Assignment_01_OOP;

namespace Assignment_02_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01 : Theoretical Questions

            #region Q1

            /*
             * a) There is many problems in this code that violates encapsulation principle, such as: first one is fields are public, So anyone can access and modify them without any control, and there is no validation for the data
             * Second one ,we must validate the data before assigning it to the fields, and we can also add validation logic in methods to ensure that the data is valid before assigning it to the fields.
             * 
             * b) To fix the code and make it follow encapsulation principle, we can make the fields private and provide public properties to access and modify them.
             * We can also add validation logic in the properties to ensure that the data is valid before assigning it to the fields.
             * 
             * c) exposing fields directly (as public) is considered a bad practice in OOP ,As it violates the encapsulation principle, which is one of the fundamental principles of OOP. Encapsulation is the concept of hiding the internal details of an object and only exposing a public interface to interact with it. When fields are exposed directly, it allows external code to access and modify them without any control or validation, which can lead to bugs and security issues.
             * It also makes it harder to maintain and change the internal implementation of the class without affecting the external code that uses it.
             * 
             * 
             */

            #endregion

            #region Q2

            /*
             * The difference between a field and a property is that a field is a variable that is declared directly in a class or struct,
             * while a property is a member that provides a flexible mechanism to read, write, or compute the value of a private field and it can contain logic to validate the data before assigning it to the field. 
             * A property can also have a getter and a setter, which allows you to control how the value is accessed and modified, while a field does not have this capability.
             * 
             */

            //StudentQ2 student = new StudentQ2
            //{
            //    Birthdate = new DateTime(2000, 1, 1)
            //};

            //Console.WriteLine($"Student's age: {student.Age}");

            //StudentQ2 student = new StudentQ2();

            //student.NumberofCourses = 5;
            //student.TotalHours = 15;


            //Console.WriteLine($"Student's GPA: {student.GPA}");
            #endregion

            #region Q3

            /*
             * 
             * a) Keyword (this) reflect on the class which contain collection and it is an indexer allows an object to be accessed like an array,
             * its perpose is to provide a way to access the elements of an object using an index, similar to how you would access elements of an array.
             * 
             * b) It means that we assign or set new value (Ali) in index 10 in object (register) ,we can make indexer safer by adding validation logic to ensure that the index is within the valid range before accessing or modifying the elements of the collection.
             * 
             * c) Yes class can have more than one indexer ,This is called indexer overloading, and it works just like method overloading.
             * It will be usful when we want to provide different ways to access the elements of a collection, for example, we can have one indexer that takes an integer index and another indexer that takes a string key. (Methods overloading)
             * 
             */

            #endregion

            #region Q4

            /*
             * a) Static means that the member belongs to the type itself rather than to a specific object. It can be accessed without creating an instance of the class but it can only access static members of the class.
             * On the other hand, non-static members (like Item field) belong to a specific instance of the class and can only be accessed through an object of that class.
             * 
             * b) Actaully no static methods can not access non-static members directly, because non-static members belong to a specific instance of the class, and static methods do not have access to any instance of the class.
             * However, static methods can access non-static members indirectly by creating an instance of the class and then accessing the non-static members through that instance (As a parameter) 
             * 
             */

            #endregion

            #endregion


            #region Part 02 : Practical

            Console.WriteLine("========================== Welcome To Movie Ticket Booking System ==========================");


            Cinema cinema = new Cinema();

            // Movie Name (Always Required)
            for (int i = 0; i < 3; i++)
            {

                Console.WriteLine($"Enter data for Ticket 0{i + 1}");
                string movieName;
                do
                {
                    Console.Write("Enter Movie Name: ");
                    movieName = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(movieName));

                Console.Write("Do you want to use default ticket values? (Y/N): ");
                string choice = Console.ReadLine()?.ToUpper();

                Ticket ticket;
                TicketType ticketType;

                if (choice == "Y")
                {
                    // Uses chained constructor
                    ticket = new Ticket(movieName);
                }
                else
                {
                    // ================= FULL INPUT MODE =================

                    // Ticket Type
                    while (true)
                    {
                        Console.Write("Enter Ticket Type (0 = Standard , 1 = VIP , 2 = IMAX ) : ");

                        if (int.TryParse(Console.ReadLine(), out int ticketTypeInput) &&
                            Enum.IsDefined(typeof(TicketType), ticketTypeInput))
                        {
                            ticketType = (TicketType)ticketTypeInput;
                            break;
                        }

                        Console.WriteLine("Invalid ticket type. Please enter 0, 1, or 2.");
                    }

                    // Seat Row
                    char seatRow;
                    while (true)
                    {
                        Console.Write("Enter Seat Row (A, B, C...): ");
                        string input = Console.ReadLine()?.ToUpper();

                        if (!string.IsNullOrWhiteSpace(input) &&
                            input.Length == 1 &&
                            char.IsLetter(input[0]))
                        {
                            seatRow = input[0];
                            break;
                        }

                        Console.WriteLine("Invalid row. Please enter a single letter.");
                    }

                    // Seat Number
                    int seatNumber;
                    while (true)
                    {
                        Console.Write("Enter Seat Number: ");

                        if (int.TryParse(Console.ReadLine(), out seatNumber) && seatNumber > 0)
                            break;

                        Console.WriteLine("Seat number must be a positive number.");
                    }

                    // Ticket Price
                    double price;
                    while (true)
                    {
                        Console.Write("Enter Price: ");

                        if (double.TryParse(Console.ReadLine(), out price) && price > 0)
                            break;

                        Console.WriteLine("Price must be greater than 0.");
                    }

                    SeatLocation seatLocation = new SeatLocation(seatRow, seatNumber);

                    ticket = new Ticket(movieName, ticketType, seatLocation, price);
                }

                if (cinema.AddTicket(ticket))
                {
                    Console.WriteLine("Ticket added successfully");
                }
                else
                {
                    Console.WriteLine("Failed to add ticket, Something went wrong.");
                }

            }
            Console.WriteLine("================= All Tickets =================");

            for (int i = 0; i < 3; i++)
            {

                Console.WriteLine($"Ticket#{1 + i} : {cinema[i].MovieName} | {cinema[i].Type} | {cinema[i].Seat} | {cinema[i].Price} | {cinema[i].PriceAfterTax}");

            }
            Console.WriteLine();
            Console.Write("Enter movie name to search: ");

            string searchMovieName = Console.ReadLine();

            Ticket TFound = cinema.GetMovieName(searchMovieName);
            if (TFound != null)
            {
                Console.WriteLine($"Found Ticket{TFound.TicketId}: {TFound.MovieName} | {TFound.Type} | {TFound.Seat} | {TFound.Price} | {TFound.PriceAfterTax}");
            }
            else
            {
                Console.WriteLine("No ticket found with that movie name.");
            }
            #endregion
        }
    }
}
