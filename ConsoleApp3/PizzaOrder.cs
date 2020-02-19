using System.Collections.Generic;

namespace ConsoleApp3
{
    public class PizzaOrder
    {
        public int NumberOfPizzas => PizzaToOrderId.Count;

        public List<int> PizzaToOrderId { get; set; }

        public PizzaOrder()
        {
            PizzaToOrderId = new List<int>();
        }
        
    }
}