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
            LineChart lineChart = new LineChart("test0");
            List<ObservablePoint> points = new List<ObservablePoint>();
            points.Add(new ObservablePoint(0, 2));
            points.Add(new ObservablePoint(1, 1));
            points.Add(new ObservablePoint(2, 1));
            points.Add(new ObservablePoint(3, 0));
            points.Add(new ObservablePoint(4, 2));
            points.Add(new ObservablePoint(5, 2));
            lineChart.AddSeries("title", points);
            lineChart.CreatePNG("png/myImage0.png");


            BarChart barChart = new BarChart("test1");
            List<ObservableValue> values = new List<ObservableValue>();
            values.Add(new ObservableValue(2));
            values.Add(new ObservableValue(1));
            values.Add(new ObservableValue(1));
            values.Add(new ObservableValue(0));
            values.Add(new ObservableValue(2));
            values.Add(new ObservableValue(2));
            barChart.AddSeries("title", values);
            barChart.CreatePNG("png/myImage1.png");

            PieChart pieChart = new PieChart("test2");
            pieChart.AddSeries("Maria", new List<ObservableValue>() { new ObservableValue(3) });
            pieChart.AddSeries("Charles", new List<ObservableValue>() { new ObservableValue(4) });
            pieChart.AddSeries("Frida", new List<ObservableValue>() { new ObservableValue(6) });
            pieChart.AddSeries("Frederic", new List<ObservableValue>() { new ObservableValue(2) });
            pieChart.CreatePNG("png/myImage2.png");
        }
	}
}
