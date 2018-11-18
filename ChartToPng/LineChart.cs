using ChartToPng.Abstract;
using ChartToPng.Helpers;
using LiveCharts;
using LiveCharts.Configurations;
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
    public class LineChart<V> : CartesianChart<LineSeries, V>
    {
        public LineChart(string title) : base(title)
        {

        }

        protected override LineSeries CreateSeries()
        {
            return new LineSeries();
        }
    }
}
