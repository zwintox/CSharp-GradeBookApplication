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
                    var name = command.Split(' ')[1];
                    var gradeBook = new StandardGradeBook(name);
                }
                else if(command.StartsWith("load"))
                {
                    var name = command.Split(' ')[1];
                    var gradeBook = GradeBook.Load(name);
                }
                else if(command == "help")
                { 
                    Console.WriteLine("GradeBook accepts the following commands:");
                    Console.WriteLine("Create 'Name' - Creates a new gradebook where 'Name' is the name of the gradebook.");
                    Console.WriteLine("Load 'Name' - Loads the gradebook with the provided 'Name'.");
                    Console.WriteLine("Help - Displays all accepted commands.");
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