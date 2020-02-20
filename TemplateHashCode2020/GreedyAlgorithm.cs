using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Policy;

namespace TemplateHashCode2020
{
	public class GreedyAlgorithm
	{
		public ProblemInstance Problem { get; set; }
		public GreedyAlgorithm(ProblemInstance problem)
		{
			Problem = problem;
		}

		public SolutionInstance Optimize(int batchSize)
		{
			var solution = new SolutionInstance();
			var sum = 0;
			var time = 0;
			HashSet<Library> doneLibraries = new HashSet<Library>();
			HashSet<Library> availableLibraries = new HashSet<Library>(Problem.Libraries);
			var doneBooks = new HashSet<int>();
			List<Library> output = new List<Library>();

			Dictionary<int, List<int>> copyBooksInLibrary =
				new Dictionary<int, List<int>>();
			foreach (Library l in availableLibraries)
			{
				copyBooksInLibrary[l.Id] = l.BooksId.OrderByDescending(b => Problem.Books[b].Value).ToList();
			}

			Dictionary<int, List<int>> shippingOrder = new Dictionary<int, List<int>>();
			while (time < Problem.NumberOfDays && availableLibraries.Count != 0)
			{
				var pOrderLibrary = availableLibraries.OrderByDescending(lib => LibraryScore(lib, time, doneLibraries, doneBooks));

                foreach (var selectedLib in pOrderLibrary.Take(batchSize))
                {
                    doneLibraries.Add(selectedLib);
                    availableLibraries.Remove(selectedLib);
                    output.Add(selectedLib);
				    shippingOrder[selectedLib.Id] = fuseBooks(
					selectedLib.BooksId.OrderByDescending(bookId => Problem.Books[bookId].Value).ToList(), copyBooksInLibrary[selectedLib.Id]);
                    time += selectedLib.TimeToSignUp;
                    foreach (var id in selectedLib.BooksId)
				//foreach (var id in selectedLib.BooksId.OrderByDescending(b => Problem.Books[b].Value).Take(numberOfBooksCanAnalyze(selectedLib,time)))
                    {
                        doneBooks.Add(id);
                    }
                    Console.WriteLine($"{time}  {Problem.NumberOfDays}");
                }
			}
			solution.SignUpLibraryList = output;
			solution.ShippingOrders = shippingOrder;

			return solution;
		}

		public List<int> fuseBooks(List<int> book1, List<int> books2)
		{
			foreach (var el in books2)
			{
				if (!book1.Contains(el))
				{
					book1.Add(el);
				}
			}

			return book1;
		}

		public int numberOfBooksCanAnalyze(Library lib, int time)
		{
			return (Problem.NumberOfDays - time - lib.TimeToSignUp - 1) * lib.ShippingCapacity;
		}

		public double LibraryScore(Library lib, int time, HashSet<Library> doneLibraries, HashSet<int> alreadyBooks)
		{
			var libBooks = lib.BooksId;
			libBooks.ExceptWith(alreadyBooks);
            var estimatedNumberOfAvailableBooks = libBooks.Count > 0 ? libBooks.Count : lib.NumberOfBooks;
            var A = Math.Min(((double)numberOfBooksCanAnalyze(lib, time)), estimatedNumberOfAvailableBooks);
			var B = libBooks.Sum(b => Problem.Books[b].Value);
			var C = 1 / Math.Log(lib.TimeToSignUp);
			return A * B * C;
		}



		public double BookScore(int bookId, HashSet<int> doneBooksIds)
		{
			if (doneBooksIds.Contains(bookId))
			{
				return 0;
			}
			else return Problem.Books[bookId].Value;
		}


	}
}