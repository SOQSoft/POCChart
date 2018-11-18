using ChartToPng.Abstract;
using ChartToPng.Helpers;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System.Collections.Generic;
using System.Windows;

namespace ChartToPng
{
	public class BarChart<V> : CartesianChart<ColumnSeries, V>
	{
		public BarChart(string title) : base(title)
		{
			
		}

        protected override ColumnSeries CreateSeries()
		{
            return new ColumnSeries();
		}
    }
}
