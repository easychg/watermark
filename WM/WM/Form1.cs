using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Management;

namespace WM
{
    public partial class Form1 : Form
    {
        List<string> listExtention = new List<string>();
        public Form1()
        {
            InitializeComponent();
            string aa = getHardDiskID();
            Form.CheckForIllegalCrossThreadCalls = false;
            listExtention.AddRange(new string[] { ".jpg", ".gif", ".png",".bmp",".jpeg" });
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
        }
        #region 在新线程中运行函数
        /// <summary>
        /// 在新线程中运行函数
        /// </summary>
        /// <param name="func">传入 函数名(无参、无返回值)</param>
        /// <param name="IsBackground">是否为后台线程(后台线程，窗口关闭后就终止线程)</param>
        public static void ThreadNew(VoidFunction func, bool IsBackground)
        {
            Thread th1 = new Thread(new ThreadStart(func));
            th1.IsBackground = IsBackground;//后台线程，窗口关闭后就终止线程
            th1.Start();
        }
        /// <summary>
        /// 在新线程中运行函数
        /// </summary>
        /// <param name="func">传入 函数名(有一个参数、无返回值)</param>
        /// <param name="para">object参数</param>
        /// <param name="IsBackground">是否为后台线程(后台线程，窗口关闭后就终止线程)</param>
        public static Thread ThreadNew(ParamFunction func, object para, bool IsBackground)
        {
            Thread th1 = new Thread(new ParameterizedThreadStart(func));
            //判断状态
            //((int)th1.ThreadState &((int)ThreadState.Running | (int)ThreadState.Suspended) ) == 0
            th1.IsBackground = IsBackground;
            th1.Start(para);
            return th1;
        }
        //允许线程之间进行操作
        public static void OprateBetweenThread()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        // 无参的、返回值为void的委托，可以用来做参数名
        public delegate void VoidFunction();

        //有一个参数的、返回值为void的委托，可以用来做参数名
        public delegate void ParamFunction(object para);


        #endregion

        private void lb_selectDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtDir.Text = fbd.SelectedPath;
            }
        }

        private void lb_selectMark_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            //设置文件类型
            ofd.Filter = "图片|*.jpg;*.png;*.gif;*.jpeg;*.bmp";

            //设置默认文件类型显示顺序
            //ofd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录
            ofd.RestoreDirectory = true;

            //点了保存按钮进入
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                txtMark.Text = ofd.FileName.ToString();
                //ConfigFile.Instanse["txtMark"] = txtMark.Text;
                pictureBox1.Image = Image.FromFile(ofd.FileName.ToString());
            }
        }
        int success = 0; //成功
        int falure = 0; //失败
        int total = 0;
        private void MakeWaterMark()
        {
            success = 0;
            falure = 0;
            total = 0;
            string errmsg = "";
            string markPicPath = txtMark.Text.Trim();
            string strtxtDir = txtDir.Text.Trim();
            if (strtxtDir == "" || markPicPath == "")
            {
                MessageBox.Show("请选择目录和水印文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (Directory.Exists(strtxtDir) == false)
            {
                MessageBox.Show("文件夹不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                btnExec.Enabled = false;
                List<string> PictureList = new List<string>();
                lb_statusInfo.Text = "状态：正在检索图片…";
                SearchFile(txtDir.Text.Trim(), ref PictureList);
                foreach (string s in PictureList)
                {
                    try
                    {

                        MakeWaterPic(s, "123", markPicPath, "");
                        success++;
                    }
                    catch (Exception er)
                    {
                        falure++;
                        errmsg += er.Message;
                    }
                    total++;
                    lb_statusInfo.Text = "状态：正在为第" + (total + 1) + "张图片加水印…";
                }
                lb_statusInfo.Text = "状态：完成！共" + total + ",成功" + success + ",失败" + falure;
                btnExec.Enabled = true;
                if (errmsg != "") MessageBox.Show(errmsg, "执行完成，部分文件出错信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void SearchFile(string parentDir, ref List<string> PictureList)
        {
            try
            {
                string[] subFiles = Directory.GetFiles(parentDir);
                string[] subDirs = Directory.GetDirectories(parentDir, "*.*", SearchOption.TopDirectoryOnly);
                PictureList.AddRange(subFiles);
                foreach (string dir in subDirs)
                {
                    SearchFile(dir, ref PictureList);
                }
            }
            catch (Exception ex) { }
        }


        private string MakeWaterPic(string SourcePicPath, string WaterText, string WaterPath, string SaveName)
        {
            if (File.Exists(SourcePicPath) == false)
            {
                return "-1";//文件不存在
            }
            string extension = Path.GetExtension(SourcePicPath).ToLower();//后缀
            if (listExtention.Contains(extension) == false) throw new Exception("不允许的后缀:" + SourcePicPath + "\n");

            System.Drawing.Image image = System.Drawing.Image.FromFile(SourcePicPath, true);
            int imgwidth = image.Width;
            int imgheight = image.Height;
            using (System.Drawing.Bitmap bitmap = new Bitmap(image.Width, image.Height))
            {
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))//
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.Clear(System.Drawing.Color.Transparent);
                    g.DrawImage(image, 0, 0, imgwidth, imgheight);//画上原图片
                    image.Dispose();
                    if (WaterText != "")
                    {
                        Font f = new Font("Verdana", 32);
                        Brush b = new SolidBrush(Color.Yellow);
                        g.DrawString(WaterText, f, b, 10, 10);
                    }
                    //g.Dispose();

                    //加图片水印
                    System.Drawing.Image copyImage = System.Drawing.Image.FromFile(WaterPath);
                    //Rectangle[destRect ] 它指定所绘制图像的位置和大小。将图像进行缩放以适合该矩形。
                    //Rectangle[srcRect ] 它指定 image 对象中要绘制的部分。
                    g.DrawImage(copyImage, new Rectangle(imgwidth - copyImage.Width, imgheight - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
                    if (File.Exists(SourcePicPath))
                    {
                        File.Delete(SourcePicPath);
                    }
                    
                    switch (extension)
                    {
                        case ".jpg":
                            bitmap.Save(SourcePicPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case ".gif":
                            bitmap.Save(SourcePicPath, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case ".png":
                            bitmap.Save(SourcePicPath, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        case ".jpeg":
                            bitmap.Save(SourcePicPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case ".bmp":
                            bitmap.Save(SourcePicPath, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        default:
                            throw new Exception("不允许的后缀:" + SourcePicPath);
                    }
                    pictureBox1.Image = Image.FromFile(SourcePicPath);
                }
            }

            return "1";
        }
        
        private void btnExec_Click(object sender, EventArgs e)
        {
            ThreadNew(MakeWaterMark, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //txtDir.Text = ConfigFile.Instanse["txtDir"];
            //txtMark.Text = ConfigFile.Instanse["txtMark"];
        }
        private string getHardDiskID()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            string strHardDiskID = null;
            foreach (ManagementObject mo in searcher.Get())
            {
                strHardDiskID = mo["SerialNumber"].ToString().Trim();
                break;
            }
            return strHardDiskID;
        }

    }
}
