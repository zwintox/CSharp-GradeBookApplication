using System;

namespace GradeBook
{
    class Program
    {
        //#Todo refactor this into several stand alone and testable methods
        static void Main(string[] args)
        {
            Console.WriteLine("#=======================#");
            Console.WriteLine("# Welcome to GradeBook! #");
            Console.WriteLine("#=======================#");
            Console.WriteLine(string.Empty);

            var quit = false;
            while (!quit)
            {
                Console.WriteLine("What would you like to do?");
                var command = Console.ReadLine().ToLower();

                if(command.StartsWith("create"))
                {
                    GradeBook gradeBook;
                    var parts = command.Split(' ');
                    var name = parts[1].ToLower();
                    var type = parts[2].ToLower();
                    var weighted = bool.Parse(parts[3]);
                    switch(type)
                    {
                        case "standard":
                            gradeBook = new StandardGradeBook(name, weighted);
                            break;
                    }

                }
                else if(command.StartsWith("load"))
                {
                    var name = command.Split(' ')[1];
                    var gradeBook = GradeBook.Load(name);
                }
                else if(command == "help")
                { 
                    Console.WriteLine("GradeBook accepts the following commands:");
                    Console.WriteLine("");
                    Console.WriteLine("Create 'Name' 'Type' 'Weighted' - Creates a new gradebook where 'Name' is the name of the gradebook, 'Type' is what type of grading it should use, and 'Weighted' is whether or not grades should be weighted (true or false).");
                    Console.WriteLine("");
                    Console.WriteLine("Accepted Types:");
                    Console.WriteLine("Standard - Commonly used A,B,C,D,F grading system.");
                    Console.WriteLine("Rank - Rank based grading is used.");
                    Console.WriteLine("SixPoint - Six-point grading system is used.");
                    Console.WriteLine("OneToFour - 1-2-3-4 Grading System is used.");
                    Console.WriteLine("ESNU - E-S-N-U Grading System is used.");
                    Console.WriteLine("");
                    Console.WriteLine("Load 'Name' - Loads the gradebook with the provided 'Name'.");
                    Console.WriteLine("");
                    Console.WriteLine("Help - Displays all accepted commands.");
                    Console.WriteLine("");
                    Console.WriteLine("Quit - Exits the application");
                }
                else if(command == "quit")
                {
                    quit = true;
                }
                else
                {
                    Console.WriteLine("{0} was not recognized, please try again.", command);
                }
            }
            Console.WriteLine("Thank you for using GradeBook!");
            Console.WriteLine("Have a nice day!");
            Console.Read();
        }
    }
}