using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PipelineNetwork
{
    public partial class Form1 : Form
    {
        Network network;
        Component[] tempArr;
        Component temporary;
        int compA = 0;
        int compB = 0;
        public Form1()
        {
            InitializeComponent();
            network = new Network();
            WindowState = FormWindowState.Maximized;
            // this size has to be optimized - for now does not matter :D
            networkGround.ClientSize  = new Size(MaximumSize.Width, MaximumSize.Height);
            pumpSettingsGroupbox.Enabled = false;
            adjSplitterGroupBox.Enabled = false;
            tempArr = new Component[2];
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Pipe_radioButton_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void AdjSplitter_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AdjSplitter_radioButton.Checked == true)
            {
                adjSplitterGroupBox.Enabled = true;
            }
            else
            {
                adjSplitterGroupBox.Enabled = false;
            }
        }

        private void Splitter_radioButton_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Merger_radioButton_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Sink_radioButtion_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void networkGround_Click(object sender, EventArgs e)
        {    
        }

        private void networkGround_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            network.DrawAllComponents(gr, imageList1);
            network.DrawAllPipelines(gr);
        }

        private void networkGround_MouseClick(object sender, MouseEventArgs e)
        {
            //sugestion to do removing the component by right clicking that.
            RadioButton radiobutton = new RadioButton();
            Component temp;
            int x = e.X;
            int y = e.Y;
            
            if(removeComponentRadioButton.Checked == true)
            {
                temp = network.GetComponent(x, y, imageList1.ImageSize.Width);
                if (temp != null)
                {
                    temp.Pressed = true;
                    networkGround.Invalidate();
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this component?", "Deleting a component", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (network.DeleteComponent(temp))
                        {
                            networkGround.Invalidate();
                        }
                    }
                    else
                    {
                        temp.Pressed = false;
                        networkGround.Invalidate();
                    }
                }
            }
            else if (removePipeRadioButton.Checked == true)
            {
                Component pipestoberemoved = network.GetComponent(x, y, imageList1.ImageSize.Width); //For Pumps and mergers 0 position is for output for Sinks and splitters 0 position is for input,
                Component neighbor = null;                                                           //For Merger input top is 1 and input bot is 2
                                                                                                    //For Splitter output top is 1 and output bot is 2
                if (pipestoberemoved != null)
                {
                    if (pipestoberemoved is Pump || pipestoberemoved is Sink)
                    {
                        neighbor = pipestoberemoved.PipesConnected[0];
                        network.RemoveConnection(pipestoberemoved, neighbor);
                        networkGround.Invalidate();
                    }
                    else if(pipestoberemoved is Merger)
                    {
                        if (pipestoberemoved.Y - 10 < y && x < pipestoberemoved.X)
                        {
                            neighbor = pipestoberemoved.PipesConnected[2];
                        }
                        else if (pipestoberemoved.Y > y && x < pipestoberemoved.X)
                        {
                            neighbor = pipestoberemoved.PipesConnected[1];
                        }
                        else if(x > pipestoberemoved.X)
                        {
                            neighbor = pipestoberemoved.PipesConnected[0];
                        }
                        network.RemoveConnection(pipestoberemoved, neighbor);
                        networkGround.Invalidate();
                    }
                    else if(pipestoberemoved is Splitter)
                    {
                        if (pipestoberemoved.Y - 10 < y && x > pipestoberemoved.X)
                        {
                            neighbor = pipestoberemoved.PipesConnected[2];
                        }
                        else if (pipestoberemoved.Y > y && x > pipestoberemoved.X)
                        {
                            neighbor = pipestoberemoved.PipesConnected[1];
                        }
                        else if (x < pipestoberemoved.X)
                        {
                            neighbor = pipestoberemoved.PipesConnected[0];
                        }
                        network.RemoveConnection(pipestoberemoved, neighbor);
                        networkGround.Invalidate();
                    }
                }
                else
                {
                    MessageBox.Show("Click on an input or an output on drawn component");
                }
            }
            else if(Pipe_radioButton.Checked == true)
            {
                
                if (tempArr[0] == null)
                {
                    tempArr[0] = network.GetComponent(x, y, imageList1.ImageSize.Width);

                    if (tempArr[0] != null)
                    {
                        if (tempArr[0].Y-10 > y)
                    {
                        compA = 0;
                    }
                    else
                    {
                        compA = 1;
                    }}
                }
                else
                {
                    tempArr[1] = network.GetComponent(x, y, imageList1.ImageSize.Width);
                    if (tempArr[1] != null)
                    {
                        if (tempArr[1].Y-10 > y)
                        {
                            compB = 0;
                        }
                        else
                        {
                            compB = 1;
                        }
                    }
                }

                if (tempArr[0] != null && tempArr[1] != null)
                {
                    if (tempArr[0] != tempArr[1])
                    {
                        if(network.AddPipeline(tempArr[0], tempArr[1], compA, compB))
                        {
                            
                        }
                        else
                        {
                            MessageBox.Show("Click on 2 differnt free output and or inputs on 2 different drawn components");
                            tempArr = new Component[2];
                        }
                    }
                    tempArr = new Component[2];
                    networkGround.Invalidate();
                }
            }
            else if (editSettingsButton.Checked == true)
            {
                temp = network.GetComponent(x, y, imageList1.ImageSize.Width);
                if (temp != null)
                {
                    if (temp is Pump)
                    {
                        temp.Pressed = true;
                        temporary = temp;
                        pumpSettingsGroupbox.Enabled = true;
                        networkGround.Invalidate();
                    }
                }
                else
                {
                    MessageBox.Show("You have not chosen any element!", "No element selected", MessageBoxButtons.OK);

                }
            }
            else
            {
                temp = network.GetComponent(x, y, imageList1.ImageSize.Width *2);
                if (temp != null)
                {
                        MessageBox.Show("This place is occupied by other element! Please, choose other one!", "Bad move", MessageBoxButtons.OK);
                }
                else if ( x- imageList1.ImageSize.Width/2 < 0 || x + imageList1.ImageSize.Width > networkGround.ClientRectangle.Right - networkGround.Location.X|| y- imageList1.ImageSize.Width< 0 || y + imageList1.ImageSize.Width> networkGround.ClientRectangle.Bottom - networkGround.Location.Y)
                {
                    MessageBox.Show("The element cannot exceed the borders of the Canvas  area!", "Bad move", MessageBoxButtons.OK);

                }
                else
                {
                    AddTheProperElement(x, y);
                } 
            }
            Invalidate();
        }
        void AddTheProperElement(int x, int y)
        {
            if (pump_radioButtion.Checked == true)
            {
                    pumpSettingsGroupbox.Enabled = true;
   
                int max_flow = Decimal.ToInt32(maxFlowNumeric.Value);
                int cur_flow = Decimal.ToInt32(curFlowNumeric.Value);
                if (cur_flow <= max_flow)
                {
                    network.AddComponent(new Pump(null,max_flow, cur_flow, x, y));
                }
                else
                {
                    MessageBox.Show("Current flow cannot be greater than maximum one!", "Wrong flows input!", MessageBoxButtons.OK);
                }
            }
            else if (Sink_radioButtion.Checked == true)
            {
                network.AddComponent(new Sink(null, 0, x, y));
            }
            else if (Merger_radioButton.Checked == true)
            {
                network.AddComponent(new Merger(null, null, null,0, x, y));
            }
            else if (Splitter_radioButton.Checked == true)
            {
                network.AddComponent(new Splitter(null, null, null, 0, x, y));
            }
            else if (AdjSplitter_radioButton.Checked == true)
            {
                int proportion = adjSplitterTrackBar.Value;
                network.AddComponent(new AdjustableSplitter(0, 0, proportion, null, null, null, 100, x, y));
            }
            else
            {
                MessageBox.Show("Something went wrong! You did not choose the component!","ERROR", MessageBoxButtons.OK);
            }
            networkGround.Invalidate();
        }

        private void adjSplitterTrackBar_ValueChanged(object sender, EventArgs e)
        {
            adj_splitter_textBox.Text = adjSplitterTrackBar.Value.ToString();
        }

        private void adj_splitter_textBox_TextChanged(object sender, EventArgs e)
        {
            int value;
            if(int.TryParse(adj_splitter_textBox.Text, out value))
            {
                if (value < 0)
                {
                    MessageBox.Show("Adjustable Splitter cannot be set below 0!", "Bad value!", MessageBoxButtons.OK);
                    adj_splitter_textBox.Text = "0";
                }
                else if (value > 100)
                {
                    MessageBox.Show("Adjustable Splitter cannot be set above 100!", "Bad value!", MessageBoxButtons.OK);
                    adj_splitter_textBox.Text = "100";
                }
                else
                {
                    adjSplitterTrackBar.Value = value;
                }
            }
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(" Are you sure you want to create new project? All unsaved work will be lost!", " Are you sure?", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                network.RemoveAllComponents();
                networkGround.Invalidate();
            }
           
        }

        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(" Are you sure you want to close this project? All unsaved work will be lost!", " Are you sure?", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                network.RemoveAllComponents();
                networkGround.Invalidate();
            }

        }

        private void exitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(" Do you want to exit programme? ", " Are you sure?", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutWindow = new AboutBox1();
            aboutWindow.ShowDialog();
        }

        private void pump_radioButtion_CheckedChanged(object sender, EventArgs e)
        {
            
            if (pump_radioButtion.Checked == true)
            {
                pumpSettingsGroupbox.Enabled = true;
            }
            else
            {
                pumpSettingsGroupbox.Enabled = false;
            }
        }

        private void confirmChangesButton_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)// NOT ON A BUTTON BUT ON A RADIOBUTTON PERHAPS
        {
            pumpSettingsGroupbox.Enabled = false;
            temporary.Pressed = false;
            
            int max_flow = Decimal.ToInt32(maxFlowNumeric.Value);
            int cur_flow = Decimal.ToInt32(curFlowNumeric.Value);
            network.ChangePumpFlow(temporary as Pump, max_flow, cur_flow);
            network.Recalc(temporary);
            temporary = null;
            networkGround.Invalidate();
        }

      


    }
}
