using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SDKExamples.Chart
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChartGrid : ExamplePageBase
    {
        public ChartGrid()
        {
            this.InitializeComponent();
        }
    }

    public class CustomPointChartGrid
    {
        public string Category { get; set; }
        public double Value { get; set; }
    }

    public class ViewModelChartGrid
    {
        public ViewModelChartGrid()
        {
            this.Source = new List<CustomPointChartGrid>()
            {
                new CustomPointChartGrid{ Category = "Apples", Value = 10 },
                new CustomPointChartGrid{ Category = "Oranges", Value = 32 },
                new CustomPointChartGrid{ Category = "Pears", Value = 15 },
            };
        }
        public List<CustomPointChartGrid> Source { get; set; }
    }
}
