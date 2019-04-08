using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner
{
    class RadioBoxPanel : Layer
    {
        IndexedFlowLayout p;
        protected string type;
        protected InputLayer[] choice = new InputLayer[100];
        protected int noOfChoices = -1;
        protected int currentChoice = -1;



        public RadioBoxPanel()
        {
           // p = new System.Windows.Forms.FlowLayoutPanel();
            p.BackColor = System.Drawing.Color.Transparent;
            p.ForeColor = System.Drawing.Color.Black;
            //p.Dock = System.Windows.Forms.DockStyle.Top;
            p.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            p.AutoSize = true;
        }

        public RadioBoxPanel(string name, int ind,string type) : base(ind)
        {
            this.type = type;
            p = new IndexedFlowLayout(ind);
            p.BackColor = System.Drawing.Color.White;
            //p.ForeColor = System.Drawing.Color.Black;
          //  p.Dock = System.Windows.Forms.DockStyle.Top;
            this.name = name;
        }

        public override IndexedFlowLayout getPanel()
        {
            return p;
        }

        public override void setNoOfChoices(int s)
        {
            this.noOfChoices = s;
        }

        public override void Delete()
        {
            for (int i = 0; i < choice.Length; i++)
            {
                if (choice[i] == null)
                    continue;
                this.choice[i].Delete();
            }
            
            this.choice = null;
        }

        public override void addChoice(string value)
        {
            noOfChoices++;
            currentChoice = noOfChoices;
            choice[currentChoice] = new InputLayer("input", currentChoice, type, name, value);
            p.Controls.Add(choice[currentChoice].getPanel());
            p.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            p.AutoSize = true;
            choice[currentChoice].getInputDesign().Click += (s, er) =>
            {
                IndexedFlowLayout f = (IndexedFlowLayout)choice[currentChoice].getPanel().Parent;
                Form1.currentLayer = f.getIndex();
            };
           /* choice[currentChoice].getInputDesign().Click += (s, er) =>
            {
                System.Windows.MessageBox.Show(currentChoice.ToString());
                System.Windows.MessageBox.Show(choice[currentChoice].getIndex().ToString());

            };*/
        }


        override public void deleteLi()
        {
            choice[currentChoice].Delete();
            choice[currentChoice] = null;
            noOfChoices--;
            currentChoice = noOfChoices;
        }

        override public InputLayer getChoice()
        {
            return choice[currentChoice];
        }  // get li at current li position

        override public int getCurrentLi()
        {
            return currentChoice;
        }

        override public void setCurrentLi(int i)
        {
            this.currentChoice = i;
        }

        public override string writeHTMLCode()
        {
            string temp = "";
            for (int i = 0; i < choice.Length; i++)
            {
                if (choice[i] == null)
                    continue;

                temp += choice[i].writeHTMLCode() + "\n";
            }

            return temp;

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
