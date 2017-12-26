namespace PipelineNetwork
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menu_strip = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.confirmChangesButton = new System.Windows.Forms.Button();
            this.adjSplitterGroupBox = new System.Windows.Forms.GroupBox();
            this.adj_splitter_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.adjSplitterTrackBar = new System.Windows.Forms.TrackBar();
            this.pumpSettingsGroupbox = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.curFlowNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxFlowNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxFlowLabel = new System.Windows.Forms.Label();
            this.currentFlowLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.editSettingsButton = new System.Windows.Forms.RadioButton();
            this.removePipeRadioButton = new System.Windows.Forms.RadioButton();
            this.removeComponentRadioButton = new System.Windows.Forms.RadioButton();
            this.MergerPictureBox = new System.Windows.Forms.PictureBox();
            this.Pump_pictureBox = new System.Windows.Forms.PictureBox();
            this.SinkPictureBox = new System.Windows.Forms.PictureBox();
            this.SplitterPictureBox = new System.Windows.Forms.PictureBox();
            this.AdjSplitterPictureBox = new System.Windows.Forms.PictureBox();
            this.Pipe_radioButton = new System.Windows.Forms.RadioButton();
            this.AdjSplitter_radioButton = new System.Windows.Forms.RadioButton();
            this.pump_radioButtion = new System.Windows.Forms.RadioButton();
            this.Splitter_radioButton = new System.Windows.Forms.RadioButton();
            this.Sink_radioButtion = new System.Windows.Forms.RadioButton();
            this.Merger_radioButton = new System.Windows.Forms.RadioButton();
            this.networkGround = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menu_strip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.adjSplitterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adjSplitterTrackBar)).BeginInit();
            this.pumpSettingsGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.curFlowNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFlowNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MergerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pump_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinkPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjSplitterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.networkGround)).BeginInit();
            this.SuspendLayout();
            // 
            // menu_strip
            // 
            this.menu_strip.BackColor = System.Drawing.Color.Gainsboro;
            this.menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menu_strip, "menu_strip");
            this.menu_strip.Name = "menu_strip";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.saveAsProjectToolStripMenuItem,
            this.closeProjectToolStripMenuItem,
            this.exitProgramToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            resources.ApplyResources(this.projectToolStripMenuItem, "projectToolStripMenuItem");
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            resources.ApplyResources(this.newProjectToolStripMenuItem, "newProjectToolStripMenuItem");
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            resources.ApplyResources(this.openProjectToolStripMenuItem, "openProjectToolStripMenuItem");
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            resources.ApplyResources(this.saveProjectToolStripMenuItem, "saveProjectToolStripMenuItem");
            // 
            // saveAsProjectToolStripMenuItem
            // 
            this.saveAsProjectToolStripMenuItem.Name = "saveAsProjectToolStripMenuItem";
            resources.ApplyResources(this.saveAsProjectToolStripMenuItem, "saveAsProjectToolStripMenuItem");
            // 
            // closeProjectToolStripMenuItem
            // 
            this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
            resources.ApplyResources(this.closeProjectToolStripMenuItem, "closeProjectToolStripMenuItem");
            this.closeProjectToolStripMenuItem.Click += new System.EventHandler(this.closeProjectToolStripMenuItem_Click);
            // 
            // exitProgramToolStripMenuItem
            // 
            this.exitProgramToolStripMenuItem.Name = "exitProgramToolStripMenuItem";
            resources.ApplyResources(this.exitProgramToolStripMenuItem, "exitProgramToolStripMenuItem");
            this.exitProgramToolStripMenuItem.Click += new System.EventHandler(this.exitProgramToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.confirmChangesButton);
            this.panel1.Controls.Add(this.adjSplitterGroupBox);
            this.panel1.Controls.Add(this.pumpSettingsGroupbox);
            this.panel1.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // confirmChangesButton
            // 
            resources.ApplyResources(this.confirmChangesButton, "confirmChangesButton");
            this.confirmChangesButton.Name = "confirmChangesButton";
            this.confirmChangesButton.UseVisualStyleBackColor = true;
            this.confirmChangesButton.Click += new System.EventHandler(this.confirmChangesButton_Click);
            // 
            // adjSplitterGroupBox
            // 
            this.adjSplitterGroupBox.BackColor = System.Drawing.Color.Chartreuse;
            this.adjSplitterGroupBox.Controls.Add(this.adj_splitter_textBox);
            this.adjSplitterGroupBox.Controls.Add(this.label3);
            this.adjSplitterGroupBox.Controls.Add(this.label2);
            this.adjSplitterGroupBox.Controls.Add(this.label1);
            this.adjSplitterGroupBox.Controls.Add(this.adjSplitterTrackBar);
            resources.ApplyResources(this.adjSplitterGroupBox, "adjSplitterGroupBox");
            this.adjSplitterGroupBox.Name = "adjSplitterGroupBox";
            this.adjSplitterGroupBox.TabStop = false;
            // 
            // adj_splitter_textBox
            // 
            resources.ApplyResources(this.adj_splitter_textBox, "adj_splitter_textBox");
            this.adj_splitter_textBox.Name = "adj_splitter_textBox";
            this.adj_splitter_textBox.TextChanged += new System.EventHandler(this.adj_splitter_textBox_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // adjSplitterTrackBar
            // 
            this.adjSplitterTrackBar.BackColor = System.Drawing.Color.Yellow;
            resources.ApplyResources(this.adjSplitterTrackBar, "adjSplitterTrackBar");
            this.adjSplitterTrackBar.Maximum = 100;
            this.adjSplitterTrackBar.Name = "adjSplitterTrackBar";
            this.adjSplitterTrackBar.SmallChange = 5;
            this.adjSplitterTrackBar.TickFrequency = 5;
            this.adjSplitterTrackBar.Value = 50;
            this.adjSplitterTrackBar.ValueChanged += new System.EventHandler(this.adjSplitterTrackBar_ValueChanged);
            // 
            // pumpSettingsGroupbox
            // 
            this.pumpSettingsGroupbox.BackColor = System.Drawing.Color.Teal;
            this.pumpSettingsGroupbox.Controls.Add(this.btnSave);
            this.pumpSettingsGroupbox.Controls.Add(this.curFlowNumeric);
            this.pumpSettingsGroupbox.Controls.Add(this.maxFlowNumeric);
            this.pumpSettingsGroupbox.Controls.Add(this.maxFlowLabel);
            this.pumpSettingsGroupbox.Controls.Add(this.currentFlowLabel);
            resources.ApplyResources(this.pumpSettingsGroupbox, "pumpSettingsGroupbox");
            this.pumpSettingsGroupbox.Name = "pumpSettingsGroupbox";
            this.pumpSettingsGroupbox.TabStop = false;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // curFlowNumeric
            // 
            resources.ApplyResources(this.curFlowNumeric, "curFlowNumeric");
            this.curFlowNumeric.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.curFlowNumeric.Name = "curFlowNumeric";
            this.curFlowNumeric.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // maxFlowNumeric
            // 
            resources.ApplyResources(this.maxFlowNumeric, "maxFlowNumeric");
            this.maxFlowNumeric.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.maxFlowNumeric.Name = "maxFlowNumeric";
            this.maxFlowNumeric.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // maxFlowLabel
            // 
            resources.ApplyResources(this.maxFlowLabel, "maxFlowLabel");
            this.maxFlowLabel.Name = "maxFlowLabel";
            // 
            // currentFlowLabel
            // 
            resources.ApplyResources(this.currentFlowLabel, "currentFlowLabel");
            this.currentFlowLabel.Name = "currentFlowLabel";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Controls.Add(this.editSettingsButton);
            this.groupBox1.Controls.Add(this.removePipeRadioButton);
            this.groupBox1.Controls.Add(this.removeComponentRadioButton);
            this.groupBox1.Controls.Add(this.MergerPictureBox);
            this.groupBox1.Controls.Add(this.Pump_pictureBox);
            this.groupBox1.Controls.Add(this.SinkPictureBox);
            this.groupBox1.Controls.Add(this.SplitterPictureBox);
            this.groupBox1.Controls.Add(this.AdjSplitterPictureBox);
            this.groupBox1.Controls.Add(this.Pipe_radioButton);
            this.groupBox1.Controls.Add(this.AdjSplitter_radioButton);
            this.groupBox1.Controls.Add(this.pump_radioButtion);
            this.groupBox1.Controls.Add(this.Splitter_radioButton);
            this.groupBox1.Controls.Add(this.Sink_radioButtion);
            this.groupBox1.Controls.Add(this.Merger_radioButton);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // editSettingsButton
            // 
            resources.ApplyResources(this.editSettingsButton, "editSettingsButton");
            this.editSettingsButton.Name = "editSettingsButton";
            this.editSettingsButton.TabStop = true;
            this.editSettingsButton.UseVisualStyleBackColor = true;
            // 
            // removePipeRadioButton
            // 
            resources.ApplyResources(this.removePipeRadioButton, "removePipeRadioButton");
            this.removePipeRadioButton.Name = "removePipeRadioButton";
            this.removePipeRadioButton.TabStop = true;
            this.removePipeRadioButton.UseVisualStyleBackColor = true;
            // 
            // removeComponentRadioButton
            // 
            resources.ApplyResources(this.removeComponentRadioButton, "removeComponentRadioButton");
            this.removeComponentRadioButton.Name = "removeComponentRadioButton";
            this.removeComponentRadioButton.TabStop = true;
            this.removeComponentRadioButton.UseVisualStyleBackColor = true;
            // 
            // MergerPictureBox
            // 
            resources.ApplyResources(this.MergerPictureBox, "MergerPictureBox");
            this.MergerPictureBox.Name = "MergerPictureBox";
            this.MergerPictureBox.TabStop = false;
            // 
            // Pump_pictureBox
            // 
            resources.ApplyResources(this.Pump_pictureBox, "Pump_pictureBox");
            this.Pump_pictureBox.Name = "Pump_pictureBox";
            this.Pump_pictureBox.TabStop = false;
            // 
            // SinkPictureBox
            // 
            resources.ApplyResources(this.SinkPictureBox, "SinkPictureBox");
            this.SinkPictureBox.Name = "SinkPictureBox";
            this.SinkPictureBox.TabStop = false;
            // 
            // SplitterPictureBox
            // 
            resources.ApplyResources(this.SplitterPictureBox, "SplitterPictureBox");
            this.SplitterPictureBox.Name = "SplitterPictureBox";
            this.SplitterPictureBox.TabStop = false;
            // 
            // AdjSplitterPictureBox
            // 
            resources.ApplyResources(this.AdjSplitterPictureBox, "AdjSplitterPictureBox");
            this.AdjSplitterPictureBox.Name = "AdjSplitterPictureBox";
            this.AdjSplitterPictureBox.TabStop = false;
            // 
            // Pipe_radioButton
            // 
            resources.ApplyResources(this.Pipe_radioButton, "Pipe_radioButton");
            this.Pipe_radioButton.Name = "Pipe_radioButton";
            this.Pipe_radioButton.UseVisualStyleBackColor = true;
            this.Pipe_radioButton.CheckedChanged += new System.EventHandler(this.Pipe_radioButton_CheckedChanged);
            // 
            // AdjSplitter_radioButton
            // 
            resources.ApplyResources(this.AdjSplitter_radioButton, "AdjSplitter_radioButton");
            this.AdjSplitter_radioButton.Name = "AdjSplitter_radioButton";
            this.AdjSplitter_radioButton.UseVisualStyleBackColor = true;
            this.AdjSplitter_radioButton.CheckedChanged += new System.EventHandler(this.AdjSplitter_radioButton_CheckedChanged);
            // 
            // pump_radioButtion
            // 
            resources.ApplyResources(this.pump_radioButtion, "pump_radioButtion");
            this.pump_radioButtion.Checked = true;
            this.pump_radioButtion.Name = "pump_radioButtion";
            this.pump_radioButtion.TabStop = true;
            this.pump_radioButtion.UseVisualStyleBackColor = true;
            this.pump_radioButtion.CheckedChanged += new System.EventHandler(this.pump_radioButtion_CheckedChanged);
            // 
            // Splitter_radioButton
            // 
            resources.ApplyResources(this.Splitter_radioButton, "Splitter_radioButton");
            this.Splitter_radioButton.Name = "Splitter_radioButton";
            this.Splitter_radioButton.UseVisualStyleBackColor = true;
            this.Splitter_radioButton.CheckedChanged += new System.EventHandler(this.Splitter_radioButton_CheckedChanged);
            // 
            // Sink_radioButtion
            // 
            resources.ApplyResources(this.Sink_radioButtion, "Sink_radioButtion");
            this.Sink_radioButtion.Name = "Sink_radioButtion";
            this.Sink_radioButtion.UseVisualStyleBackColor = true;
            this.Sink_radioButtion.CheckedChanged += new System.EventHandler(this.Sink_radioButtion_CheckedChanged);
            // 
            // Merger_radioButton
            // 
            resources.ApplyResources(this.Merger_radioButton, "Merger_radioButton");
            this.Merger_radioButton.Name = "Merger_radioButton";
            this.Merger_radioButton.UseVisualStyleBackColor = true;
            this.Merger_radioButton.CheckedChanged += new System.EventHandler(this.Merger_radioButton_CheckedChanged);
            // 
            // networkGround
            // 
            this.networkGround.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.networkGround, "networkGround");
            this.networkGround.Name = "networkGround";
            this.networkGround.TabStop = false;
            this.networkGround.Click += new System.EventHandler(this.networkGround_Click);
            this.networkGround.Paint += new System.Windows.Forms.PaintEventHandler(this.networkGround_Paint);
            this.networkGround.MouseClick += new System.Windows.Forms.MouseEventHandler(this.networkGround_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Silver;
            this.imageList1.Images.SetKeyName(0, "sink.png");
            this.imageList1.Images.SetKeyName(1, "pump.png");
            this.imageList1.Images.SetKeyName(2, "splitter.png");
            this.imageList1.Images.SetKeyName(3, "Adjustible_splitter_1.png");
            this.imageList1.Images.SetKeyName(4, "Merger.png");
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.networkGround);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu_strip);
            this.MainMenuStrip = this.menu_strip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.menu_strip.ResumeLayout(false);
            this.menu_strip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.adjSplitterGroupBox.ResumeLayout(false);
            this.adjSplitterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adjSplitterTrackBar)).EndInit();
            this.pumpSettingsGroupbox.ResumeLayout(false);
            this.pumpSettingsGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.curFlowNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFlowNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MergerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pump_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinkPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjSplitterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.networkGround)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu_strip;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton Pipe_radioButton;
        private System.Windows.Forms.RadioButton AdjSplitter_radioButton;
        private System.Windows.Forms.RadioButton Splitter_radioButton;
        private System.Windows.Forms.RadioButton Merger_radioButton;
        private System.Windows.Forms.RadioButton Sink_radioButtion;
        private System.Windows.Forms.RadioButton pump_radioButtion;
        private System.Windows.Forms.PictureBox AdjSplitterPictureBox;
        private System.Windows.Forms.PictureBox SplitterPictureBox;
        private System.Windows.Forms.PictureBox MergerPictureBox;
        private System.Windows.Forms.PictureBox SinkPictureBox;
        private System.Windows.Forms.PictureBox Pump_pictureBox;
        private System.Windows.Forms.RadioButton removePipeRadioButton;
        private System.Windows.Forms.RadioButton removeComponentRadioButton;
        private System.Windows.Forms.Label currentFlowLabel;
        private System.Windows.Forms.Label maxFlowLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox pumpSettingsGroupbox;
        private System.Windows.Forms.GroupBox adjSplitterGroupBox;
        private System.Windows.Forms.TrackBar adjSplitterTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox networkGround;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox adj_splitter_textBox;
        private System.Windows.Forms.NumericUpDown curFlowNumeric;
        private System.Windows.Forms.NumericUpDown maxFlowNumeric;
        private System.Windows.Forms.RadioButton editSettingsButton;
        private System.Windows.Forms.Button confirmChangesButton;
        private System.Windows.Forms.Button btnSave;
    }
}

