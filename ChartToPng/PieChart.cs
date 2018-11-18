using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ChartToPng.Abstract;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;

namespace ChartToPng
{
    public partial class PieChart : BaseChart<LiveCharts.Wpf.PieChart, PieSeries, ObservableValue>
    {
        private bool _pushOut = true;
        private Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

        public PieChart(string title) : base(title)
        {
        }

        protected override LiveCharts.Wpf.PieChart CreateChart()
        {
            return new LiveCharts.Wpf.PieChart();
        }

        protected override PieSeries CreateSeries()
        {
            return new PieSeries();
        }

        protected override void AfterSetupSeries(PieSeries series)
        {
            if (_pushOut)
            {
                series.PushOut = 15;
                _pushOut = false;
            }
            series.LabelPoint = labelPoint;
        }
    }
}