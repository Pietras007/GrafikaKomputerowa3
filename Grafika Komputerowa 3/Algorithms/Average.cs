using Grafika_Komputerowa_3.Constans;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_Komputerowa_3.Algorithms
{
    public static class Average
    {
        public static Color[,] ComputeAlgorithm(Color[,] currentImage, int Kr, int Kg, int Kb)
        {
            Color[,] image = new Color[CONST.bitmapWidth, CONST.bitmapHeight];
            int[] sum = new int[CONST.bitmapWidth];
            int sumOfAll = 0;
            Parallel.For(0, CONST.bitmapWidth, i =>
            {
                for (int j = 0; j < CONST.bitmapHeight; j++)
                {
                    byte gray = (byte)(0.299 * currentImage[i, j].R + 0.587 * currentImage[i, j].G + 0.114 * currentImage[i, j].B);
                    sum[i] += gray;
                }
            });

            for(int i= 0;i< CONST.bitmapWidth;i++)
            {
                sumOfAll += sum[i];
            }

            int average = sumOfAll / (CONST.bitmapWidth * CONST.bitmapHeight);
            average = 127;
            Parallel.For(0, CONST.bitmapWidth, i =>
            {
                for (int j = 0; j < CONST.bitmapHeight; j++)
                {
                    byte grayColor = (byte)(0.299 * currentImage[i, j].R + 0.587 * currentImage[i, j].G + 0.114 * currentImage[i, j].B);
                    if(grayColor < average)
                    {
                        image[i, j] = Color.FromArgb(currentImage[i, j].A, 0, 0, 0);
                    }
                    else
                    {
                        image[i, j] = Color.FromArgb(currentImage[i, j].A, 255, 255, 255);
                    }
                }
            });

            return image;
        }
    }
}
