using System.Linq;

namespace ConsoleApp3
{
    public class DummyAlgorithm
    {
        public PizzaOrder Order { get; set; }
        public DummyAlgorithm(PizzaOrder order)
        {
            Order = order;
        }

        public void OptimizeRides(HubInstance hub)
        {
            var sum = 0;
            var pOrderSlice = hub.TypesOfPizzas.OrderByDescending(p => p.NumberOfSlices);
            foreach (var p in pOrderSlice)
            {
                if (sum + p.NumberOfSlices < hub.MaximumSlices)
                {
                    sum += p.NumberOfSlices;
                    Order.PizzaToOrderId.Add(p.Id);
                }
            }
        }


    }
}