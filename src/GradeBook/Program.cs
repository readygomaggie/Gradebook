using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Maggie's book");

            while(true) 
            {
                Console.WriteLine("Enter grade");
                var input = Console.ReadLine();

                if (input.ToUpper() == "Q") 
                {
                    break;
                }

                try 
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("argument exception");
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"Average grade is {stats.Average:N1}");
            Console.WriteLine($"Highest grade is {stats.High}");
            Console.WriteLine($"Lowest grade is {stats.Low}");
            System.Console.WriteLine($"Letter grade is {stats.Letter}");


        }
    }
}
