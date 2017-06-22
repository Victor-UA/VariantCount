using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariantCount
{
    class MyRows
    {
        public List<string> Fields;
        public List<MyRow> Rows;

        public MyRows()
        {
            Fields = new List<string>();
            Rows = new List<MyRow>();
        }
    }
}
