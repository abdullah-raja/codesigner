using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner
{
    class InputLayer : Layer
    {
        Control design;
        Element code;
        IndexedTextBox label;
        IndexedFlowLayout panel;
        public InputLayer()
        {

        }

        public InputLayer(string tag, int ind, String type, String name) : base(ind) // for textbox
        {
            code = new Element(tag);
            code.getHTML().getAttributeList().getAttributes()["type"] = type;
            code.getHTML().getAttributeList().getAttributes()["name"] = name;
            panel = new IndexedFlowLayout(ind);
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.AutoSize = true;
            design = new TextBox();
            design.Font = new Font("Times New Roman", 16);
            label = new IndexedTextBox(ind);
            panel.Controls.Add(label);
            panel.Controls.Add(design);
           
            label.Text = "Label" + ind;
            label.BorderStyle = BorderStyle.None;
            label.ReadOnly = true;
            label.BackColor = Color.White;
            label.Width = 15 * label.Text.Length;
            label.Font = new Font("Times New Roman", 16);
            code.getHTML().setValue(label.Text);

            label.Click += (s, er) =>
            {
                Form1.currentLayer = index;
            };

            code.getHTML().getAttributeList().updateAttributeString();
            design.Click += (s, er) =>
            {
                Form1.currentLayer = index;
                MessageBox.Show(Form1.currentLayer.ToString());
            };
        }

        public InputLayer(string tag, int ind, String type, String name, String value) : base(ind)  // for boxes
        {
            code = new Element(tag);
            code.getHTML().getAttributeList().getAttributes()["type"] = type;
            code.getHTML().getAttributeList().getAttributes()["name"] = name;
            panel = new IndexedFlowLayout(ind);
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.AutoSize = true;

            if (type == "radio")
                design = new IndexedRadioButton(ind);

            if(type == "checkbox")
                design = new IndexedCheckBox(ind);


            design.Text = value;
            code.getHTML().getAttributeList().getAttributes()["value"] = design.Text;
            label = new IndexedTextBox(ind);
            label.Text = "Label" + ind;
            label.BorderStyle = BorderStyle.None;
            label.ReadOnly = true;
            label.BackColor = Color.White;
            panel.Controls.Add(design);
            code.getHTML().setValue(label.Text);





            code.getHTML().getAttributeList().updateAttributeString();
            design.Click += (s, er) =>
            {
                
            };

           

        }

        public InputLayer(String type, String tag, int ind) : base(ind)
        {
            code = new Element(tag);
            code.getHTML().getAttributeList().getAttributes()["type"] = type;
            code.getHTML().getAttributeList().getAttributes()["value"] = "Submit";
            design = new Button();
            design.Text = code.getHTML().getAttributeList().getAttributes()["value"];
            code.getHTML().getAttributeList().updateAttributeString();

            design.Click += (s, er) =>
            {
                Form1.currentLayer = index;
            };
        }


        public override IndexedFlowLayout getPanel()
        {
            return panel;
        }

        public override void Delete()
        {
            design.Dispose();
            label.Dispose();
            this.design = null;
            this.code = null;
            this.label = null;
        }

        public override int getIndex()
        {
            return this.index;
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
            return selected;
        }

        public override void toggleSelected()
        {
            selected = !selected;
        }

        public override Element getCode()
        {
            return code;

        }

        public override Control getInputDesign()
        {
            return design;
        }

        public override IndexedTextBox getLabel()
        {
            return label;
        }

        public override string writeHTMLCode()
        {
            return code.getHtmlCode();
        }

    }
}
