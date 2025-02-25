using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Primitives.DragDrop;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Telerik.UI.Xaml.Controls.Primitives.DragDrop
{
    internal class ContentControlDragVisualContext : DragVisualContext
    {
        private ContentControl dragVisual = new ContentControl();

        public override FrameworkElement DragVisualHost
        {
            get { return this.dragVisual; }
        }

        internal override void PrepareDragVisual(FrameworkElement content)
        {
            this.dragVisual.Content = content;
            Canvas.SetZIndex(this.dragVisual, 10);

            base.PrepareDragVisual(content);
        }

        internal override void ClearDragVisual()
        {
            this.dragVisual.Content = null;
            base.ClearDragVisual();
        }
    }
}