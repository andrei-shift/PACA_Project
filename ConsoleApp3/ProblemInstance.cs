using System.Collections.Generic;

namespace TemplateHashCode2020
{
    public class ProblemInstance
    {
        public int MaximumSlices { get; set; }
        public int NumberOfPizzas { get; set; }

        public List<Pizza> TypesOfPizzas { get; set; }
    }

    public class Pizza
    {
        public int Id { get; set; }
        public int NumberOfSlices { get; set; }
    }
}