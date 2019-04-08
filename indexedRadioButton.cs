using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner
{
    class IndexedRadioButton : System.Windows.Forms.RadioButton
    {
        int index;
        
        public IndexedRadioButton(int index)
        {
            this.index = index;


        }

        public int getIndex()
        {
            return index;
        }
    }
}
