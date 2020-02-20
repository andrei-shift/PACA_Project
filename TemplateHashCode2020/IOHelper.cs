using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TemplateHashCode2020
{
    public static class IOHelper
    {
        public static ProblemInstance ReadInputFile(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                var firstLine = sr.ReadLine().Split(' ');

                var hub = new ProblemInstance();
                hub.NumberOfBooks = int.Parse(firstLine[0]);
                hub.NumberOfLibraries = int.Parse(firstLine[1]);
                hub.NumberOfDays = int.Parse(firstLine[2]);

                var secondLine = sr.ReadLine().Split(' ');
                var counter = 0;
                hub.Books = secondLine.Select(l =>
                {
                    var result = new Book();
                    result.Id = counter;
                    result.Value = int.Parse(l);
                    counter++;
                    return result;
                }).ToList();

                var libC = 0;
                string s;
                while ((s = sr.ReadLine()) != null && s != "")
                {
                    var splittedL = s.Split(' ');
                    var library = new Library();
                    library.Id = libC;
                    library.NumberOfBooks = int.Parse(splittedL[0]);
                    library.TimeToSignUp = int.Parse(splittedL[1]);
                    library.ShippingCapacity = int.Parse(splittedL[2]);
                    libC++;

                    var sBis = sr.ReadLine().Split(' ');

                    foreach (var book in sBis.Select(int.Parse))
                    {
                        library.BooksId.Add(book);
                    }

                    hub.Libraries.Add(library);
                }

                return hub;
            }
        }

        public static SolutionInstance ReadPreviousSolution(string path, ProblemInstance pb)
        {
            using (StreamReader sr = File.OpenText(path))
            {

                var solution = new SolutionInstance();
                solution.SignUpLibraryList = new List<Library>();
                solution.ShippingOrders = new Dictionary<int, List<int>>();
                var firstLine = sr.ReadLine().Split(' ');
                string s;

                while ((s = sr.ReadLine()) != null)
                {
                    var l = s.Split(' ');
                    solution.SignUpLibraryList.Add(pb.Libraries[int.Parse(l[0])]);
                    var newL = sr.ReadLine().Split(' ');
                    if (newL.First() != "")
                    {
                        solution.ShippingOrders.Add(int.Parse(l[0]), newL.Select(ll => int.Parse(ll)).ToList());
                    }
                }

                return solution;
            }
        }


        public static void WriteOutputResult(SolutionInstance f, string outputPath)
        {
            using (var w = new StreamWriter(outputPath))
            {
                // first line

                var usefullLibraries = f.SignUpLibraryList.Where(lib =>
                    f.ShippingOrders.ContainsKey(lib.Id)).ToList();
                w.WriteLine(usefullLibraries.Count);


                foreach (var lib in usefullLibraries)
                {
                    w.WriteLine(lib.Id + " " +lib.BooksId.Count);
                    w.WriteLine(string.Join(" ", lib.BooksId));
                }

                w.Flush();
            }

        }
    }
}