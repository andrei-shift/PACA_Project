using System.Collections.Generic;

namespace TemplateHashCode2020
{
    public class SolutionInstance
    {
        public int NumberOfPizzas => PizzaToOrderId.Count;

        public List<int> PizzaToOrderId { get; set; }

        public SolutionInstance()
        {
            PizzaToOrderId = new List<int>();
        }
        
    }
}