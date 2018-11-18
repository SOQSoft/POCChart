using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartToPng
{
    public abstract class BaseChartFactory
    {
        protected Chart _chart;

        public BaseChartFactory()
        {
            CreateChart();
            SetupChart();

            ChartValues<ObservablePoint> values = new ChartValues<ObservablePoint>();
            LineSeries series = new LineSeries();
            values.Add(new ObservablePoint(0, 0));
            series.Values = values;
            
            new CartesianChart().Series.Add(new LineSeries());
        }

        private void SetupChart()
        {
            throw new NotImplementedException();
        }

        protected abstract void CreateChart();

        public void StartNewSeries(string title)
        {
            CreateSeries();
            SetupSeries();
        }

        protected abstract void CreateSeries();
        private void SetupSeries()
        {
            throw new NotImplementedException();
        }

        public void CreatePNG(string path)
        {
            throw new NotImplementedException();
        }

        //C# equivalent for Stream?
        public void CreatePNGStream()
        {
            throw new NotImplementedException();
        }
    }
}
