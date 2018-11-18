using ChartToPng.Helpers;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace ChartToPng.Abstract
{
    public abstract class BaseChart<C, S, V> 
        where C : Chart, new()
        where S : Series
    {
        public C Chart { get; private set;  }
        public ChartDisplay Display { get; private set; }

        public BaseChart(string title)
        {
            Chart = new C();
            Display = new ChartDisplay(Chart, title);
            SetupChart();
		}
        
        private void SetupChart()
        {
            Chart.DisableAnimations = true;
            DefaultLegend legend = new DefaultLegend();
            legend.Series = new List<SeriesViewModel>();
            Chart.ChartLegend = legend;
            Chart.LegendLocation = LegendLocation.Right;
        }

        public void AddSeries(string title, List<V> data)
        {
            S series = CreateSeries();
            SetupSeries(series, title, data);
            AfterSetupSeries(series);
        }

        protected abstract S CreateSeries();
        private void SetupSeries(S series, string title, List<V> data)
        {
            ChartValues<V> values = new ChartValues<V>();
            values.AddRange(data);
            series.Values = values;
            series.Title = title;
            Chart.Series.Add(series);
            SeriesViewModel legendSeries = new SeriesViewModel();
            legendSeries.Fill = series.Fill;
            legendSeries.PointGeometry = series.PointGeometry;
            legendSeries.Stroke = series.Stroke;
            legendSeries.StrokeThickness = series.StrokeThickness;
            legendSeries.Title = series.Title;
            ((DefaultLegend)Chart.ChartLegend).Series.Add(new SeriesViewModel());
        }
        protected virtual void AfterSetupSeries(S series)
        {

        }

        public MemoryStream CreatePNGStream()
        {
            //Create Window
            Display.Detach();
            Window window = new Window() { Content = Display.Panel };
            window.WindowStyle = WindowStyle.None;
            window.AllowsTransparency = true;
            window.Width = 500;
            window.Height = 300;
            window.Opacity = 0.001;
            window.Show();
            Chart.Update(true, true); //force chart redraw
            window.UpdateLayout();

            //Render Bitmap
            var encoder = new PngBitmapEncoder();
            var bitmap = new RenderTargetBitmap((int)Display.Panel.ActualWidth, (int)Display.Panel.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(Display.Panel);
            window.Close();
            window.Content = null;
            Display.Attach();

            //Create PNG
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            MemoryStream stream = new MemoryStream();
            encoder.Save(stream);
            return stream;
        }

        public void CreatePNG(string path)
        {
            FileInfo info = new FileInfo(path);
            if (!info.Exists) { info.Directory.Create(); }
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
