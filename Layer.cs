using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;


namespace CoDesigner
{
   abstract class Layer
    {
        protected IndexedTextBox layerinfo;  // Layer panel info
        protected string name;
        protected int index;
        protected bool selected;
        // int index;
        public Layer()
        {

        }

        
        public Layer(int ind)
        {
            this.index = ind;
            layerinfo = new IndexedTextBox(ind); // creating a text box
            this.name = "Layer " + index;
           selected = false;
           
            
            // LAYER PANEL -- SARIM 
            layerinfo.Text = name;
            layerinfo.BorderStyle = BorderStyle.FixedSingle;
            layerinfo.ReadOnly = true;
            layerinfo.BackColor = Color.Gray;
            layerinfo.ForeColor = Color.White;
            // LAYER PANEL -- SARIM 

        }

        public Layer(int ind, string tag)
        {
            /*code = new Element(tag);
            if (tag == "li")
            {

                // SPECIFYING DEFAULT PROPERTIES -- SHAHEER
                
                design = new IndexedTextBox(ind);
                design.Margin = new Padding(32, 16, 32, 16);
                
                design.Font = new Font("Times New Roman", 20);
                design.Text = code.getHTML().getValue();//is se text change ho rha he
                design.BorderStyle = BorderStyle.None;
                design.ReadOnly = true;
                design.BackColor = Color.White;
                // SPECIFYING DEFAULT PROPERTIES -- SHAHEER


            }


            layerinfo = new IndexedTextBox(ind);
            this.name = "Layer" + ind;
            // design = new IndexedTextBox(ind);
            */
            selected = false;
            layerinfo.Text = name;
            layerinfo.BorderStyle = BorderStyle.Fixed3D;
            layerinfo.ReadOnly = true;
            layerinfo.BackColor = Color.Gray;


        }





        public static int clickedIndex(object s, EventArgs er, IndexedTextBox t)
        {
            return t.getIndex();
        }
        abstract public void Delete();
        abstract public int getIndex();
        abstract public string getName();
        abstract public IndexedTextBox getLayerInfo();
        abstract public bool isSelected();
        abstract public void toggleSelected();
        

        
        virtual public IndexedTextBox getDesign()
        {
            return null;
        }
        virtual public Element getCode()
        {
            return null;
        }


            
        virtual public void addLi(string tag)
        {

        }

        virtual public void addLi(string tag, TableLayer Ab,    System.Windows.Forms.TextBox input)
        {

        }

        virtual public void deleteLi()
        {

        }

        virtual public Layer getLi()
        {
            return null;
        }

        virtual public Layer getDd()
        {
            return null;
        }

        virtual public int getCurrentLi()
        {
            return 0;
        }

        virtual public void setCurrentLi(int i)
        {

        }

        public virtual string writeHTMLCode()
        {
            return null;
        }

        public virtual System.Windows.Forms.Control getInputDesign()
        {
            return null;
        }

        public virtual IndexedTextBox getLabel()
        {
            return null;
        }

        public virtual void addChoice(string value)
        {

        }

        virtual public InputLayer getChoice()
        {
            return null;
        }

        public virtual void setNoOfChoices(int s)
        {

        }

        public virtual void setCurrentTr(int i)
        {

        }

        public virtual int getCurrentTr()
        {
            return 0;
        }

        public virtual Layer getTr()
        {
            return null;
        }


        public virtual void deleteTr()
        {

        }

        public virtual void addTr()
        {
            
        }

        public virtual System.Windows.Forms.Panel getP()
        {
            return null;
        }

        public virtual IndexedFlowLayout getPanel()
        {
            return null;
        }

        /*public Element getcode()
        {
            return code;
        }
        public IndexedTextBox getdesign()
        {
            return design;
        }*/

        /* public int getInt()
         {

             return index;
         }*/


    }


}
