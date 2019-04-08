using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner
{
    class IndexedCheckBox : System.Windows.Forms.CheckBox
    {
        int index;

        public IndexedCheckBox(int index)
        {
            this.index = index;


        }

        public int getIndex()
        {
            return index;
        }
    }
}
