using System.Collections;
using System.Xml.Linq;

namespace SDKExamples;

public sealed partial class MainPage : Page
{
	public static Frame RootFrame;
	private ControlData[] _controls;
	private Example[] _examples;

	public Microsoft.UI.Xaml.Controls.NavigationView NavigationView
	{
		get { return NavigationViewControl; }
	}
	public MainPage()
	{
		this.InitializeComponent();

		MainPage.RootFrame = rootFrame;

		if (MainPage.Source == null)
		{
			this.LoadData();
		}
	}

	public static IEnumerable Source { get; set; }

	private async void LoadData()
	{
		string Read()
		{
			if (GetType().Assembly.GetManifestResourceNames().First(a => a.EndsWith("Examples.xml")) is string res)
			{
				using (var stream = new StreamReader(GetType().Assembly.GetManifestResourceStream(res)))
				{
					return stream.ReadToEnd();
				}
			}

			return "";
		}

		var text = Read();
		var doc = XDocument.Parse(text);
		_controls = this.GetControls(doc).ToArray();
		var dummyTextBlock = new TextBlock();

		for (var i = 0; i < _controls.Length; i++)
		{
			var controlData = _controls[i] as ControlData;
			var item = new Microsoft.UI.Xaml.Controls.NavigationViewItem()
			{
				Content = controlData.Name,
				DataContext = controlData
			};

			item.Icon = new FontIcon()
			{
				FontFamily = dummyTextBlock.FontFamily,
				Glyph = controlData.Name[0].ToString() + controlData.Name[1].ToString()
			};

			NavigationViewControl.MenuItems.Add(item);
		}
	}
	private IEnumerable<ControlData> GetControls(XDocument doc)
	{

		return from control in doc.Descendants("Control")
			   select new ControlData
			   (
				   control.Attribute("Name").Value,
				   from example in control.Descendants("Example")
				   select new Example(example.Attribute("ClassName").Value, example.Attribute("DisplayName").Value)
				);
	}

	private void BackButtonClicked(object sender, RoutedEventArgs e)
	{
		this.DataContext = MainPage.Source;
	}

	private void OnNavigationViewItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
	{

		for (var i = 0; i < _controls.Length; i++)
		{
			var controlData = _controls[i] as ControlData;
			if (controlData.Name == (args.InvokedItem as string))
			{
				_examples = controlData.Examples.ToArray();
				break;
			}
		}

		rootFrame.Navigate(typeof(SectionPage), _examples);
	}
}
