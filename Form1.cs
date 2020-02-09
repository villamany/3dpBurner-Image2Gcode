/*  3dpBurner Image2Gcode. A Image to GCODE converter for GRBL based devices.
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
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace _3dpBurnerImage2Gcode
{
    public partial class Form1 : Form
    {
        const string ver = "v1.0";
        Bitmap originalImage;
        Bitmap adjustedImage;
        float lastValue;//Aux for apply processing to image only when a new value is detected
        public Form1()
        {
            InitializeComponent();
            Properties.Settings.Default.Upgrade();
        }
        float ratio; //Used to lock the aspect ratio when the option is selected
        //Save settings
        private void saveSettings()
        {
            try
            {
                string set;
                Properties.Settings.Default.autoZoom=autoZoomToolStripMenuItem.Checked;
                if (imperialinToolStripMenuItem.Checked) set = "imperial";
                    else set = "metric";
                Properties.Settings.Default.units =set;
                Properties.Settings.Default.width = tbWidth.Text;
                Properties.Settings.Default.height = tbHeight.Text;
                Properties.Settings.Default.resolution = tbRes.Text;
                Properties.Settings.Default.minPower = tbLaserMin.Text;
                Properties.Settings.Default.maxPower = tbLaserMax.Text;
                Properties.Settings.Default.header = rtbPreGcode.Text;
                Properties.Settings.Default.footer = rtbPostGcode.Text;
                Properties.Settings.Default.feedrate = tbFeedRate.Text;
                Properties.Settings.Default.oncode = comboBoxOnCode.Text;
                Properties.Settings.Default.offcode = comboBoxOffCode.Text;
                if (rbUseZ.Checked) set = "Z";
                else set = "S";
                Properties.Settings.Default.powerCommand = set;
                Properties.Settings.Default.pattern = cbEngravingPattern.Text;
                Properties.Settings.Default.edgeLines = cbEdgeLines.Checked;
                Properties.Settings.Default.woodPower = tbWoodPower.Text;
                Properties.Settings.Default.woodFeed = tbWoodFeed.Text;
                Properties.Settings.Default.leatherPower = tbLeatherPower.Text;
                Properties.Settings.Default.leatherFeed = tbLeatherFeed.Text;
                Properties.Settings.Default.aaPower = tbAAPower.Text;
                Properties.Settings.Default.aaFeed = tbAAFeed.Text;

                Properties.Settings.Default.Save();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error saving config: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //Load settings
        private void loadSettings()
        {
            try
            {
                autoZoomToolStripMenuItem.Checked=Properties.Settings.Default.autoZoom;
                autoZoomToolStripMenuItem_Click(this, null);

                if (Properties.Settings.Default.units=="imperial")
                {
                    imperialinToolStripMenuItem.Checked=true;
                    imperialinToolStripMenuItem_Click(this,null);
                }
                else 
                {
                    metricmmToolStripMenuItem.Checked=true;
                    metricmmToolStripMenuItem_Click(this,null);
                }
                tbWidth.Text=Properties.Settings.Default.width;
                tbHeight.Text=Properties.Settings.Default.height;
                tbRes.Text=Properties.Settings.Default.resolution;
                tbLaserMin.Text=Properties.Settings.Default.minPower;
                tbLaserMax.Text=Properties.Settings.Default.maxPower;
                rtbPreGcode.Text=Properties.Settings.Default.header;
                rtbPostGcode.Text=Properties.Settings.Default.footer;
                tbFeedRate.Text=Properties.Settings.Default.feedrate;
                if (Properties.Settings.Default.powerCommand == "Z")
                    rbUseZ.Checked = true;
                        else rbUseS.Checked = true;
                comboBoxOnCode.Text = Properties.Settings.Default.oncode;
                comboBoxOffCode.Text = Properties.Settings.Default.offcode;
                cbEngravingPattern.Text=Properties.Settings.Default.pattern;
                cbEdgeLines.Checked=Properties.Settings.Default.edgeLines;
                tbWoodPower.Text = Properties.Settings.Default.woodPower;
                tbWoodFeed.Text = Properties.Settings.Default.woodFeed;
                tbLeatherPower.Text = Properties.Settings.Default.leatherPower;
                tbLeatherFeed.Text = Properties.Settings.Default.leatherFeed;
                tbAAPower.Text = Properties.Settings.Default.aaPower;
                tbAAFeed.Text = Properties.Settings.Default.aaFeed;

            }
            catch (Exception e)
            {
                MessageBox.Show("Error saving config: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        //Interpolate a 8 bit grayscale value (0-255) between min,max
        private float interpolate(float grayValue, float min, float max) //float grayValue, float min, float max
        {
            float dif = max - min;
            return (min + ((grayValue * dif) / 255));
        }

        //Return true if char is a valid float digit, show eror message is not and return false
        private bool checkDigitFloat(char ch )
        {
            if ((ch != '.') & (ch != '0') & (ch != '1') & (ch != '2') & (ch != '3') & (ch != '4') & (ch != '5') & (ch != '6') & (ch != '7') & (ch != '8') & (ch != '9') & (Convert.ToByte(ch) != 8) & (Convert.ToByte(ch) != 13))//is a 0-9 numbre or . decimal separator, backspace or enter
            {
                MessageBox.Show("Allowed chars are '0'-'9' and '.' as decimal separator", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        //Return true if char is a valid integer digit, show eror message is not and return false
        private bool checkDigitInteger(char ch)
        {
            if ((ch != '0') & (ch != '1') & (ch != '2') & (ch != '3') & (ch != '4') & (ch != '5') & (ch != '6') & (ch != '7') & (ch != '8') & (ch != '9') & (Convert.ToByte(ch) != 8) & (Convert.ToByte(ch) != 13))//is a 0-9 numbre or . decimal separator, backspace or enter
            {
                MessageBox.Show("Allowed chars are '0'-'9'", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
              
        //Apply dirthering to an image (Convert to 1 bit)
        private Bitmap imgDirther(Bitmap input)
        {
            lblStatus.Text = "Dirthering...";
            Refresh();
            var masks = new byte[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
            var output = new Bitmap(input.Width, input.Height, PixelFormat.Format1bppIndexed);
            var data = new sbyte[input.Width, input.Height];
            var inputData = input.LockBits(new Rectangle(0, 0, input.Width, input.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            try
            {
                var scanLine = inputData.Scan0;
                var line = new byte[inputData.Stride];
                for (var y = 0; y < inputData.Height; y++, scanLine += inputData.Stride)
                {
                    Marshal.Copy(scanLine, line, 0, line.Length);
                    for (var x = 0; x < input.Width; x++)
                    {
                        data[x, y] = (sbyte)(64 * (GetGreyLevel(line[x * 3 + 2], line[x * 3 + 1], line[x * 3 + 0]) - 0.5));
                    }
                }
            }
            finally
            {
                input.UnlockBits(inputData);
            }
            var outputData = output.LockBits(new Rectangle(0, 0, output.Width, output.Height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
            try
            {
                var scanLine = outputData.Scan0;
                for (var y = 0; y < outputData.Height; y++, scanLine += outputData.Stride)
                {
                    var line = new byte[outputData.Stride];
                    for (var x = 0; x < input.Width; x++)
                    {
                        var j = data[x, y] > 0;
                        if (j) line[x / 8] |= masks[x % 8];
                        var error = (sbyte)(data[x, y] - (j ? 32 : -32));
                        if (x < input.Width - 1) data[x + 1, y] += (sbyte)(7 * error / 16);
                        if (y < input.Height - 1)
                        {
                            if (x > 0) data[x - 1, y + 1] += (sbyte)(3 * error / 16);
                            data[x, y + 1] += (sbyte)(5 * error / 16);
                            if (x < input.Width - 1) data[x + 1, y + 1] += (sbyte)(1 * error / 16);
                        }
                    }
                    Marshal.Copy(line, 0, scanLine, outputData.Stride);
                }
            }
            finally
            {
                output.UnlockBits(outputData);
            }
            lblStatus.Text = "Done";
            Refresh();
            return (output);
        }
        private static double GetGreyLevel(byte r, byte g, byte b)//aux for dirthering
        {
            return (r * 0.299 + g * 0.587 + b * 0.114) / 255;
        }
        //Adjust brightness contrast and gamma of an image      
        private Bitmap imgBalance(Bitmap img, int brigh, int cont, int gam)
        {
            lblStatus.Text = "Balancing...";
            Refresh();
            ImageAttributes imageAttributes;
            float brightness = (brigh / 100.0f)+ 1.0f; 
            float contrast = (cont / 100.0f) +1.0f; 
            float gamma = 1/(gam / 100.0f) ; 
            float adjustedBrightness = brightness - 1.0f;
            Bitmap output;
            // create matrix that will brighten and contrast the image
            float[][] ptsArray ={
            new float[] {contrast, 0, 0, 0, 0}, // scale red
            new float[] {0, contrast, 0, 0, 0}, // scale green
            new float[] {0, 0, contrast, 0, 0}, // scale blue
            new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
            new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};

            output = new Bitmap(img);
            imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            Graphics g = Graphics.FromImage(output);
            g.DrawImage(output, new Rectangle(0, 0, output.Width, output.Height)
            , 0, 0, output.Width, output.Height,
            GraphicsUnit.Pixel, imageAttributes);
            lblStatus.Text = "Done";
            Refresh();
            return (output);
        }    
        //Return a grayscale version of an image
        private Bitmap imgGrayscale(Bitmap original)
        {
            lblStatus.Text = "Grayscaling...";
            Refresh();
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);//create a blank bitmap the same size as original
            Graphics g = Graphics.FromImage(newBitmap);//get a graphics object from the new image
            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
                {
                    new float[] {.299f, .299f, .299f, 0, 0},
                    new float[] {.587f, .587f, .587f, 0, 0},
                    new float[] {.114f, .114f, .114f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });
            ImageAttributes attributes = new ImageAttributes();//create some image attributes
            attributes.SetColorMatrix(colorMatrix);//set the color matrix attribute

            //draw the original image on the new image using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
            g.Dispose();//dispose the Graphics object
            lblStatus.Text = "Done";
            Refresh();
            return (newBitmap);
        }
        //Return a inverted colors version of a image
        private Bitmap imgInvert(Bitmap original)
        {
            lblStatus.Text = "Inverting...";
            Refresh();
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);//create a blank bitmap the same size as original
            Graphics g = Graphics.FromImage(newBitmap);//get a graphics object from the new image
            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
                {
                    new float[] {-1, 0, 0, 0, 0},
                    new float[] {0, -1, 0, 0, 0},
                    new float[] {0, 0, -1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {1, 1, 1, 0, 1}
                });
            ImageAttributes attributes = new ImageAttributes();//create some image attributes
            attributes.SetColorMatrix(colorMatrix);//set the color matrix attribute

            //draw the original image on the new image using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
            g.Dispose();//dispose the Graphics object
            lblStatus.Text = "Done";
            Refresh();
            return (newBitmap);
        }

        //Resize image to desired width/height for gcode generation
        private Bitmap imgResize(Bitmap input, Int32 xSize, Int32 ySize)
        {
            //Resize
            Bitmap output;
            lblStatus.Text = "Resizing...";
            Refresh();
            output= new Bitmap(input,new Size(xSize, ySize));
            lblStatus.Text = "Done";
            Refresh();
            return(output);
        }
        //Invoked when the user input any value for image adjust
        private void userAdjust()
        {
            try
            {
                if (adjustedImage == null) return;//if no image, do nothing
                //Apply resize to original image
                Int32 xSize;//Total X pixels of resulting image for GCode generation
                Int32 ySize;//Total Y pixels of resulting image for GCode generation
                xSize = Convert.ToInt32(float.Parse(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat) / float.Parse(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat));
                ySize = Convert.ToInt32(float.Parse(tbHeight.Text, CultureInfo.InvariantCulture.NumberFormat) / float.Parse(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat));
                adjustedImage = imgResize(originalImage, xSize, ySize);
                //Apply balance to adjusted (resized) image
                adjustedImage = imgBalance(adjustedImage, tBarBrightness.Value, tBarContrast.Value, tBarGamma.Value);
                //Reset dirthering to adjusted (resized and balanced) image
                cbDirthering.Text = "GrayScale 8 bit";
                //Display image
                pictureBox1.Image = adjustedImage;
                //Set preview
                autoZoomToolStripMenuItem_Click(this, null);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error resizing/balancing image: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Display a invalid values message
        private void invalidValue()
        {
            lblStatus.Text = "Invalid values! Check it.";
        }
         //Contrast adjusted by user
        private void tBarContrast_Scroll(object sender, EventArgs e)
        {
            lblContrast.Text = Convert.ToString(tBarContrast.Value);
            Refresh();
            userAdjust(); 
        }
        //Brightness adjusted by user
        private void tBarBrightness_Scroll(object sender, EventArgs e)
        {
            lblBrightness.Text = Convert.ToString(tBarBrightness.Value);
            Refresh();
            userAdjust();          
        }
        //Gamma adjusted by user
        private void tBarGamma_Scroll(object sender, EventArgs e)
        {
            lblGamma.Text = Convert.ToString(tBarGamma.Value/100.0f);
            Refresh();
            userAdjust(); 
        }
        //Quick preview of the original image. Todo: use a new image container for fas return to processed image
        private void btnCheckOrig_MouseDown(object sender, MouseEventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            if (!File.Exists(openFileDialog1.FileName)) return;
            lblStatus.Text = "Loading original image...";
            Refresh();
            pictureBox1.Image = originalImage;
            lblStatus.Text = "Done";
        }
        //Reload the processed image after temporal preiew of the original image
        private void btnCheckOrig_MouseUp(object sender, MouseEventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            if (!File.Exists(openFileDialog1.FileName)) return;
            pictureBox1.Image = adjustedImage;
        }

        //Check if a new image width has been confirmad by user, process it.
        private void widthChangedCheck()
        {
            try
            {
                if (adjustedImage == null) return;//if no image, do nothing
                float newValue = Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat);//Get the user input value           
                if (newValue == lastValue) return;//if not is a new value do nothing     
                lastValue = Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat);
                if (cbLockRatio.Checked)
                {
                    tbHeight.Text = Convert.ToString((newValue / ratio), CultureInfo.InvariantCulture.NumberFormat);
                }
                userAdjust();
            }
            catch 
            {
                MessageBox.Show("Check width value.", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Check if a new image height has been confirmad by user, process it.
        private void heightChangedCheck()
        {
            try
            {
                if (adjustedImage == null) return;//if no image, do nothing
                float newValue = Convert.ToSingle(tbHeight.Text, CultureInfo.InvariantCulture.NumberFormat);//Get the user input value   
                if (newValue == lastValue) return;//if not is a new value do nothing
                lastValue = Convert.ToSingle(tbHeight.Text, CultureInfo.InvariantCulture.NumberFormat);
                if (cbLockRatio.Checked)
                {
                    tbWidth.Text = Convert.ToString((newValue * ratio), CultureInfo.InvariantCulture.NumberFormat);
                }
                userAdjust();
            }
            catch {
                MessageBox.Show("Check height value.", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Check if a new image resolution has been confirmad by user, process it.
        private void resolutionChangedCheck()
        {
            try
            {
                if (adjustedImage == null) return;//if no image, do nothing
                float newValue = Convert.ToSingle(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat);//Get the user input value
                if (newValue == lastValue) return;//if not is a new value do nothing
                lastValue = Convert.ToSingle(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat);
                userAdjust();
            }
            catch {
                MessageBox.Show("Check resolution value.", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //CheckBox lockAspectRatio checked. Set as mandatory the user setted width and calculate the height by using the original aspect ratio
        private void cbLockRatio_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLockRatio.Checked)
            {
                tbHeight.Text = Convert.ToString((Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat) / ratio), CultureInfo.InvariantCulture.NumberFormat);//Initialize y size
                if (adjustedImage == null) return;//if no image, do nothing
                userAdjust();
            }
        }
        //On form load
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "3dpBurner Image2Gcode (Modded for MPCNC)" + ver;
            lblStatus.Text = "Done";
            loadSettings();


#if DEBUG   //Load file automatically if debugging
            //if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;//if no image, do nothing
            openFileDialog1.FileName = "D:\\Pictures\\Debug_Pic.png";
            if (!File.Exists(openFileDialog1.FileName)) return;
            lblStatus.Text = "Opening file...";
            Refresh();
            tBarBrightness.Value = 0;
            tBarContrast.Value = 0;
            tBarGamma.Value = 100;
            lblBrightness.Text = Convert.ToString(tBarBrightness.Value);
            lblContrast.Text = Convert.ToString(tBarContrast.Value);
            lblGamma.Text = Convert.ToString(tBarGamma.Value / 100.0f);
            originalImage = new Bitmap(Image.FromFile(openFileDialog1.FileName));
            originalImage = imgGrayscale(originalImage);
            adjustedImage = new Bitmap(originalImage);
            ratio = (originalImage.Width + 0.0f) / originalImage.Height;//Save ratio for future use if needled
            if (cbLockRatio.Checked) tbHeight.Text = Convert.ToString((Convert.ToSingle(tbWidth.Text) / ratio), CultureInfo.InvariantCulture.NumberFormat);//Initialize y size
            userAdjust();
            lblStatus.Text = "Done";
            string fN = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
            saveFileDialog1.FileName = fN + ".gcode";
            saveFileDialog1.InitialDirectory = "C:\\Users\\BRYAN\\Desktop";
#endif
            toolTip1.InitialDelay = 500;
            toolTip1.ShowAlways = true;

            autoZoomToolStripMenuItem_Click(this, null);//Set preview zoom mode
        }
        //Width confirmed by user by the enter key
        private void tbWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Prevent any not allowed char
            if (!checkDigitFloat(e.KeyChar))
            {
                e.Handled = true;//Stop the character from being entered into the control since it is non-numerical.
                return;
            }

            if (e.KeyChar==Convert.ToChar(13))
            {              
                widthChangedCheck();
            }
        }
        //Height confirmed by user by the enter key
        private void tbHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Prevent any not allowed char
            if (!checkDigitFloat(e.KeyChar))
            {
                e.Handled = true;//Stop the character from being entered into the control since it is non-numerical.
                return;
            }
            if (e.KeyChar == Convert.ToChar(13))
            {             
                heightChangedCheck();
            }
        }
        //Resolution confirmed by user by the enter key
        private void tbRes_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Prevent any not allowed char
            if (!checkDigitFloat(e.KeyChar))
            {
                e.Handled = true;//Stop the character from being entered into the control since it is non-numerical.
                return;
            }
            if (e.KeyChar == Convert.ToChar(13))
            {
                resolutionChangedCheck();
            }
        }
        //Width control leave focus. Check if new value
        private void tbWidth_Leave(object sender, EventArgs e)
        {
            widthChangedCheck();
        }
        //Height control leave focus. Check if new value
        private void tbHeight_Leave(object sender, EventArgs e)
        {
            heightChangedCheck();
        }
        //Resolution control leave focus. Check if new value
        private void tbRes_Leave(object sender, EventArgs e)
        {
            resolutionChangedCheck();
        }
        //Width control get focusv
        private void tbWidth_Enter(object sender, EventArgs e)
        {
            try
            {
                lastValue = Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat);
            }
            catch { }
        }
        //Height control get focus. Backup actual value for check changes.
        private void tbHeight_Enter(object sender, EventArgs e)
        {
            try
            {
                lastValue = Convert.ToSingle(tbHeight.Text, CultureInfo.InvariantCulture.NumberFormat);
            }
            catch { }
        }
        //Resolution control get focus. Backup actual value for check changes.
        private void tbRes_Enter(object sender, EventArgs e)
        {
            try
            {
                lastValue = Convert.ToSingle(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat);
            }
            catch { }
        }

        private String modelOrigin()
        {
            String travel2 = "G0 ";
            float width = float.Parse(tbWidth.Text);
            float height = float.Parse(tbHeight.Text);

            if (ori0.Checked) {
                //Move from bottom left corner
                travel2 += "Y" + height;
            }

            else if (ori1.Checked)
            {
                //Move from Bottom mid
                travel2 += "X-" + width/2 + " Y" + height;
            }

            else if (ori2.Checked)
            {
                //Move from bottom right corner
                travel2 += "X-" + width + " Y" + height;
            }

            else if (ori3.Checked)
            {
                //Move from left mid
                travel2 += "Y" + height / 2;
            }

            else if (ori4.Checked)
            {
                //Move from middle
                travel2 += "X-" + width / 2 + " Y" + height / 2;
            }

            else if (ori5.Checked)
            {
                //Move from right mid
                travel2 += "X-" + width + " Y" + height / 2;
            }

            else if (ori6.Checked)
            {
                //Don't do anything; already here
                travel2 = "";
            }

            else if (ori7.Checked)
            {
                //Move from top mid
                travel2 += "X-" + width / 2;
            }

            else
            {
                //Move from top right corner
                travel2 += "X-" + width;
            }

            //Draw box outline with laser power = S5
            travel2 += "; Move to top left corner and begin box\r\nG92 X0 Y" + height + "\r\n";
            travel2 += "\r\n" + comboBoxOnCode.Text + "5\r\n";
            travel2 += "G0 X" + width + "\r\n";
            travel2 += "G0 Y0\r\n";
            travel2 += "G0 X0\r\n";
            return travel2;
        }
        
        //Generate a "minimalist" gcode line based on the actual and last coordinates and laser power
        string line;
        float coordX;//X
        float coordY;//Y
        float sz;//S (or Z)
        float lastX;//Last x/y  coords for compare
        float lastY;
        float lastSz;//last 'S' value for compare
        string szChar;//Use 'S' or 'Z' for test laser power
        string coordXStr;//String formated X
        string coordYStr;////String formated Y
        string szStr;////String formated S
        bool deleteThisLine = false;//Flag to delete a movement line. True = line deleted; False = line saved
        private void generateLine()
        {
            //Generate Gcode line
            line = "";
            if ((coordX != lastX) || (coordY != lastY))
            {
                if (!deleteThisLine) //this section does nothing right now
                {
                    //line += "G1 ";
                }

                if (coordX != lastX)//Experimental Feature.. Optimized Raster based on checkbox           
                {
                    if(cbOptimizedRaster.Checked) //If line is allowed and cb is not checked, print line
                    {
                        if (!deleteThisLine)
                        {
                            line += "G1 ";
                            coordXStr = string.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.###}", coordX);
                            line += 'X' + coordXStr + ' ';// + deleteThisLine;
                        }
                        
                    }
                    else //Optimization not required, continue as usual. (Works for horizontal and diagonal)
                    {
                        line += "G1 ";
                        coordXStr = string.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.###}", coordX);
                        line += 'X' + coordXStr + ' ';// + deleteThisLine;
                    }

                }

                if (coordY != lastY)//Add Y coord to line if is diferent from previous //& sz != lastSz. We will always be printing G1 Y lines until I figure something out
                {
                    line += "G1 ";
                    coordYStr = string.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.###}", coordY);
                    line += 'Y' + coordYStr + ' ';//+ deleteThisLine;
                }
                //line += "\r";
            }
           
        }

        private void generateMLine()
        {
            //Generate Mcode line
            line = "";

            if (sz != lastSz)//Add power value to line if is diferent from previous
            {
                deleteThisLine = false;

                szStr = szChar + Convert.ToString(sz);
                line += szStr;// + deleteThisLine;
                //deleteThisLine = true;
            }
            else //No power change, set flag to true
            {
                deleteThisLine = true;
            }
        }
        //Generate button click
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            float resol = Convert.ToSingle(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat);//Resolution (or laser spot size)
            float w = Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat);//Get the user input value only for check for cancel if not valid         
            float h = Convert.ToSingle(tbHeight.Text, CultureInfo.InvariantCulture.NumberFormat);//Get the user input value only for check for cancel if not valid              

            if ((resol <= 0) | (adjustedImage.Width < 1) | (adjustedImage.Height < 1) | (w < 1) | (h < 1))
            {
                MessageBox.Show("Check width, height and resolution values.", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(tbFeedRate.Text) < 1)
            {
                MessageBox.Show("Check feedrate value.", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            Int32 lin;//top/botom pixel
            Int32 col;//Left/right pixel

            lblStatus.Text="Generating file...";
            Refresh();

            List<string> fileLines;
            fileLines = new List<string>();
            //S or Z use as power command
            if (rbUseS.Checked) szChar = comboBoxOnCode.Text; else szChar = "Z";


            //first Gcode line
            line = "(Generated by 3dpBurner Image2Gcode " + ver+")";
            fileLines.Add(line);
            line="(@"+DateTime.Now.ToString("MMM/dd/yyy HH:mm:ss)");
            fileLines.Add(line);



            line = comboBoxOffCode.Text + "\r\n";//Make sure laser off
            fileLines.Add(line);

            //Add the pre-Gcode lines
            lastX = -1;//reset last positions
            lastY = -1;
            lastSz = -1;
            foreach(string s in rtbPreGcode.Lines)
            {
                fileLines.Add(s);
            }
            line = "G90\r\n";//Absolute coordinates
            fileLines.Add(line);

            if (imperialinToolStripMenuItem.Checked) line = "G20\r\n";//Imperial units
                else line = "G21\r\n";//Metric units
            fileLines.Add(line);
            line = "F" + tbFeedRate.Text + "\r\n";//Feedrate
            fileLines.Add(line);

            //Generate picture Gcode
            Int32 pixTot = adjustedImage.Width * adjustedImage.Height;
            Int32 pixBurned = 0;
            //////////////////////////////////////////////
            // Generate Gcode lines by Horizontal scanning
            //////////////////////////////////////////////
            if (cbEngravingPattern.Text == "Horizontal scanning")
            {
                //Travel from modelOrigin to top left
                line = modelOrigin();
                fileLines.Add(line);
                //Goto rapid move to left top corner
                line = "G0 X0 Y" + string.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.###}", adjustedImage.Height * Convert.ToSingle(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat));
                fileLines.Add(line);
                line = "G1";//G1 mode
                fileLines.Add(line);
                line = comboBoxOnCode.Text + "0";
                fileLines.Add(line);
                //line = "M106\r";//Switch laser on
                //fileLines.Add(line);

                //Start image
                lin = adjustedImage.Height - 1;//top tile
                col = 0;//Left pixel
                while (lin >= 0)
                {
                    //Y coordinate
                    coordY = resol * (float)lin;
                    while (col < adjustedImage.Width)//From left to right
                    {
                        //X coordinate
                        coordX = resol * (float)col;
                        //Power value
                        Color cl = adjustedImage.GetPixel(col, (adjustedImage.Height - 1) - lin);//Get pixel color

                        sz = (255 - (cl.R + cl.G +cl.B) / 3) * (cl.A/255);

                        sz = interpolate(sz, float.Parse(tbLaserMin.Text), float.Parse(tbLaserMax.Text));
                        //sz = interpolate(sz, Convert.ToInt32(tbLaserMax.Text), Convert.ToInt32(tbLaserMax.Text));

                        if(cbOptimizedRaster.Checked && sz < float.Parse(tbThreshold.Text)/100 * float.Parse(tbLaserMax.Text))
                        {
                            sz = 0;
                        }

                        if (!cbLaserDecimal.Checked) { sz = Convert.ToInt32(sz); } //Converts float to int if decimals are not desired

                        //Preparing for power change, we need coordinate just before so set flag to false
                        if (sz != lastSz)
                        {
                            deleteThisLine = false;
                        }

                        generateLine();
                        pixBurned++;
                        //adjustedImage.SetPixel(col, (adjustedImage.Height-1)-lin, Color.Red);
                        //pictureBox1.Image = adjustedImage;
                        //Refresh();

                        if (!string.IsNullOrEmpty(line)) fileLines.Add(line);
                        generateMLine();
                        if (!string.IsNullOrEmpty(line)) fileLines.Add(line);
                        lastX = coordX;
                        lastY = coordY;
                        lastSz = sz;
                        col++;
                    }
                    col--;
                    lin--;
                    coordY = resol * (float)lin;
                    while ((col >= 0) & (lin >= 0))//From right to left
                    {
                        //X coordinate
                        coordX = resol * (float)col;
                        //Power value
                        Color cl = adjustedImage.GetPixel(col, (adjustedImage.Height - 1) - lin);//Get pixel color
                        
                        
                        sz = (255 - (cl.R + cl.G + cl.B) / 3) * (cl.A / 255);


                        sz = interpolate(sz, float.Parse(tbLaserMin.Text), float.Parse(tbLaserMax.Text));
                        //sz = interpolate(sz, Convert.ToInt32(tbLaserMin.Text), Convert.ToInt32(tbLaserMax.Text));

                        if (cbOptimizedRaster.Checked && sz < float.Parse(tbThreshold.Text) / 100 * float.Parse(tbLaserMax.Text))
                        {
                            sz = 0;
                        }

                        if (!cbLaserDecimal.Checked) { sz = Convert.ToInt32(sz); }

                        //Preparing for power change, we need coordinate just before so set flag to false
                        if (sz != lastSz)
                        {
                            deleteThisLine = false;
                        }

                        generateLine();
                        pixBurned++;
                        //adjustedImage.SetPixel(col, (adjustedImage.Height-1)-lin, Color.Red);
                        //pictureBox1.Image = adjustedImage;
                        //Refresh();

                        if (!string.IsNullOrEmpty(line)) fileLines.Add(line);
                        generateMLine();
                        if (!string.IsNullOrEmpty(line)) fileLines.Add(line);
                        lastX = coordX;
                        lastY = coordY;
                        lastSz = sz;
                        col--;
                    }
                    col++;
                    lin--;
                    lblStatus.Text = "Generating file... " + Convert.ToString((pixBurned*100)/pixTot ) + "%";
                    Refresh();
                }

            }
            //////////////////////////////////////////////
            // Generate Gcode lines by Diagonal scanning
            //////////////////////////////////////////////
            else
            {
                //Travel from modelOrigin to top left
                line = modelOrigin();
                fileLines.Add(line);
                //Goto rapid move to left top corner
                line = "G0 X0 Y0";
                fileLines.Add(line);
                line = "G1";//G1 mode
                fileLines.Add(line);
                line = comboBoxOnCode.Text + "0";
                fileLines.Add(line);
                //line = "M106\r";//Switch laser on
                //fileLines.Add(line);

                //Start image
                col = 0;
                lin = 0;
            while((col<adjustedImage.Width)|(lin<adjustedImage.Height))          
            {
                while ((col < adjustedImage.Width)&(lin>=0))
                {
                    //Y coordinate
                    coordY = resol * (float)lin;
                    //X coordinate
                    coordX = resol * (float)col;

                    //Power value
                    Color cl = adjustedImage.GetPixel(col, (adjustedImage.Height - 1) - lin);//Get pixel color
                    sz = (255 - (cl.R + cl.G + cl.B) / 3) * (cl.A / 255);


                    sz = interpolate(sz, float.Parse(tbLaserMin.Text), float.Parse(tbLaserMax.Text));
                    //sz = interpolate(sz, Convert.ToInt32(tbLaserMin.Text), Convert.ToInt32(tbLaserMax.Text));

                    if (!cbLaserDecimal.Checked) { sz = Convert.ToInt32(sz); }

                        //Preparing for power change, we need coordinate just before so set flag to false
                        if (sz != lastSz)
                    {
                      deleteThisLine = false;
                    }

                    generateLine();
                    pixBurned++;

                    //adjustedImage.SetPixel(col, (adjustedImage.Height-1)-lin, Color.Red);
                    //pictureBox1.Image = adjustedImage;
                    //Refresh();

                    if (!string.IsNullOrEmpty(line)) fileLines.Add(line);
                    generateMLine();
                    if (!string.IsNullOrEmpty(line)) fileLines.Add(line);
                    lastX = coordX;
                    lastY = coordY;
                    lastSz = sz;

                    col++;
                    lin--;
                }
                col--;
                lin++;

                if (col >= adjustedImage.Width-1) lin++;
                else col++;
                 while ((col >=0)&(lin<adjustedImage.Height))
                {
                    //Y coordinate
                    coordY = resol * (float)lin;
                    //X coordinate
                    coordX = resol * (float)col;

                    //Power value
                    Color cl = adjustedImage.GetPixel(col, (adjustedImage.Height - 1) - lin);//Get pixel color
                    sz = (255 - (cl.R + cl.G + cl.B) / 3) * (cl.A / 255);


                    sz = interpolate(sz, float.Parse(tbLaserMin.Text), float.Parse(tbLaserMax.Text));
                    //sz = interpolate(sz, Convert.ToInt32(tbLaserMin.Text), Convert.ToInt32(tbLaserMax.Text));

                    if (!cbLaserDecimal.Checked) { sz = Convert.ToInt32(sz); }
                        
                    //Preparing for power change, we need coordinate just before so set flag to false
                    if (sz != lastSz)
                        {
                            deleteThisLine = false;
                        }

                        generateLine();
                    pixBurned++;
                    
                    //adjustedImage.SetPixel(col, (adjustedImage.Height-1)-lin, Color.Red);
                    //pictureBox1.Image = adjustedImage;
                   // Refresh();

                    if (!string.IsNullOrEmpty(line)) fileLines.Add(line);
                    generateMLine();
                    if (!string.IsNullOrEmpty(line)) fileLines.Add(line);
                    lastX = coordX;
                    lastY = coordY;
                    lastSz = sz;

                    col--;
                    lin++;
                }
                 col++;
                 lin--;
                 if (lin >= adjustedImage.Height-1) col++;
                 else lin++;
                 lblStatus.Text = "Generating file... " + Convert.ToString((pixBurned * 100) / pixTot) + "%"; 
                 Refresh();
            }


            }
            //Edge lines
            if (cbEdgeLines.Checked)
            {
                line = comboBoxOffCode.Text +"\r";
                fileLines.Add(line);
                line = "G0 X0 Y0\r";
                fileLines.Add(line);
                line = szChar + tbLaserMax.Text + "\r";
                fileLines.Add(line);
                line = "G1 X0 Y"+string.Format(CultureInfo.InvariantCulture.NumberFormat,"{0:0.###}",(adjustedImage.Height-1)*resol)+"\r";
                fileLines.Add(line);
                line = "G1 X" + string.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.###}", (adjustedImage.Width - 1) * resol) + " Y" +string.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.###}",(adjustedImage.Height - 1) * resol) + "\r";
                fileLines.Add(line);
                line = "G1 X" + string.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.###}",(adjustedImage.Width - 1)*resol) + " Y0\r";
                fileLines.Add(line);
                line = "G1 X0 Y0\r";
                fileLines.Add(line);
            }
            //Switch laser off
            line = comboBoxOffCode.Text + "\r";//G1 mode
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
            lblStatus.Text = "Done (" + Convert.ToString(pixBurned) + "/" + Convert.ToString(pixTot)+")";
        }
        //Horizontal mirroring
        private void btnHorizMirror_Click(object sender, EventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            lblStatus.Text = "Mirroring...";
            Refresh();
            adjustedImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            originalImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Image = adjustedImage;
            lblStatus.Text = "Done";
        }
        //Vertical mirroing
        private void btnVertMirror_Click(object sender, EventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            lblStatus.Text = "Mirroring...";
            Refresh();
            adjustedImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
            originalImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Image = adjustedImage;
            lblStatus.Text = "Done";
        }
        //Rotate right
        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            lblStatus.Text = "Rotating...";
            Refresh();
            adjustedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            originalImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            ratio = 1 / ratio;
            string s = tbHeight.Text;
            tbHeight.Text = tbWidth.Text;
            tbWidth.Text = s;
            pictureBox1.Image = adjustedImage;
            autoZoomToolStripMenuItem_Click(this, null);
            lblStatus.Text = "Done";
        }
        //Rotate left
        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            lblStatus.Text = "Rotating...";
            Refresh();
            adjustedImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            originalImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            ratio = 1 / ratio;
            string s = tbHeight.Text;
            tbHeight.Text = tbWidth.Text;
            tbWidth.Text = s;
            pictureBox1.Image = adjustedImage;
            autoZoomToolStripMenuItem_Click(this, null);
            lblStatus.Text = "Done";
        }
        //Invert image color
        private void btnInvert_Click(object sender, EventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            adjustedImage = imgInvert(adjustedImage);
            originalImage= imgInvert(originalImage);
            pictureBox1.Image = adjustedImage;
        }

        private void cbDirthering_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            if (cbDirthering.Text == "Dirthering FS 1 bit")
            {
                lblStatus.Text = "Dithering...";
                adjustedImage = imgDirther(adjustedImage);
                pictureBox1.Image = adjustedImage;
                lblStatus.Text = "Done";
            }
            else
                userAdjust();
        }
        //Feedrate Text changed
        private void tbFeedRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Prevent any not allowed char
            if (!checkDigitInteger(e.KeyChar))
            {
                e.Handled = true;//Stop the character from being entered into the control since it is non-numerical.
                return;
            }
        }
        //Metric units selected
        private void metricmmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imperialinToolStripMenuItem.Checked = false;
            gbDimensions.Text = "Output (mm)";
            lblFeedRateUnits.Text = "mm/min";
        }
        //Imperial unitsSelected
        private void imperialinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metricmmToolStripMenuItem.Checked = false;
            gbDimensions.Text = "Output (in)";
            lblFeedRateUnits.Text = "in/min";
        }
        //About dialog
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frmAbout = new Form2();
            frmAbout.ShowDialog();
        }
        //Preview AutoZoom
        private void autoZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autoZoomToolStripMenuItem.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Width = panel1.Width;
                pictureBox1.Height = panel1.Height;
                pictureBox1.Top = 0;
                pictureBox1.Left = 0;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                if (pictureBox1.Width > panel1.Width) pictureBox1.Left = 0; else pictureBox1.Left = (panel1.Width / 2) - (pictureBox1.Width / 2);
                if (pictureBox1.Height > panel1.Height) pictureBox1.Top = 0; else pictureBox1.Top = (panel1.Height / 2) - (pictureBox1.Height / 2);
            }
        }
        //Laser Min keyPress
        private void tbLaserMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            ////Prevent any not allowed char
            //if (!checkDigitInteger(e.KeyChar))
            //{
            //    e.Handled = true;//Stop the character from being entered into the control since it is non-numerical.
            //    return;
            //}

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        //Laser Max keyPress
        private void tbLaserMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            ////Prevent any not allowed char
            //if (!checkDigitInteger(e.KeyChar))
            //{
            //    e.Handled = true;//Stop the character from being entered into the control since it is non-numerical.
            //    return;
            //}
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        //OpenFile, save picture grayscaled to originalImage and save the original aspect ratio to ratio
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;//if no image, do nothing
                if (!File.Exists(openFileDialog1.FileName)) return;
                lblStatus.Text = "Opening file...";
                Refresh();
                tBarBrightness.Value = 0;
                tBarContrast.Value = 0;
                tBarGamma.Value = 100;
                lblBrightness.Text = Convert.ToString(tBarBrightness.Value);
                lblContrast.Text = Convert.ToString(tBarContrast.Value);
                lblGamma.Text = Convert.ToString(tBarGamma.Value / 100.0f);
                originalImage = new Bitmap(Image.FromFile(openFileDialog1.FileName));
                originalImage = imgGrayscale(originalImage);
                adjustedImage = new Bitmap(originalImage);
                ratio = (originalImage.Width + 0.0f) / originalImage.Height;//Save ratio for future use if needled
                if (cbLockRatio.Checked) tbHeight.Text = Convert.ToString((Convert.ToSingle(tbWidth.Text) / ratio), CultureInfo.InvariantCulture.NumberFormat);//Initialize y size
                userAdjust();
                lblStatus.Text = "Done";
                string fN = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                saveFileDialog1.FileName = fN + ".gco";
            }
            catch (Exception err)
            {
                MessageBox.Show("Error opening file: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Exit Menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        //On form closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
        }

        private void rbUseS_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxOnCode.Visible = true;
            groupBoxOffCode.Visible = true;
        }

        private void rbUseZ_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxOnCode.Visible = false;
            groupBoxOffCode.Visible = false;
        }
        private void rbMax_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMax.Checked)
            {
                tbLaserMax.Text = "255";
            }
        }
        private void rbWood_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWood.Checked)
            {
                int err = 0;
                if (int.TryParse(tbWoodPower.Text, out err))
                {
                    tbLaserMax.Text = Convert.ToString(255 * int.Parse(tbWoodPower.Text) / 100);
                }

                if (cbFeedOverride.Checked)
                {
                    tbFeedRate.Text = tbWoodFeed.Text;
                }
            }
        }

        private void rbLeather_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLeather.Checked)
            {
                int err = 0;
                if (int.TryParse(tbLeatherPower.Text, out err))
                {
                    tbLaserMax.Text = Convert.ToString(255 * int.Parse(tbLeatherPower.Text) / 100);
                }
                if (cbFeedOverride.Checked)
                {
                    tbFeedRate.Text = tbLeatherFeed.Text;
                }
            }
        }

        private void rbAA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAA.Checked)
            {
                int err = 0;
                if (int.TryParse(tbAAPower.Text, out err))
                {
                    tbLaserMax.Text = Convert.ToString(255 * int.Parse(tbAAPower.Text) / 100);
                }
                if (cbFeedOverride.Checked)
                {
                    tbFeedRate.Text = tbAAFeed.Text;
                }
            }
        }

        private void tbWoodPower_TextChanged(object sender, EventArgs e)
        {
            if (rbWood.Checked)
            {
                int err = 0;
                if (int.TryParse(tbWoodPower.Text, out err))
                {
                    tbLaserMax.Text = Convert.ToString(255 * int.Parse(tbWoodPower.Text) / 100);
                }

            }
        }

        private void tbLeatherPower_TextChanged(object sender, EventArgs e)
        {
            if (rbLeather.Checked)
            {
                int err = 0;
                if (int.TryParse(tbLeatherPower.Text, out err))
                {
                    tbLaserMax.Text = Convert.ToString(255 * int.Parse(tbLeatherPower.Text) / 100);
                }

            }
        }

        private void tbAAPower_TextChanged(object sender, EventArgs e)
        {
            if (rbAA.Checked)
            {
                int err = 0;
                if (int.TryParse(tbAAPower.Text, out err))
                {
                    tbLaserMax.Text = Convert.ToString(255 * int.Parse(tbAAPower.Text) / 100);
                }

            }
        }

        private void cbOptimizedRaster_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOptimizedRaster.Checked)
            {
                cbEngravingPattern.Text="Horizontal scanning";
                tbThreshold.Enabled = true;
            }
            else
            {
                tbThreshold.Enabled = false;
            }
        }

        private void tbThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbThreshold_TextChanged(object sender, EventArgs e)
        {

            int num;

            if (!int.TryParse(tbThreshold.Text, out num))
            {
                num = 0;
                //MessageBox.Show("Please enter a whole number between 0 and 100.");
                tbThreshold.Text = "0";
            }

            if (int.TryParse(tbThreshold.Text, out num))
            {
                if (Int16.Parse(tbThreshold.Text) > 100)
                {
                    MessageBox.Show("Please enter a whole number between 0 and 100.");
                    tbThreshold.Text = "100";
                }
            }
        }
    }
}
