using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceGrid;

namespace VariantCount
{
    public class Fill : mySourceGridTools.Fill
    {
        public List<string> Fields;

        public Fill(List<string> fields) : base()
        {
            Fields = fields;
        }

        public override void GridUpdateRow(
            SourceGrid.Grid grid, object item, int Index)
        {
            grid.Rows[Index].Tag = item;
            Type itemType = item.GetType();
            if (itemType == typeof(MyRow))
            {
                MyRow row = item as MyRow;
                for (int i = 0; i < row.Count; i++)
                {
                    grid[Index, 0].Value = row[Fields[i]];
                    grid[Index, i].Tag = row;
                }
                return;
            }

            {
                grid[Index, 0].Value = item;
            }
        }
                
        public override void GridInsertRow<T>(
            SourceGrid.Grid grid,
            T item,
            Func<T, Color, mySourceGridTools.GridCellController> newCellController = null,
            int Index = -1)
        {
            int index = Index < 0 ? grid.RowsCount : Index;
            grid.Rows.Insert(index);
            grid.Rows[index].Tag = item;

            Type itemType = item.GetType();
            SourceGrid.Cells.Controllers.IController CellController =
                (newCellController == null ?
                    new GridCellController(Color.LightBlue) :
                    CellController = newCellController(item, Color.LightBlue)
                );
            if (itemType == typeof(MyRow))
            {
                MyRow row = item as MyRow;
                for (int i = 0; i < row.Count; i++)
                {
                    grid[index, i] = newCell(row, row[Fields[i]], CellController);
                }
                return;
            }

            {
                grid[index, 0] = newCell(item, item, CellController);
            }
        }
    }
}
