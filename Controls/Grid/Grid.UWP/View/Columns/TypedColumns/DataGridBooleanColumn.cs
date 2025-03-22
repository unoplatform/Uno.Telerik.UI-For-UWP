using System;
using Telerik.UI.Xaml.Controls.Grid.Primitives;
using Telerik.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;

namespace Telerik.UI.Xaml.Controls.Grid
{
    /// <summary>
    /// A special <see cref="DataGridTypedColumn"/> implementation that presents boolean data.
    /// </summary>
    public class DataGridBooleanColumn : DataGridTextColumn
    {
        private const string UncheckedGlyph = "\u2612";
        private const string CheckedGlyph = "\u2611";
        private const string IndeterminateGlyph = "\u25A3";

        private static Type booleanType = typeof(bool);
        private static Type checkBoxType = typeof(CheckBox);

        private Style defaultCellEditorStyle;
        private Style defaultCellStyle;

        internal override Style DefaultCellContentStyle
        {
            get
            {
                if (this.defaultCellStyle == null)
                {
                    defaultCellStyle = /* UNO TODO */Controls.Primitives.ResourceHelper.LoadEmbeddedResource(
                        typeof(DataGridTextColumn),
                        "Telerik.UI.Xaml.Controls.Grid.View.Columns.Resources.DefaultBooleanColumnStyle.xaml",
                        "DefaultColumnStyle") as Style;
                }
                return this.defaultCellStyle;
            }
        }

        internal override Style DefaultCellEditorStyle
        {
            get
            {
                if (this.defaultCellEditorStyle == null)
                {
                    defaultCellEditorStyle = /* UNO TODO */Controls.Primitives.ResourceHelper.LoadEmbeddedResource(
                        typeof(DataGridTextColumn),
                        "Telerik.UI.Xaml.Controls.Grid.View.Columns.Resources.DefaultBooleanColumnEditorStyle.xaml",
                        "DefaultColumnEditorStyle") as Style;
                }
                return this.defaultCellEditorStyle;
            }
        }

        internal override bool SupportsCompositeFilter
        {
            get
            {
                return false;
            }
        }

        internal override bool CanEdit
        {
            get { return this.PropertyInfoInitialized && this.PropertyInfo.DataType == DataGridBooleanColumn.booleanType && this.CanUserEdit; }
        }

        /// <summary>
        /// Gets the type of the editor for the DataGridBooleanColumn that is visualized when entering in edit mode.
        /// </summary>
        /// <returns>The type of the editor.</returns>
        public override object GetEditorType(object item)
        {
            return this.CanEdit ? DataGridBooleanColumn.checkBoxType : DataGridBooleanColumn.TextBlockType;
        }

        
        /// <summary>
        /// Creates the <see cref="DataGridBooleanFilterControl" /> instance that allows filtering operation to be applied upon this column.
        /// </summary>
        protected internal override DataGridFilterControlBase CreateFilterControl()
        {
            return new DataGridBooleanFilterControl()
            {
                PropertyName = this.PropertyName
            };
        }
    }
}
