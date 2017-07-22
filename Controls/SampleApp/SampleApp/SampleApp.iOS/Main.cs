using System.Diagnostics;
using UIKit;

namespace SampleApp.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main(string[] args)
		{
			System.Console.WriteLine($"ProcessID: {Process.GetCurrentProcess().Id} name: {Process.GetCurrentProcess().ProcessName}");

			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main(args, null, typeof(App));
		}
	}

}  