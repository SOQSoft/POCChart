using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartToPng
{
    public class LineChart : BaseChart<CartesianChart, LineSeries, ObservablePoint>
    {
        public LineChart(string title) : base(title)
        {

        }

        protected override CartesianChart CreateChart()
        {
            return new CartesianChart();
        }

        protected override LineSeries CreateSeries()
        {
            return new LineSeries();
        }
    }
}
