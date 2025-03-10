using System;
using Windows.UI.Core;

namespace Telerik.UI.Xaml.Controls.Data
{
    internal class DelegateUpdate
    {
        private Action updateAction;

        public DelegateUpdate(Action action)
        {
            this.updateAction = action;
            this.Priority = Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal;
        }

        public Microsoft.UI.Dispatching.DispatcherQueuePriority Priority { get; set; }

        internal virtual void Process()
        {
            if (this.updateAction != null)
            {
                this.updateAction();
            }
        }
    }
}
