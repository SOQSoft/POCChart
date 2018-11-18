using GalaSoft.MvvmLight;
using LiveCharts.Defaults;
using System.Collections.Generic;
using System.Diagnostics;

namespace ChartToPng
{
	public class Program : ViewModelBase
	{
		private string _image;
		private BarChart barChart;


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
			barChart = new BarChart("Aantal bezoekers");
			TestAddLabels();
			TestAddData();
			Image = "/png/test.jpg";
			Trace.WriteLine("Started!");
		}
		public void TestAddLabels()
		{
			string[] tString = new string[] { "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00", "0:00", "1:00", "2:00" };
			barChart.AddLabels(
				tString,
				"Tijdstip");
			bool correct = true;
			for (int i = 0; i < tString.Length; i++)
			{
				if (!tString[i].Equals(barChart.Chart.AxisX[0].Labels[i]))
					correct = false;
			}
			System.Console.WriteLine(correct ? "It succeeded succesfully" : "It did probably not succeed succesfully");
		}
		public void TestAddData()
		{
			List<object> data = new List<object>() { 10, 30, 40, 70, 120, 130, 140, 130, 80, 60, 20 };
			string title = "test1";
			barChart.AddSeries(title, data);
		}
	}
}
