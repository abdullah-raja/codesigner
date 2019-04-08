using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner
{
    class TextLayer : Layer
    {
        Element code;
        IndexedTextBox design;


        public TextLayer()
        {

        }

        public TextLayer(string tag, int ind, ListLayer list) : base(ind)
        {
            design = new IndexedTextBox(index);
            code = new Element(tag);

            design.Text = code.getHTML().getValue();//is se text change ho rha he
            design.BorderStyle = BorderStyle.None;
            design.ReadOnly = true;
            design.BackColor = Color.White;
            design.Click += (s, er) =>
            {
                list.setCurrentLi(design.getIndex());
            };
        }

        public TextLayer(string tag, int ind) : base(ind)
        {
            design = new IndexedTextBox(index);
            code = new Element(tag);

            design.Text = code.getHTML().getValue();//is se text change ho rha he
            design.BorderStyle = BorderStyle.None;
            design.ReadOnly = true;
            design.BackColor = Color.White;
            
           /* design.Click += (s, er) =>
            {
                Form1.currentLayer = design.getIndex();
                this.selected = design.isSelected();

            };*/

        }

        public TextLayer(string tag, int selectedI, int ind) : base(ind)
        {

            design = new IndexedTextBox(index);  // initializing text box, with index = index
            if (selectedI.ToString() == "-1") // if no choice selected
            {
                code = new Element();
                design.Font = new Font("Times New Roman", 32);
                design.Margin = new Padding(0, 10, 0, 10);
            }

            else
            {
                //string tag = TagType.SelectedItem.ToString();
                code = new Element(tag);
                design.Text = "TextLayer " + index;
                switch (selectedI)
                {
                    case 0: // for h1
                        design.Font = new Font("Times New Roman", 32);
                        design.Margin = new Padding(0, 10, 0, 10);
                        design.Width = 32 * design.Text.Length;
                        break;

                    case 1: // h2
                        design.Font = new Font("Times New Roman", 24);
                        design.Margin = new Padding(0, 13, 0, 13);
                        design.Width = 24 * design.Text.Length;
                        break;

                    case 2: //h3
                        design.Font = new Font("Times New Roman", 19);
                        design.Margin = new Padding(0, 16, 0, 16);
                        design.Width = 19 * design.Text.Length;
                        break;

                    case 3: // h4
                        design.Font = new Font("Times New Roman", 16);
                        design.Margin = new Padding(0, 21, 0, 21);
                        design.Width = 16 * design.Text.Length;
                        break;

                    case 4:  //h5
                        design.Font = new Font("Times New Roman", 14);
                        design.Margin = new Padding(0, 26, 0, 26);
                        design.Width = 14 * design.Text.Length;
                        break;


                    case 5:  // h6
                        design.Font = new Font("Times New Roman", 11);
                        design.Margin = new Padding(0, 37, 0, 37);
                        design.Width = 11 * design.Text.Length;
                        break;


                    default:  //p
                        design.Font = new Font("Times New Roman", 20);
                        design.Margin = new Padding(0, 8, 0, 8);
                        design.Width = 20 * design.Text.Length;
                        break;

                }
            }

                        //is se text change ho rha he
            design.BorderStyle = BorderStyle.None;
            design.ReadOnly = true;
            design.BackColor = Color.White;
            design.Click += (s, er) =>
            {
                Form1.currentLayer = design.getIndex();
                Form1.selectLayer();
            };

            /*design.Click += (s, er) =>
            {
                if (code.getHTML().getTag() == "ul")
                {
                    MessageBox.Show(Form1.currentLayer.ToString());
                    Form1.layers[Form1.currentLayer].setCurrentLi(design.getIndex());
                }

                else
                {
                    Form1.currentLayer = design.getIndex();
                    this.selected = design.isSelected();
                }

            };*/



        }

        

        public override void Delete()
        {
            this.code = null;
            this.design.Dispose();
            this.design = null;
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

        public override IndexedTextBox getDesign()
        {
            return design;
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

        public override string writeHTMLCode()
        {
            return code.getHtmlCode();
        }


    }
}
