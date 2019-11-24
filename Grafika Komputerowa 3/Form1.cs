using Grafika_Komputerowa_3.Algorithms;
using Grafika_Komputerowa_3.Constans;
using Grafika_Komputerowa_3.Picture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika_Komputerowa_3
{
    public partial class Form1 : Form
    {
        Color[,] picture;
        Color[,] sample1;
        Color[,] sample2;
        Color[,] sample3;
        Color[,] currentImage;
        Color[,] resultColor;
        int Kr;
        int Kg;
        int Kb;
        int K;
        AlgorithmEnum algorithm;
        LoadedPicture loadedPicture;
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Image (.jpg)|*.jpg|Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif";
            openFileDialog.Title = "Select a Image File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadImage(openFileDialog.FileName);
            }
        }

        private void LoadImage(string path)
        {
            using (Bitmap picture1 = new Bitmap(path))
            {
                using (Bitmap picture2 = new Bitmap(picture1, CONST.bitmapWidth, CONST.bitmapHeight))
                {
                    picture = SettingColorValues.GetColorsTable(picture2, CONST.bitmapWidth, CONST.bitmapHeight);
                }
            }
            loadedPicture = LoadedPicture.picture;
            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Loading bitmaps
            using (Bitmap sample11 = new Bitmap("../../Samples/Picture1.jpg"))
            using (Bitmap sample12 = new Bitmap(sample11, CONST.bitmapWidth, CONST.bitmapHeight))
            {
                sample1 = SettingColorValues.GetColorsTable(sample12, CONST.bitmapWidth, CONST.bitmapHeight);
            }

            using (Bitmap sample21 = new Bitmap("../../Samples/Picture2.jpg"))
            using (Bitmap sample22 = new Bitmap(sample21, CONST.bitmapWidth, CONST.bitmapHeight))
            {
                sample2 = SettingColorValues.GetColorsTable(sample22, CONST.bitmapWidth, CONST.bitmapHeight);
            }

            using (Bitmap sample31 = new Bitmap("../../Samples/Picture3.jpg"))
            using (Bitmap sample32 = new Bitmap(sample31, CONST.bitmapWidth, CONST.bitmapHeight))
            {
                sample3 = SettingColorValues.GetColorsTable(sample32, CONST.bitmapWidth, CONST.bitmapHeight);
            }


            //Load K-values
            Kr = (int)numericUpDown1.Value;
            Kg = (int)numericUpDown2.Value;
            Kb = (int)numericUpDown3.Value;
            K = (int)numericUpDown4.Value;

            //ProgressBar invisible
            progressBar1.Visible = false;
        }

        private void sample1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadedPicture = LoadedPicture.sample1;
            pictureBox1.Invalidate();
        }

        private void sample2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadedPicture = LoadedPicture.sample2;
            pictureBox1.Invalidate();
        }

        private void sample3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadedPicture = LoadedPicture.sample3;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (loadedPicture == LoadedPicture.picture)
            {
                currentImage = picture;
                g.SetColorsToGraphics(picture);
            }
            else if (loadedPicture == LoadedPicture.sample1)
            {
                currentImage = sample1;
                g.SetColorsToGraphics(sample1);
            }
            else if (loadedPicture == LoadedPicture.sample2)
            {
                currentImage = sample2;
                g.SetColorsToGraphics(sample2);
            }
            else if (loadedPicture == LoadedPicture.sample3)
            {
                currentImage = sample3;
                g.SetColorsToGraphics(sample3);
            }

            //ComputeResultColor();
        }

        private void ComputeResultColor()
        {
            if (currentImage != null && !backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                BlockButtons();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (resultColor != null)
            {
                Graphics g = e.Graphics;
                g.SetColorsToGraphics(resultColor);
                progressBar1.Visible = false;
                UnBlockButtons();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Kr = (int)numericUpDown1.Value;
            //ComputeResultColor();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Kg = (int)numericUpDown2.Value;
            //ComputeResultColor();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Kb = (int)numericUpDown3.Value;
            //ComputeResultColor();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            K = (int)numericUpDown4.Value;
            //ComputeResultColor();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Color[,] color = null;
            if (algorithm == AlgorithmEnum.ditheringAverage)
            {
                color = Average.ComputeAlgorithm(currentImage, Kr, Kg, Kb, backgroundWorker1);
            }
            else if (algorithm == AlgorithmEnum.ditheringOrderedVersion1)
            {
                color = Ordered.ComputeAlgorithmVersion1(currentImage, Kr, Kg, Kb);
            }
            else if (algorithm == AlgorithmEnum.ditheringOrderedVersion2)
            {
                color = Ordered.ComputeAlgorithmVersion2(currentImage, Kr, Kg, Kb);
            }
            else if (algorithm == AlgorithmEnum.ditheringFloydSteinberg)
            {
                color = ErrorDiffusion.FloydSteinberg(currentImage, Kr, Kg, Kb, backgroundWorker1);
            }
            else if (algorithm == AlgorithmEnum.ditheringBurkes)
            {
                color = ErrorDiffusion.Burkes(currentImage, Kr, Kg, Kb, backgroundWorker1);
            }
            else if (algorithm == AlgorithmEnum.ditheringStucky)
            {
                color = ErrorDiffusion.Stucky(currentImage, Kr, Kg, Kb, backgroundWorker1);
            }
            else if (algorithm == AlgorithmEnum.popularityAlgorythm)
            {
                color = Popularity.ComputeAlgorithm(currentImage, K);
            }
            e.Result = color;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            resultColor = (Color[,])e.Result;
            pictureBox2.Invalidate();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.ditheringAverage;
            //ComputeResultColor();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.ditheringOrderedVersion1;
            //ComputeResultColor();
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.ditheringOrderedVersion2;
            //ComputeResultColor();
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.ditheringFloydSteinberg;
            //ComputeResultColor();
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.ditheringBurkes;
            //ComputeResultColor();
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.ditheringStucky;
            //ComputeResultColor();
        }

        private void radioButton7_Click(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.popularityAlgorythm;
            //ComputeResultColor();
        }

        private void BlockButtons()
        {
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            radioButton6.Enabled = false;
            radioButton7.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            button1.Enabled = false;
        }

        private void UnBlockButtons()
        {
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            radioButton5.Enabled = true;
            radioButton6.Enabled = true;
            radioButton7.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            numericUpDown4.Enabled = true;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComputeResultColor();
        }
    }
}
