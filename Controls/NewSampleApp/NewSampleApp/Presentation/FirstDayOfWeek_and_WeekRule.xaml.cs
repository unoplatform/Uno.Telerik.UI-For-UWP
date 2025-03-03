using System;
using System.Globalization;
using Telerik.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Controls;

namespace NewSampleApp.Presentation
{
	public sealed partial class FirstDayOfWeek_and_WeekRule : ExamplePageBase
	{
		public FirstDayOfWeek_and_WeekRule()
		{
			this.InitializeComponent();

			CultureInfo culture = new CultureInfo("en-US");
			culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Wednesday;
			culture.DateTimeFormat.CalendarWeekRule = CalendarWeekRule.FirstFullWeek;
			CultureService.SetCulture(this.calendar, culture);
		}
	}
}
