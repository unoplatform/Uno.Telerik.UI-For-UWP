using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

namespace Telerik.UI.Xaml.Controls.DataVisualization
{
    /// <summary>
    /// Contains data to update an arc based on an angle.
    /// </summary>
    internal class UpdateArcContext
    {
        internal double angle;
        internal double radius;
        internal double minAngle;
        internal Point center;
        internal ArcSegment arc;
    }
}
