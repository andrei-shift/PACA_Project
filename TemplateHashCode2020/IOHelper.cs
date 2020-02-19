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

                var hub = new ProblemInstance();
                var firstLine = sr.ReadLine().Split(' ');

                hub.MaximumSlices = int.Parse(firstLine.First());
                hub.NumberOfPizzas = int.Parse(firstLine.Last());
                var secondLine = sr.ReadLine().Split(' ');
                var counter = 0;
                hub.TypesOfPizzas = secondLine.Select(l =>
                {
                    var result = new Pizza();
                    result.NumberOfSlices = int.Parse(l);
                    result.Id = counter;
                    counter++;
                    return result;
                }).ToList();


                //while ((s = sr.ReadLine()) != null)
                //{
                //}

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
                w.WriteLine(f.NumberOfPizzas);
                w.WriteLine(string.Join(" ", f.PizzaToOrderId));
                w.Flush();

            }

        }
    }
}