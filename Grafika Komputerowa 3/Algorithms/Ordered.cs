using Grafika_Komputerowa_3.Constans;
using Grafika_Komputerowa_3.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_Komputerowa_3.Algorithms
{
    public static class Ordered
    {
        public static Color[,] ComputeAlgorithmVersion1(Color[,] currentImage, int Kr, int Kg, int Kb, Random random)
        {
            Color[,] image = (Color[,])currentImage.Clone();
            int nR = OrderedHelper.GetClosestN(Kr);
            int nG = OrderedHelper.GetClosestN(Kg);
            int nB = OrderedHelper.GetClosestN(Kb);
            Parallel.For(0, CONST.bitmapWidth, i =>
            {
                for (int j = 0; j < CONST.bitmapHeight; j++)
                {
                    int r = Values.Round255(OrderedHelper.GetColorForOrdered(currentImage[i, j].R, nR, random, -1, -1));
                    int g = Values.Round255(OrderedHelper.GetColorForOrdered(currentImage[i, j].G, nG, random, -1, -1));
                    int b = Values.Round255(OrderedHelper.GetColorForOrdered(currentImage[i, j].B, nB, random, -1, -1));
                    image[i, j] = Color.FromArgb(r, g, b);
                }
            });

            return image;
        }

        public static Color[,] ComputeAlgorithmVersion2(Color[,] currentImage, int Kr, int Kg, int Kb, Random random)
        {
            Color[,] image = (Color[,])currentImage.Clone();
            int nR = OrderedHelper.GetClosestN(Kr);
            int nG = OrderedHelper.GetClosestN(Kg);
            int nB = OrderedHelper.GetClosestN(Kb);
            Parallel.For(0, CONST.bitmapWidth, i =>
            {
                for (int j = 0; j < CONST.bitmapHeight; j++)
                {
                    int r = Values.Round255(OrderedHelper.GetColorForOrdered(currentImage[i, j].R, nR, random, i, j));
                    int g = Values.Round255(OrderedHelper.GetColorForOrdered(currentImage[i, j].G, nG, random, i, j));
                    int b = Values.Round255(OrderedHelper.GetColorForOrdered(currentImage[i, j].B, nB, random, i, j));
                    image[i, j] = Color.FromArgb(r, g, b);
                }
            });

            return image;
        }
    }
}
