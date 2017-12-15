using System;
using System.Collections.Generic;
using Telerik.Core;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

#if NETFX_CORE
using DefaultPresenter = Windows.UI.Xaml.Controls.TextBlock;
#else
using DefaultPresenter = Windows.UI.Xaml.Controls.Border;
#endif

namespace Telerik.UI.Xaml.Controls.Input.Calendar
{
    internal class XamlHeaderContentLayer : CalendarLayer
    {
        internal List<DefaultPresenter> realizedCalendarCellDefaultPresenters;

        private DefaultPresenter measurementPresenter;
        private Canvas contentPanel;

        public XamlHeaderContentLayer()
        {
            this.contentPanel = new Canvas();

            this.realizedCalendarCellDefaultPresenters = new List<DefaultPresenter>();
        }

        internal Panel VisualContainer
        {
            get
            {
                return this.contentPanel;
            }
        }

        protected internal override UIElement VisualElement
        {
            get
            {
                return this.contentPanel;
            }
        }

        internal void UpdateUI()
        {
            if (this.Owner.Model.CalendarHeaderCells == null)
            {
                this.VisualElement.Visibility = Visibility.Collapsed;
                return;
            }

            this.VisualElement.ClearValue(FrameworkElement.VisibilityProperty);

            int index = 0;
            foreach (CalendarHeaderCellModel cell in this.Owner.Model.CalendarHeaderCells)
            {
                if (!cell.layoutSlot.IsSizeValid())
                {
                    continue;
                }

                FrameworkElement element = this.GetDefaultVisual(cell, index);

                if (element != null)
                {
                    RadRect layoutSlot = cell.layoutSlot;
                    layoutSlot = XamlContentLayerHelper.ApplyLayoutSlotAlignment(element, layoutSlot);
                    XamlContentLayer.ArrangeUIElement(element, layoutSlot, false);

                    index++;
                }
            }

            while (index < this.realizedCalendarCellDefaultPresenters.Count)
            {
                this.realizedCalendarCellDefaultPresenters[index].Visibility = Visibility.Collapsed;
                index++;
            }
        }

        internal RadSize MeasureContent(object owner, object content)
        {
            this.EnsureMeasurementPresenter();

            if (owner is CalendarHeaderCellType)
            {
                CalendarHeaderCellType headerType = (CalendarHeaderCellType)owner;


#if NETFX_CORE
				var localPresenter = this.measurementPresenter;
#else
				// UNO TODO
				var localPresenter = this.measurementPresenter.Child as TextBlock;
#endif

				if (headerType == CalendarHeaderCellType.DayName)
                {
                    if (this.Owner.DayNameCellStyleSelector != null)
                    {
						localPresenter.Style = this.Owner.DayNameCellStyleSelector.SelectStyle(new CalendarCellStyleContext() { Label = content.ToString() }, this.Owner);
                    }
                    else
                    {
						localPresenter.Style = this.Owner.DayNameCellStyle.ContentStyle;
                    }
                }
                else
                {
                    if (this.Owner.WeekNumberCellStyleSelector != null)
                    {
						localPresenter.Style = this.Owner.WeekNumberCellStyleSelector.SelectStyle(new CalendarCellStyleContext() { Label = content.ToString() }, this.Owner);
                    }
                    else
                    {
						localPresenter.Style = this.Owner.WeekNumberCellStyle.ContentStyle;
                    }
                }

				localPresenter.Text = content.ToString();

				return XamlContentLayerHelper.MeasureVisual(this.measurementPresenter);  
			}

			return RadSize.Empty;
        }

        private static void ApplyStyleToDefaultVisual(TextBlock visual, CalendarCellModel cell)
        {
            Style cellStyle = cell.Context.GetEffectiveCellContentStyle();
            if (cellStyle == null)
            {
                return;
            }

            visual.Style = cellStyle;
        }

        private FrameworkElement GetDefaultVisual(CalendarNode cell, int virtualIndex)
        {
#if NETFX_CORE
			TextBlock visual;

			if (virtualIndex < this.realizedCalendarCellDefaultPresenters.Count)
			{
				visual = this.realizedCalendarCellDefaultPresenters[virtualIndex];

				visual.ClearValue(TextBlock.VisibilityProperty);
				visual.ClearValue(TextBlock.StyleProperty);
			}
			else
			{
				visual = this.CreateDefaultVisual();
			}

			XamlContentLayerHelper.PrepareDefaultVisual(visual, cell);

			return visual;
#else
			// TODO UNO
			DefaultPresenter visual;

			if (virtualIndex < this.realizedCalendarCellDefaultPresenters.Count)
			{
				visual = this.realizedCalendarCellDefaultPresenters[virtualIndex];

				visual.ClearValue(Border.VisibilityProperty);
				(visual.Child as TextBlock).ClearValue(TextBlock.StyleProperty);
			}
			else
			{
				visual = this.CreateDefaultVisual();
			}

			XamlContentLayerHelper.PrepareDefaultVisualUno(visual, cell);

			return visual;
#endif
		}

		private DefaultPresenter CreateDefaultVisual()
        {
#if NETFX_CORE
			TextBlock textBlock = new TextBlock();

			this.AddVisualChild(textBlock);
			this.realizedCalendarCellDefaultPresenters.Add(textBlock);

			return textBlock;
#else
			// TODO UNO
			TextBlock textBlock = new TextBlock();
			var border = new Border { Child = textBlock };

			this.AddVisualChild(border);
			this.realizedCalendarCellDefaultPresenters.Add(border);

			return border;
#endif

		}

		private void EnsureMeasurementPresenter()
        {
            if (this.measurementPresenter == null)
            {
#if NETFX_CORE
				this.measurementPresenter = new TextBlock();
                this.measurementPresenter.Opacity = 0;
                this.measurementPresenter.IsHitTestVisible = false;

				// TODO UNO
                // this.AddVisualChild(this.measurementPresenter);
#else
				// TODO UNO
				this.measurementPresenter = new Border { Child = new TextBlock() };
				this.measurementPresenter.Opacity = 0;
				this.measurementPresenter.IsHitTestVisible = false;

				this.AddVisualChild(this.measurementPresenter);
#endif
			}
		}
    }
}
