using Telerik.Charting;
using Telerik.UI.Automation.Peers;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Automation.Peers;

namespace Telerik.UI.Xaml.Controls.Chart
{
    /// <summary>
    /// Represents a chart series that plot their points using financial "Bar" shapes.
    /// </summary>
    public partial class OhlcSeries : OhlcSeriesBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OhlcSeries" /> class.
        /// </summary>
        public OhlcSeries()
        {
            this.DefaultStyleKey = typeof(OhlcSeries);
        }

        internal override FrameworkElement CreateDefaultDataPointVisual(DataPoint point)
        {
            return new OhlcStick();
        }

        /// <inheritdoc/>
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new OhlcSeriesAutomationPeer(this);
        }
    }
}
