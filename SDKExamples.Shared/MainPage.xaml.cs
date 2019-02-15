using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SDKExamples.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

#if !NETFX_CORE
			this.TopAppBar = new CommandBar();
			this.Padding = new Thickness(0, 55, 0, 0);
#endif

			if (MainPage.Source == null)
            {
                this.LoadData();
            }
			
#if __WASM__
			switch (Environment.GetEnvironmentVariable("UNO_BOOTSTRAP_MONO_RUNTIME_MODE"))
			{
				case "Interpreter":
					UnoShell.AppEnvironmentMode = "Interpreted";
					break;
				case "FullAOT":
					UnoShell.AppEnvironmentMode = "AOT";
					break;
				case "InterpreterAndAOT":
					UnoShell.AppEnvironmentMode = "Mixed";
					break;
			}
#endif
		}

		public static IEnumerable Source { get; set; }

		private async void LoadData()
		{
#if NETSTANDARD2_0
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

#elif !NETFX_CORE
			var text = File.ReadAllText("Data/Examples.xml");
#else
			var text = await Windows.Storage.PathIO.ReadTextAsync("ms-appx:///Data/Examples.xml");
#endif
			var doc = XDocument.Parse(text);
			
			MainPageList.ItemsSource = this.GetControls(doc).ToArray();
			MainPageList.SelectedIndex = 0;
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

        private void MainList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			var control = (sender as ListView).SelectedItem as ControlData;
			this.DataContext = control.Examples;
		}

		private void SecondaryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var example = (sender as ListView).SelectedItem as Example;

			var exampleType = Type.GetType(string.Format(example.TypeName));
			if (exampleType != null)
			{
				rootFrame.Navigate(exampleType, example.DisplayName);
			}
		}
	}
}
