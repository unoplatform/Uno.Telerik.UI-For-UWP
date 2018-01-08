using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SDKExamples.UWP
{
	[global::Android.App.ApplicationAttribute(
		Label = "@string/ApplicationName",
		LargeHeap = true,
		HardwareAccelerated = true,
		Theme = "@style/AppTheme"
	)]
	public class DroidApp : Windows.UI.Xaml.NativeApplication
	{
		public DroidApp(IntPtr javaReference, JniHandleOwnership transfer)
			: base(new App(), javaReference, transfer)
		{
		}
	}
}