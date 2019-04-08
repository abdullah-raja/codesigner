using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CoDesigner
{
   

    public partial class Form1 : Form
    {
        static Layer[] layers =new Layer[100];   // creating array of layers
        public static int currentLayer = -1;        // selected layer
        public static int noOfLayers = -1;      
        public static string middleHTML = "";
        public static string htmlOpen = "<!DOCTYPE html>\n<html>\n<head>\n<title>Document</title>\n</head>\n<body>\n\n";
        public static string htmlClose = "\n\n</body>\n</html>";
        public static bool radioTextActive = false;
        public static bool radioValueActive = false;
        public static bool tableInputActive = false;



        public static void selectLayer()
        {
            for(int i = 0; i < layers.Length; i++)
            {
                if (layers[i] == null || i == currentLayer)
                    continue;
                layers[i].getDesign().BorderStyle = BorderStyle.None;
            }
           
            layers[currentLayer].getDesign().BorderStyle = BorderStyle.FixedSingle;
        }




        public void createListLayer(string tag)
        {
            currentLayer = noOfLayers;
            currentLayer++;
            noOfLayers++;

            layers[currentLayer] = new ListLayer(currentLayer, tag);
            DesignCanvas.Controls.Add(layers[currentLayer].getPanel());
            layers[currentLayer].getPanel().FlowDirection = FlowDirection.TopDown;
            layers[currentLayer].getPanel().AutoSize = true;

        }



        public static string writeCompleteHTML()    // combines all the html of the elements and write complete code
        {
            string midHTML = "";
            for(int i = 0; i <= noOfLayers; i++)
            {
                if (layers[i] == null)
                    continue;

                midHTML += "\n" + layers[i].writeHTMLCode();
            }

            return htmlOpen + midHTML + htmlClose;
            
        }
        public Form1()
        {
            InitializeComponent();
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowDialog(object sender, EventArgs e)
        {
            HideDialog(sender, e);
            CreateElement.Visible = true;
           

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NewProject(object sender, EventArgs e)
        {
            DesignCanvas.Visible = true;
            CssCode.Visible = true;
            HtmlCode.Visible = true;
            TextTool.Enabled = true;

        }

        private void HideDialog(object sender, EventArgs e)
        {
            CreateElement.Visible = false;
            

        }

        

        private void CreateTextElement(object sender, EventArgs e)
        {
            currentLayer = noOfLayers;
            currentLayer++;
            noOfLayers++;
            

            

            layers[currentLayer] = new TextLayer(TagType.SelectedItem.ToString(), TagType.SelectedIndex,currentLayer);
            DesignCanvas.Controls.Add(layers[currentLayer].getDesign());
            selectLayer();
           
            //layers[currentLayer].getDesign().BringToFront();

        

            panel1.Controls.Add(layers[currentLayer].getLayerInfo());
            layers[currentLayer].getLayerInfo().Dock = DockStyle.Bottom;
            layers[currentLayer].getLayerInfo().BringToFront();


            HtmlCode.Text = writeCompleteHTML();
            HideDialog(sender, e);

          layers[currentLayer].getDesign().Click += (s, er) =>
            {

                Form1.currentLayer = layers[currentLayer].getDesign().getIndex();
                //  this.selected = design.isSelected();

            };
            

            layers[currentLayer].getDesign().DoubleClick += (s, er) =>
            {

           
                 layers[currentLayer].getDesign().ReadOnly = false;
            };

            



            layers[currentLayer].getDesign().KeyDown += (s, key) =>
            {
                if (key.KeyCode == Keys.Enter)
                {
                    layers[currentLayer].getDesign().ReadOnly = true;

                  
                    this.ActiveControl = DesignCanvas;

                }
            };

            layers[currentLayer].getDesign().TextChanged += (s, e3) =>
            {
                layers[currentLayer].getDesign().Width = 32 * layers[currentLayer].getDesign().Text.Length;
                layers[currentLayer].getCode().getHTML().setValue(layers[currentLayer].getDesign().Text);
                HtmlCode.Text = writeCompleteHTML();
                
               
                
            };
           
            
            


        }

        private void CreateUl(object sender, EventArgs e)
        {
            
            MessageBox.Show("ok");
            
            
            
        }

        private void DesignCanvas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("clicked");
        }

        private void createListElement(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            layers[currentLayer].Delete();
            layers[currentLayer] = null;
            

          
            HtmlCode.Text = writeCompleteHTML();
            noOfLayers--;
            currentLayer = noOfLayers;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
               
            }

        private void toolStripButton2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void DeleteLi(object sender, EventArgs e)
        {
            layers[currentLayer].deleteLi();
            HtmlCode.Text = writeCompleteHTML();
        }

        private void AddDt(object sender, EventArgs e)
        {
            layers[currentLayer].addLi("dt");
            
            IndexedTextBox temp1 = layers[currentLayer].getDd().getDesign(); // will create text box for dd
            IndexedTextBox temp2 = layers[currentLayer].getLi().getDesign(); // will create for dt
            

            temp1.Click += (s, er) =>  // dd click
            {
                //MessageBox.Show(currentLayer.ToString());
                layers[currentLayer].setCurrentLi(temp1.getIndex());


            };

            temp2.Click += (s, er) =>  // dt click
            {
                //MessageBox.Show(currentLayer.ToString());
                layers[currentLayer].setCurrentLi(temp2.getIndex());


            };

            temp1.Text = "Dd#" + layers[currentLayer].getCurrentLi();
            temp2.Text = "Dt#" + layers[currentLayer].getCurrentLi();

            layers[currentLayer].getDd().getCode().getHTML().setValue(temp1.Text);  // setting vlue of dd to text in textbox
            layers[currentLayer].getLi().getCode().getHTML().setValue(temp2.Text); // setting dt

            HtmlCode.Text = writeCompleteHTML();


           /* temp1.Dock = DockStyle.Top;
            temp1.BringToFront();

            temp2.Dock = DockStyle.Top;
            temp2.BringToFront();*/
            temp1.DoubleClick += (s, er) =>
            {

                // MessageBox.Show(currentLayer.ToString());
                temp1.ReadOnly = false;
            };

            temp2.DoubleClick += (s, er) =>
            {

                // MessageBox.Show(currentLayer.ToString());
                temp2.ReadOnly = false;
            };





            temp1.KeyDown += (s, key) =>
            {
                if (key.KeyCode == Keys.Enter)
                {
                    temp1.ReadOnly = true;
                    temp1.Text = temp1.Text;


                    this.ActiveControl = DesignCanvas;

                }
            };

            temp2.KeyDown += (s, key) =>
            {
                if (key.KeyCode == Keys.Enter)
                {
                    temp2.ReadOnly = true;
                    temp2.Text = temp2.Text;


                    this.ActiveControl = DesignCanvas;

                }
            };


            temp1.TextChanged += (s, er3) =>
            {
                Layer tempLayer = layers[currentLayer].getDd();
                tempLayer.getCode().getHTML().setValue(temp1.Text);

                HtmlCode.Text = writeCompleteHTML();




            };

            temp2.TextChanged += (s, er3) =>
            {
                Layer tempLayer = layers[currentLayer].getLi();
                tempLayer.getCode().getHTML().setValue(temp2.Text);

                HtmlCode.Text = writeCompleteHTML();




            };



        }

        private void AddLi(object sender, EventArgs e)
        {
             
            layers[currentLayer].addLi("li");
            IndexedTextBox temp  =layers[currentLayer].getLi().getDesign();

            
            
            temp.Click += (s, er) =>
            {
                //MessageBox.Show(currentLayer.ToString());
                layers[currentLayer].setCurrentLi(temp.getIndex());
                

            };
           // MessageBox.Show(currentLayer.ToString());
            temp.Text = "Li#" + layers[currentLayer].getCurrentLi();
            layers[currentLayer].getLi().getCode().getHTML().setValue(temp.Text);

            



            HtmlCode.Text = writeCompleteHTML();
            //temp.Dock = DockStyle.Top;
            //temp.BringToFront();
            temp.DoubleClick += (s, er) =>
            {

               // MessageBox.Show(currentLayer.ToString());
                temp.ReadOnly = false;
            };





            temp.KeyDown += (s, key) =>
            {
                if (key.KeyCode == Keys.Enter)
                {
                    temp.ReadOnly = true;
                    temp.Text = (char)254 + "\t" + temp.Text;


                    this.ActiveControl = DesignCanvas;

                }
            };

            temp.TextChanged += (s, er3) =>
            {
                Layer tempLayer = layers[currentLayer].getLi();
                tempLayer.getCode().getHTML().setValue(temp.Text);
               
                HtmlCode.Text = writeCompleteHTML();
                



            };

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Ul_Click(object sender, EventArgs e)
        {
            createListLayer("ul");
            
            HtmlCode.Text = writeCompleteHTML();
        }

        private void Ol_Click(object sender, EventArgs e)
        {
            createListLayer("ol");
            HtmlCode.Text = writeCompleteHTML();
        }

        private void Dl_Click(object sender, EventArgs e)
        {
            currentLayer = noOfLayers;
            currentLayer++;
            noOfLayers++;

            layers[currentLayer] = new DefinedListLayer(currentLayer, "dl");
            DesignCanvas.Controls.Add(layers[currentLayer].getPanel());
            layers[currentLayer].getPanel().FlowDirection = FlowDirection.TopDown;
            layers[currentLayer].getPanel().AutoSize = true;
            HtmlCode.Text = writeCompleteHTML();
        }



        protected void click_event(object sender, EventArgs e)
        {
            IndexedTextBox temp = sender as IndexedTextBox;
            MessageBox.Show(currentLayer.ToString());
            layers[currentLayer].setCurrentLi(temp.getIndex());
        }


        private void radio_Click(object sender, EventArgs e)
        {
            form.Visible = true;
          /*  currentLayer = noOfLayers;
            currentLayer++;
            noOfLayers++;




            layers[currentLayer] = new panel("Radio", currentLayer);
            
            DesignCanvas.Controls.Add(layers[currentLayer].getInputDesign());
            layers[currentLayer].getInputDesign().Dock = DockStyle.Left; */
        }

        private void createRadio(object sender, EventArgs e)
        {
            currentLayer = noOfLayers;
            currentLayer++;
            noOfLayers++;

            layers[currentLayer] = new RadioBoxPanel("Radio", currentLayer,"radio");
            DesignCanvas.Controls.Add(layers[currentLayer].getP());
        }



        private void textbox_Click(object sender, EventArgs e)
        {
            currentLayer = noOfLayers;
            currentLayer++;
            noOfLayers++;

            layers[currentLayer] = new InputLayer("input", currentLayer, "text", "firstname");
            //DesignCanvas.Controls.Add(layers[currentLayer].getLabel());
           /* layers[currentLayer].getLabel().Dock = DockStyle.Left;
            layers[currentLayer].getLabel().BringToFront();*/
            DesignCanvas.Controls.Add(layers[currentLayer].getPanel());


            /* DesignCanvas.Controls.Add(layers[currentLayer].getInputDesign());


             layers[currentLayer].getInputDesign().Dock = DockStyle.Top;

             layers[currentLayer].getInputDesign().BringToFront();*/
            layers[currentLayer].getInputDesign().Width = 300;
            HtmlCode.Text = writeCompleteHTML();

            IndexedTextBox tempLabel = layers[currentLayer].getLabel();
            tempLabel.DoubleClick += (s, er) =>
            {
                tempLabel.ReadOnly = false;
            };

            tempLabel.KeyDown += (s, key) =>
            {
                if (key.KeyCode == Keys.Enter)
                {
                    tempLabel.ReadOnly = true;
                    


                    this.ActiveControl = DesignCanvas;

                }
            };

            tempLabel.TextChanged += (s, er3) =>
            {
                layers[currentLayer].getLabel().Width = 15 * layers[currentLayer].getLabel().Text.Length;
                layers[currentLayer].getCode().getHTML().setValue(tempLabel.Text);
                HtmlCode.Text = writeCompleteHTML();

                
            };


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (inputName.Text == "")
            {
                MessageBox.Show("Please Enter Name");
            }

            else
            {

                Panel p = new Panel();
                form.Visible = false;
                DesignCanvas.Controls.Add(p);
                p.Size = new Size(350, 250);
                p.Location = new Point(150, 80);
                p.BackColor = Color.FromArgb(40, 40, 40);
                p.ForeColor = Color.White;
                p.Font = new Font("Microsoft Sans Serif", 11);
                p.AutoScroll = true;

                TextBox[] textInputs = new TextBox[(int)choices.Value];
                TextBox[] valueInputs = new TextBox[(int)choices.Value];

                for (int i = 0; i < choices.Value; i++)
                {
                    int y = 18;
                    int offset = 10;
                    Label textLabel = new Label();
                    textLabel.Location = new Point(16, (i + 1) * (y + offset));
                    textLabel.AutoSize = true;
                    textLabel.Anchor = AnchorStyles.Left;

                    TextBox text = new TextBox();
                    text.Location = new Point(60, (i + 1) * (y + offset));
                    text.BorderStyle = BorderStyle.None;
                    text.BackColor = Color.White;
                    text.ForeColor = Color.Black;
                    text.ReadOnly = false;
                    textInputs[i] = text;


                    Label valueLabel = new Label();
                    valueLabel.Location = new Point(166, (i + 1) * (y + offset));
                    valueLabel.AutoSize = true;
                    valueLabel.Anchor = AnchorStyles.Left;





                    TextBox value = new TextBox();
                    value.Location = new Point(215, (i + 1) * (y + offset));
                    value.BorderStyle = BorderStyle.None;
                    value.BackColor = Color.White;
                    value.ReadOnly = false;
                    valueInputs[i] = value;

                    textLabel.Text = "Text #" + (i + 1) + ": ";
                    valueLabel.Text = "Value #" + (i + 1) + ": ";

                    p.Controls.Add(textLabel);
                    p.Controls.Add(text);
                    p.Controls.Add(valueLabel);
                    p.Controls.Add(value);




                }

                Button Ok = new Button();
                Button Cancel = new Button();
                Ok.BackColor = Color.FromArgb(40, 40, 40);
                Ok.Text = "OK";
                Ok.Location = new Point(50, 200);
                Ok.Size = new Size(116, 34);
                Ok.FlatStyle = FlatStyle.Flat;
                //Ok.Click += new EventHandler(createRadio);
                Ok.Click += (s, err) =>
                {

                    currentLayer = noOfLayers;
                    currentLayer++;
                    noOfLayers++;

                    if (radiobutton.Checked)
                        layers[currentLayer] = new RadioBoxPanel(inputName.Text, currentLayer, "radio");

                    if (check.Checked)
                        layers[currentLayer] = new RadioBoxPanel(inputName.Text, currentLayer, "checkbox");
                    DesignCanvas.Controls.Add(layers[currentLayer].getPanel());
                    p.Visible = false;
                //  layers[currentLayer].setNoOfChoices((int)choices.Value);
                for (int i = 0; i < textInputs.Length; i++)
                    {
                        layers[currentLayer].addChoice(valueInputs[i].Text);
                       // layers[currentLayer].getP().Controls.Add(layers[currentLayer].getChoice().getInputDesign());
                        layers[currentLayer].getChoice().getInputDesign().Text = textInputs[i].Text;
                        layers[currentLayer].getChoice().getInputDesign().Dock = DockStyle.Top;
                        layers[currentLayer].getChoice().getInputDesign().BringToFront();
                        layers[currentLayer].getChoice().getCode().getHTML().setValue(textInputs[i].Text);




                        if (radiobutton.Checked)
                        {
                            IndexedRadioButton temp = (IndexedRadioButton)layers[currentLayer].getChoice().getInputDesign();



                            temp.Click += (sr, er) =>
                            {
                                layers[currentLayer].setCurrentLi(temp.getIndex());
                            // layers[currentLayer].setCurrentLi(1);
                            // MessageBox.Show(layers[currentLayer].getChoice().getCode().getHTML().getValue());
                            RadioText.Text = layers[currentLayer].getChoice().getCode().getHTML().getValue();
                                radioValue.Text = layers[currentLayer].getChoice().getCode().getHTML().getAttributeList().getAttributes()["value"];
                            };

                        }

                        if (check.Checked)
                        {
                            IndexedCheckBox temp = (IndexedCheckBox)layers[currentLayer].getChoice().getInputDesign();



                            temp.Click += (sr, er) =>
                            {
                                layers[currentLayer].setCurrentLi(temp.getIndex());
                            // layers[currentLayer].setCurrentLi(1);
                            // MessageBox.Show(layers[currentLayer].getChoice().getCode().getHTML().getValue());
                            RadioText.Text = layers[currentLayer].getChoice().getCode().getHTML().getValue();
                                radioValue.Text = layers[currentLayer].getChoice().getCode().getHTML().getAttributeList().getAttributes()["value"];
                            };
                        }
                        HtmlCode.Text = writeCompleteHTML();
                    }




                };






                Cancel.BackColor = Color.FromArgb(40, 40, 40);
                Cancel.Text = "Cancel";
                Cancel.Location = new Point(180, 200);
                Cancel.Size = new Size(116, 34);
                Cancel.FlatStyle = FlatStyle.Flat;

                Cancel.Click += (s, er) =>
                {
                    form.Visible = true;
                    p.Visible = false;
                };


                p.Controls.Add(Ok);
                p.Controls.Add(Cancel);

            }
        }

        private void RadioText_TextChanged(object sender, EventArgs e)
        {
            if (radioTextActive)
            {
                layers[currentLayer].getChoice().getCode().getHTML().setValue(RadioText.Text);
                layers[currentLayer].getChoice().getInputDesign().Text = RadioText.Text;
                HtmlCode.Text = writeCompleteHTML();
            }
        }

        private void RadioText_Enter(object sender, EventArgs e)
        {
            radioTextActive = true;
        }

        private void RadioText_Leave(object sender, EventArgs e)
        {
            radioTextActive = false;
        }

        private void radioValue_TextChanged(object sender, EventArgs e)
        {
            if (radioValueActive)
            {
                
                layers[currentLayer].getChoice().getCode().getHTML().getAttributeList().getAttributes()["value"] = radioValue.Text;
                layers[currentLayer].getChoice().getCode().getHTML().getAttributeList().updateAttributeString();
                HtmlCode.Text = writeCompleteHTML();
            }
        }

        private void radioValue_Enter(object sender, EventArgs e)
        {
            radioValueActive = true;
        }

        private void radioValue_Leave(object sender, EventArgs e)
        {
            radioValueActive = false;
        }

        private void AddChoiceOk_Click(object sender, EventArgs e)
        {
            AddValueDialog.Visible = false;
            layers[currentLayer].addChoice(AddChoiceValue.Text);
           // layers[currentLayer].getP().Controls.Add(layers[currentLayer].getChoice().getInputDesign());
            layers[currentLayer].getChoice().getInputDesign().Text = AddChoiceText.Text;
            layers[currentLayer].getChoice().getInputDesign().Dock = DockStyle.Top;
            layers[currentLayer].getChoice().getInputDesign().BringToFront();
            layers[currentLayer].getChoice().getCode().getHTML().setValue(AddChoiceText.Text);

            if (layers[currentLayer].getChoice().getInputDesign() is IndexedRadioButton)
            {
                IndexedRadioButton temp = (IndexedRadioButton)layers[currentLayer].getChoice().getInputDesign();



                temp.Click += (sr, er) =>
                {
                    layers[currentLayer].setCurrentLi(temp.getIndex());
                    // layers[currentLayer].setCurrentLi(1);
                    // MessageBox.Show(layers[currentLayer].getChoice().getCode().getHTML().getValue());
                    RadioText.Text = layers[currentLayer].getChoice().getCode().getHTML().getValue();
                    radioValue.Text = layers[currentLayer].getChoice().getCode().getHTML().getAttributeList().getAttributes()["value"];
                };

            }

            if (layers[currentLayer].getChoice().getInputDesign() is IndexedCheckBox)
            {
                IndexedCheckBox temp = (IndexedCheckBox)layers[currentLayer].getChoice().getInputDesign();



                temp.Click += (sr, er) =>
                {
                    layers[currentLayer].setCurrentLi(temp.getIndex());
                    // layers[currentLayer].setCurrentLi(1);
                    // MessageBox.Show(layers[currentLayer].getChoice().getCode().getHTML().getValue());
                    RadioText.Text = layers[currentLayer].getChoice().getCode().getHTML().getValue();
                    radioValue.Text = layers[currentLayer].getChoice().getCode().getHTML().getAttributeList().getAttributes()["value"];
                };
            }
            HtmlCode.Text = writeCompleteHTML();
        }

        private void AddChoice_Click(object sender, EventArgs e)
        {
            AddValueDialog.Visible = true;
        }

        private void addChoiceCancel_Click(object sender, EventArgs e)
        {
            AddValueDialog.Visible = false;
        }

        private void CreateTableOk_Click(object sender, EventArgs e)
        {
            TextBox[,] tableInputs = new TextBox[(int)NoOfRows.Value, (int)NoOfCol.Value];
            CreateTableDialog.Visible = false;
            FlowLayoutPanel mainPanel = new FlowLayoutPanel();
            mainPanel.FlowDirection = FlowDirection.TopDown;
            DesignCanvas.Controls.Add(mainPanel);
            mainPanel.Location = new Point(100, 100);
               
            mainPanel.AutoSize = true;
            mainPanel.BackColor = Color.FromArgb(40, 40, 40);
            mainPanel.ForeColor = Color.White;

            FlowLayoutPanel headingsPanel = new FlowLayoutPanel();
            headingsPanel.FlowDirection = FlowDirection.LeftToRight;
            headingsPanel.AutoSize = true;
            headingsPanel.AutoScroll = true;

            
            for(int i = 0; i < NoOfCol.Value; i++)
            {
                Label headings = new Label();
                headings.Width = 100;
                headings.Text = "<td>";
                headings.TextAlign = ContentAlignment.MiddleCenter;
                headingsPanel.Controls.Add(headings);

            }
           mainPanel.Controls.Add(headingsPanel);

            for (int i = 0; i < NoOfRows.Value; i++)
            {
                FlowLayoutPanel innerPanel = new FlowLayoutPanel();
                innerPanel.FlowDirection = FlowDirection.LeftToRight;
                innerPanel.AutoSize = true;

                for(int j = 0; j < NoOfCol.Value; j++)
                {
                    tableInputs[i,j] = new TextBox();
                    innerPanel.Controls.Add(tableInputs[i, j]);

                }

                mainPanel.Controls.Add(innerPanel);
            }

            FlowLayoutPanel buttons = new FlowLayoutPanel();
            buttons.FlowDirection = FlowDirection.LeftToRight;
            buttons.AutoSize = true;

            Button Ok = new Button();
            Ok.BackColor = Color.FromArgb(40, 40, 40);
            Ok.Text = "OK";
            Ok.Location = new Point(50, 200);
            Ok.Size = new Size(116, 34);
            Ok.FlatStyle = FlatStyle.Flat;
            Ok.Click += (s, er) =>
            {
                mainPanel.Visible = false;
                currentLayer = noOfLayers;
                currentLayer++;
                noOfLayers++;

                layers[currentLayer] = new TableLayer(currentLayer, "table");
                for (int i = 0; i < NoOfRows.Value; i++)
                {
                    layers[currentLayer].addTr();
                    
                    for (int j = 0; j < NoOfCol.Value; j++)
                    {
                        layers[currentLayer].getTr().addLi("td",(TableLayer)layers[currentLayer],TableTextInput);
                        layers[currentLayer].getTr().getLi().getDesign().Text = tableInputs[i, j].Text;
                        layers[currentLayer].getTr().getLi().getCode().getHTML().setValue(tableInputs[i, j].Text);
                        layers[currentLayer].getTr().getLi().getDesign().Font = new Font("Times New Roman", 16);
                        layers[currentLayer].getTr().getLi().getDesign().Width = 15 * layers[currentLayer].getTr().getLi().getDesign().Text.Length;
                        

                    }
                }
                /*layers[currentLayer].getTr().getPanel().Click += (s4, er4) => {

                    layers[currentLayer].setCurrentTr(layers[currentLayer].getPanel().getIndex());
                    MessageBox.Show(layers[currentLayer].getCurrentTr().ToString());

                };*/
                DesignCanvas.Controls.Add(layers[currentLayer].getPanel());
              
                HtmlCode.Text = writeCompleteHTML();
                mainPanel.Dispose();
            };

            Button Back = new Button();
            Back.BackColor = Color.FromArgb(40, 40, 40);
            Back.Text = "BACK";
            //Ok.Location = new Point(150, 200);
            Back.Size = new Size(116, 34);
            Back.FlatStyle = FlatStyle.Flat;
            Back.Click += (s, er) =>
            {
                mainPanel.Visible = false;
                CreateTableDialog.Visible = true;

            };

            buttons.Controls.Add(Ok);
            buttons.Controls.Add(Back);

            mainPanel.Controls.Add(buttons);

        }

        private void TableInput_TextChanged(object sender, EventArgs e)
        {
            if (tableInputActive)
            {
                layers[currentLayer].getTr().getLi().getDesign().Width = 15 * layers[currentLayer].getTr().getLi().getDesign().Text.Length;
                layers[currentLayer].getTr().getLi().getCode().getHTML().setValue(layers[currentLayer].getTr().getLi().getDesign().Text);
                layers[currentLayer].getTr().getLi().getDesign().Text = TableTextInput.Text;
                HtmlCode.Text = writeCompleteHTML();
            }
        }

        private void TableInput_Enter(object sender, EventArgs e)
        {
            tableInputActive = true;
        }

        private void TableInput_Leave(object sender, EventArgs e)
        {
            tableInputActive = false;
        }

        

        private void Createtable_Click(object sender, EventArgs e)
        {
            CreateTableDialog.Visible = true;
           
        }

        private void addRow_Click(object sender, EventArgs e)
        {
            TextBox[] columnInputs = new TextBox[(int)NoOfCol.Value];
            FlowLayoutPanel mainPanel = new FlowLayoutPanel();
            mainPanel.FlowDirection = FlowDirection.TopDown;
            DesignCanvas.Controls.Add(mainPanel);
            mainPanel.Location = new Point(100, 100);
            mainPanel.AutoSize = true;
            mainPanel.BackColor = Color.FromArgb(40, 40, 40);
            mainPanel.ForeColor = Color.White;


            FlowLayoutPanel innerPanel = new FlowLayoutPanel();
            innerPanel.FlowDirection = FlowDirection.LeftToRight;
            innerPanel.AutoSize = true;

            for (int j = 0; j < NoOfCol.Value; j++)
            {
                columnInputs[j] = new TextBox();
                innerPanel.Controls.Add(columnInputs[j]);

            }

            mainPanel.Controls.Add(innerPanel);

            FlowLayoutPanel buttons = new FlowLayoutPanel();
            buttons.FlowDirection = FlowDirection.LeftToRight;
            buttons.AutoSize = true;

            Button Ok = new Button();
            Ok.BackColor = Color.FromArgb(40, 40, 40);
            Ok.Text = "OK";
            Ok.Location = new Point(50, 200);
            Ok.Size = new Size(116, 34);
            Ok.FlatStyle = FlatStyle.Flat;
            Ok.Click += (s, er) =>
            {
                mainPanel.Visible = false;
                
                
                    layers[currentLayer].addTr();

                    for (int j = 0; j < NoOfCol.Value; j++)
                    {
                        layers[currentLayer].getTr().addLi("td", (TableLayer)layers[currentLayer], TableTextInput);
                        layers[currentLayer].getTr().getLi().getDesign().Text = columnInputs[j].Text;
                        layers[currentLayer].getTr().getLi().getCode().getHTML().setValue(columnInputs[j].Text);
                        layers[currentLayer].getTr().getLi().getDesign().Font = new Font("Times New Roman", 16);
                        layers[currentLayer].getTr().getLi().getDesign().Width = 15 * layers[currentLayer].getTr().getLi().getDesign().Text.Length;
                        

                    }
                
                
                DesignCanvas.Controls.Add(layers[currentLayer].getPanel());
                layers[currentLayer].getPanel().Dock = DockStyle.Top;
                layers[currentLayer].getPanel().BringToFront();
                HtmlCode.Text = writeCompleteHTML();
                mainPanel.Dispose();
            };

            Button Back = new Button();
            Back.BackColor = Color.FromArgb(40, 40, 40);
            Back.Text = "BACK";
            //Ok.Location = new Point(150, 200);
            Back.Size = new Size(116, 34);
            Back.FlatStyle = FlatStyle.Flat;
            Back.Click += (s, er) =>
            {
                mainPanel.Visible = false;
                CreateTableDialog.Visible = true;

            };

            buttons.Controls.Add(Ok);
            buttons.Controls.Add(Back);

            mainPanel.Controls.Add(buttons);

        }

        private void deleteRow_Click(object sender, EventArgs e)
        {
            layers[currentLayer].deleteTr();
            HtmlCode.Text = writeCompleteHTML();
        }

        private void saveHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, HtmlCode.Text);
            }
        }

        private void saveAndRunHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, HtmlCode.Text);
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
            }
        }


    }





    




    
}
