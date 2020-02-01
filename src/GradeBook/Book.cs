using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook {
    public class Book
    {
        private List<double> grades;
        public string Name;

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade) 
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            else 
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            
        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;
                default:
                    Console.WriteLine("invalid letter");
                    break;
            }
        }

        public Statistics GetStatistics()
        {
            
            var stats = new Statistics();

            stats.Average = grades.Average();
            stats.High = grades.Max();
            stats.Low = grades.Min();
            stats.Letter = GetLetterGrade(stats.Average);

            return stats;
        }

        private char GetLetterGrade(double numberGrade)
        {
            switch (numberGrade)
            {
                case var d when d >= 90.0:
                    return 'A';
                case var d when d >= 80.0:
                    return 'B';
                case var d when d >= 70.0:
                    return 'C';
                case var d when d >= 60.0:
                    return 'D';
                case var d when d < 60.0:
                    return 'F';
                default:
                    return 'I';
            }
        }

        public List<double> GetGrades()
        {  
            return grades;
        }

    }
}