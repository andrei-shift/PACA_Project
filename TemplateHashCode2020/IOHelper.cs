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
                    library.BooksId = sBis.Select(ll => { return int.Parse(ll); }).ToList();
                    hub.Libraries.Add(library);
                }

                return hub;
            }
        }

        public static SolutionInstance ReadPreviousSolution(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {

                var pizza = new SolutionInstance();
                var firstLine = sr.ReadLine().Split(' ');


                //while ((s = sr.ReadLine()) != null)
                //{
                //}

                return pizza;
            }
        }


        public static void WriteOutputResult(SolutionInstance f, string outputPath)
        {
            using (var w = new StreamWriter(outputPath))
            {
                // first line
                w.WriteLine(f.NumberOfLibraries);
                w.WriteLine(string.Join(" ", f.SignUpLibraryList));
                w.Flush();

            }

        }
    }
}