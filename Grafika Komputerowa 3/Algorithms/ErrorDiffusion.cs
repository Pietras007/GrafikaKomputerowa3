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
    public static class ErrorDiffusion
    {
        public static Color[,] FloydSteinberg(Color[,] currentImage, int Kr, int Kg, int Kb)
        {
            Color[,] transformedImage = (Color[,])currentImage.Clone();
            for (int i = 0; i < CONST.bitmapWidth; i++)
            {
                for (int j = 0; j < CONST.bitmapHeight; j++)
                {
                    int redError = Math.Abs(transformedImage[i, j].R - Colors.GetClosestColor(currentImage[i, j].R, Kr));
                    int greenError = Math.Abs(transformedImage[i, j].G - Colors.GetClosestColor(currentImage[i, j].G, Kg));
                    int blueError = Math.Abs(transformedImage[i, j].B - Colors.GetClosestColor(currentImage[i, j].B, Kb));
                    for (int y = 0; y <= 2 * FloydSteinbergMatrix.y; y++)
                    {
                        for (int x = 0; x <= 2 * FloydSteinbergMatrix.x; x++)
                        {
                            if (Index.IsCorrectIndex(i + y - FloydSteinbergMatrix.y , j + x - FloydSteinbergMatrix.x))
                            {
                                Color transformingColor = transformedImage[i + y - FloydSteinbergMatrix.y, j + x - FloydSteinbergMatrix.x];
                                int r = Values.Round255(transformingColor.R + ((redError * FloydSteinbergMatrix.values[x, y]) / FloydSteinbergMatrix.division));
                                int g = Values.Round255(transformingColor.G + ((greenError * FloydSteinbergMatrix.values[x, y]) / FloydSteinbergMatrix.division));
                                int b = Values.Round255(transformingColor.B + ((blueError * FloydSteinbergMatrix.values[x, y]) / FloydSteinbergMatrix.division));
                                transformedImage[i + y - FloydSteinbergMatrix.y, j + x - FloydSteinbergMatrix.x] = Color.FromArgb(transformingColor.A, r, g, b);
                            }
                        }
                    }
                }
            }

            return transformedImage;
        }

        public static Color[,] Burkes(Color[,] currentImage, int Kr, int Kg, int Kb)
        {
            Color[,] image = new Color[CONST.bitmapWidth, CONST.bitmapHeight];

            return image;
        }

        public static Color[,] Stucky(Color[,] currentImage, int Kr, int Kg, int Kb)
        {
            Color[,] image = new Color[CONST.bitmapWidth, CONST.bitmapHeight];

            return image;
        }
    }
}
