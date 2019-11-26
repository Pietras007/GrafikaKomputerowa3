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
    public static class Average
    {
        public static Color[,] ComputeAlgorithm(Color[,] currentImage, int Kr, int Kg, int Kb, BackgroundWorker backgroundWorker)
        {
            Color[,] image = new Color[CONST.bitmapWidth, CONST.bitmapHeight];
            Color[,,] listOfAvailableColors = Colors.GetAllAvailableColors(Kr, Kg, Kb);
            object SyncObject = new object();
            int index = 0;
            Parallel.For(0, CONST.bitmapWidth, i =>
            {
                for (int j = 0; j < CONST.bitmapHeight; j++)
                {
                    image[i,j] = Colors.GetClosestColor(listOfAvailableColors, currentImage[i, j]);
                }
                lock (SyncObject)
                {
                    index++;
                }
                backgroundWorker.ReportProgress((int)((double)(index + 1) / CONST.bitmapWidth * 100) % 101);
            });

            backgroundWorker.ReportProgress(100);
            return image;
        }
    }
}
