using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChartToPng
{
    public abstract class BaseChart<T>
    {
        private Chart _chart;

        public BaseChart(string title)
        {
            _chart = CreateChart();
            SetupChart(title);
            AfterSetupChart(_chart);

            /*
            ChartValues<ObservablePoint> values = new ChartValues<ObservablePoint>();
            LineSeries series = new LineSeries();
            values.Add(new ObservablePoint(0, 0));
            series.Values = values;

            new CartesianChart().Series.Add(new LineSeries());
            */

        }

        protected abstract Chart CreateChart();
        private void SetupChart(string title)
        {
            _chart.DisableAnimations = true;
            _chart.ChartLegend = new DefaultLegend();
            _chart.LegendLocation = LegendLocation.Right;
        }
        protected virtual void AfterSetupChart(Chart chart)
        {

        }

        public void AddSeries(string title, List<T> data)
        {
            Series series = CreateSeries();
            SetupSeries(series, title, data);
            AfterSetupSeries(series);
        }

        protected abstract Series CreateSeries();
        private void SetupSeries(Series series, string title, List<T> data)
        {
            ChartValues<T> values = new ChartValues<T>();
            values.AddRange(data);
            series.Values = values;
            _chart.Series.Add(series);
            ((DefaultLegend)_chart.ChartLegend).Series.Add(series);
        }
        protected virtual void AfterSetupSeries(Series series)
        {

        }

        public MemoryStream CreatePNGStream()
        {
            Window window = new Window() { Content = _chart };
            window.WindowStyle = WindowStyle.None;
            window.AllowsTransparency = true;
            window.Width = 800;
            window.Height = 400;
            window.Opacity = 0.001;
            window.Show();
            _chart.Update(true, true); //force chart redraw
            window.UpdateLayout();

            var encoder = new PngBitmapEncoder();
            var bitmap = new RenderTargetBitmap((int)_chart.ActualWidth, (int)_chart.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(_chart);
            window.Close();

            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            MemoryStream stream = new MemoryStream();
            encoder.Save(stream);
            return stream;
        }

        public void CreatePNG(string path)
        {
            Stream file = File.Create(path);
            MemoryStream graph = CreatePNGStream();
            byte[] graphBytes = graph.ToArray();
            file.Write(graphBytes, 0, graphBytes.Length);
            file.Flush();

            file.Close();
            graph.Close();
            file.Dispose();
            graph.Dispose();
        }
    }
}
