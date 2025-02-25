using Telerik.UI.Xaml.Controls.Data.DataForm;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;

namespace Telerik.UI.Xaml.Controls.Data
{
    /// <summary>
    /// Represents a ListEditor control.
    /// </summary>
    public partial class ListEditor : ComboBox, ITypeEditor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListEditor"/> class.
        /// </summary>
        public ListEditor()
        {
            this.DefaultStyleKey = typeof(ListEditor);
        }

        /// <summary>
        /// Method used for generating bindings for the <see cref="ITypeEditor"/> properties.
        /// </summary>
        public void BindEditor()
        {
            Binding b1 = new Binding();
            b1.Path = new PropertyPath("ValueOptions");
            this.SetBinding(ListEditor.ItemsSourceProperty, b1);

            Binding b = new Binding() { Mode = BindingMode.TwoWay };
            b.Path = new PropertyPath("PropertyValue");
            this.SetBinding(ListEditor.SelectedItemProperty, b);

            Binding b2 = new Microsoft.UI.Xaml.Data.Binding();
            b2.Path = new PropertyPath("Watermark");
            this.SetBinding(ListEditor.PlaceholderTextProperty, b2);

            Binding b3 = new Binding();
            b3.Converter = new IsEnabledEditorConvetrer();
            b3.Path = new PropertyPath(string.Empty);
            this.SetBinding(ListEditor.IsEnabledProperty, b3);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DataFormComboBoxItem();
        }
    }
}
