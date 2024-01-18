// Developed by Donis Abraham
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Drawing;
using SeekOrigin = System.IO.SeekOrigin;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace ImageResizer
{
    public partial class frmImgResizer : Form
    {
        private bool mouseDrag = false;
        private bool cropStart = false;
        private AppConfig config;
        private int cropWidth;
        private int cropHeight;
        System.Drawing.Rectangle cropArea;
        System.Drawing.Pen cropPen = new System.Drawing.Pen(System.Drawing.Color.YellowGreen, 3);
        int initialMouseX = 0;
        int initialMouseY = 0;
        SixLabors.ImageSharp.Image? originalImage;
        SixLabors.ImageSharp.Image? workImage;
        SixLabors.ImageSharp.Image? croppedImage;
        SixLabors.ImageSharp.Image? canvasImage;
        string inputImgName = "";
        private string source;
        private string destination;
        public frmImgResizer()
        {
            InitializeComponent();
            /*width_txt.Enabled = false;
            height_txt.Enabled = false;*/
            source_txt.Enabled = false;
            /*            destination_txt.Enabled = false;
            */
            config = new AppConfig();
            source = config.source;
            destination = config.destination;
            string cropWidthstr = config.width;
            string cropHeightstr = config.height;
            cropWidth = int.Parse(cropWidthstr);
            cropHeight = int.Parse(cropHeightstr);
            source_txt.Text = source.ToString();
            /*            destination_txt.Text = destination.ToString();
            */            /*width_txt.Text = cropWidth.ToString();
                        height_txt.Text = cropHeight.ToString();*/
        }
        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            pBImgIn.Image = null;
            cropStart = false;
            inputImgName = "";
            initialMouseX = 0;
            initialMouseY = 0;
            mouseDrag = false;
            btnCrop.Enabled = true;
            pBImgIn.SizeMode = PictureBoxSizeMode.CenterImage;
            pBImgIn.Refresh();
            OpenFileDialog inputFile = new OpenFileDialog();
            inputFile.InitialDirectory = @source;
            inputFile.Filter = "JPG Files (*.jpg)|*.jpg";
            inputFile.Multiselect = false;
            if (DialogResult.OK == inputFile.ShowDialog())
            {
                originalImage = SixLabors.ImageSharp.Image.Load(inputFile.FileName);
                inputImgName = inputFile.SafeFileName;
                if (originalImage.Width < cropWidth)
                {
                    SixLabors.ImageSharp.Image? tempImage;
                    tempImage = originalImage.Clone(x => x.Crop(originalImage.Width, originalImage.Height));
                    /*tempImage.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new SixLabors.ImageSharp.Size(cropWidth *2, cropHeight *2),
                        Sampler = KnownResamplers.Bicubic
                    })); //*/
                    canvas(tempImage);
                    /*         width_txt.Text = tempImage.Width.ToString();
                             height_txt.Text = tempImage.Height.ToString();*/

                }
                else
                {
                    align(originalImage);
                    /* width_txt.Text = originalImage.Width.ToString();
                     height_txt.Text = originalImage.Height.ToString();*/
                }
            }
        }
        private void align(SixLabors.ImageSharp.Image finalimage)
        {
            int workImgWidth = 0;
            int workImgHeight = 0;
            if (finalimage != null)
            {
                if (finalimage.Width > (cropWidth * 2))
                {
                    workImgWidth = cropWidth * 2;
                    workImgHeight = Convert.ToInt32((float)workImgWidth * ((float)finalimage.Height / (float)finalimage.Width));
                    if (workImgHeight > (cropHeight * 2))
                    {
                        workImgWidth = Convert.ToInt32((cropHeight * 2) * ((float)workImgWidth / (float)workImgHeight));
                        workImgHeight = cropHeight * 2;
                    }
                }
                else if (finalimage.Height > (cropHeight * 2))
                {
                    workImgHeight = cropHeight * 2;
                    workImgWidth = Convert.ToInt32(workImgHeight * ((float)finalimage.Width / (float)finalimage.Height));
                    if (workImgWidth > (cropWidth * 2))
                    {
                        workImgHeight = Convert.ToInt32((cropWidth * 2) * ((float)workImgHeight / (float)workImgWidth));
                        workImgWidth = cropWidth * 2;
                    }
                }
                else
                {
                    workImgWidth = finalimage.Width;
                    workImgHeight = finalimage.Height;
                }

                filename_view.Text = inputImgName;
                workImage = finalimage.Clone(x => x.Crop(finalimage.Width, finalimage.Height));
                workImage.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new SixLabors.ImageSharp.Size(workImgWidth, workImgHeight),
                    Sampler = KnownResamplers.Bicubic
                })); //
                MemoryStream workImgStream = new MemoryStream();
                workImage.SaveAsJpeg(workImgStream, new JpegEncoder() { Quality = 100 });
                pBImgIn.Image = System.Drawing.Image.FromStream(workImgStream); //inputImg;
                originalImage = finalimage.Clone(x => x.Crop(finalimage.Width, finalimage.Height));
            }
        }
        private void pBImgIn_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDrag)
            {
                cropArea.X = cropArea.X + (e.X - initialMouseX);
                cropArea.Y = cropArea.Y + (e.Y - initialMouseY);

                if (cropArea.Y < (pBImgIn.Height / 2 - pBImgIn.Image.Height / 2))
                {
                    cropArea.Y = (pBImgIn.Height / 2 - pBImgIn.Image.Height / 2);
                }
                if ((cropArea.Y + cropHeight) > (pBImgIn.Height / 2 + pBImgIn.Image.Height / 2))
                {
                    cropArea.Y = (pBImgIn.Height / 2 + pBImgIn.Image.Height / 2) - cropHeight;
                }
                if (cropArea.X < (pBImgIn.Width / 2 - pBImgIn.Image.Width / 2))
                {
                    cropArea.X = (pBImgIn.Width / 2 - pBImgIn.Image.Width / 2);
                }
                if ((cropArea.X + cropWidth) > (pBImgIn.Width / 2 + pBImgIn.Image.Width / 2))
                {
                    cropArea.X = (pBImgIn.Width / 2 + pBImgIn.Image.Width / 2) - cropWidth;
                }
                initialMouseX = e.X;
                initialMouseY = e.Y;
                pBImgIn.Refresh();
                pBImgIn.CreateGraphics().DrawRectangle(cropPen, cropArea);
                crop();
            }
        }
        private void pBImgIn_MouseDown(object sender, MouseEventArgs e)
        {
            if (pBImgIn.Image != null)
            {
                if (System.Windows.Forms.Control.ModifierKeys == Keys.Control)
                {
                    cropStart = false;
                    mouseDrag = false;
                }
                else
                {
                    pBImgIn.Refresh();
                    if (initialMouseX == 0 || initialMouseY == 0)
                    {
                        initialMouseX = e.X;
                        initialMouseY = e.Y;
                        if (initialMouseY / 2 < (pBImgIn.Height / 2 - pBImgIn.Image.Height / 2))
                        {
                            initialMouseY = ((pBImgIn.Height / 2 - pBImgIn.Image.Height / 2)) * 2;
                        }
                        if ((cropArea.Y + cropHeight) > (pBImgIn.Height / 2 + pBImgIn.Image.Height / 2))
                        {
                            initialMouseY = (pBImgIn.Height / 2 + pBImgIn.Image.Height / 2) - cropHeight;
                        }
                        if (initialMouseX / 2 < (pBImgIn.Width / 2 - pBImgIn.Image.Width / 2))
                        {
                            initialMouseX = ((pBImgIn.Width / 2 - pBImgIn.Image.Width / 2) * 2);
                        }
                        if ((cropArea.X + cropWidth) > (pBImgIn.Width / 2 + pBImgIn.Image.Width / 2))
                        {
                            initialMouseX = (pBImgIn.Width / 2 + pBImgIn.Image.Width / 2) - cropWidth;
                        }
                        cropArea = new System.Drawing.Rectangle(initialMouseX / 2, initialMouseY / 2, cropWidth, cropHeight);
                    }
                    else
                    {
                        cropArea.X = cropArea.X + (e.X - initialMouseX);
                        cropArea.Y = cropArea.Y + (e.Y - initialMouseY);
                        initialMouseX = e.X;
                        initialMouseY = e.Y;
                        if (cropArea.Y < (pBImgIn.Height / 2 - pBImgIn.Image.Height / 2))
                        {
                            cropArea.Y = (pBImgIn.Height / 2 - pBImgIn.Image.Height / 2);
                        }
                        if ((cropArea.Y + cropHeight) > (pBImgIn.Height / 2 + pBImgIn.Image.Height / 2))
                        {
                            cropArea.Y = (pBImgIn.Height / 2 + pBImgIn.Image.Height / 2) - cropHeight;
                        }
                        if (cropArea.X < (pBImgIn.Width / 2 - pBImgIn.Image.Width / 2))
                        {
                            cropArea.X = (pBImgIn.Width / 2 - pBImgIn.Image.Width / 2);
                        }
                        if ((cropArea.X + cropWidth) > (pBImgIn.Width / 2 + pBImgIn.Image.Width / 2))
                        {
                            cropArea.X = (pBImgIn.Width / 2 + pBImgIn.Image.Width / 2) - cropWidth;
                        }
                    }
                    pBImgIn.CreateGraphics().DrawRectangle(cropPen, cropArea);
                    mouseDrag = true;
                    cropStart = true;
                }
            }
        }
        private void frmImgResizer_Load(object sender, EventArgs e)
        {
            btnCrop.Enabled = false;
            int cropWidth = 241;
            int cropHeight = 189;
            pBImgIn.Image = null;
            inputImgName = "";
            initialMouseX = 0;
            initialMouseY = 0;
            mouseDrag = false;
            pBImgIn.SizeMode = PictureBoxSizeMode.CenterImage;
            pBImgIn.Refresh();
            cropArea = new System.Drawing.Rectangle(0, 0, cropWidth, cropHeight);
        }
        private void save()
        {
            MemoryStream currentImgStream = new MemoryStream();
            previewBox.Image.Save(currentImgStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            if (currentImgStream != null)
            {
                currentImgStream.Seek(0, SeekOrigin.Begin);
                SixLabors.ImageSharp.Image currentImg = SixLabors.ImageSharp.Image.Load(currentImgStream);
                currentImg.Metadata.HorizontalResolution = 200;
                currentImg.Metadata.VerticalResolution = 200;
                currentImg.SaveAsJpeg(destination + "\\" + inputImgName.Replace(".jpg", "") + "_Cropped.jpg", new JpegEncoder() { Quality = 100 });
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            btnCrop.Enabled = false;
            cropStart = false;
            pBImgIn.Image = null;
            inputImgName = "";
            initialMouseX = 0;
            initialMouseY = 0;
            mouseDrag = false;
            pBImgIn.Refresh();
            previewBox.Image = null;
            filename_view.Text = null;
            previewBox.Refresh();
            workImage = null;
            originalImage = null;
            croppedImage = null;
            canvasImage = null;
        }
        private void PBImgIn_MouseWheel(object sender, MouseEventArgs e)
        {
            pBImgIn.SizeMode = PictureBoxSizeMode.CenterImage;
            int newWidth = 0;
            int newHeight = 0;
            if (originalImage != null)
            {
                SixLabors.ImageSharp.Image currentImg = originalImage.Clone(x => x.Crop(originalImage.Width, originalImage.Height));
                if (e.Delta > 0 && System.Windows.Forms.Control.ModifierKeys == Keys.None)
                {
                    newWidth = pBImgIn.Image.Width + ((pBImgIn.Image.Width * 3) / 100);
                    newHeight = pBImgIn.Image.Height + ((pBImgIn.Image.Height * 3) / 100);
                    currentImg.Mutate(x => x
                    .Resize(new ResizeOptions
                    {
                        Size = new SixLabors.ImageSharp.Size(newWidth, newHeight),
                        Sampler = KnownResamplers.Bicubic
                    }));

                }
                else if (e.Delta < 0 && System.Windows.Forms.Control.ModifierKeys == Keys.None)
                {
                    if (pBImgIn.Image.Width - ((pBImgIn.Image.Width * 3) / 100) < 241)
                    {
                        newWidth = 241;
                    }
                    else if (pBImgIn.Image.Height - ((pBImgIn.Image.Height * 3) / 100) < 189)
                    {
                        newHeight = 189;
                    }
                    else
                    {
                        newWidth = pBImgIn.Image.Width - ((pBImgIn.Image.Width * 3) / 100);
                        newHeight = pBImgIn.Image.Height - ((pBImgIn.Image.Height * 3) / 100);
                    }
                    currentImg.Mutate(x => x
                    .Resize(new ResizeOptions
                    {
                        Size = new SixLabors.ImageSharp.Size(newWidth, newHeight),
                        Sampler = KnownResamplers.Bicubic

                    }));

                }
                else if (e.Delta > 0 && System.Windows.Forms.Control.ModifierKeys == Keys.Control)
                {
                    newWidth = pBImgIn.Image.Width + ((pBImgIn.Image.Width * 1) / 100);
                    newHeight = pBImgIn.Image.Height + ((pBImgIn.Image.Height * 1) / 100);
                    currentImg.Mutate(x => x
                    .Resize(new ResizeOptions
                    {
                        Size = new SixLabors.ImageSharp.Size(newWidth, newHeight),
                        Sampler = KnownResamplers.Bicubic

                    }));
                }
                else if (e.Delta < 0 && System.Windows.Forms.Control.ModifierKeys == Keys.Control)
                {
                    if (pBImgIn.Image.Width - ((pBImgIn.Image.Width * 1) / 100) < 241)
                    {
                        newWidth = 241;
                    }
                    else
                    {
                        newWidth = pBImgIn.Image.Width - ((pBImgIn.Image.Width * 1) / 100);
                    }
                    if (pBImgIn.Image.Height - ((pBImgIn.Image.Height * 1) / 100) < 189)
                    {
                        newHeight = 189;
                    }
                    else
                    {
                        newHeight = pBImgIn.Image.Height - ((pBImgIn.Image.Height * 1) / 100);
                    }
                    currentImg.Mutate(x => x
                    .Resize(new ResizeOptions
                    {
                        Size = new SixLabors.ImageSharp.Size(newWidth, newHeight),
                        Sampler = KnownResamplers.Bicubic
                    }));
                }
                MemoryStream newImgStream = new MemoryStream();
                currentImg.SaveAsJpeg(newImgStream, new JpegEncoder() { Quality = 100 });
                System.Drawing.Image newImg = System.Drawing.Image.FromStream(newImgStream); //inputImg;
                pBImgIn.SizeMode = PictureBoxSizeMode.CenterImage;
                pBImgIn.Width = newImg.Width;
                pBImgIn.Height = newImg.Height;
                pBImgIn.SizeMode = PictureBoxSizeMode.CenterImage;
                pBImgIn.Refresh();
                pBImgIn.Image = newImg;
                if (cropStart)
                {
                    if (cropArea.Y < (pBImgIn.Height / 2 - pBImgIn.Image.Height / 2))
                    {
                        cropArea.Y = (pBImgIn.Height / 2 - pBImgIn.Image.Height / 2);
                    }
                    if ((cropArea.Y + cropHeight) > (pBImgIn.Height / 2 + pBImgIn.Image.Height / 2))
                    {
                        cropArea.Y = (pBImgIn.Height / 2 + pBImgIn.Image.Height / 2) - cropHeight;
                    }
                    if (cropArea.X < (pBImgIn.Width / 2 - pBImgIn.Image.Width / 2))
                    {
                        cropArea.X = (pBImgIn.Width / 2 - pBImgIn.Image.Width / 2);
                    }
                    if ((cropArea.X + cropWidth) > (pBImgIn.Width / 2 + pBImgIn.Image.Width / 2))
                    {
                        cropArea.X = (pBImgIn.Width / 2 + pBImgIn.Image.Width / 2) - cropWidth;
                    }
                    pBImgIn.Refresh();
                    pBImgIn.CreateGraphics().DrawRectangle(cropPen, cropArea);
                }
            }
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void crop()
        {
            if ((pBImgIn.Image.Width >= cropWidth) && (pBImgIn.Image.Height >= cropHeight))
            {
                MemoryStream currentImgStream = new MemoryStream();
                pBImgIn.Image.Save(currentImgStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (currentImgStream != null)
                {
                    currentImgStream.Seek(0, SeekOrigin.Begin);
                    SixLabors.ImageSharp.Image currentImg = SixLabors.ImageSharp.Image.Load(currentImgStream);
                    int cloneX = cropArea.X - ((pBImgIn.Width / 2) - (pBImgIn.Image.Width / 2));
                    int cloneY = cropArea.Y - ((pBImgIn.Height / 2) - (pBImgIn.Image.Height / 2));
                    if (cloneX < 0)
                    {
                        cloneX = 0;
                    }
                    if (cloneY < 0)
                    {
                        cloneY = 0;
                    }
                    SixLabors.ImageSharp.Image finalImage = currentImg.Clone(x => x.Crop(new SixLabors.ImageSharp.Rectangle(cloneX, cloneY, cropWidth, cropHeight)));
                    MemoryStream finalImgStream = new MemoryStream();
                    finalImage.SaveAsJpeg(finalImgStream, new JpegEncoder() { Quality = 100 });
                    pBImgIn.Width = finalImage.Width;
                    pBImgIn.Height = finalImage.Height;
                    previewBox.Image = System.Drawing.Image.FromStream(finalImgStream); //inputImg;
                    previewBox.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }

        }
        private void btnCrop_Click(object sender, EventArgs e)
        {
            save();
            clear();
        }
        private void pBImgIn_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseDrag)
            {
                mouseDrag = false;
            }
        }
        private void add_canvas_Click(object sender, EventArgs e)
        {
            if (pBImgIn.Image != null)
            {
                MemoryStream currentImgStream = new MemoryStream();
                pBImgIn.Image.Save(currentImgStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (currentImgStream != null)
                {
                    currentImgStream.Seek(0, SeekOrigin.Begin);
                    System.Drawing.Image dummyImg = System.Drawing.Image.FromStream(currentImgStream);
                    int padding = 50;
                    int newWidth = dummyImg.Width + 100;
                    int newHeight = dummyImg.Height;
                    Bitmap newImage = new Bitmap(newWidth, newHeight);
                    using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(newImage))
                    {
                        graphics.Clear(System.Drawing.Color.Gray);
                    }
                    System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(padding, 0, dummyImg.Width, dummyImg.Height);
                    using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(newImage))
                    {
                        graphics.DrawImage(dummyImg, destRect);
                    }
                    MemoryStream finalImgStream = new MemoryStream();
                    newImage.Save(finalImgStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    finalImgStream.Seek(0, SeekOrigin.Begin);
                    SixLabors.ImageSharp.Image canvas = SixLabors.ImageSharp.Image.Load(finalImgStream);
                    align(canvas);
                }
                else
                {
                    MessageBox.Show("Please load any image!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void canvas(SixLabors.ImageSharp.Image tempimage)
        {
            MemoryStream currentImgStream = new MemoryStream();
            tempimage.SaveAsJpeg(currentImgStream, new JpegEncoder() { Quality = 100 });
            if (currentImgStream != null)
            {
                currentImgStream.Seek(0, SeekOrigin.Begin);
                System.Drawing.Image dummyImg = System.Drawing.Image.FromStream(currentImgStream);
                int padding = 50;
                int newWidth = dummyImg.Width + (cropWidth - tempimage.Width);
                int newHeight = dummyImg.Height;
                Bitmap newImage = new Bitmap(newWidth, newHeight);
                using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(newImage))
                {
                    graphics.Clear(System.Drawing.Color.Gray);
                }
                System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(padding, 0, dummyImg.Width, dummyImg.Height);
                using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(newImage))
                {
                    graphics.DrawImage(dummyImg, destRect);
                }
                MemoryStream finalImgStream = new MemoryStream();
                newImage.Save(finalImgStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                finalImgStream.Seek(0, SeekOrigin.Begin);
                SixLabors.ImageSharp.Image canvas = SixLabors.ImageSharp.Image.Load(finalImgStream);
                align(canvas);
            }
            else
            {
                MessageBox.Show("Please load any image!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void RotateBtn_Click(object sender, EventArgs e)
        {
            if (workImage != null)
            {
                workImage.Mutate(x => x.BackgroundColor(new Rgba32(0, 0, 0, 0)));
                workImage.Mutate(x => x.Rotate(90));
                MemoryStream workImgStream = new MemoryStream();
                workImage.SaveAsJpeg(workImgStream, new JpegEncoder() { Quality = 100 });
                workImgStream.Seek(0, SeekOrigin.Begin);
                SixLabors.ImageSharp.Image canvas = SixLabors.ImageSharp.Image.Load(workImgStream);
                align(canvas);
                canvas.Dispose();
                workImgStream.SetLength(0);
            }
            else
            {
                MessageBox.Show("Please load any image!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AlignLT_Click(object sender, EventArgs e)
        {
            if (workImage != null)
            {
                workImage.Mutate(x => x.BackgroundColor(new Rgba32(0, 0, 0, 0)));
                workImage.Mutate(x => x.Rotate(-1));
                MemoryStream workImgStream = new MemoryStream();
                workImage.SaveAsJpeg(workImgStream, new JpegEncoder() { Quality = 100 });
                workImgStream.Seek(0, SeekOrigin.Begin);
                SixLabors.ImageSharp.Image canvas = SixLabors.ImageSharp.Image.Load(workImgStream);
                align(canvas);
                canvas.Dispose();
                workImgStream.SetLength(0);
            }
            else
            {
                MessageBox.Show("Please load any image!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AlignRt_Click(object sender, EventArgs e)
        {
            if (workImage != null)
            {
                workImage.Mutate(x => x.BackgroundColor(new Rgba32(0, 0, 0, 0)));
                workImage.Mutate(x => x.Rotate(1));
                MemoryStream workImgStream = new MemoryStream();
                workImage.SaveAsJpeg(workImgStream, new JpegEncoder() { Quality = 100 });
                workImgStream.Seek(0, SeekOrigin.Begin);
                SixLabors.ImageSharp.Image canvas = SixLabors.ImageSharp.Image.Load(workImgStream);
                align(canvas);
                canvas.Dispose();
                workImgStream.SetLength(0);
            }
            else
            {
                MessageBox.Show("Please load any image!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bg_rm_Click(object sender, EventArgs e)
        {
            if (previewBox.Image == null)
            {
                MessageBox.Show("Please select crop area", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                MemoryStream workImgStream = new MemoryStream();
                previewBox.Image.Save(workImgStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap originalImage = new Bitmap(workImgStream);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
    }
}