using SDKExamples.UWP;
using SDKExamples.UWP.AutoCompleteBox;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SDKExamples
{
	public sealed partial class SectionPage : Page
	{
		public SectionPage()
		{
			this.InitializeComponent();
		}

		protected override async void OnNavigatedTo(NavigationEventArgs e)
		{
			var control = e.Parameter as ControlData;
			this.DataContext = control.Examples;
		}

		private void SecondaryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var example = (sender as ListView).SelectedItem as Example;
			var exampleType = Type.GetType(string.Format(example.TypeName));

			MainPage.RootFrame.Navigate(exampleType, example.DisplayName);
		}
	}
}
