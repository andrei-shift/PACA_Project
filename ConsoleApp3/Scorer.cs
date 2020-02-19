using System.Linq;

namespace TemplateHashCode2020
{
    public static class Scorer
    {
        public static int ComputeScore(SolutionInstance po, ProblemInstance problem)
        {
            var total = po.PizzaToOrderId.Sum(l => problem.TypesOfPizzas[l].NumberOfSlices);
            return total > problem.MaximumSlices ? 0 : total;
        }
    }
}