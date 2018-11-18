using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChartToPng.Helpers
{
    public class ChartDisplay : DockPanel
    {
        public Panel Panel { get; }

        public ChartDisplay(Chart chart, string title)
        {
            Label titleLabel = new Label() { Content = title };
            titleLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            titleLabel.FontSize = 25;
            titleLabel.HorizontalAlignment = HorizontalAlignment.Center;

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

            Grid.SetRow(chart, 1);
            grid.Children.Add(titleLabel);
            grid.Children.Add(chart);

            Panel = grid;
            Attach();
        }

        public void Attach()
        {
            Children.Clear();
            Children.Add(Panel);
        }

        public void Detach()
        {
            Children.Clear();
        }
    }
}
