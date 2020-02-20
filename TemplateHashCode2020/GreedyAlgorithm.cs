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

        public SolutionInstance Optimize()
        {
            var solution = new SolutionInstance();
            var sum = 0;
            //var pOrderSlice = Problem.Books.OrderByDescending(p => p.NumberOfSlices);
            //foreach (var p in pOrderSlice)
            //{
            //    if (sum + p.NumberOfSlices < Problem.MaximumSlices)
            //    {
            //        sum += p.NumberOfSlices;
            //        solution.SignUpLibraryList.Add(p.Id);
            //    }
            //}

            return solution;
        }


    }
}