using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\consta\Desktop\PizzaOrder\c_medium.in";

            var hubInstance = ReadInputFile(path);
            var pizzaOrder = new PizzaOrder();
            var algoGreedyShort = new DummyAlgorithm(pizzaOrder);
            algoGreedyShort.OptimizeRides(hubInstance);
            var score = ComputeScore(pizzaOrder, hubInstance);
            Console.Out.WriteLine(score);
            WriteOutputResult(pizzaOrder, @"C:\Users\consta\Desktop\PizzaOrder\ResultTestMedium.csv");
            Console.In.Read();
        }

        public static int ComputeScore(PizzaOrder po, HubInstance hub)
        {
            var total = po.PizzaToOrderId.Sum(l => hub.TypesOfPizzas[l].NumberOfSlices);
            return total > hub.MaximumSlices ? 0 : total;
        }

        public static HubInstance ReadInputFile(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {

                var hub = new HubInstance();
                var firstLine = sr.ReadLine().Split(' ');

                hub.MaximumSlices = int.Parse(firstLine.First());
                hub.NumberOfPizzas = int.Parse(firstLine.Last());
                var secondLine = sr.ReadLine().Split(' ');
                var counter = 0;
                hub.TypesOfPizzas = secondLine.Select( l=>
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
        public static void WriteOutputResult(PizzaOrder f, string outputPath)
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
