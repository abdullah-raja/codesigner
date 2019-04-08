using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner
{
    class ListLayer : Layer
    {
        protected Element code;
        protected Layer[] li = new Layer[100];
        protected int noOfLi;
        protected int currentLi;
        protected IndexedFlowLayout p;

        public ListLayer()
        {

        }

        public override IndexedFlowLayout getPanel()
        {
            return p;
        }

        public ListLayer(int ind, string tag) : base(ind)
        {
            p = new IndexedFlowLayout(ind);
            code = new Element(tag);
            noOfLi = -1;
            currentLi = -1;

        }

        override public void addLi(string tag)
        {
            noOfLi++;
            currentLi = noOfLi;
            li[currentLi] = new TextLayer(tag, currentLi);
            
            p.Controls.Add(li[currentLi].getDesign());
            li[currentLi].getDesign().Click += (s, er) =>
            {
                IndexedFlowLayout f = (IndexedFlowLayout)li[currentLi].getDesign().Parent;
                Form1.currentLayer = f.getIndex();
            };
            
        }

        override public void addLi(string tag, TableLayer Ab, System.Windows.Forms.TextBox input)
        {
            noOfLi++;
            currentLi = noOfLi;
            li[currentLi] = new TextLayer(tag, currentLi,this);
            li[currentLi].getDesign().Click += (s, er) =>
            {
                IndexedFlowLayout f = (IndexedFlowLayout)li[currentLi].getDesign().Parent;
                IndexedFlowLayout parentF = (IndexedFlowLayout)f.Parent;
                Form1.currentLayer = parentF.getIndex();
                // MessageBox.Show(f.getIndex().ToString());
                
                setCurrentTrOfTable(Ab, f.getIndex());
                input.Text = li[currentLi].getDesign().Text;
                // setCurrentLi(li[currentLi].getDesign().getIndex());



                // MessageBox.Show(this.index.ToString());
            };

            /*li[currentLi].getDesign().DoubleClick += (s, er) =>
            {
                
                li[currentLi].getDesign().ReadOnly = true;
            };*/
            p.Controls.Add(li[currentLi].getDesign());
        }

        public void setCurrentTrOfTable(TableLayer A, int i)
        {
           
            A.setCurrentTr(i);
        }

        override public void deleteLi()
        {
            li[currentLi].Delete();
            li[currentLi] = null;
            noOfLi--;
            currentLi = noOfLi;
        }

        override public Layer getLi()
        {
            return li[currentLi];
        }  // get li at current li position

        override public int getCurrentLi()
        {
            return currentLi;
        }

        override public void setCurrentLi(int i)
        {
            this.currentLi = i;
        }

        public override string writeHTMLCode()
        {
            string temp = "\n";
            for(int i = 0; i < li.Length; i++)
            {
                if (li[i] == null)
                    continue;

                temp += li[i].writeHTMLCode() + "\n";
            }

            this.code.getHTML().setValue(temp);
            return code.getHtmlCode();
        } // will return complete html code



        public override void Delete()
        {
            for(int i = 0; i < li.Length; i++)
            {
                if (li[i] == null)
                    continue;
                this.li[i].Delete();
            }
            this.code = null;
            this.li = null;
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

        public override Element getCode()
        {
            return code;
        }

        public override bool isSelected()
        {
            return selected;
        }

        public override void toggleSelected()
        {
            selected = !selected;
        }
    }
}
