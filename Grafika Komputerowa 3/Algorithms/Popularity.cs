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
            Color[,,] listOfAvailableColors = Colors.GetAllAvailableColors(currentImage, K, backgroundWorker);

            backgroundWorker.ReportProgress(100);
            Parallel.For(0, CONST.bitmapWidth, i =>
            {
                for(int j=0;j<CONST.bitmapHeight;j++)
                {
                    image[i, j] = Colors.GetClosestColor(listOfAvailableColors, currentImage[i, j]);
                }
            });

            return image;
        }
    }
}
