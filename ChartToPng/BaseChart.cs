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
    public abstract class BaseChart
    {
        protected Chart _chart;

        public BaseChart(string title)
        {
            /*
            CreateChart();
            SetupChart();

            ChartValues<ObservablePoint> values = new ChartValues<ObservablePoint>();
            LineSeries series = new LineSeries();
            values.Add(new ObservablePoint(0, 0));
            series.Values = values;
            
            new CartesianChart().Series.Add(new LineSeries());
            */
            
        }

        public abstract void AddSeries(string title, List<object> data);

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
