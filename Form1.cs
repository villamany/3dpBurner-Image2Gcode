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
//Form 1 (Main form)

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
using System.Drawing.Imaging;
using System.Globalization;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        const string ver = "v0.1development";
        Bitmap originalImage;
        Bitmap adjustedImage;
        float lastValue;//Aux for aply processing on image onli when a value is changer
        public Form1()
        {
            InitializeComponent();
        }
        float ratio; //Use to lock aspect ratio when option is checked
        //Auxiliar function. Adjust brightness contrast and gamma of an image (parameters values from -100 to 100)      
        private void imgBalance(int brigh, int cont, int gam)
        {
            ImageAttributes imageAttributes;
            float brightness = (brigh / 100.0f)+ 1.0f; // no change in brightness
            float contrast = (cont / 100.0f) +1.0f; // twice the contrast
            float gamma = 1/(gam / 100.0f) ; // no change in gamma
            //float gamma = (gam / 100.0f) + 1.0f; // no change in gamma

            float adjustedBrightness = brightness - 1.0f;
            // create matrix that will brighten and contrast the image
            float[][] ptsArray ={
            new float[] {contrast, 0, 0, 0, 0}, // scale red
            new float[] {0, contrast, 0, 0, 0}, // scale green
            new float[] {0, 0, contrast, 0, 0}, // scale blue
            new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
            new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};

            imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            Graphics g = Graphics.FromImage(adjustedImage);
            g.DrawImage(adjustedImage, new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height)
            , 0, 0, adjustedImage.Width, adjustedImage.Height,
            GraphicsUnit.Pixel, imageAttributes);
        }    
        //Auxiliar function. Create a grayscale version of image
        public static Bitmap imgGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
      {
         new float[] {.3f, .3f, .3f, 0, 0},
         new float[] {.59f, .59f, .59f, 0, 0},
         new float[] {.11f, .11f, .11f, 0, 0},
         new float[] {0, 0, 0, 1, 0},
         new float[] {0, 0, 0, 0, 1}
      });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }
        //Auxiliar function. Resize image to desired width/height for gcode generation
        private void imgResize()
        {
            Int32 xSize;//Total X pixels of resulting image for GCode generation
            Int32 ySize;//Total Y pixels of resulting image for GCode generation
            xSize = Convert.ToInt32(float.Parse(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat) / float.Parse(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat));
            ySize = Convert.ToInt32(float.Parse(tbHeight.Text, CultureInfo.InvariantCulture.NumberFormat) / float.Parse(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat));
            adjustedImage = new Bitmap(adjustedImage, new Size(xSize, ySize));
        }
        //Show a invalid values message
        private void invalidValue()
        {
            lblStatus.Text = "Invalid values! Check it.";
        }
        //Reset the invalid value message
        private void validValue()
        {
            lblStatus.Text = "";
        }
        //Apply all corrections to original image and save as processed one
        private void adjustImg()
        {

            try
            {
                lblStatus.Text = "Processing image...";
                Refresh();
                if (!File.Exists(openFileDialog1.FileName)) return;
                adjustedImage = imgGrayscale(originalImage);
                imgBalance(tBarBrightness.Value, tBarContrast.Value, tBarGamma.Value);
                imgResize();
                validValue();
                lblStatus.Text = "Done";
            }
            catch
            {
                invalidValue();
            }
            
            pictureBox1.Image = adjustedImage;
            
        }
        //OpenFile, get original image and original ratio
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                if (!File.Exists(openFileDialog1.FileName)) return;
                tBarBrightness.Value = 0;
                tBarContrast.Value = 0;
                tBarGamma.Value = 100;
                lblBrightness.Text = Convert.ToString(tBarBrightness.Value);
                lblContrast.Text = Convert.ToString(tBarContrast.Value);
                lblGamma.Text = Convert.ToString(tBarGamma.Value / 100.0f);
                originalImage = new Bitmap(Image.FromFile(openFileDialog1.FileName));
                ratio = (originalImage.Width + 0.0f) / originalImage.Height;//Save ratio for future use if needled
                if (cbLockRatio.Checked) tbHeight.Text = Convert.ToString((Convert.ToSingle(tbWidth.Text) / ratio), CultureInfo.InvariantCulture.NumberFormat);//Initialize y size
                adjustImg();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error opening file: "+err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Contrast adjust
        private void tBarContrast_Scroll(object sender, EventArgs e)
        {
            lblContrast.Text = Convert.ToString(tBarContrast.Value);
            Refresh();
            adjustImg();
        }
        //tBarBrightness adjust
        private void tBarBrightness_Scroll(object sender, EventArgs e)
        {
            lblBrightness.Text = Convert.ToString(tBarBrightness.Value);
            Refresh();
            adjustImg();
        }
        //Gamma adjust
        private void tBarGamma_Scroll(object sender, EventArgs e)
        {
            lblGamma.Text = Convert.ToString(tBarGamma.Value/100.0f);
            Refresh();
            adjustImg();
        }
        //Quick preview of the original image. Todo: use a new image container for fas return to processed image
        private void btnCheckOrig_MouseDown(object sender, MouseEventArgs e)
        {
            if (!File.Exists(openFileDialog1.FileName)) return;
            lblStatus.Text = "Loading original image...";
            Refresh();
            adjustedImage = imgGrayscale(originalImage);
            pictureBox1.Image = adjustedImage;
            lblStatus.Text = "Done";
        }
        //Reload the processed image after temporal preiew of the original image
        private void btnCheckOrig_MouseUp(object sender, MouseEventArgs e)
        {
            adjustImg();
        }
        //Resolution control new value. Update image.
        private void tbRes_TextChanged(object sender, EventArgs e)
        {
            adjustImg();
        }
        //Check if a new image width has been confirmad by user, process it.
        private void widthChanged()
        {
            float newValue = Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat);
            if (newValue == lastValue) return;//if not is a new value do nothing
     
            lastValue = Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat);

            try
            {
                if (cbLockRatio.Checked)
                {
                    tbHeight.Text = Convert.ToString((newValue / ratio), CultureInfo.InvariantCulture.NumberFormat);
                }
            }
            catch
            {
                invalidValue();
            }
            adjustImg();
        }
        //Check if a new image height has been confirmad by user, process it.
        private void heightChanged()
        {
            float newValue = Convert.ToSingle(tbHeight.Text, CultureInfo.InvariantCulture.NumberFormat);
            if (newValue == lastValue) return;//if not is a new value do nothing

            try
            {
                if (cbLockRatio.Checked)
                {
                    tbWidth.Text = Convert.ToString((newValue * ratio), CultureInfo.InvariantCulture.NumberFormat);
                }
            }
            catch
            {
                invalidValue();
            }
            adjustImg();
        }
        //CheckBox lockAspectRatio checked. Set the user width value and calculate the height
        private void cbLockRatio_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLockRatio.Checked)
            {
                tbHeight.Text = Convert.ToString((Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat) / ratio), CultureInfo.InvariantCulture.NumberFormat);//Initialize y size
                adjustImg();
            }
        }
        //On form load. Hide status labels
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "3dpBurner Image2Gcode " + ver;
            lblStatus.Text = "Done";
        }
        //With control enter key pressed. Check new value
        private void tbWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==Convert.ToChar(13))
            {              
                widthChanged();
                tbWidth_Enter(null, null);
            }
        }
        //Height control enter key pressed. Check new value
        private void tbHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {             
                heightChanged();
                tbHeight_Enter(null, null);
            }
        }
        //Width control leave focus. Check new value
        private void tbWidth_Leave(object sender, EventArgs e)
        {
            widthChanged();
        }
        //Height control leave focus. Check new value
        private void tbHeight_Leave(object sender, EventArgs e)
        {
            heightChanged();
        }
        //Width control get focus. Backup actual value for compare
        private void tbWidth_Enter(object sender, EventArgs e)
        {
            lastValue=Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat);
        }
        //Height control get focus. Backup actual value for compare
        private void tbHeight_Enter(object sender, EventArgs e)
        {
            lastValue = Convert.ToSingle(tbHeight.Text, CultureInfo.InvariantCulture.NumberFormat);
        }
        //Resolution control get focus. Backup actual value for compare
        private void tbRes_Enter(object sender, EventArgs e)
        {
            lastValue = Convert.ToSingle(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat);
        }
        //Generate a minimalist gcode line based on the actual and last coordinates and power
        string line;
        float coordX;//X
        float coordY;//Y
        Int32 sz;//S (or Z)
        float lastX;//Last x/y  coords for compare
        float lastY;
        Int32 lastSz;//last 'S' value for compare
        string coordXStr;//String formated X
        string coordYStr;////String formated Y
        char szChar;//Use 'S' or 'Z' for test laser power
        string szStr;////String formated S
        private void generateLine()
        {
            //Generate Gcode line
            line = "";
            if (coordX != lastX)//Add X coord to line if is diferent from previous             
            {
                coordXStr = Convert.ToString(coordX, CultureInfo.InvariantCulture.NumberFormat);
                coordXStr = string.Format("{0:0.###}", Convert.ToString(coordXStr));
                line += 'X' + coordXStr;
            }
            if (coordY != lastY)//Add Y coord to line if is diferent from previous
            {
                coordYStr = Convert.ToString(coordY, CultureInfo.InvariantCulture.NumberFormat);
                coordYStr = string.Format("{0:0.###}", coordYStr);
                line += 'Y' + coordYStr;
            }
            if (sz != lastSz)//Add power value to line if is diferent from previous
            {
                szStr = szChar + Convert.ToString(sz);
                line += szStr;
            }
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            
            lblStatus.Text="Generating file...";
            Refresh();

            List<string> fileLines;
            fileLines = new List<string>();
            float resol=Convert.ToSingle(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat);//Resolution (or laser spot size)
            if (rbUseS.Checked) szChar = 'S'; else sz = 'Z';

            //Add the pre-Gcode lines
            lastX = -1;//reset last positions
            lastY = -1;
            lastSz = -1;
            foreach(string s in rtbPreGcode.Lines)
            {
                fileLines.Add(s);
            }
            line = "G90\r";//Absolute coordinates
            fileLines.Add(line);
            line = "G21\r";//Metric units
            fileLines.Add(line);
            line = "F" + tbFeedRate.Text + "\r";//Feedrate
            fileLines.Add(line);
            //Goto rapid move to lef top corner
            line = "G0X0Y" + string.Format("{0:0.###}", Convert.ToString(adjustedImage.Height * Convert.ToSingle(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat), CultureInfo.InvariantCulture.NumberFormat));
            fileLines.Add(line);
            line = "G1\r";//G1 mode
            fileLines.Add(line);
            line = "M3\r";//Switch laser on
            fileLines.Add(line);
            //////////////////////////////////////////////
            // Generate Gcode lines by Horozontal scanning
            //////////////////////////////////////////////
            Int32 lin = adjustedImage.Height - 1;//top tile
            Int32 col = 0;//Left pixel
            while (lin>=0)
            {
                //Y coordinate
                coordY=resol * (float) lin;           
                while (col<adjustedImage.Width)//From left to right
                {
                    //X coordinate
                    coordX = resol * (float)col;
                    //Power value
                    Color cl = adjustedImage.GetPixel(col, (adjustedImage.Height - 1)-lin);//Get pixel color
                    sz = 255-cl.R;
                    generateLine();
                    if (!string.IsNullOrEmpty(line)) fileLines.Add(line);
                    lastX=coordX;
                    lastY=coordY;
                    lastSz=sz;
                    col++;
                }
                col--;
                lin--;
                coordY = resol * (float)lin; 
                while ((col > 0)&(lin>=0))//From left to right
                {
                    //X coordinate
                    coordX = resol * (float)col;
                    //Power value
                    Color cl = adjustedImage.GetPixel(col, (adjustedImage.Height - 1) - lin);//Get pixel color
                    sz = 255 - cl.R;
                    generateLine();
                    if (!string.IsNullOrEmpty(line)) fileLines.Add(line);
                    lastX=coordX;
                    lastY=coordY;
                    lastSz=sz;
                    col--;
                }
                lin--;

                lblStatus.Text = "Generating file... " + Convert.ToString(((adjustedImage.Height - 1) - lin) * 100 / (adjustedImage.Height - 1)) + "%";
                Refresh();
            }
            //Switch laser off
            line = "M5\r";//G1 mode
            fileLines.Add(line);

            //Add the post-Gcode 
            foreach (string s in rtbPostGcode.Lines)
            {
                fileLines.Add(s);
            }
            lblStatus.Text="Saving file...";
            Refresh();
            //Save file
            File.WriteAllLines(saveFileDialog1.FileName , fileLines);
            lblStatus.Text="Done";
        }
    }
}
