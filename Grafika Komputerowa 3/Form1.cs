﻿using Grafika_Komputerowa_3.Constans;
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
        int numericRed;
        int numericGreen;
        int numericBlue;
        int numericK;
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.ditheringAverage;
            pictureBox2.Invalidate();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.ditheringOrderedVersion1;
            pictureBox2.Invalidate();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.ditheringOrderedVersion2;
            pictureBox2.Invalidate();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.ditheringFloydSteinberg;
            pictureBox2.Invalidate();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.ditheringBurkes;
            pictureBox2.Invalidate();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.ditheringStucky;
            pictureBox2.Invalidate();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            algorithm = AlgorithmEnum.popularityAlgorythm;
            pictureBox2.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (loadedPicture == LoadedPicture.picture)
            {
                currentImage = picture;
                g.SetColorsToGraphics(picture);
            }
            else if(loadedPicture == LoadedPicture.sample1)
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
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if(algorithm == AlgorithmEnum.ditheringAverage)
            {

            }
            else if(algorithm == AlgorithmEnum.ditheringOrderedVersion1)
            {

            }
            else if (algorithm == AlgorithmEnum.ditheringOrderedVersion2)
            {

            }
            else if (algorithm == AlgorithmEnum.ditheringFloydSteinberg)
            {

            }
            else if (algorithm == AlgorithmEnum.ditheringBurkes)
            {

            }
            else if (algorithm == AlgorithmEnum.ditheringStucky)
            {

            }
            else if (algorithm == AlgorithmEnum.popularityAlgorythm)
            {

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericRed = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericGreen = (int)numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericBlue = (int)numericUpDown3.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            numericK = (int)numericUpDown4.Value;
        }

    }
}
