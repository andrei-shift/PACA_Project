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

		public SolutionInstance Optimize()
		{
			var solution = new SolutionInstance();
			var sum = 0;
			var time = 0;
			HashSet<Library> doneLibraries = new HashSet<Library>();
			HashSet<Library> availableLibraries = new HashSet<Library>(Problem.Libraries);
			var doneBooks = new HashSet<int>();
			List<Library> output = new List<Library>();
			Dictionary<int, List<int>> shippingOrder = new Dictionary<int, List<int>>();
			while (time < Problem.NumberOfDays && availableLibraries.Count != 0)
			{
				var pOrderLibrary = availableLibraries.OrderByDescending(lib => LibraryScore(lib, time, doneLibraries));
				var selectedLib = pOrderLibrary.First();
				doneLibraries.Add(selectedLib);
				availableLibraries.Remove(selectedLib);
				output.Add(selectedLib);
				shippingOrder[selectedLib.Id] =
					selectedLib.BooksId.OrderByDescending(bookId => BookScore(bookId, doneBooks)).ToList();
				time += selectedLib.TimeToSignUp;
				foreach (var id in selectedLib.BooksId)
				{
					doneBooks.Add(id);
				}
				Console.WriteLine($"{time}  {Problem.NumberOfDays}");
			}
			solution.SignUpLibraryList = output;
			solution.ShippingOrders = shippingOrder;

			return solution;
		}

		public double LibraryScore(Library lib, int time, HashSet<Library> doneLibraries)
		{
			var libBooks = new HashSet<int>(lib.BooksId);
			var alreadyBooks = new HashSet<int>(doneLibraries.SelectMany(other => other.BooksId).ToList());
			libBooks.ExceptWith(alreadyBooks);
			var A = Math.Min(((double)(Problem.NumberOfDays - time - lib.TimeToSignUp) * lib.ShippingCapacity), libBooks.Count);
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