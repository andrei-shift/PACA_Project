using System.Linq;

namespace TemplateHashCode2020
{
    public class GreedyAlgorithm
    {
        public ProblemInstance Problem { get; set; }
        public GreedyAlgorithm(ProblemInstance problem)
        {
            Problem = problem;
        }

        public SolutionInstance Optimize(ProblemInstance problem)
        {
            var solution = new SolutionInstance();
            var sum = 0;
            var pOrderSlice = problem.TypesOfPizzas.OrderByDescending(p => p.NumberOfSlices);
            foreach (var p in pOrderSlice)
            {
                if (sum + p.NumberOfSlices < problem.MaximumSlices)
                {
                    sum += p.NumberOfSlices;
                    solution.PizzaToOrderId.Add(p.Id);
                }
            }

            return solution;
        }


    }
}