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
            Image = "/png/test.jpg";

            LineChart chart = new LineChart("Test");
            chart.AddSeries("test", new List<ObservablePoint>()
            {
                new ObservablePoint(0,0),
                new ObservablePoint(1,1),
                new ObservablePoint(2,1),
            });
            string path = "png/myImage.png";
            chart.CreatePNG(path);
            Image = path;
        }
    }
}
