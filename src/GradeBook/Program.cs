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
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;

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
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book name {book.Name}");
            Console.WriteLine($"Average grade is {stats.Average:N1}");
            Console.WriteLine($"Highest grade is {stats.High}");
            Console.WriteLine($"Lowest grade is {stats.Low}");
            Console.WriteLine($"Letter grade is {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade added");
        }
    }
}
