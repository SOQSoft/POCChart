using GalaSoft.MvvmLight;
using LiveCharts.Defaults;
using System.Collections.Generic;
using System.Diagnostics;

namespace ChartToPng
{
	public class Program : ViewModelBase
	{
		private string _image;

		public string Image
		{
			get => _image;
			set
			{
				_image = value;
				RaisePropertyChanged();
			}
		}
		public Program()
		{
			BarChart barChart = new BarChart("Test1");
			int[] ints = new int[] { 10, 30, 40, 70, 80, 140, 180 };
			List<ObservableValue> list = new List<ObservableValue>();
			foreach (int i in ints)
				list.Add(new ObservableValue(i));
			barChart.AddSeries("Appels", list);
			barChart.ShowWindow();
			Image = "/png/test.jpg";
			Trace.WriteLine("Started!");
		}
	}
}
