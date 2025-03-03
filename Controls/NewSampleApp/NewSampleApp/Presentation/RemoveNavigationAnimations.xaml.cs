using Telerik.UI.Xaml.Controls.Input.Calendar;
using Telerik.UI.Xaml.Controls.Input.Calendar.Commands;
using Microsoft.UI.Xaml.Controls;

namespace NewSampleApp.Presentation
{
    public sealed partial class RemoveNavigationAnimations : ExamplePageBase
    {
        public RemoveNavigationAnimations()
        {
            this.InitializeComponent();
        }

        private void NavigateToUpperViewClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            this.calendar.MoveToUpperView();
        }

        private void NavigateToLowerViewClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            this.calendar.MoveToLowerView(this.calendar.CurrentDate);
        }
    }

    public class CustomMoveToUpperViewCommand : CalendarCommand
    {
        public CustomMoveToUpperViewCommand()
        {
            this.Id = CommandId.MoveToUpperView;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            (parameter as CalendarViewChangeContext).AnimationStoryboard = null;
            this.Owner.CommandService.ExecuteDefaultCommand(CommandId.MoveToUpperView, parameter);
        }
    }
}
