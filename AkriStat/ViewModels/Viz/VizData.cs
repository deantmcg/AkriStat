using System.Collections.Generic;

namespace AkriStat.ViewModels.Viz
{
    public class VizData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public List<double> Data { get; set; } = new List<double>();
    }
}