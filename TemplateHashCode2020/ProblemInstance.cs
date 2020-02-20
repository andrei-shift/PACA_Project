using System;
using System.Collections.Generic;

namespace TemplateHashCode2020
{
    public class ProblemInstance
    {
        public int NumberOfBooks { get; set; }
        public int NumberOfLibraries { get; set; }
        public int NumberOfDays { get; set; }

        public List<Book> Books { get; set; }
        public List<Library> Libraries { get; set; }

        public ProblemInstance()
        {
            Books =  new List<Book>();
            Libraries = new List<Library>();
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public override bool Equals(Object obj)
        {
            return Id == ((Library)obj).Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

    }
    public class Library
    {
        public int Id { get; set; }
        public int NumberOfBooks { get; set; }
        public int TimeToSignUp { get; set; }
        public int ShippingCapacity { get; set; }
        public HashSet<int> BooksId { get; set; }

        public override bool Equals(Object obj)
        {
            return Id == ((Library)obj).Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

    }
}