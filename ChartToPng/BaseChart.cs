using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace ChartToPng
{
    public abstract class BaseChart<C, S, V> 
        where C : Chart 
        where S : Series
    {
        private C _chart;
        public string Title {get; set;}

        public BaseChart(string title)
        {
            Title = title;
            _chart = CreateChart();
            SetupChart();
            AfterSetupChart(_chart);

			/*
            ChartValues<ObservablePoint> values = new ChartValues<ObservablePoint>();
            LineSeries series = new LineSeries();
            values.Add(new ObservablePoint(0, 0));
            series.Values = values;

            new CartesianChart().Series.Add(new LineSeries());
            */
		}

        protected abstract C CreateChart();
        private void SetupChart()
        {
            _chart.DisableAnimations = true;
            DefaultLegend legend = new DefaultLegend();
            legend.Series = new List<SeriesViewModel>();
            _chart.ChartLegend = legend;
            _chart.LegendLocation = LegendLocation.Right;
        }
        protected virtual void AfterSetupChart(C chart)
        {

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
            _chart.Series.Add(series);
            SeriesViewModel legendSeries = new SeriesViewModel();
            legendSeries.Fill = series.Fill;
            legendSeries.PointGeometry = series.PointGeometry;
            legendSeries.Stroke = series.Stroke;
            legendSeries.StrokeThickness = series.StrokeThickness;
            legendSeries.Title = series.Title;
            ((DefaultLegend)_chart.ChartLegend).Series.Add(new SeriesViewModel());
        }
        protected virtual void AfterSetupSeries(S series)
        {

        }

        public MemoryStream CreatePNGStream()
        {
            Window window = CreateAndShowWindow();
            Grid grid = (Grid) window.Content;
            var encoder = new PngBitmapEncoder();
            var bitmap = new RenderTargetBitmap((int)grid.ActualWidth, (int)grid.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(grid);
            window.Close();

            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            MemoryStream stream = new MemoryStream();
            encoder.Save(stream);
            return stream;
        }

        private Window CreateAndShowWindow()
        {
            Label title = new Label() { Content = Title };
            title.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            title.FontSize = 25;
            title.HorizontalAlignment = HorizontalAlignment.Center;

            Grid grid = new Grid();
            ColumnDefinition column = new ColumnDefinition();
            column.Width = new GridLength(1, GridUnitType.Star);
            grid.ColumnDefinitions.Add(column);

            RowDefinition row = new RowDefinition();
            row.Height = GridLength.Auto;
            grid.RowDefinitions.Add(row);
            row = new RowDefinition();
            row.Height = new GridLength(1, GridUnitType.Star);
            grid.RowDefinitions.Add(row);
           
            Grid.SetRow(_chart, 1);
            grid.Children.Add(title);
            grid.Children.Add(_chart);
            
            Window window = new Window() { Content = grid };
            window.WindowStyle = WindowStyle.None;
            window.AllowsTransparency = true;
            window.Width = 500;
            window.Height = 300;
            window.Opacity = 0.001;
            window.Show();
            _chart.Update(true, true); //force chart redraw
            window.UpdateLayout();

            return window;
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

        public C CopyChart()
        {
            return (C)XamlReader.Load(new XmlTextReader(new StringReader(XamlWriter.Save(_chart))));
        }
	}
}
