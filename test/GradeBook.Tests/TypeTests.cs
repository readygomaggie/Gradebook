using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    
    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMultipleMethods()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");

            Assert.Equal(3, count);
        }
        
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            
            var result = log("Hello");

            Assert.Equal("Hello", result);
        }

        string IncrementCount(string message)
        {
            count++;
            return message;
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Maggie";
            var upper = MakeUppercase(name);

            Assert.Equal("Maggie", name);
            Assert.Equal("MAGGIE", upper);

        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetAnInteger();
            SetInteger(x);

            Assert.Equal(3, x);
        }

        private void SetInteger(int x)
        {
            x = 5;
        }

        private int GetAnInteger()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(out Book book, string newName)
        {
            book = new Book(newName);
        }
        
        [Fact]
        public void CSharpIsPassedByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string newName)
        {
            book = new Book(newName);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string newName)
        {
            book.Name = newName;
        }

        [Fact]
        public void GetBooksReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
