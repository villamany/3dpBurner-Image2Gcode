﻿/*  3dpBurner Image2Gcode. A Image to GCODE converter for GRBL based devices.
    This file is part of 3dpBurner Image2Gcode application.
   
    Copyright (C) 2015  Adrian V. J. (villamany) contact: villamany@gmail.com
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
//Form 1 (Main form design)

namespace WindowsFormsApplication1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.cbEngravingPattern = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblFeedRateUnits = new System.Windows.Forms.Label();
            this.tbFeedRate = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbUseS = new System.Windows.Forms.RadioButton();
            this.rbUseZ = new System.Windows.Forms.RadioButton();
            this.cbEdgeLines = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbPostGcode = new System.Windows.Forms.RichTextBox();
            this.rtbPreGcode = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.tbLaserMax = new System.Windows.Forms.TextBox();
            this.tbLaserMin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbDirthering = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblGamma = new System.Windows.Forms.Label();
            this.tBarGamma = new System.Windows.Forms.TrackBar();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.tBarBrightness = new System.Windows.Forms.TrackBar();
            this.lblContrast = new System.Windows.Forms.Label();
            this.tBarContrast = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnInvert = new System.Windows.Forms.Button();
            this.btnRotateLeft = new System.Windows.Forms.Button();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.btnVertMirror = new System.Windows.Forms.Button();
            this.btnHorizMirror = new System.Windows.Forms.Button();
            this.gbDimensions = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbRes = new System.Windows.Forms.TextBox();
            this.cbLockRatio = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.btnCheckOrig = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metricmmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imperialinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarContrast)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.gbDimensions.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp)| *.jpg; *.jpeg; *.jpe; *" +
    ".jfif; *.png; *.bmp|All files(*.*)|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "file.nc";
            this.saveFileDialog1.Filter = "G-Code Files(*.CNC;*.NC;*.TAP;*.TXT)|*.CNC;*.NC;*.TAP;*.TXT|All files (*.*)|*.*";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(118, 15);
            this.lblStatus.Text = "toolStripStatusLabel1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 476);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(649, 20);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.cbEngravingPattern);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.cbEdgeLines);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.rtbPostGcode);
            this.tabPage2.Controls.Add(this.rtbPreGcode);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.btnGenerate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(191, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "GCODE";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1, 316);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Engraving pattern";
            // 
            // cbEngravingPattern
            // 
            this.cbEngravingPattern.FormattingEnabled = true;
            this.cbEngravingPattern.Items.AddRange(new object[] {
            "Horizontal scanning",
            "Diagonal scanning"});
            this.cbEngravingPattern.Location = new System.Drawing.Point(1, 332);
            this.cbEngravingPattern.Name = "cbEngravingPattern";
            this.cbEngravingPattern.Size = new System.Drawing.Size(187, 21);
            this.cbEngravingPattern.TabIndex = 4;
            this.cbEngravingPattern.Text = "Horizontal scanning";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblFeedRateUnits);
            this.groupBox3.Controls.Add(this.tbFeedRate);
            this.groupBox3.Location = new System.Drawing.Point(1, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 56);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Feedrate";
            // 
            // lblFeedRateUnits
            // 
            this.lblFeedRateUnits.AutoSize = true;
            this.lblFeedRateUnits.Location = new System.Drawing.Point(53, 26);
            this.lblFeedRateUnits.Name = "lblFeedRateUnits";
            this.lblFeedRateUnits.Size = new System.Drawing.Size(44, 13);
            this.lblFeedRateUnits.TabIndex = 19;
            this.lblFeedRateUnits.Text = "mm/min";
            // 
            // tbFeedRate
            // 
            this.tbFeedRate.Location = new System.Drawing.Point(11, 23);
            this.tbFeedRate.Name = "tbFeedRate";
            this.tbFeedRate.Size = new System.Drawing.Size(36, 20);
            this.tbFeedRate.TabIndex = 2;
            this.tbFeedRate.Text = "1000";
            this.tbFeedRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFeedRate_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbUseS);
            this.groupBox2.Controls.Add(this.rbUseZ);
            this.groupBox2.Location = new System.Drawing.Point(1, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 41);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Laser power command";
            // 
            // rbUseS
            // 
            this.rbUseS.AutoSize = true;
            this.rbUseS.Checked = true;
            this.rbUseS.Location = new System.Drawing.Point(21, 16);
            this.rbUseS.Name = "rbUseS";
            this.rbUseS.Size = new System.Drawing.Size(58, 17);
            this.rbUseS.TabIndex = 2;
            this.rbUseS.TabStop = true;
            this.rbUseS.Text = "Use \'S\'";
            this.rbUseS.UseVisualStyleBackColor = true;
            // 
            // rbUseZ
            // 
            this.rbUseZ.AutoSize = true;
            this.rbUseZ.Location = new System.Drawing.Point(117, 16);
            this.rbUseZ.Name = "rbUseZ";
            this.rbUseZ.Size = new System.Drawing.Size(58, 17);
            this.rbUseZ.TabIndex = 2;
            this.rbUseZ.Text = "Use \'Z\'";
            this.rbUseZ.UseVisualStyleBackColor = true;
            // 
            // cbEdgeLines
            // 
            this.cbEdgeLines.AutoSize = true;
            this.cbEdgeLines.Checked = true;
            this.cbEdgeLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEdgeLines.Location = new System.Drawing.Point(39, 361);
            this.cbEdgeLines.Name = "cbEdgeLines";
            this.cbEdgeLines.Size = new System.Drawing.Size(112, 17);
            this.cbEdgeLines.TabIndex = 5;
            this.cbEdgeLines.Text = "Engrave edge line";
            this.cbEdgeLines.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gcode Footer";
            // 
            // rtbPostGcode
            // 
            this.rtbPostGcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbPostGcode.Location = new System.Drawing.Point(1, 121);
            this.rtbPostGcode.Name = "rtbPostGcode";
            this.rtbPostGcode.Size = new System.Drawing.Size(187, 83);
            this.rtbPostGcode.TabIndex = 1;
            this.rtbPostGcode.Text = "(Footer)\nG0 X0 Y0\n(Footer end)";
            this.rtbPostGcode.WordWrap = false;
            // 
            // rtbPreGcode
            // 
            this.rtbPreGcode.Location = new System.Drawing.Point(1, 20);
            this.rtbPreGcode.Name = "rtbPreGcode";
            this.rtbPreGcode.Size = new System.Drawing.Size(187, 83);
            this.rtbPreGcode.TabIndex = 0;
            this.rtbPreGcode.Text = "(Header)\nG0 X0 Y0\n(Header end)";
            this.rtbPreGcode.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gcode Header";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(30, 386);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(133, 23);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate file...";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.tbLaserMax);
            this.tabPage3.Controls.Add(this.tbLaserMin);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(191, 422);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Laser profile";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(184, 66);
            this.label10.TabIndex = 30;
            this.label10.Text = "GrayScale values (0-255) will be interpolated between Min and Max Power Values.";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // tbLaserMax
            // 
            this.tbLaserMax.Location = new System.Drawing.Point(6, 84);
            this.tbLaserMax.Name = "tbLaserMax";
            this.tbLaserMax.Size = new System.Drawing.Size(37, 20);
            this.tbLaserMax.TabIndex = 29;
            this.tbLaserMax.Text = "255";
            this.tbLaserMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLaserMax_KeyPress);
            // 
            // tbLaserMin
            // 
            this.tbLaserMin.Location = new System.Drawing.Point(8, 34);
            this.tbLaserMin.Name = "tbLaserMin";
            this.tbLaserMin.Size = new System.Drawing.Size(35, 20);
            this.tbLaserMin.TabIndex = 28;
            this.tbLaserMin.Text = "0";
            this.tbLaserMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLaserMin_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Max Power";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Min Power";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.gbDimensions);
            this.tabPage1.Controls.Add(this.btnCheckOrig);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(191, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Image";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbDirthering);
            this.groupBox6.Location = new System.Drawing.Point(1, 368);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(187, 48);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Mode";
            // 
            // cbDirthering
            // 
            this.cbDirthering.FormattingEnabled = true;
            this.cbDirthering.Items.AddRange(new object[] {
            "GrayScale 8 bit",
            "Dirthering FS 1 bit"});
            this.cbDirthering.Location = new System.Drawing.Point(9, 17);
            this.cbDirthering.Name = "cbDirthering";
            this.cbDirthering.Size = new System.Drawing.Size(169, 21);
            this.cbDirthering.TabIndex = 14;
            this.cbDirthering.Text = "GrayScale 8 bit";
            this.cbDirthering.SelectedIndexChanged += new System.EventHandler(this.cbDirthering_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblGamma);
            this.groupBox5.Controls.Add(this.tBarGamma);
            this.groupBox5.Controls.Add(this.lblBrightness);
            this.groupBox5.Controls.Add(this.tBarBrightness);
            this.groupBox5.Controls.Add(this.lblContrast);
            this.groupBox5.Controls.Add(this.tBarContrast);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(1, 30);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(187, 218);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            // 
            // lblGamma
            // 
            this.lblGamma.AutoSize = true;
            this.lblGamma.Location = new System.Drawing.Point(86, 150);
            this.lblGamma.Name = "lblGamma";
            this.lblGamma.Size = new System.Drawing.Size(13, 13);
            this.lblGamma.TabIndex = 19;
            this.lblGamma.Text = "1";
            // 
            // tBarGamma
            // 
            this.tBarGamma.BackColor = System.Drawing.SystemColors.Window;
            this.tBarGamma.Location = new System.Drawing.Point(3, 164);
            this.tBarGamma.Maximum = 500;
            this.tBarGamma.Minimum = 1;
            this.tBarGamma.Name = "tBarGamma";
            this.tBarGamma.Size = new System.Drawing.Size(181, 45);
            this.tBarGamma.TabIndex = 2;
            this.tBarGamma.TickFrequency = 22;
            this.tBarGamma.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tBarGamma.Value = 50;
            this.tBarGamma.Scroll += new System.EventHandler(this.tBarGamma_Scroll);
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Location = new System.Drawing.Point(86, 17);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(13, 13);
            this.lblBrightness.TabIndex = 16;
            this.lblBrightness.Text = "0";
            // 
            // tBarBrightness
            // 
            this.tBarBrightness.BackColor = System.Drawing.SystemColors.Window;
            this.tBarBrightness.Location = new System.Drawing.Point(3, 31);
            this.tBarBrightness.Maximum = 127;
            this.tBarBrightness.Minimum = -127;
            this.tBarBrightness.Name = "tBarBrightness";
            this.tBarBrightness.Size = new System.Drawing.Size(181, 45);
            this.tBarBrightness.TabIndex = 0;
            this.tBarBrightness.TickFrequency = 10;
            this.tBarBrightness.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tBarBrightness.Scroll += new System.EventHandler(this.tBarBrightness_Scroll);
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Location = new System.Drawing.Point(86, 83);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(13, 13);
            this.lblContrast.TabIndex = 13;
            this.lblContrast.Text = "0";
            // 
            // tBarContrast
            // 
            this.tBarContrast.BackColor = System.Drawing.SystemColors.Window;
            this.tBarContrast.Location = new System.Drawing.Point(3, 97);
            this.tBarContrast.Maximum = 127;
            this.tBarContrast.Minimum = -127;
            this.tBarContrast.Name = "tBarContrast";
            this.tBarContrast.Size = new System.Drawing.Size(181, 45);
            this.tBarContrast.TabIndex = 1;
            this.tBarContrast.TickFrequency = 10;
            this.tBarContrast.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tBarContrast.Scroll += new System.EventHandler(this.tBarContrast_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Gamma";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Brightness";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Contrast";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnInvert);
            this.groupBox4.Controls.Add(this.btnRotateLeft);
            this.groupBox4.Controls.Add(this.btnRotateRight);
            this.groupBox4.Controls.Add(this.btnVertMirror);
            this.groupBox4.Controls.Add(this.btnHorizMirror);
            this.groupBox4.Location = new System.Drawing.Point(1, 244);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(187, 54);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // btnInvert
            // 
            this.btnInvert.BackgroundImage = global::_3dpBurnerImage2Gcode.Properties.Resources.inv2;
            this.btnInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInvert.Location = new System.Drawing.Point(151, 16);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(28, 28);
            this.btnInvert.TabIndex = 9;
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.AccessibleDescription = "";
            this.btnRotateLeft.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnRotateLeft.BackgroundImage = global::_3dpBurnerImage2Gcode.Properties.Resources.left;
            this.btnRotateLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRotateLeft.Location = new System.Drawing.Point(7, 16);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(28, 28);
            this.btnRotateLeft.TabIndex = 5;
            this.btnRotateLeft.UseVisualStyleBackColor = true;
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.BackgroundImage = global::_3dpBurnerImage2Gcode.Properties.Resources.right;
            this.btnRotateRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRotateRight.Location = new System.Drawing.Point(43, 16);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(28, 28);
            this.btnRotateRight.TabIndex = 6;
            this.btnRotateRight.UseVisualStyleBackColor = true;
            this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // btnVertMirror
            // 
            this.btnVertMirror.BackgroundImage = global::_3dpBurnerImage2Gcode.Properties.Resources.flip_vertical;
            this.btnVertMirror.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVertMirror.Location = new System.Drawing.Point(115, 16);
            this.btnVertMirror.Name = "btnVertMirror";
            this.btnVertMirror.Size = new System.Drawing.Size(28, 28);
            this.btnVertMirror.TabIndex = 8;
            this.btnVertMirror.UseVisualStyleBackColor = true;
            this.btnVertMirror.Click += new System.EventHandler(this.btnVertMirror_Click);
            // 
            // btnHorizMirror
            // 
            this.btnHorizMirror.BackgroundImage = global::_3dpBurnerImage2Gcode.Properties.Resources.flip_horizontal;
            this.btnHorizMirror.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHorizMirror.Location = new System.Drawing.Point(79, 16);
            this.btnHorizMirror.Name = "btnHorizMirror";
            this.btnHorizMirror.Size = new System.Drawing.Size(28, 28);
            this.btnHorizMirror.TabIndex = 7;
            this.btnHorizMirror.UseVisualStyleBackColor = true;
            this.btnHorizMirror.Click += new System.EventHandler(this.btnHorizMirror_Click);
            // 
            // gbDimensions
            // 
            this.gbDimensions.Controls.Add(this.label11);
            this.gbDimensions.Controls.Add(this.tbRes);
            this.gbDimensions.Controls.Add(this.cbLockRatio);
            this.gbDimensions.Controls.Add(this.label9);
            this.gbDimensions.Controls.Add(this.tbHeight);
            this.gbDimensions.Controls.Add(this.label8);
            this.gbDimensions.Controls.Add(this.tbWidth);
            this.gbDimensions.Location = new System.Drawing.Point(1, 299);
            this.gbDimensions.Name = "gbDimensions";
            this.gbDimensions.Size = new System.Drawing.Size(187, 67);
            this.gbDimensions.TabIndex = 5;
            this.gbDimensions.TabStop = false;
            this.gbDimensions.Text = "Output (mm)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(100, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Resol";
            // 
            // tbRes
            // 
            this.tbRes.Location = new System.Drawing.Point(137, 40);
            this.tbRes.Name = "tbRes";
            this.tbRes.Size = new System.Drawing.Size(34, 20);
            this.tbRes.TabIndex = 12;
            this.tbRes.Text = "0.18";
            this.tbRes.Enter += new System.EventHandler(this.tbRes_Enter);
            this.tbRes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRes_KeyPress);
            this.tbRes.Leave += new System.EventHandler(this.tbRes_Leave);
            // 
            // cbLockRatio
            // 
            this.cbLockRatio.AutoSize = true;
            this.cbLockRatio.Checked = true;
            this.cbLockRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLockRatio.Location = new System.Drawing.Point(100, 20);
            this.cbLockRatio.Name = "cbLockRatio";
            this.cbLockRatio.Size = new System.Drawing.Size(82, 17);
            this.cbLockRatio.TabIndex = 13;
            this.cbLockRatio.Text = "Aspect ratio";
            this.cbLockRatio.UseVisualStyleBackColor = true;
            this.cbLockRatio.CheckedChanged += new System.EventHandler(this.cbLockRatio_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Height";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(56, 40);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(36, 20);
            this.tbHeight.TabIndex = 11;
            this.tbHeight.Text = "100";
            this.tbHeight.Enter += new System.EventHandler(this.tbHeight_Enter);
            this.tbHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHeight_KeyPress);
            this.tbHeight.Leave += new System.EventHandler(this.tbHeight_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Width";
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(56, 19);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(36, 20);
            this.tbWidth.TabIndex = 10;
            this.tbWidth.Text = "60";
            this.tbWidth.Enter += new System.EventHandler(this.tbWidth_Enter);
            this.tbWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWidth_KeyPress);
            this.tbWidth.Leave += new System.EventHandler(this.tbWidth_Leave);
            // 
            // btnCheckOrig
            // 
            this.btnCheckOrig.Location = new System.Drawing.Point(51, 6);
            this.btnCheckOrig.Name = "btnCheckOrig";
            this.btnCheckOrig.Size = new System.Drawing.Size(93, 23);
            this.btnCheckOrig.TabIndex = 1;
            this.btnCheckOrig.Text = "Check Original";
            this.btnCheckOrig.UseVisualStyleBackColor = true;
            this.btnCheckOrig.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCheckOrig_MouseDown);
            this.btnCheckOrig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCheckOrig_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(452, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(199, 448);
            this.tabControl1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 450);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.unitsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(649, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoZoomToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // autoZoomToolStripMenuItem
            // 
            this.autoZoomToolStripMenuItem.Checked = true;
            this.autoZoomToolStripMenuItem.CheckOnClick = true;
            this.autoZoomToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoZoomToolStripMenuItem.Name = "autoZoomToolStripMenuItem";
            this.autoZoomToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.autoZoomToolStripMenuItem.Text = "Preview AutoZoom";
            this.autoZoomToolStripMenuItem.Click += new System.EventHandler(this.autoZoomToolStripMenuItem_Click);
            // 
            // unitsToolStripMenuItem
            // 
            this.unitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metricmmToolStripMenuItem,
            this.imperialinToolStripMenuItem});
            this.unitsToolStripMenuItem.Name = "unitsToolStripMenuItem";
            this.unitsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.unitsToolStripMenuItem.Text = "Units";
            // 
            // metricmmToolStripMenuItem
            // 
            this.metricmmToolStripMenuItem.Checked = true;
            this.metricmmToolStripMenuItem.CheckOnClick = true;
            this.metricmmToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metricmmToolStripMenuItem.Name = "metricmmToolStripMenuItem";
            this.metricmmToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.metricmmToolStripMenuItem.Text = "Metric (mm)";
            this.metricmmToolStripMenuItem.Click += new System.EventHandler(this.metricmmToolStripMenuItem_Click);
            // 
            // imperialinToolStripMenuItem
            // 
            this.imperialinToolStripMenuItem.CheckOnClick = true;
            this.imperialinToolStripMenuItem.Name = "imperialinToolStripMenuItem";
            this.imperialinToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.imperialinToolStripMenuItem.Text = "Imperial (in)";
            this.imperialinToolStripMenuItem.Click += new System.EventHandler(this.imperialinToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(649, 496);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3dpBurner Image2Gcode";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarContrast)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.gbDimensions.ResumeLayout(false);
            this.gbDimensions.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbEngravingPattern;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblFeedRateUnits;
        private System.Windows.Forms.TextBox tbFeedRate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbUseS;
        private System.Windows.Forms.RadioButton rbUseZ;
        private System.Windows.Forms.CheckBox cbEdgeLines;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbPostGcode;
        private System.Windows.Forms.RichTextBox rtbPreGcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbDirthering;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblGamma;
        private System.Windows.Forms.TrackBar tBarGamma;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.TrackBar tBarBrightness;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.TrackBar tBarContrast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.Button btnRotateLeft;
        private System.Windows.Forms.Button btnRotateRight;
        private System.Windows.Forms.Button btnVertMirror;
        private System.Windows.Forms.Button btnHorizMirror;
        private System.Windows.Forms.GroupBox gbDimensions;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbRes;
        private System.Windows.Forms.CheckBox cbLockRatio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.Button btnCheckOrig;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbLaserMin;
        private System.Windows.Forms.TextBox tbLaserMax;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem unitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metricmmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imperialinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoZoomToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label10;
    }
}

