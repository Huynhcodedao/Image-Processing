using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using OpenCvSharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using AForge.Math;
using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using System.Linq;
using OpenCvSharp.Extensions;
using EmguMat = Emgu.CV.Mat;
using OpenCvMat = OpenCvSharp.Mat;
using Emgu.CV; // Import Emgu.CV namespace
using Emgu.CV.CvEnum;
using SysDraw = System.Drawing;
using System.Numerics;
using ServiceStack;
using Emgu.CV.Structure;
using Emgu.CV;
using TheArtOfDev.HtmlRenderer.Adapters;
using AForgeCore.Math;
using OpenCvSharp.CPlusPlus;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsProcessingimage
{

    public partial class Form1 : Form
    {

        private string username;
        private bool isMouseDown = false;
        private SysDraw.Point startPoint = SysDraw.Point.Empty;
        private SysDraw.Point endPoint = SysDraw.Point.Empty;
        private SysDraw.Rectangle selectionRect = SysDraw.Rectangle.Empty;
        private void pictureBoxAnhGoc_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                startPoint = e.Location;
                endPoint = e.Location;
                pictureBoxAnhGoc.Invalidate();
            }
        }
        private void pictureBoxAnhFilter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                startPoint = e.Location;
                endPoint = e.Location;
               pictureBoxAnhFilter.Invalidate();
            }
        }

        private void pictureBoxAnhGoc_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                endPoint = e.Location;
                pictureBoxAnhGoc.Invalidate(); // Vẽ lại PictureBox để hiển thị vùng chọn
            }
        }
        private void pictureBoxAnhFilter_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                endPoint = e.Location;
                pictureBoxAnhFilter.Invalidate(); // Vẽ lại PictureBox để hiển thị vùng chọn
            }
        }

        private void pictureBoxAnhGoc_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                isMouseDown = false;
                endPoint = e.Location;
                CropImage();
            }
        }
        private void pictureBoxAnhFilter_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                isMouseDown = false;
                endPoint = e.Location;
                CropImageFilter();
            }
        }

        private void pictureBoxAnhGoc_Paint(object sender, PaintEventArgs e)
        {
            if (isMouseDown)
            {
                // Vẽ hình chữ nhật chọn
                selectionRect = new SysDraw.Rectangle(
                    Math.Min(startPoint.X, endPoint.X),
                    Math.Min(startPoint.Y, endPoint.Y),
                    Math.Abs(startPoint.X - endPoint.X),
                    Math.Abs(startPoint.Y - endPoint.Y)
                );
                e.Graphics.DrawRectangle(Pens.Red, selectionRect);
            }
        }
        private void pictureBoxAnhFilter_Paint(object sender, PaintEventArgs e)
        {
            if (isMouseDown)
            {
                // Vẽ hình chữ nhật chọn
                selectionRect = new SysDraw.Rectangle(
                    Math.Min(startPoint.X, endPoint.X),
                    Math.Min(startPoint.Y, endPoint.Y),
                    Math.Abs(startPoint.X - endPoint.X),
                    Math.Abs(startPoint.Y - endPoint.Y)
                );
                e.Graphics.DrawRectangle(Pens.Red, selectionRect);
            }
        }

        private void CropImage()
        {
            if (selectionRect.Width > 0 && selectionRect.Height > 0)
            {
                Bitmap srcBitmap = new Bitmap(pictureBoxAnhGoc.Image);

                // Tính toán kích thước của vùng cắt
                int cropWidth = selectionRect.Width;
                int cropHeight = selectionRect.Height;

                // Đảm bảo tỷ lệ của ảnh cắt
                double originalWidth = srcBitmap.Width;
                double originalHeight = srcBitmap.Height;
                double ratioX = originalWidth / pictureBoxAnhGoc.Width;
                double ratioY = originalHeight / pictureBoxAnhGoc.Height;
                cropWidth = (int)(cropWidth * ratioX);
                cropHeight = (int)(cropHeight * ratioY);

                // Tạo ảnh cắt với kích thước phù hợp
                Bitmap croppedBitmap = new Bitmap(cropWidth, cropHeight);

                using (Graphics g = Graphics.FromImage(croppedBitmap))
                {
                    // Tính toán vùng cắt trên ảnh gốc dựa trên tỷ lệ
                    int x = (int)(selectionRect.X * ratioX);
                    int y = (int)(selectionRect.Y * ratioY);
                    System.Drawing.Rectangle cropRect = new System.Drawing.Rectangle(x, y, cropWidth, cropHeight);

                    // Vẽ ảnh cắt từ ảnh gốc vào ảnh mới
                    g.DrawImage(srcBitmap, new System.Drawing.Rectangle(0, 0, cropWidth, cropHeight), cropRect, GraphicsUnit.Pixel);
                }

                pictureBoxAnhFilter.Image = croppedBitmap; // Hiển thị ảnh đã cắt trong PictureBox khác
            }
        }
        private void CropImageFilter()
        {
            if (selectionRect.Width > 0 && selectionRect.Height > 0)
            {
                Bitmap srcBitmap = new Bitmap(pictureBoxAnhFilter.Image);

                // Tính toán kích thước của vùng cắt
                int cropWidth = selectionRect.Width;
                int cropHeight = selectionRect.Height;

                // Đảm bảo tỷ lệ của ảnh cắt
                double originalWidth = srcBitmap.Width;
                double originalHeight = srcBitmap.Height;
                double ratioX = originalWidth / pictureBoxAnhFilter.Width;
                double ratioY = originalHeight / pictureBoxAnhFilter.Height;
                cropWidth = (int)(cropWidth * ratioX);
                cropHeight = (int)(cropHeight * ratioY);

                // Tạo ảnh cắt với kích thước phù hợp
                Bitmap croppedBitmap = new Bitmap(cropWidth, cropHeight);

                using (Graphics g = Graphics.FromImage(croppedBitmap))
                {
                    // Tính toán vùng cắt trên ảnh gốc dựa trên tỷ lệ
                    int x = (int)(selectionRect.X * ratioX);
                    int y = (int)(selectionRect.Y * ratioY);
                    System.Drawing.Rectangle cropRect = new System.Drawing.Rectangle(x, y, cropWidth, cropHeight);

                    // Vẽ ảnh cắt từ ảnh gốc vào ảnh mới
                    g.DrawImage(srcBitmap, new System.Drawing.Rectangle(0, 0, cropWidth, cropHeight), cropRect, GraphicsUnit.Pixel);
                }

                pictureBoxAnhFilter.Image = croppedBitmap; // Hiển thị ảnh đã cắt trong PictureBox khác
            }
        }


        // Thêm các sự kiện cho PictureBox
        private void InitializePictureBoxEvents()
        {
            pictureBoxAnhGoc.MouseDown += pictureBoxAnhGoc_MouseDown;
            pictureBoxAnhGoc.MouseMove += pictureBoxAnhGoc_MouseMove;
            pictureBoxAnhGoc.MouseUp += pictureBoxAnhGoc_MouseUp;
            pictureBoxAnhGoc.Paint += pictureBoxAnhGoc_Paint;
        }
        private void InitializePictureBoxEvents1()
        {
            pictureBoxAnhFilter.MouseDown += pictureBoxAnhFilter_MouseDown;
            pictureBoxAnhFilter.MouseMove += pictureBoxAnhFilter_MouseMove;
            pictureBoxAnhFilter.MouseUp += pictureBoxAnhFilter_MouseUp;
            pictureBoxAnhFilter.Paint += pictureBoxAnhFilter_Paint;
        }
        public Form1(string username)
        {
            InitializeComponent();
            CenterToScreen();
            InitializePictureBoxEvents();
            InitializePictureBoxEvents1();
            this.username = username;
            lb1.Text = $"Welcome, {username}";
           
        }



        bool menuExpand = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            sidebarChucnang.Height = 0;
            groupFilter.Height = 0;
            load2.Height = 0;
            flowLayoutPanel1.Height = 0;
            sidebarLoad.Height = 0;
            txtpsnr.Visible = false;
        }

        private void menu_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuConterner.Height += 10;
                if (menuConterner.Height >= 260)
                {
                    menu.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuConterner.Height -= 10;
                if (menuConterner.Height <= 55)
                {
                    menu.Stop();
                    menuExpand = false;
                }
            }
        }
        //su kien menu
        private void btnMenu_Click(object sender, EventArgs e)
        {
            menu.Start();
        }
        bool sidebarExpand = true;

        private void slidebarTransmittion_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 49)
                {
                    sidebarExpand = false;
                    slidebarTransmittion.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 210)
                {
                    sidebarExpand = true;
                    slidebarTransmittion.Stop();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            slidebarTransmittion.Start();
        }


        //sự kiện logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // sự kiện view
        private void btnView_Click(object sender, EventArgs e)
        {
            DrawHistogram(pictureBoxAnhGoc, pictureBoxAnhFilter);
        }


        void DrawHistogram(PictureBox pictureBox, PictureBox pictureBoxFilter)
        {
            // Kiểm tra xem pictureBox có hình ảnh không
            if (pictureBox.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy hình ảnh từ PictureBox
            Bitmap image = new Bitmap(pictureBox.Image);

            // Tạo một Bitmap mới để tính toán histogram
            Bitmap histogramBitmap = new Bitmap(256, 200);

            // Tính histogram cho từng kênh màu
            int[] redHistogram = new int[256];
            int[] greenHistogram = new int[256];
            int[] blueHistogram = new int[256];

            // Đi qua từng pixel trong ảnh và tăng giá trị tương ứng trong histogram
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    redHistogram[pixelColor.R]++;
                    greenHistogram[pixelColor.G]++;
                    blueHistogram[pixelColor.B]++;
                }
            }

            // Tìm giá trị lớn nhất trong histogram để chuẩn hóa kích thước
            int maxHistogramValue = Math.Max(redHistogram.Max(), Math.Max(greenHistogram.Max(), blueHistogram.Max()));

            // Vẽ histogram
            using (Graphics g = Graphics.FromImage(histogramBitmap))
            {
                g.Clear(Color.White);

                // Vẽ histogram cho mỗi kênh màu
                Pen redPen = new Pen(Color.Red);
                Pen greenPen = new Pen(Color.Green);
                Pen bluePen = new Pen(Color.Blue);

                for (int i = 0; i < 256; i++)
                {
                    int redHeight = (int)((double)redHistogram[i] / maxHistogramValue * 200);
                    int greenHeight = (int)((double)greenHistogram[i] / maxHistogramValue * 200);
                    int blueHeight = (int)((double)blueHistogram[i] / maxHistogramValue * 200);

                    g.DrawLine(redPen, i, 200, i, 200 - redHeight);
                    g.DrawLine(greenPen, i, 200, i, 200 - greenHeight);
                    g.DrawLine(bluePen, i, 200, i, 200 - blueHeight);
                }

                // Ký hiệu lại dải màu
                Font labelFont = new Font("Arial", 8);
                Brush labelBrush = Brushes.Black;

                g.DrawString("R", labelFont, labelBrush, new PointF(10, 180));
                g.DrawString("G", labelFont, labelBrush, new PointF(110, 180));
                g.DrawString("B", labelFont, labelBrush, new PointF(210, 180));
            }

            // Hiển thị histogram trên PictureBoxFilter
            pictureBoxFilter.Image = histogramBitmap;
        }


        //sự kiện File
        private void btnFile_Click(object sender, EventArgs e)
        {
            sidebarLoadtranmistion.Start();
            lb1.Visible = false;
        }
        //sự kiên about
        private void btnAbout_Click(object sender, EventArgs e)
        {

        }
        //sự kiện setting
        private void btnSetting_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //meànfilter
        private Bitmap ApplyMeanFilter(Bitmap originalImage)
        {
            int kernelSize = 3;
            int edge = kernelSize / 2;
            Bitmap result = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = edge; y < originalImage.Height - edge; y++)
            {
                for (int x = edge; x < originalImage.Width - edge; x++)
                {
                    int sumR = 0, sumG = 0, sumB = 0;
                    for (int j = -edge; j <= edge; j++)
                    {
                        for (int k = -edge; k <= edge; k++)
                        {
                            Color pixel = originalImage.GetPixel(x + k, y + j);
                            sumR += pixel.R;
                            sumG += pixel.G;
                            sumB += pixel.B;
                        }
                    }
                    int avgR = sumR / (kernelSize * kernelSize);
                    int avgG = sumG / (kernelSize * kernelSize);
                    int avgB = sumB / (kernelSize * kernelSize);

                    result.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                }
            }
            return result;
        }
        //Load anhr
        // Load Image button click event handler
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            pictureBoxAnhFilter.Visible = true;
            pictureBoxAnhGoc.Visible = true;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image
                Bitmap selectedImage = new Bitmap(openFileDialog.FileName);
                pictureBoxAnhGoc.Image = selectedImage;

                // Convert the image to byte array
                byte[] imageBytes = ImageToByteArray(selectedImage);

                // Save image to MySQL database
                SaveImageToDatabase(imageBytes);
            }
        }

        // Convert Image to byte array
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        // Get user ID by username
        private int GetUserIdByUsername(string username)
        {
            string connectionString = "server=localhost;database=processingimage;uid=root;pwd=123456789;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id FROM users WHERE username = @username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        throw new Exception("User not found.");
                    }
                }
            }
        }

        // Compute image hash
        private string ComputeImageHash(byte[] imageBytes)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(imageBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        // Save image to database with duplicate check
        private void SaveImageToDatabase(byte[] imageBytes)
        {
         
            int userId = GetUserIdByUsername(username);
            string connectionString = "server=localhost;database=processingimage;uid=root;pwd=123456789;";
            var imageHash = ComputeImageHash(imageBytes);

            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Check if the image already exists
                    var checkQuery = "SELECT COUNT(*) FROM user_images WHERE user_id = @user_id AND image_hash = @image_hash";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@user_id", userId);
                        checkCmd.Parameters.AddWithValue("@image_hash", imageHash);
                        var imageExists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;

                        if (!imageExists)
                        {
                            // Insert the image if it doesn't exist
                            var insertQuery = "INSERT INTO user_images (user_id, image, image_hash) VALUES (@user_id, @image, @image_hash)";
                            using (var insertCmd = new MySqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@user_id", userId);
                                insertCmd.Parameters.AddWithValue("@image", imageBytes);
                                insertCmd.Parameters.AddWithValue("@image_hash", imageHash);
                                insertCmd.ExecuteNonQuery();
                               
                            }
                        }
                        else
                        {
                          
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }




        //láy ảnh từ database
        private void button2_Click(object sender, EventArgs e)
        {
            timerAnh.Start();
            pictureBoxAnhFilter.Visible = true;
            pictureBoxAnhGoc.Visible = true;
            var userId = GetUserIdByUsername(username);

            var connectionString = "server=localhost;database=processingimage;uid=root;pwd=123456789;";
            var query = "SELECT image FROM user_images WHERE user_id = @user_id";

            using (var connection = new MySqlConnection(connectionString))
            {
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@user_id", userId);

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var imageData = (byte[])reader["image"];
                            if (imageData != null)
                            {
                                using (var ms = new MemoryStream(imageData))
                                {
                                    var image = new Bitmap(ms);
                                    var pictureBox = new PictureBox
                                    {
                                        Image = image,
                                        SizeMode = PictureBoxSizeMode.Zoom,
                                        Height = 60,
                                        Width = 60,
                                        Margin = new Padding(10)
                                    };
                                    // Thêm sự kiện Click cho PictureBox
                                    pictureBox.Click += (s, args) =>
                                    {
                                        pictureBoxAnhGoc.Image = ((PictureBox)s).Image;
                                    };

                                    flowLayoutPanel1.Controls.Add(pictureBox);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            }
        //luu anhFform
        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem PictureBox có chứa ảnh hay không
            if (pictureBoxAnhFilter.Image == null)
            {
                MessageBox.Show("Không có ảnh để lưu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Image Files (*.bmp, *.jpg, *.png, *.gif)|*.bmp;*.jpg;*.png;*.gif|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lưu ảnh theo định dạng đã chọn
                    pictureBoxAnhFilter.Image.Save(saveFileDialog1.FileName);
                    MessageBox.Show("Lưu ảnh thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sidebarLoad_Paint(object sender, PaintEventArgs e)
        {

        }
        //sidebar của phần load ảnh
        bool sidebarLoadExpand = false;
        private void sidebarLoadtranmistion_Tick(object sender, EventArgs e)
        {
            if (sidebarLoadExpand == false)
            {
                sidebarChucnang.Height += 5;
                load2.Height += 5;
                sidebarLoad.Height += 5;
                if (sidebarLoad.Height >= 50)
                {
                    sidebarLoadtranmistion.Stop();
                    sidebarLoadExpand = true;
                }
            }
            else
            {
                sidebarChucnang.Height -= 5;
                load2.Height -= 5;
                sidebarLoad.Height -= 5;
                if (sidebarLoad.Height <= 0)
                {
                    sidebarLoadtranmistion.Stop();
                    sidebarLoadExpand = false;
                }
            }
        }
        // sự kiện đóng mở filter
        bool fillterExpand = false;
        private void timeFiltertransmistion_Tick(object sender, EventArgs e)
        {
            if (fillterExpand == false)
            {
                groupFilter.Height += 5;
                if (groupFilter.Height >= 65)
                {
                    timeFiltertransmistion.Stop();
                    fillterExpand = true;
                }
            }
            else
            {
                groupFilter.Height -= 5;
                if (groupFilter.Height <= 0)
                {
                    timeFiltertransmistion.Stop();
                    fillterExpand = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timeFiltertransmistion.Start();
        }
           
        private Bitmap dstBitmap;
        private object kernel;

        private void AutoProcessImageBasedOnPSNR()
        {
            if (pictureBoxAnhGoc.Image != null)
            {
                Bitmap originalImage = new Bitmap(pictureBoxAnhGoc.Image);

                // Apply various filters to the original image
                Bitmap[] filteredImages = new Bitmap[]
                {
            GaussianBlur(originalImage),
            Segmentation(originalImage, 250), // Example threshold for segmentation
         
                
                MedianFilter(originalImage, 3), // Example median filter
                ApplySobelFilter(originalImage), // Example Sobel filter
            ApplyCannyFilter(originalImage) // Example Canny filter
                };

                // Calculate PSNR for each filtered image
                double[] psnrs = new double[filteredImages.Length];
                for (int i = 0; i < filteredImages.Length; i++)
                {
                    psnrs[i] = CalculatePSNR(originalImage, filteredImages[i]);
                }

                // Find the index of the filtered image with the highest PSNR
                int maxPSNRIndex = Array.IndexOf(psnrs, psnrs.Max());

                // Display the filtered image with the highest PSNR
                pictureBoxAnhFilter.Image = filteredImages[maxPSNRIndex];
                label2.Text = GetFilterName(maxPSNRIndex); // Get filter name based on index
                txtpsnr.Text = "PSNR: " + psnrs[maxPSNRIndex].ToString("F2");
                txtpsnr.Visible = true;
            }
            else
            {
                MessageBox.Show("Please load an image into pictureBoxAnhGoc.");
            }
        }

      

        // Helper function to get filter name based on index
        private string GetFilterName(int index)
        {
            switch (index)
            {
                case 0:
                    return "Gaussian Blur";
                case 1:
                    return "Segmentation";
               
                case 2:
                    return "Median Filter";
                case 3:
                    return "Sobel Filter";
                case 4:
                    return "Canny Filter";
                default:
                    return "Unknown Filter";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AutoProcessImageBasedOnPSNR();
        }
        //segmentation
        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "Segmentation";
            if (pictureBoxAnhGoc.Image != null)
            {
                // Convert PictureBox image to a Bitmap
                Bitmap originalBitmap = new Bitmap(pictureBoxAnhGoc.Image);
                // Apply segmentation
                Bitmap segmentedBitmap = Segmentation(originalBitmap, 250); // Example threshold
                                                                            // Calculate PSNR
                double psnr = CalculatePSNR(originalBitmap, segmentedBitmap);

                txtpsnr.Text = "PSNR: " + psnr.ToString("F2");              // Display the segmented image
                pictureBoxAnhFilter.Image = segmentedBitmap;
            }
            else
            {
                MessageBox.Show("Please load an image into pictureBoxAnhGoc.");
            }
        }
        private Bitmap Segmentation(Bitmap image, int threshold)
        {
            // Create a new bitmap with the same size as the original image
            Bitmap segmentedBitmap = new Bitmap(image.Width, image.Height);

            // Loop through each pixel in the image
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    // Get the pixel value
                    Color pixelColor = image.GetPixel(x, y);
                    // Convert pixel to grayscale (assuming image is already grayscale)
                    int grayValue = pixelColor.R; // R, G, and B values are the same in grayscale
                                                  // Apply thresholding
                    if (grayValue > threshold)
                    {
                        segmentedBitmap.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        segmentedBitmap.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return segmentedBitmap;
        }


        private void AddSaltPepperNoise(Bitmap srcBmp, double pa, double pb)
        {
            int amount1 = (int)(srcBmp.Width * srcBmp.Height * pa);
            int amount2 = (int)(srcBmp.Width * srcBmp.Height * pb);

            // Pepper noise
            Random rand = new Random();
            for (int counter = 0; counter < amount1; ++counter)
            {
                int x = rand.Next(srcBmp.Width);
                int y = rand.Next(srcBmp.Height);
                srcBmp.SetPixel(x, y, Color.Black);
            }

            // Salt noise
            for (int counter = 0; counter < amount2; ++counter)
            {
                int x = rand.Next(srcBmp.Width);
                int y = rand.Next(srcBmp.Height);
                srcBmp.SetPixel(x, y, Color.White);
            }
        }

        // Biến để lưu trạng thái ban đầu của hình ảnh
        private Bitmap originalImage;

        // Hàm lưu trạng thái ban đầu của hình ảnh
        private void SaveOriginalImage()
        {
            if (pictureBoxAnhGoc.Image != null)
            {
                originalImage = new Bitmap(pictureBoxAnhGoc.Image);
            }
        }

        // Hàm khôi phục lại hình ảnh ban đầu
        private void RestoreOriginalImage()
        {
            if (originalImage != null)
            {
                pictureBoxAnhGoc.Image = new Bitmap(originalImage);
            }
            else
            {
                MessageBox.Show("Original image not found.");
            }
        }

        // Thêm nhiễu và lưu trạng thái ban đầu
        private void AddNoiseToImage()
        {
            SaveOriginalImage();
            if (pictureBoxAnhGoc.Image != null)
            {
                Bitmap myBitmap = new Bitmap(pictureBoxAnhGoc.Image);
                AddSaltPepperNoise(myBitmap, 0.001, 0.001);
                pictureBoxAnhGoc.Image = myBitmap;

                // Lưu trạng thái ban đầu của hình ảnh
                SaveOriginalImage();
            }
            else
            {
                MessageBox.Show("Please load an image into pictureBoxAnhGoc.");
            }
        }
      
        // Sự kiện xảy ra khi nhấn vào nút thêm nhiễu
        private void btnCombine_Click(object sender, EventArgs e)
        {
            AddNoiseToImage();
        }

        //bộ lọc 2D filter
        private void btn2D_Click(object sender, EventArgs e)
        {
            txtpsnr.Visible = true;
            label2.Text = "2D";

            if (pictureBoxAnhGoc.Image != null)
            {
                Bitmap srcBitmap = new Bitmap(pictureBoxAnhGoc.Image);
                Bitmap dstBitmap = new Bitmap(srcBitmap.Width, srcBitmap.Height);

                // Create Gaussian kernel
                double[,] kernel = CreateGaussianKernel(5, 1.0);

                // Apply filter
                Filter2DManual(srcBitmap, dstBitmap, kernel);
                double psnr = CalculatePSNR(srcBitmap, dstBitmap);
                txtpsnr.Text = "PSNR: " + psnr.ToString("F2");

                // Show the result in the result PictureBox
                pictureBoxAnhFilter.Image = dstBitmap;
            }
        }
        private double[,] CreateGaussianKernel(int kernelSize, double sigma)
        {
            double[,] kernel = new double[kernelSize, kernelSize];
            double mean = kernelSize / 2;
            double sum = 0.0;

            for (int x = 0; x < kernelSize; ++x)
            {
                for (int y = 0; y < kernelSize; ++y)
                {
                    kernel[x, y] = Math.Exp(-0.5 * (Math.Pow((x - mean) / sigma, 2.0) + Math.Pow((y - mean) / sigma, 2.0))) / (2 * Math.PI * sigma * sigma);
                    sum += kernel[x, y];
                }
            }

            for (int x = 0; x < kernelSize; ++x)
            {
                for (int y = 0; y < kernelSize; ++y)
                {
                    kernel[x, y] /= sum;
                }
            }

            return kernel;
        }

        private void Filter2DManual(Bitmap srcBitmap, Bitmap dstBitmap, double[,] kernel)
        {
            int kernelRadiusX = kernel.GetLength(1) / 2;
            int kernelRadiusY = kernel.GetLength(0) / 2;

            for (int y = kernelRadiusY; y < srcBitmap.Height - kernelRadiusY; ++y)
            {
                for (int x = kernelRadiusX; x < srcBitmap.Width - kernelRadiusX; ++x)
                {
                    double sum = 0.0;
                    for (int ky = -kernelRadiusY; ky <= kernelRadiusY; ++ky)
                    {
                        for (int kx = -kernelRadiusX; kx <= kernelRadiusX; ++kx)
                        {
                            int px = x + kx;
                            int py = y + ky;

                            Color pixelColor = srcBitmap.GetPixel(px, py);
                            double intensity = (double)(pixelColor.R + pixelColor.G + pixelColor.B) / 3.0;
                            sum += kernel[ky + kernelRadiusY, kx + kernelRadiusX] * intensity;
                        }
                    }

                    int newValue = (int)Math.Min(Math.Max(sum, 0), 255);
                    dstBitmap.SetPixel(x, y, Color.FromArgb(newValue, newValue, newValue));
                }
            }
        }
        private double CalculatePSNR(Bitmap img, Bitmap source)
        {
            double PSNR = 0;
            double MSE = 0;
            int totalPixels = img.Width * img.Height;

            for (int y = 0; y < img.Height; ++y)
            {
                for (int x = 0; x < img.Width; ++x)
                {
                    Color imgColor = img.GetPixel(x, y);
                    Color sourceColor = source.GetPixel(x, y);
                    double error = Math.Pow(imgColor.R - sourceColor.R, 2) + Math.Pow(imgColor.G - sourceColor.G, 2) + Math.Pow(imgColor.B - sourceColor.B, 2);
                    MSE += error;
                }
            }

            MSE /= totalPixels;
            if (MSE > 0)
            {
                PSNR = 10 * Math.Log10(255 * 255 / MSE);
            }
            else
            {
                PSNR = double.PositiveInfinity;
            }

            return PSNR;
        }
    
    private void btnMean_Click(object sender, EventArgs e)
        {
            label2.Text = "Mean Filter";
            Bitmap srcImage = (Bitmap)pictureBoxAnhGoc.Image;
            Bitmap resultImage = new Bitmap(srcImage.Width, srcImage.Height);

            int windowSize = 3; // Kích thước cửa sổ trung bình

            for (int y = windowSize / 2; y < srcImage.Height - windowSize / 2; y++)
            {
                for (int x = windowSize / 2; x < srcImage.Width - windowSize / 2; x++)
                {
                    int sum = 0;

                    // Lấy các giá trị pixel trong cửa sổ
                    for (int wy = -windowSize / 2; wy <= windowSize / 2; wy++)
                    {
                        for (int wx = -windowSize / 2; wx <= windowSize / 2; wx++)
                        {
                            Color pixelColor = srcImage.GetPixel(x + wx, y + wy);
                            int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                            sum += grayValue;
                        }
                    }
                    int average = sum / (windowSize * windowSize);
                    resultImage.SetPixel(x, y, Color.FromArgb(average, average, average));
                }
            }
            double psnr1 = CalculatePSNR(srcImage, resultImage);
            txtpsnr.Text = "PSNR: " + psnr1.ToString("F2");
            txtpsnr.Visible = true;
            pictureBoxAnhFilter.Image = resultImage;
            
        
    }

        private void pictureBoxAnhFilter_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // bộ lọc Wiener
        private void btnWiener_Click(object sender, EventArgs e)
        {
            label2.Text = "Wiener Filter";
            // Get the image from the PictureBox
            Bitmap image = (Bitmap)pictureBoxAnhGoc.Image;

            // Convert the image to a 2D array
            double[,] imageArray = new double[image.Width, image.Height];
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    imageArray[x, y] = pixel.R / 255.0;
                }
            }

            // Define the kernel
            double[,] kernel = new double[,] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };
            double K = 0.01;

            // Apply the Wiener filter
            double[,] filteredImageArray = WienerFilter(imageArray, kernel, K);

            // Convert the filtered image array back to a Bitmap
            Bitmap filteredImage = new Bitmap(image.Width, image.Height);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    int intensity = (int)Math.Round(filteredImageArray[x, y] * 255);
                    intensity = ClampColorValue(intensity);
                    filteredImage.SetPixel(x, y, Color.FromArgb(intensity, intensity, intensity));
                }
            }

            // Display the filtered image
            pictureBoxAnhFilter.Image = filteredImage;
        }
        private int ClampColorValue(int value)
        {
            if (value < 0)
                return 0;
            if (value > 255)
                return 255;
            return value;
        }
        private double[,] WienerFilter(double[,] image, double[,] kernel, double K)
        {
            int width = image.GetLength(0);
            int height = image.GetLength(1);

            // Normalize the kernel
            double kernelSum = 0;
            for (int x = 0; x < kernel.GetLength(0); x++)
            {
                for (int y = 0; y < kernel.GetLength(1); y++)
                {
                    kernelSum += kernel[x, y];
                }
            }
            for (int x = 0; x < kernel.GetLength(0); x++)
            {
                for (int y = 0; y < kernel.GetLength(1); y++)
                {
                    kernel[x, y] /= kernelSum;
                }
            }

            // Perform FFT on image and kernel
            double[,] fftImageReal, fftImageImag, fftKernelReal, fftKernelImag;
            FFT(image, out fftImageReal, out fftImageImag);
            FFT(kernel, out fftKernelReal, out fftKernelImag);

            // Apply Wiener filter
            double[,] filteredImageReal = new double[width, height];
            double[,] filteredImageImag = new double[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double kernelConjReal = fftKernelReal[x % fftKernelReal.GetLength(0), y % fftKernelReal.GetLength(1)];
                    double kernelConjImag = -fftKernelImag[x % fftKernelImag.GetLength(0), y % fftKernelImag.GetLength(1)];
                    double denominator = kernelConjReal * kernelConjReal + kernelConjImag * kernelConjImag + K;
                    filteredImageReal[x, y] = (fftImageReal[x, y] * kernelConjReal + fftImageImag[x, y] * kernelConjImag) / denominator;
                    filteredImageImag[x, y] = (fftImageImag[x, y] * kernelConjReal - fftImageReal[x, y] * kernelConjImag) / denominator;
                }
            }

            // Perform IFFT on filtered image
            double[,] ifftImageReal, ifftImageImag;
            IFFT(filteredImageReal, filteredImageImag, out ifftImageReal, out ifftImageImag);

            return ifftImageReal;
        }

        private void FFT(double[,] input, out double[,] real, out double[,] imag)
        {
            int width = input.GetLength(0);
            int height = input.GetLength(1);
            real = new double[width, height];
            imag = new double[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double sumReal = 0;
                    double sumImag = 0;
                    for (int k = 0; k < width; k++)
                    {
                        for (int l = 0; l < height; l++)
                        {
                            sumReal += input[k, l] * Math.Cos(2 * Math.PI * (k * x / width + l * y / height));
                            sumImag += input[k, l] * Math.Sin(2 * Math.PI * (k * x / width + l * y / height));
                        }
                    }
                    real[x, y] = sumReal;
                    imag[x, y] = sumImag;
                }
            }
        }

        private void IFFT(double[,] real, double[,] imag, out double[,] ifftReal, out double[,] ifftImag)
        {
            int width = real.GetLength(0);
            int height = real.GetLength(1);
            ifftReal = new double[width, height];
            ifftImag = new double[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double sumReal = 0;
                    double sumImag = 0;
                    for (int k = 0; k < width; k++)
                    {
                        for (int l = 0; l < height; l++)
                        {
                            sumReal += real[k, l] * Math.Cos(2 * Math.PI * (k * x / width + l * y / height)) -
                                       imag[k, l] * Math.Sin(2 * Math.PI * (k * x / width + l * y / height));
                            sumImag += real[k, l] * Math.Sin(2 * Math.PI * (k * x / width + l * y / height)) +
                                       imag[k, l] * Math.Cos(2 * Math.PI * (k * x / width + l * y / height));
                        }
                    }
                    ifftReal[x, y] = sumReal / (width * height);
                    ifftImag[x, y] = sumImag / (width * height);
                }
            }
        }




        // Phương thức để áp dụng Median Filter 
        private void btnMedian_Click(object sender, EventArgs e)
        {
            label2.Text = "Median Filter";
            Bitmap srcImage = (Bitmap)pictureBoxAnhGoc.Image;

            if (srcImage != null)
            {
                int windowSize = 3; // Window size for median filter

                Bitmap resultImage = MedianFilter(srcImage, windowSize);

                double psnr = CalculatePSNR(srcImage, resultImage);
                txtpsnr.Text = "PSNR: " + psnr.ToString("F2");
                txtpsnr.Visible = true;
                pictureBoxAnhFilter.Image = resultImage;
            }
        }

        private Bitmap MedianFilter(Bitmap srcImage, int windowSize)
        {
            Bitmap resultImage = new Bitmap(srcImage.Width, srcImage.Height);

            for (int y = windowSize / 2; y < srcImage.Height - windowSize / 2; y++)
            {
                for (int x = windowSize / 2; x < srcImage.Width - windowSize / 2; x++)
                {
                    List<int> values = new List<int>();

                    // Get pixel values within the window
                    for (int wy = -windowSize / 2; wy <= windowSize / 2; wy++)
                    {
                        for (int wx = -windowSize / 2; wx <= windowSize / 2; wx++)
                        {
                            Color pixelColor = srcImage.GetPixel(x + wx, y + wy);
                            int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                            values.Add(grayValue);
                        }
                    }

                    // Sort and select the median value
                    values.Sort();
                    int medianValue = values[values.Count / 2];
                    resultImage.SetPixel(x, y, Color.FromArgb(medianValue, medianValue, medianValue));
                }
            }

            return resultImage;
        }


        private void pictureBoxAnhGoc_Click(object sender, EventArgs e)
        {

        }
        private Bitmap ApplySobelFilter(Bitmap originalImage)
        {
            Bitmap resultImage = new Bitmap(originalImage.Width, originalImage.Height);

            int[,] sobelX = {
        { -1, 0, 1 },
        { -2, 0, 2 },
        { -1, 0, 1 }
    };

            int[,] sobelY = {
        { -1, -2, -1 },
        {  0,  0,  0 },
        {  1,  2,  1 }
    };

            for (int y = 1; y < originalImage.Height - 1; y++)
            {
                for (int x = 1; x < originalImage.Width - 1; x++)
                {
                    int sumX = 0;
                    int sumY = 0;

                    for (int ky = 0; ky < 3; ky++)
                    {
                        for (int kx = 0; kx < 3; kx++)
                        {
                            Color pixelColor = originalImage.GetPixel(x + kx - 1, y + ky - 1);
                            int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                            sumX += sobelX[ky, kx] * grayValue;
                            sumY += sobelY[ky, kx] * grayValue;
                        }
                    }

                    int gradient = (int)Math.Sqrt(sumX * sumX + sumY * sumY);
                    gradient = Math.Min(Math.Max(gradient, 0), 255);
                    resultImage.SetPixel(x, y, Color.FromArgb(gradient, gradient, gradient));
                }
            }

            return resultImage;
        }

        private void btnSobel_Click(object sender, EventArgs e)
        {
            label2.Text = "Sobel Filter";
            Bitmap originalImage = (Bitmap)pictureBoxAnhGoc.Image;

            Bitmap resultImage = ApplySobelFilter(originalImage);

            double psnr = CalculatePSNR(originalImage, resultImage);
            txtpsnr.Text = "PSNR: " + psnr.ToString("F2");
            txtpsnr.Visible = true;
            pictureBoxAnhFilter.Image = resultImage;
        }


        //bộ lọc canny
        private void btnCanny_Click(object sender, EventArgs e)
        {
            label2.Text = "Canny Filter";
            // Get the image from the PictureBox
            Bitmap image = (Bitmap)pictureBoxAnhGoc.Image;

            // Apply the Canny edge detection filter
            Bitmap filteredImage = ApplyCannyFilter(image);
            // Calculate PSNR
            double psnr = CalculatePSNR(image, filteredImage);

            txtpsnr.Text = "PSNR: " + psnr.ToString("F2");
            // Display the filtered image in a new PictureBox
            pictureBoxAnhFilter.Image = filteredImage;

        }
        private Bitmap ApplyCannyFilter(Bitmap image)
        {
            // Convert the image to grayscale
            Bitmap grayscaleImage = ConvertToGrayscale(image);

            // Apply the Gaussian filter to reduce noise
            Bitmap gaussianImage = ApplyGaussianFilter(grayscaleImage);

            // Calculate the gradient images in the x and y directions
            Bitmap gradientXImage = CalculateGradientX(gaussianImage);
            Bitmap gradientYImage = CalculateGradientY(gaussianImage);

            // Calculate the non-maximum suppression
            Bitmap nonMaxSuppressionImage = NonMaximumSuppression(gradientXImage, gradientYImage);

            // Apply the double thresholding
            Bitmap thresholdImage = DoubleThresholding(nonMaxSuppressionImage);

            return thresholdImage;
        }

        private Bitmap ConvertToGrayscale(Bitmap image)
        {
            Bitmap grayscaleImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);
                    grayscaleImage.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }

            return grayscaleImage;
        }

        private Bitmap ApplyGaussianFilter(Bitmap image)
        {
            Bitmap gaussianImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    int sum = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int neighborX = x + i;
                            int neighborY = y + j;

                            if (neighborX >= 0 && neighborX < image.Width && neighborY >= 0 && neighborY < image.Height)
                            {
                                Color neighborPixel = image.GetPixel(neighborX, neighborY);
                                sum += neighborPixel.R;
                            }
                        }
                    }

                    gaussianImage.SetPixel(x, y, Color.FromArgb(sum / 9, sum / 9, sum / 9));
                }
            }

            return gaussianImage;
        }

        private Bitmap CalculateGradientX(Bitmap image)
        {
            Bitmap gradientImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    int dx = 0;

                    if (x > 0)
                    {
                        Color leftPixel = image.GetPixel(x - 1, y);
                        dx += leftPixel.R;
                    }

                    if (x < image.Width - 1)
                    {
                        Color rightPixel = image.GetPixel(x + 1, y);
                        dx -= rightPixel.R;
                    }

                    gradientImage.SetPixel(x, y, Color.FromArgb(Math.Abs(dx), Math.Abs(dx), Math.Abs(dx)));
                }
            }

            return gradientImage;
        }

        private Bitmap CalculateGradientY(Bitmap image)
        {
            Bitmap gradientImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    int dy = 0;

                    if (y > 0)
                    {
                        Color topPixel = image.GetPixel(x, y - 1);
                        dy += topPixel.R;
                    }

                    if (y < image.Height - 1)
                    {
                        Color bottomPixel = image.GetPixel(x, y + 1);
                        dy -= bottomPixel.R;
                    }

                    gradientImage.SetPixel(x, y, Color.FromArgb(Math.Abs(dy), Math.Abs(dy), Math.Abs(dy)));
                }
            }

            return gradientImage;
        }

        private Bitmap NonMaximumSuppression(Bitmap gradientXImage, Bitmap gradientYImage)
        {
            Bitmap nonMaxSuppressionImage = new Bitmap(gradientXImage.Width, gradientXImage.Height);

            for (int x = 0; x < gradientXImage.Width; x++)
            {
                for (int y = 0; y < gradientXImage.Height; y++)
                {
                    Color gradientXPixel = gradientXImage.GetPixel(x, y);
                    Color gradientYPixel = gradientYImage.GetPixel(x, y);

                    int magnitude = (int)Math.Sqrt(gradientXPixel.R * gradientXPixel.R + gradientYPixel.R * gradientYPixel.R);
                    double direction = Math.Atan2(gradientYPixel.R, gradientXPixel.R);

                    if (direction < 0) direction += 2 * Math.PI;

                    int neighborX = x;
                    int neighborY = y;

                    if (direction >= 0 && direction < Math.PI / 8)
                    {
                        neighborX = x + 1;
                        neighborY = y;
                    }
                    else if (direction >= Math.PI / 8 && direction < 3 * Math.PI / 8)
                    {
                        neighborX = x + 1;
                        neighborY = y + 1;
                    }
                    else if (direction >= 3 * Math.PI / 8 && direction < 5 * Math.PI / 8)
                    {
                        neighborX = x;
                        neighborY = y + 1;
                    }
                    else if (direction >= 5 * Math.PI / 8 && direction < 7 * Math.PI / 8)
                    {
                        neighborX = x - 1;
                        neighborY = y + 1;
                    }
                    else if (direction >= 7 * Math.PI / 8 && direction < 2 * Math.PI)
                    {
                        neighborX = x - 1;
                        neighborY = y;
                    }

                    if (neighborX >= 0 && neighborX < gradientXImage.Width && neighborY >= 0 && neighborY < gradientXImage.Height)
                    {
                        Color neighborPixel = gradientXImage.GetPixel(neighborX, neighborY);

                        if (magnitude > neighborPixel.R)
                        {
                            nonMaxSuppressionImage.SetPixel(x, y, Color.FromArgb(Math.Min(255, magnitude), Math.Min(255, magnitude), Math.Min(255, magnitude)));
                        }
                        else
                        {
                            nonMaxSuppressionImage.SetPixel(x, y, Color.Black);
                        }
                    }
                    else
                    {
                        nonMaxSuppressionImage.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return nonMaxSuppressionImage;
        }

        private Bitmap DoubleThresholding(Bitmap nonMaxSuppressionImage)
        {
            Bitmap thresholdImage = new Bitmap(nonMaxSuppressionImage.Width, nonMaxSuppressionImage.Height);

            int highThreshold = 100;
            int lowThreshold = 50;

            for (int x = 0; x < nonMaxSuppressionImage.Width; x++)
            {
                for (int y = 0; y < nonMaxSuppressionImage.Height; y++)
                {
                    Color pixel = nonMaxSuppressionImage.GetPixel(x, y);

                    if (pixel.R > highThreshold)
                    {
                        thresholdImage.SetPixel(x, y, Color.White);
                    }
                    else if (pixel.R > lowThreshold)
                    {
                        thresholdImage.SetPixel(x, y, Color.Gray);
                    }
                    else
                    {
                        thresholdImage.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return thresholdImage;
        }

        //gaussian filter
        private void btnGausian_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn ảnh hay chưa
            if (pictureBoxAnhGoc.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh trước khi thực hiện bộ lọc Gaussian.");
                return;
            }

            Bitmap srcImage = (Bitmap)pictureBoxAnhGoc.Image;

            // Apply Gaussian filter
            Bitmap blurredImage = GaussianBlur(srcImage);

            // Calculate PSNR
            double psnr = CalculatePSNR(srcImage, blurredImage);
          
            txtpsnr.Text = "PSNR: " + psnr.ToString("F2");
            txtpsnr.Visible = true;
            // Hiển thị ảnh đã lọc lên pictureBox
            pictureBoxAnhFilter.Image = blurredImage;
            label2.Text = "Gausian Blur";
        }
        private Bitmap GaussianBlur(Bitmap image)
        {
            // Số lượng cột và hàng của kernel
            int kernelSize = 5;

            // Tạo một bitmap mới với kích thước giống như ảnh gốc
            Bitmap blurredImage = new Bitmap(image.Width, image.Height);

            // Tạo một kernel Gaussian
            double[,] kernel = CreateGaussianKernel(kernelSize);

            // Áp dụng kernel Gaussian lên ảnh
            for (int y = kernelSize / 2; y < image.Height - kernelSize / 2; y++)
            {
                for (int x = kernelSize / 2; x < image.Width - kernelSize / 2; x++)
                {
                    double pixel = 0.0;
                    for (int i = -kernelSize / 2; i <= kernelSize / 2; i++)
                    {
                        for (int j = -kernelSize / 2; j <= kernelSize / 2; j++)
                        {
                            Color color = image.GetPixel(x - i, y - j);
                            double gray = (color.R + color.G + color.B) / 3.0;
                            pixel += gray * kernel[i + kernelSize / 2, j + kernelSize / 2];
                        }
                    }
                    blurredImage.SetPixel(x, y, Color.FromArgb((int)pixel, (int)pixel, (int)pixel));
                }
            }

            return blurredImage;
        }

        private double[,] CreateGaussianKernel(int kernelSize)
        {
            double[,] kernel = new double[kernelSize, kernelSize];
            double sigma = kernelSize / 2.0;
            double s = 2.0 * sigma * sigma;
            double sum = 0.0;

            for (int y = 0; y < kernelSize; y++)
            {
                for (int x = 0; x < kernelSize; x++)
                {
                    int dx = x - kernelSize / 2;
                    int dy = y - kernelSize / 2;
                    kernel[y, x] = (Math.Exp(-(dx * dx + dy * dy) / s)) / (Math.PI * s);
                    sum += kernel[y, x];
                }
            }

            // Chuẩn hóa kernel
            for (int y = 0; y < kernelSize; y++)
            {
                for (int x = 0; x < kernelSize; x++)
                {
                    kernel[y, x] /= sum;
                }
            }

            return kernel;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        bool sidebarAnhExpand = true;
        private void timerAnh_Tick(object sender, EventArgs e)
        {
            
                if (sidebarAnhExpand)
                {
                    flowLayoutPanel1.Height += 10;
                    if (flowLayoutPanel1.Height >= 70)
                    {
                        sidebarAnhExpand = false;
                        timerAnh.Stop();
                    }
                }
                else
                {
                    flowLayoutPanel1.Height -= 10;
                    if (flowLayoutPanel1.Height <=0)
                    {
                        sidebarAnhExpand = true;
                        timerAnh.Stop();
                    }
                }
            
        }

        private void brnRes_Click(object sender, EventArgs e)
        {
            RestoreOriginalImage();
        }
    } 
}
