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
using Microsoft.UI.Core;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

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
			var control = e.Parameter;
			this.DataContext = control;
		}

		private void SecondaryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var example = (sender as ListView).SelectedItem as Example;
			var exampleType = Type.GetType(string.Format(example.TypeName));

			MainPage.RootFrame.Navigate(exampleType, example.DisplayName);
		}
	}
}
