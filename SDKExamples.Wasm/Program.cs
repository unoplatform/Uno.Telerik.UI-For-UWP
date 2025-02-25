using SDKExamples.UWP;
using System;
using Microsoft.UI.Xaml;

namespace SDKExamples.Wasm
{
	public class Program
	{
		static int Main(string[] args)
		{
			Application.Start(_ => new App());

            return 0;
		}
	}
}
