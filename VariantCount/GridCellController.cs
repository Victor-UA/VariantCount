using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceGrid;

namespace VariantCount
{
    public class GridCellController : mySourceGridTools.GridCellController
    {
        public GridCellController(Color BackColor) : base(BackColor)
        {
        }

        public override void OnDoubleClick(CellContext sender, EventArgs e)
        {
            base.OnDoubleClick(sender, e);
            //((sender.Cell as SourceGrid.Cells.Cell).Tag as IPInfo).ShowHostForm();
        }
    }
}