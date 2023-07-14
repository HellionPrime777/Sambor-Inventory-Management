using System.Collections.Generic;
using System.Windows.Controls;

namespace Inventory_Management.Model
{
    public class AutoSizedGridView : GridView
    {
        /// <summary>
        /// Клас AutoSizedGridView дозволяє забезпечити автоматичну настройку ширини стовпців у GridView у WPF. 
        /// Це може бути корисно при роботі з ListView, де стовпці мають різну ширину і мають адаптуватись до розміру вмісту.
        /// </summary>
        HashSet<int> _autoWidthColumns;

        protected override void PrepareItem(ListViewItem item)
        {
            if (_autoWidthColumns == null)
            {
                _autoWidthColumns = new HashSet<int>();

                foreach (var column in Columns)
                {
                    if (double.IsNaN(column.Width))
                        _autoWidthColumns.Add(column.GetHashCode());
                }
            }

            foreach (GridViewColumn column in Columns)
            {
                if (_autoWidthColumns.Contains(column.GetHashCode()))
                {
                    if (double.IsNaN(column.Width))
                        column.Width = column.ActualWidth;

                    column.Width = double.NaN;
                }
            }

            base.PrepareItem(item);
        }
    }
}
