using System.Collections.Generic;

namespace TemplateHashCode2020
{
    public class SolutionInstance
    {
        public int NumberOfBooks => SignUpLibraryList.Count;

        public List<Library> SignUpLibraryList { get; set; }
        public Dictionary<int, List<int>> ShippingOrders { get; set; }

        public SolutionInstance()
        {
        }
        
    }

}