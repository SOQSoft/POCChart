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
    public class LineChart : BaseChart<ObservablePoint>
    {
        public LineChart(string title) : base(title)
        {

        }

        protected override Chart CreateChart()
        {
            return new CartesianChart();
        }

        protected override void AfterSetupChart(Chart chart)
        {
        }

        protected override Series CreateSeries()
        {
            return new LineSeries();
        }
    }
}
