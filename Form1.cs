/*Changelog since last commit:

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


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        const string ver = "v0.1development";
        Bitmap originalImage;
        Bitmap adjustedImage;
        float lastValue;//Aux for apply processing to image only when a new value is detected
        public Form1()
        {
            InitializeComponent();
        }
        float ratio; //Used to lock the aspect ratio when the option is selected
        //Image manipulatios is as follow.
        
        //-Open image copy to OriginalImage, apply grayscale and sabe into the same ogiginal image, copy originalImage to adjustedImage and display adjusted image
        
        //-Apply resice to original image by user and display
        //-Aplly Balance= user brighness, contrast and and gamma inputed by user to adjustedImage and display it
        //-Apply dirthering if selected to adjusted image and display it
        //The operations as rotate, flip and invert are apllye directly to booth originalImage and adjustedImage

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
            if (adjustedImage == null) return;//if no image, do nothing
            //Apply resize to original image
            Int32 xSize;//Total X pixels of resulting image for GCode generation
            Int32 ySize;//Total Y pixels of resulting image for GCode generation
            xSize = Convert.ToInt32(float.Parse(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat) / float.Parse(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat));
            ySize = Convert.ToInt32(float.Parse(tbHeight.Text, CultureInfo.InvariantCulture.NumberFormat) / float.Parse(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat));
            adjustedImage=imgResize(originalImage, xSize, ySize);
            //Apply balance to adjusted (resized) image
            adjustedImage = imgBalance(adjustedImage, tBarBrightness.Value, tBarContrast.Value, tBarGamma.Value);
            //Reset dirthering to adjusted (resized and balanced) image
            cbDirthering.Text = "GrayScale 8 bit";
            //Display image
            pictureBox1.Image = adjustedImage;
        }
        //Display a invalid values message
        private void invalidValue()
        {
            lblStatus.Text = "Invalid values! Check it.";
        }
        //OpenFile, save picture grayscaled to originalImage and save the original aspect ratio to ratio
        private void btnOpenFile_Click(object sender, EventArgs e)
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
            }
            catch (Exception err)
            {
                MessageBox.Show("Error opening file: "+err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        //Resolution changed by user. Update image.
        private void tbRes_TextChanged(object sender, EventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            userAdjust();
            cbPreviewZoom_CheckedChanged(this, null);
        }
        //Check if a new image width has been confirmad by user, process it.
        private void widthChangedCheck()
        {
            if (adjustedImage == null) return;//if no image, do nothing
            //Get the user input value
            float newValue=Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat);           
            newValue = Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat);

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
            userAdjust();
        }
        //Check if a new image height has been confirmad by user, process it.
        private void heightChangedCheck()
        {
            //Get the user input value
            if (adjustedImage == null) return;//if no image, do nothing
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
            userAdjust();
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
            Text = "3dpBurner Image2Gcode " + ver;
            lblStatus.Text = "Done";
            cbPreviewZoom_CheckedChanged(this, null);
        }
        //Width confirmed by user by the enter key. Check new value and backup it for compare
        private void tbWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==Convert.ToChar(13))
            {              
                widthChangedCheck();
                cbPreviewZoom_CheckedChanged(this, null);
                lastValue = Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat);
            }
        }
        //Height confirmed by user by the enter key. Check new value and backup it for compare
        private void tbHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {             
                heightChangedCheck();
                cbPreviewZoom_CheckedChanged(this, null);
                lastValue = Convert.ToSingle(tbHeight.Text, CultureInfo.InvariantCulture.NumberFormat);
            }
        }
        //Width control leave focus. Check if new value
        private void tbWidth_Leave(object sender, EventArgs e)
        {
            widthChangedCheck();
            cbPreviewZoom_CheckedChanged(this, null);
        }
        //Height control leave focus. Check if new value
        private void tbHeight_Leave(object sender, EventArgs e)
        {
            heightChangedCheck();
            cbPreviewZoom_CheckedChanged(this, null);
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
        //Generate a "minimalist" gcode line based on the actual and last coordinates and laser power
        string line;
        float coordX;//X
        float coordY;//Y
        Int32 sz;//S (or Z)
        float lastX;//Last x/y  coords for compare
        float lastY;
        Int32 lastSz;//last 'S' value for compare
        char szChar;//Use 'S' or 'Z' for test laser power
        string coordXStr;//String formated X
        string coordYStr;////String formated Y
        string szStr;////String formated S
        private void generateLine()
        {
            //Generate Gcode line
            line = "";
            if (coordX != lastX)//Add X coord to line if is diferent from previous             
            {
                coordXStr = string.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.###}", coordX);
                line += 'X' + coordXStr;
            }
            if (coordY != lastY)//Add Y coord to line if is diferent from previous
            {
                coordYStr = string.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.###}", coordY);
                line += 'Y' + coordYStr;
            }
            if (sz != lastSz)//Add power value to line if is diferent from previous
            {
                szStr = szChar + Convert.ToString(sz);
                line += szStr;
            }
        }
        //Generate button click
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            
            lblStatus.Text="Generating file...";
            Refresh();

            List<string> fileLines;
            fileLines = new List<string>();
            float resol=Convert.ToSingle(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat);//Resolution (or laser spot size)
            if (rbUseS.Checked) szChar = 'S'; else sz = 'Z';

            //first Gcode line
            line = "M5\r";//Make sure laser off
            fileLines.Add(line);

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
            line = "G0X0Y" + string.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.###}", adjustedImage.Height * Convert.ToSingle(tbRes.Text, CultureInfo.InvariantCulture.NumberFormat));
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
                while ((col >= 0)&(lin>=0))//From right to left
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
                col++;
                lin--;

                lblStatus.Text = "Generating file... " + Convert.ToString(((adjustedImage.Height - 1) - lin) * 100 / (adjustedImage.Height - 1)) + "%";
                Refresh();
            }
            //Edge lines
            if (cbEdgeLines.Checked)
            {
                line = "M5\r";
                fileLines.Add(line);
                line = "G0X0Y0\r";
                fileLines.Add(line);
                line = "M3S255\r";
                fileLines.Add(line);
                line = "G1X0Y"+string.Format(CultureInfo.InvariantCulture.NumberFormat,"{0:0.###}",(adjustedImage.Height-1)*resol)+"\r";
                fileLines.Add(line);
                line = "G1X" + string.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.###}", (adjustedImage.Width - 1) * resol) + "Y" +string.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.###}",(adjustedImage.Height - 1) * resol) + "\r";
                fileLines.Add(line);
                line = "G1X" + string.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.###}",(adjustedImage.Width - 1)*resol) + "Y0\r";
                fileLines.Add(line);
                line = "G1X0Y0\r";
                fileLines.Add(line);
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
        //Horizontal mirroing
        private void btnHorizMirror_Click(object sender, EventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            lblStatus.Text = "Mirroing...";
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
            lblStatus.Text = "Mirroing...";
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
            //tbHeight.Text = Convert.ToString((Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat) / ratio), CultureInfo.InvariantCulture.NumberFormat);//Initialize y size
            //userAdjust();
            pictureBox1.Image = adjustedImage;
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
            //tbHeight.Text = Convert.ToString((Convert.ToSingle(tbWidth.Text, CultureInfo.InvariantCulture.NumberFormat) / ratio), CultureInfo.InvariantCulture.NumberFormat);//Initialize y size
            //userAdjust();
            pictureBox1.Image = adjustedImage;
            lblStatus.Text = "Done";
        }
        //Invert image color
        private void btnInvert_Click(object sender, EventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            adjustedImage = imgInvert(adjustedImage);
            originalImage= imgInvert(originalImage);
            userAdjust();
        }

        private void cbDirthering_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (adjustedImage == null) return;//if no image, do nothing
            if (cbDirthering.Text == "Dirthering FS 1 bit")
            {
                lblStatus.Text = "Dirtering...";
                adjustedImage = imgDirther(adjustedImage);
                pictureBox1.Image = adjustedImage;
                lblStatus.Text = "Done";
            }
            else
                userAdjust();
        }
        //preview mode normal/autozoom
        private void cbPreviewZoom_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPreviewZoom.Checked)
            {
                pictureBox1.Width = panel1.Width;
                pictureBox1.Height = panel1.Height;
                pictureBox1.Top = 0;
                pictureBox1.Left = 0;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                if (pictureBox1.Width>panel1.Width) pictureBox1.Left=0; else pictureBox1.Left = (panel1.Width / 2) - (pictureBox1.Width / 2);
                if (pictureBox1.Height>panel1.Height) pictureBox1.Top=0; else pictureBox1.Top = (panel1.Height / 2) - (pictureBox1.Height / 2);

                //pictureBox1.Top = (panel1.Height / 2) - (pictureBox1.Height / 2);
                //pictureBox1.Left = (panel1.Width / 2) - (pictureBox1.Width / 2);
            }
        }







    }
}
