using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System.Collections.Generic;
using System.IO;
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

            /*
            ChartValues<ObservablePoint> values = new ChartValues<ObservablePoint>();
            LineSeries series = new LineSeries();
            values.Add(new ObservablePoint(0, 0));
            series.Values = values;

            new CartesianChart().Series.Add(new LineSeries());
            */

        }

        protected abstract Chart CreateChart();
        protected virtual void SetupChart(string title)
        {
        }

        public void AddSeries(string title, List<T> data)
        {
            SetupSeries(CreateSeries(data), title);
        }

        protected abstract Series CreateSeries(List<T> Data);
        protected virtual void SetupSeries(Series series, string title)
        {
            _chart.Series.Add(series);
        }

        public void CreatePNG(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists) { Directory.CreateDirectory(fileInfo.Directory.FullName); }

            FileStream file = new FileStream(path, FileMode.Create);
            MemoryStream graph = CreatePNGStream();
            byte[] graphBytes = graph.ToArray();
            file.Write(graphBytes, 0, graphBytes.Length);
            file.Flush();

            file.Close();
            graph.Close();
        }

        public MemoryStream CreatePNGStream()
        {
            int width = 800;
            int height = 400;
            RenderTargetBitmap bitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
            PngBitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(bitmap));
            MemoryStream stream = new MemoryStream();
            pngEncoder.Save(stream);
            return stream;
        }
    }
}
