using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartToPng.Helpers;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace ChartToPng.Abstract
{
    public abstract class CartesianChart<S, V> : BaseChart<CartesianChart, S, V> where S : Series
    {
        public AxisFactory XAxis
        {
            set
            {
                Chart.AxisX.Clear();
                Chart.AxisX.Add(value.Create());
            }
        }
        public AxisFactory YAxis
        {
            set
            {
                Chart.AxisY.Clear();
                Chart.AxisY.Add(value.Create());
            }
        }

        public CartesianChart(string title) : base(title)
        {
        }

        protected override abstract S CreateSeries();
    }
}
