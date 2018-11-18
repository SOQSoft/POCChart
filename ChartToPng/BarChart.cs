using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System.Collections.Generic;
using System.Windows;

namespace ChartToPng
{
	public class BarChart : BaseChart<ObservableValue>
	{
		public BarChart(string title) : base(title)
		{
			
		}

		protected override Chart CreateChart()
		{
			return new CartesianChart();
		}

		protected override Series CreateSeries(List<ObservableValue> Data)
		{
			return new ColumnSeries(Data);
		}
	}
}
