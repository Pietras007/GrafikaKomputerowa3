using Grafika_Komputerowa_3.Constans;
using Grafika_Komputerowa_3.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_Komputerowa_3.Algorithms
{
    public static class Popularity
    {
        public static Color[,] ComputeAlgorithm(Color[,] currentImage, int K, BackgroundWorker backgroundWorker)
        {
            Color[,] image = (Color[,])currentImage.Clone();
            Color[] listOfAvailableColors = Colors.GetAllAvailableColors(currentImage, K, backgroundWorker);
            Color?[,,] colorsCurrentlyUsed = new Color?[256, 256, 256];
            object SyncObject = new object();
            object SyncObjectCurrentlyUsed = new object();
            double index = 40;
            Parallel.For(0, CONST.bitmapWidth, i =>
            {
                for(int j=0;j<CONST.bitmapHeight;j++)
                {
                    if (colorsCurrentlyUsed[currentImage[i, j].R, currentImage[i, j].G, currentImage[i, j].B] != null)
                    {
                        image[i, j] = (Color)colorsCurrentlyUsed[currentImage[i, j].R, currentImage[i, j].G, currentImage[i, j].B];
                    }
                    else
                    {
                        Color color = Colors.GetClosestColor(listOfAvailableColors, currentImage[i, j].R, currentImage[i, j].G, currentImage[i, j].B);
                        image[i, j] = color;
                        lock (SyncObjectCurrentlyUsed)
                        {
                            colorsCurrentlyUsed[currentImage[i, j].R, currentImage[i, j].G, currentImage[i, j].B] = color;
                        }
                    }
                }
                lock (SyncObject)
                {
                    index += (double)60 / CONST.bitmapWidth;
                    backgroundWorker.ReportProgress((int)index);
                }
            });

            return image;
        }
    }
}
