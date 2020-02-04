using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void ShouldCalculateGradeStatistics()
        {
            //arrange
            var book = new Book("");

            book.AddGrade(89.1);
            book.AddGrade(77.3);
            book.AddGrade(90.5);

            var result = book.GetStatistics();

            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);

        }

        [Fact]
        public void OnlyValidGradesAllowedInBook() 
        {
            var book = new Book("");
            var validGrade = 84.4;
            var invalidLowGrade = -98.3;
            var invalidHighGrade = 104.5;

            book.AddGrade(validGrade);
            book.AddGrade(invalidLowGrade);
            book.AddGrade(invalidHighGrade);

            var grades = book.GetGrades();

            Assert.Contains(validGrade, grades);
            Assert.DoesNotContain(invalidLowGrade, grades);
            Assert.DoesNotContain(invalidHighGrade, grades);
            
        }

        [Fact]
        public void LetterGradesConvertToDoubles()
        {
            var book = new Book("");
            book.AddGrade('B');

            Assert.Contains(80.0, book.GetGrades());

        }
    }
}
