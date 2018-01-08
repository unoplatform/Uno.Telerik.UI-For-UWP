using SDKExamples.UWP;
using UIKit;

namespace SDKExamples.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main(string[] args)
		{
			// Legacy clipping is enabled by default in Uno.UI 
			Uno.UI.FeatureConfiguration.UIElement.UseLegacyClipping = false;

			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main(args, null, typeof(App));
		}
	}
}