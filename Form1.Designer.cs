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
            this.cbPreviewZoom = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
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
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbRes = new System.Windows.Forms.TextBox();
            this.cbLockRatio = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.btnCheckOrig = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.lblStatus.Size = new System.Drawing.Size(118, 17);
            this.lblStatus.Text = "toolStripStatusLabel1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(3, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(620, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // cbPreviewZoom
            // 
            this.cbPreviewZoom.AutoSize = true;
            this.cbPreviewZoom.Checked = true;
            this.cbPreviewZoom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPreviewZoom.Location = new System.Drawing.Point(305, 430);
            this.cbPreviewZoom.Name = "cbPreviewZoom";
            this.cbPreviewZoom.Size = new System.Drawing.Size(116, 17);
            this.cbPreviewZoom.TabIndex = 5;
            this.cbPreviewZoom.Text = "Preview AutoZoom";
            this.cbPreviewZoom.UseVisualStyleBackColor = true;
            this.cbPreviewZoom.CheckedChanged += new System.EventHandler(this.cbPreviewZoom_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.comboBox1);
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
            this.tabPage2.Size = new System.Drawing.Size(191, 508);
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Horizontal"});
            this.comboBox1.Location = new System.Drawing.Point(1, 332);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.Text = "Horizontal scanning";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.tbFeedRate);
            this.groupBox3.Location = new System.Drawing.Point(1, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 56);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Feedrate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(53, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "mm/min";
            // 
            // tbFeedRate
            // 
            this.tbFeedRate.Location = new System.Drawing.Point(11, 23);
            this.tbFeedRate.Name = "tbFeedRate";
            this.tbFeedRate.Size = new System.Drawing.Size(36, 20);
            this.tbFeedRate.TabIndex = 18;
            this.tbFeedRate.Text = "1000";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbUseS);
            this.groupBox2.Controls.Add(this.rbUseZ);
            this.groupBox2.Location = new System.Drawing.Point(1, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 41);
            this.groupBox2.TabIndex = 16;
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
            this.rbUseS.TabIndex = 10;
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
            this.rbUseZ.TabIndex = 9;
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
            this.cbEdgeLines.TabIndex = 15;
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
            this.rtbPostGcode.TabIndex = 3;
            this.rtbPostGcode.Text = "(Footer)\nG0 X0 Y0\n(Footer end)";
            this.rtbPostGcode.WordWrap = false;
            // 
            // rtbPreGcode
            // 
            this.rtbPreGcode.Location = new System.Drawing.Point(1, 20);
            this.rtbPreGcode.Name = "rtbPreGcode";
            this.rtbPreGcode.Size = new System.Drawing.Size(187, 83);
            this.rtbPreGcode.TabIndex = 1;
            this.rtbPreGcode.Text = "(Header)\n(Generated by 3dpBurner Image2Gcode)\nM5\n(Header end)";
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
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate file...";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(191, 508);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Laser profile";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Max Power (toDo)";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(7, 76);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(52, 20);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = "255";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(6, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Min Power (toDo)";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnCheckOrig);
            this.tabPage1.Controls.Add(this.btnOpenFile);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(191, 508);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Image";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbDirthering);
            this.groupBox6.Location = new System.Drawing.Point(1, 372);
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
            this.cbDirthering.Location = new System.Drawing.Point(9, 19);
            this.cbDirthering.Name = "cbDirthering";
            this.cbDirthering.Size = new System.Drawing.Size(169, 21);
            this.cbDirthering.TabIndex = 26;
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
            this.groupBox5.TabIndex = 26;
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
            this.tBarGamma.TabIndex = 18;
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
            this.tBarBrightness.TabIndex = 15;
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
            this.tBarContrast.TabIndex = 12;
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
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            // 
            // btnInvert
            // 
            this.btnInvert.BackgroundImage = global::_3dpBurnerImage2Gcode.Properties.Resources.inv2;
            this.btnInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInvert.Location = new System.Drawing.Point(151, 16);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(28, 28);
            this.btnInvert.TabIndex = 28;
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
            this.btnRotateLeft.TabIndex = 27;
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
            this.btnRotateRight.TabIndex = 26;
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
            this.btnVertMirror.TabIndex = 25;
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
            this.btnHorizMirror.TabIndex = 24;
            this.btnHorizMirror.UseVisualStyleBackColor = true;
            this.btnHorizMirror.Click += new System.EventHandler(this.btnHorizMirror_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbRes);
            this.groupBox1.Controls.Add(this.cbLockRatio);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbHeight);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbWidth);
            this.groupBox1.Location = new System.Drawing.Point(1, 301);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 67);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output (mm)";
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
            this.tbRes.TabIndex = 24;
            this.tbRes.Text = "0.18";
            this.tbRes.TextChanged += new System.EventHandler(this.tbRes_TextChanged);
            this.tbRes.Enter += new System.EventHandler(this.tbRes_Enter);
            // 
            // cbLockRatio
            // 
            this.cbLockRatio.AutoSize = true;
            this.cbLockRatio.Checked = true;
            this.cbLockRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLockRatio.Location = new System.Drawing.Point(100, 20);
            this.cbLockRatio.Name = "cbLockRatio";
            this.cbLockRatio.Size = new System.Drawing.Size(82, 17);
            this.cbLockRatio.TabIndex = 23;
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
            this.tbHeight.TabIndex = 21;
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
            this.tbWidth.TabIndex = 19;
            this.tbWidth.Text = "60";
            this.tbWidth.Enter += new System.EventHandler(this.tbWidth_Enter);
            this.tbWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWidth_KeyPress);
            this.tbWidth.Leave += new System.EventHandler(this.tbWidth_Leave);
            // 
            // btnCheckOrig
            // 
            this.btnCheckOrig.Location = new System.Drawing.Point(93, 6);
            this.btnCheckOrig.Name = "btnCheckOrig";
            this.btnCheckOrig.Size = new System.Drawing.Size(93, 23);
            this.btnCheckOrig.TabIndex = 2;
            this.btnCheckOrig.Text = "Check Original";
            this.btnCheckOrig.UseVisualStyleBackColor = true;
            this.btnCheckOrig.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCheckOrig_MouseDown);
            this.btnCheckOrig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCheckOrig_MouseUp);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(6, 6);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "File...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(427, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(199, 534);
            this.tabControl1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 425);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(425, 425);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(626, 452);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbPreviewZoom);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.CheckBox cbPreviewZoom;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbRes;
        private System.Windows.Forms.CheckBox cbLockRatio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.Button btnCheckOrig;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

