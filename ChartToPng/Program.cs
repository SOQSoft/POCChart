using GalaSoft.MvvmLight;
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
            Trace.WriteLine("Started!");
        }
    }
}
