using Telerik.UI.Xaml.Controls.Primitives.Menu.Commands;

namespace SDKExamples.Examples.RadialMenu
{
    public sealed partial class NavigateBackCommand : ExamplePageBase
    {
        public NavigateBackCommand()
        {
            this.InitializeComponent();
        }

        private void NavigateBackClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            this.radialMenu.CommandService.ExecuteCommand(CommandId.NavigateBack, null);
        }
    }
}