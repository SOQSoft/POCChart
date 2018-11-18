using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
//using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace ChartToPng
{
    public partial class PieChartGenerator
    {
        PieChart pieChart1 { get; set; }
        public PieChartGenerator()
        {
            pieChart1 = new PieChart();
            pieChart1.DisableAnimations = true;
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
                {
                    new PieSeries
                    {
                        Title = "Maria",
                        Values = new ChartValues<double> {3},
                        PushOut = 15,
                        DataLabels = true,
                        LabelPoint = labelPoint
                    },
                    new PieSeries
                    {
                        Title = "Charles",
                        Values = new ChartValues<double> {4},
                        DataLabels = true,
                        LabelPoint = labelPoint
                    },
                    new PieSeries
                    {
                        Title = "Frida",
                        Values = new ChartValues<double> {6},
                        DataLabels = true,
                        LabelPoint = labelPoint
                    },
                    new PieSeries
                    {
                        Title = "Frederic",
                        Values = new ChartValues<double> {2},
                        DataLabels = true,
                        LabelPoint = labelPoint
                    }
                };

            pieChart1.LegendLocation = LegendLocation.Bottom;
        }

        public PieChart getChart()
        {
            return pieChart1;
        }

        public MemoryStream CreatePNGStream()
        {
            Window window = new Window() { Content = pieChart1 };
            window.WindowStyle = WindowStyle.None;
            window.AllowsTransparency = true;
            window.Width = 800;
            window.Height = 400;
            //window.Opacity = 0.001;
            window.Show();
            pieChart1.Update(true, true); //force chart redraw
            window.UpdateLayout();

            var encoder = new PngBitmapEncoder();
            var bitmap = new RenderTargetBitmap((int)pieChart1.ActualWidth, (int)pieChart1.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(pieChart1);
            //window.Close();

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

        //public void RenderChartImage()
        //{

        //    var myChart = pieChart1;

        //    var viewbox = new Viewbox();
        //    viewbox.Child = myChart;
        //    viewbox.Measure(myChart.RenderSize);
        //    viewbox.Arrange(new Rect(new Point(0, 0), myChart.RenderSize));
        //    myChart.Update(true, true); //force chart redraw
        //    viewbox.UpdateLayout();

        //    SaveToPng(myChart, "chart.png");
        //    //png file was created at the root directory.
        //}

        //private void SaveToPng(FrameworkElement visual, string fileName)
        //{
        //    var encoder = new PngBitmapEncoder();
        //    EncodeVisual(visual, fileName, encoder);
        //}

        //private static void EncodeVisual(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        //{
        //    //var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
        //    var bitmap = new RenderTargetBitmap(500, 500, 96, 96, PixelFormats.Pbgra32);
        //    bitmap.Render(visual);
        //    var frame = BitmapFrame.Create(bitmap);
        //    encoder.Frames.Add(frame);
        //    using (var stream = File.Create(fileName)) encoder.Save(stream);
        //}
    }
}