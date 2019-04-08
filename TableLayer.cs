using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner
{
    class TableLayer : Layer
    {
        protected Element code;
        protected Layer[] tr = new Layer[100];
        protected int noOfTr;
        protected int currentTr;
        protected IndexedFlowLayout p;
        public static int senderCurrentTr = 0;

        public TableLayer()
        {

        }

        public TableLayer(int ind, String tag) : base(ind)
        {
            p = new IndexedFlowLayout(ind);
            code = new Element(tag);
            noOfTr = -1;
            currentTr = -1;
            p.FlowDirection = FlowDirection.TopDown;
            p.AutoSize = true;
        }

        public override IndexedFlowLayout getPanel()
        {
            return p;
        }


        public override void addTr()
        {
            noOfTr++;
            currentTr = noOfTr;
            tr[currentTr] = new ListLayer(currentTr, "tr");
           /* IndexedTextBox t = tr[currentTr].getLi().getDesign();
            t.Click += (s, er) =>
            {
                IndexedFlowLayout f = (IndexedFlowLayout)t.Parent;
                MessageBox.Show(f.getIndex().ToString());
            };*/
            p.Controls.Add(tr[currentTr].getPanel());
            tr[currentTr].getPanel().FlowDirection = FlowDirection.LeftToRight;
            tr[currentTr].getPanel().AutoSize = true;

        }

        public override void deleteTr()
        {
            tr[currentTr].Delete();
            tr[currentTr] = null;
            noOfTr--;
            currentTr = noOfTr;
        }

        public override void setCurrentTr(int i)
        {
            currentTr = i;
            
        }

        public override int getCurrentTr()
        {
            return currentTr;
        }

        public override Layer getTr()
        {
            return tr[currentTr];
        }

        public override void Delete()
        {
            for(int i = 0; i < tr.Length; i++)
            {
                if (tr[i] == null)
                    continue;
                this.tr[i].Delete();

            }
            this.p.Dispose();
            this.p = null;
            this.code = null;
            this.tr = null;

        }

        public override string writeHTMLCode()
        {
            String temp = "\n";
            for(int i =0; i < tr.Length; i++)
            {
                if (tr[i] == null)
                    continue;
                temp += tr[i].writeHTMLCode() + "\n";
            }

            this.code.getHTML().setValue(temp);
            return code.getHtmlCode();
        }

        public override int getIndex()
        {
            return index;
        }

        public override IndexedTextBox getLayerInfo()
        {
            return layerinfo;
        }

        public override string getName()
        {
            return name;
        }

        public override bool isSelected()
        {
            throw new NotImplementedException();
        }

        public override void toggleSelected()
        {
            throw new NotImplementedException();
        }

        
    }
}
