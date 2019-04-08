using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner
{
    class IndexedFlowLayout : System.Windows.Forms.FlowLayoutPanel
    {
        public int index;
        public IndexedFlowLayout(int i)
        {
            index = i;
        }

        public int getIndex()
        {
            return index;
        }
    }
}
