using Microsoft.UI.Xaml;

namespace Telerik.Core
{
    internal interface IItemsContainer
    {
        FrameworkElement[] ViewportItems
        {
            get;
        }
    }
}
