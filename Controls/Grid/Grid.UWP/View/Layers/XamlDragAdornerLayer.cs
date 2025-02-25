using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Primitives.DragDrop;
using Windows.Foundation;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;

namespace Telerik.UI.Xaml.Controls.Grid.View
{
    internal class XamlDragAdornerLayer : SharedUILayer
    {
        private DataGridDragSurface dragSurface;

        public XamlDragAdornerLayer()
        {
            this.dragSurface = new DataGridDragSurface(this);
        }

        internal IDragSurface DragSurface
        {
            get
            {
                return this.dragSurface;
            }
        }
    }
}
