namespace NewSampleApp.Presentation;

public sealed partial class MainPage : Page
{
	public MainPage()
	{
		this.InitializeComponent();
	}
	private void NavigateToBlackoutCells_Click(object sender, RoutedEventArgs e)
	{
		Frame.Navigate(typeof(BlackoutCells));
	}
    private void NavigateToCustomEventInformation_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(CustomEventInformation));
    }
    private void NavigateToFirstDayOfWeek_and_WeekRule_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(FirstDayOfWeek_and_WeekRule));
    }
    private void NavigateToFormatting_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(Formatting));
    }
    private void NavigateToRemoveNavigationAnimations_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(RemoveNavigationAnimations));
    }
    private void NavigateToSelection_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(Selection));
    }
    private void NavigateToStyling_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(Styling));
    }
}
