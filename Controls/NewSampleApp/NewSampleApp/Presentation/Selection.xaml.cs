using System;
using Telerik.UI.Xaml.Controls.Input;
using Microsoft.UI.Xaml.Controls;

namespace NewSampleApp.Presentation
{
    public sealed partial class Selection : ExamplePageBase
    {
        public Selection()
        {
            this.InitializeComponent();

            this.DataContext = Enum.GetValues(typeof(CalendarSelectionMode));
        }

        private void ModeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.calendar.SelectionMode = (CalendarSelectionMode)(sender as ListView).SelectedItem;
        }
    }
}
