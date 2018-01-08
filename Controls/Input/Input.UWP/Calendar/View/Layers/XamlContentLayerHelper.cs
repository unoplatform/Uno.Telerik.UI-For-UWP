using System;
using Telerik.Core;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Telerik.UI.Xaml.Controls.Input.Calendar
{
    internal static class XamlContentLayerHelper
    {
		internal static RadSize MeasureVisual(FrameworkElement visual)
		{
			visual.ClearValue(FrameworkElement.WidthProperty);
			visual.ClearValue(FrameworkElement.HeightProperty);
			visual.Measure(RadCalendar.InfinitySize);

			return new RadSize(visual.DesiredSize.Width, visual.DesiredSize.Height);
		}

#if __IOS__ || __ANDROID__
		internal static RadSize MeasureVisual(TextBlock visual)
		{
			visual.ClearValue(TextBlock.WidthProperty);
			visual.ClearValue(TextBlock.HeightProperty);
			var result = IFrameworkElementHelper.Measure(visual, RadCalendar.InfinitySize);

			return new RadSize(result.Width, result.Height);
		}
#endif
		internal static RadRect ApplyLayoutSlotAlignment(FrameworkElement visual, RadRect layoutSlot)
        {
            Size desiredSize = visual.DesiredSize;

            if (desiredSize.Width < layoutSlot.Width)
            {
                switch (visual.HorizontalAlignment)
                {
                    case HorizontalAlignment.Center:
                        layoutSlot.X += (layoutSlot.Width - desiredSize.Width) / 2;
                        break;
                    case HorizontalAlignment.Right:
                        layoutSlot.X = layoutSlot.Right - desiredSize.Width;
                        break;
                }
            }

            if (desiredSize.Height < layoutSlot.Height)
            {
                switch (visual.VerticalAlignment)
                {
                    case VerticalAlignment.Center:
                        layoutSlot.Y += (layoutSlot.Height - desiredSize.Height) / 2;
                        break;
                    case VerticalAlignment.Bottom:
                        layoutSlot.Y = layoutSlot.Bottom - desiredSize.Height;
                        break;
                }
            }

            return layoutSlot;
        }

		internal static void PrepareDefaultVisual(TextBlock visual, CalendarNode cell)
        {
			visual.Tag = cell;
			visual.Text = cell.Label;

			ApplyStyleToDefaultVisual(visual, cell);

			MeasureVisual(visual);
		}

		internal static void PrepareDefaultVisualUno(Border visual, CalendarNode cell)
		{
			var textBlock = visual.Child as TextBlock;

			textBlock.Tag = cell;
			textBlock.Text = cell.Label;

			ApplyStyleToDefaultVisual(textBlock, cell);

			MeasureVisual(visual);
		}

		internal static void ApplyStyleToDefaultVisual(TextBlock visual, CalendarNode cell)
        {
            if (cell.Context == null)
            {
                return;
            }

            Style cellStyle = cell.Context.GetEffectiveCellContentStyle();
            if (cellStyle == null)
            {
                return;
            }

            visual.Style = cellStyle;
        }
    }
}
