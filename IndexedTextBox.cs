using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner
{
    class IndexedTextBox : System.Windows.Forms.TextBox
    {
        int index;
        bool selected;
        public IndexedTextBox(int index)
        {
            this.index = index;
            
           

        }

        public int getIndex()
        {
            return index;
        }

        public bool isSelected()
        {
            return selected;
        }

        public void toggleSelected()
        {
            selected = !selected;
        }

        
    }
}
