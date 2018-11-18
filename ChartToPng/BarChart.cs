using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System.Collections.Generic;

namespace ChartToPng
{
	public class BarChart : BaseChart
	{
		public Chart Chart { get; private set; }

		public BarChart(string title) : base(title)
		{
			Chart = new CartesianChart();
		}

		public override void AddSeries(string title, List<object> data)
		{
			IChartValues values = data.AsChartValues();
			ColumnSeries columnSeries = new ColumnSeries()
			{
				Values = values,
				Title = title
			};
			Chart.Series.Add(columnSeries);
		}

		public void AddLabels(string[] labels, string title)
		{
			Chart.AxisX.Add(new Axis() { Title = title, Labels = labels });
		}
	}
}
