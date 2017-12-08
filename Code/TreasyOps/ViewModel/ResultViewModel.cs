using System.Collections.Generic;

namespace TreasyOps.ViewModel
{
    public class ResultViewModel
    {
        public ResultViewModel()
        {
            Question1 = new List<AnalyzeDealsViewModel>();
            Question2 = new List<AnalyzeDealsViewModel>();
        }
        public List<AnalyzeDealsViewModel> Question1 { get; set; }
        public List<AnalyzeDealsViewModel> Question2 { get; set; }
    }
}