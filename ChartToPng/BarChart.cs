using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System.Collections.Generic;
using System.Windows;

namespace ChartToPng
{
	public class BarChart : BaseChart<CartesianChart, ColumnSeries, ObservableValue>
	{
		public BarChart(string title) : base(title)
		{
			
		}

		protected override CartesianChart CreateChart()
		{
			return new CartesianChart();
		}

        protected override void AfterSetupChart(CartesianChart chart)
        {
            //chart.AxisX.Add(new Axis() { Title = title, Labels = labels });
        }

        protected override ColumnSeries CreateSeries()
		{
            return new ColumnSeries();
		}
	}
}
