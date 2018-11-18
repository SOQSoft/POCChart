using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ChartToPng.Helpers
{
    public class AxisFactory
    {
        public IList<string> Labels { get; set; }
        public Func<double, string> LabelFormatter { get; set; }
        public double MaxValue { get; set; } = double.NaN;
        public double MinValue { get; set; } = double.NaN;
        public double MaxRange { get; set; } = double.MaxValue;
        public double MinRange { get; set; } = double.MinValue;
        public string Title { get; set; }
        public double Unit { get; set; } = 1;
        public double TickStep { get; set; } = double.NaN;
        public bool TickLines { get; set; } = true;

        private static SolidColorBrush LineColor = new SolidColorBrush(Color.FromRgb(100, 100, 100));
        private static SolidColorBrush NoColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));


        public Axis Create()
        {
            return new Axis()
            {
                Labels = Labels,
                LabelFormatter = LabelFormatter,
                MaxValue = MaxValue,
                MinValue = MinValue,
                MaxRange = MaxRange,
                MinRange = MinRange,
                Title = Title,
                Unit = Unit,
                Separator = new Separator()
                {
                    Step = TickStep,
                    StrokeThickness = TickLines ? 2 : 0
                } 
            };
        }
    }
}
