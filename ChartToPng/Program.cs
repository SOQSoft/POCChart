using GalaSoft.MvvmLight;
using LiveCharts.Wpf;
using LiveCharts;
using System.Diagnostics;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ChartToPng
{
    public class Program : ViewModelBase
    {
        public SeriesCollection PieSeries{ get; set; }
        public PieChart chart { get; set; }
        private PieChartGenerator generator;
        public ICommand generateImage { get; set; }
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
            Image = "/png/test.jpg";
            Trace.WriteLine("Started!");
            generator = new PieChartGenerator();
            chart = generator.getChart();
            PieSeries = chart.Series;
            generateImage = new RelayCommand(Render);
        }

        public void Render()
        {
            generator.RenderChartImage();
        }
    }
}
