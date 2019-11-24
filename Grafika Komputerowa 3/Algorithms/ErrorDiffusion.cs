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
            for (int j = 0; j < CONST.bitmapHeight; j++)
            {
                for (int i = 0; i < CONST.bitmapWidth; i++)
                {
                    Color oldPixel = transformedImage[i, j];
                    Color newPixel = Colors.GetClosestColor(oldPixel, Kr, Kg, Kb);
                    transformedImage[i, j] = newPixel;
                    int redError = oldPixel.R - newPixel.R;
                    int greenError = oldPixel.G - newPixel.G;
                    int blueError = oldPixel.B - newPixel.B;
                    //if (Index.IsCorrectIndex(i + 1, j))
                    //{
                    //    int r1 = Values.Round255(transformedImage[i + 1, j].R + redError * 7 / 16);
                    //    int g1 = Values.Round255(transformedImage[i + 1, j].G + greenError * 7 / 16);
                    //    int b1 = Values.Round255(transformedImage[i + 1, j].B + blueError * 7 / 16);
                    //    transformedImage[i + 1, j] = Color.FromArgb(r1, g1, b1);
                    //}
                    //if (Index.IsCorrectIndex(i - 1, j + 1))
                    //{
                    //    int r2 = Values.Round255(transformedImage[i - 1, j + 1].R + redError * 3 / 16);
                    //    int g2 = Values.Round255(transformedImage[i - 1, j + 1].G + greenError * 3 / 16);
                    //    int b2 = Values.Round255(transformedImage[i - 1, j + 1].B + blueError * 3 / 16);
                    //    transformedImage[i - 1, j + 1] = Color.FromArgb(r2, g2, b2);
                    //}
                    //if (Index.IsCorrectIndex(i, j + 1))
                    //{
                    //    int r3 = Values.Round255(transformedImage[i, j + 1].R + redError * 5 / 16);
                    //    int g3 = Values.Round255(transformedImage[i, j + 1].G + greenError * 5 / 16);
                    //    int b3 = Values.Round255(transformedImage[i, j + 1].B + blueError * 5 / 16);
                    //    transformedImage[i, j + 1] = Color.FromArgb(r3, g3, b3);
                    //}
                    //if (Index.IsCorrectIndex(i + 1, j + 1))
                    //{
                    //    int r4 = Values.Round255(transformedImage[i + 1, j + 1].R + redError * 1 / 16);
                    //    int g4 = Values.Round255(transformedImage[i + 1, j + 1].G + greenError * 1 / 16);
                    //    int b4 = Values.Round255(transformedImage[i + 1, j + 1].B + blueError * 1 / 16);
                    //    transformedImage[i + 1, j + 1] = Color.FromArgb(r4, g4, b4);
                    //}


                    for (int x = 0; x <= 2 * FloydSteinbergMatrix.x; x++)
                    {
                        for (int y = 0; y <= 2 * FloydSteinbergMatrix.y; y++)
                        {
                            if (Index.IsCorrectIndex(i + y - FloydSteinbergMatrix.y, j + x - FloydSteinbergMatrix.x))
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
