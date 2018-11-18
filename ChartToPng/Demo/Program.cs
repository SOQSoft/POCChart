using ChartToPng.Abstract;
using ChartToPng.Helpers;
using GalaSoft.MvvmLight;
using LiveCharts.Defaults;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChartToPng
{
	public class Program : ViewModelBase
	{
		private ChartDisplay _chart0;

		public ChartDisplay Chart0
		{
			get => _chart0;
			set
			{
                _chart0 = value;
				RaisePropertyChanged();
			}
		}

        private ChartDisplay _chart1;

		public ChartDisplay Chart1
		{
			get => _chart1;
			set
			{
                _chart1 = value;
				RaisePropertyChanged();
			}
		}

        private ChartDisplay _chart2;

		public ChartDisplay Chart2
		{
			get => _chart2;
			set
			{
                _chart2 = value;
				RaisePropertyChanged();
			}
		}
		public Program()
		{
            LineChart<ObservablePoint> lineChart = new LineChart<ObservablePoint>("Line Chart Demo");
            List<ObservablePoint> points = new List<ObservablePoint>();
            points.Add(new ObservablePoint(0, 2422));
            points.Add(new ObservablePoint(1, 1654));
            points.Add(new ObservablePoint(2, 1234));
            points.Add(new ObservablePoint(3, 234));
            points.Add(new ObservablePoint(4, 2475));
            points.Add(new ObservablePoint(5, 2453));
            lineChart.AddSeries("Sales", points);
            lineChart.YAxis = new AxisFactory() { MinValue = 0, LabelFormatter = d => string.Join(string.Empty, '€', d) };
            lineChart.XAxis = new AxisFactory() { TickLines = false };
            lineChart.CreatePNG("png/myImage0.png");

            BarChart<ObservableValue> barChart = new BarChart<ObservableValue>("Bar Chart Demo");
            List<ObservableValue> values = new List<ObservableValue>();
            values.Add(new ObservableValue(2));
            values.Add(new ObservableValue(5));
            values.Add(new ObservableValue(3));
            values.Add(new ObservableValue(4));
            values.Add(new ObservableValue(6));
            values.Add(new ObservableValue(3));
            barChart.AddSeries("Inspecties", values);
            barChart.XAxis = new AxisFactory()
            {
                Labels = new List<string>() { "Darryll", "Guus", "Bart", "Aaron", "Simon", "Stan" },
                Title = "Inspecteurs",
                TickLines = false,
                TickStep = 1
            };
            barChart.YAxis = new AxisFactory() { Title = "Aantal" };
            barChart.CreatePNG("png/myImage1.png");

            PieChart pieChart = new PieChart("Pie Chart Demo");
            pieChart.AddSeries("Maria", new List<ObservableValue>() { new ObservableValue(3) });
            pieChart.AddSeries("Charles", new List<ObservableValue>() { new ObservableValue(4) });
            pieChart.AddSeries("Frida", new List<ObservableValue>() { new ObservableValue(6) });
            pieChart.AddSeries("Frederic", new List<ObservableValue>() { new ObservableValue(2) });
            pieChart.CreatePNG("png/myImage2.png");

            Chart0 = lineChart.Display;
            Chart1 = barChart.Display;
            Chart2 = pieChart.Display;
        }
	}
}
