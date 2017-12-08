using System.Collections.Generic;
using System.Linq;

namespace TreasyOps.ViewModel
{
    public class AnalyzeDealsViewModel
    {
        public AnalyzeDealsViewModel()
        {
            Items = new List<AnalyzeDealsItemViewModel>();
        }
        public int WeekOfYear { get; set; }
        public int TotalItems { get { return Items.Sum(i => i.Count); } }
        public List<AnalyzeDealsItemViewModel> Items { get; set; }
    }
}