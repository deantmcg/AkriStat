using System.Collections.Generic;

namespace AkriStat.ViewModels.Viz
{
    public class VizResultsVM
    {
        public VizGenerateVM Criteria { get; set; }
        public List<VizData> Data { get; set; } = new List<VizData>();
    }
}
