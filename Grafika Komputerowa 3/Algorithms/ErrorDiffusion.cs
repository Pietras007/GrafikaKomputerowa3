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
    public static class ErrorDiffusion
    {
        public static Color[,] FloydSteinberg(Color[,] currentImage, int Kr, int Kg, int Kb, BackgroundWorker backgroundWorker)
        {
            Color[] listOfAvailableColors = Colors.GetAvailableColors(Kr, Kg, Kb);
            Color[,] transformedImage = (Color[,])currentImage.Clone();
            for (int j = 0; j < CONST.bitmapHeight; j++)
            {
                for (int i = 0; i < CONST.bitmapWidth; i++)
                {
                    Color oldPixel = transformedImage[i, j];
                    Color newPixel = Colors.GetClosestColor(listOfAvailableColors, oldPixel, Kr, Kg, Kb);
                    transformedImage[i, j] = newPixel;
                    int redError = oldPixel.R - newPixel.R;
                    int greenError = oldPixel.G - newPixel.G;
                    int blueError = oldPixel.B - newPixel.B;

                    for (int x = FloydSteinbergMatrix.x; x <= 2 * FloydSteinbergMatrix.x; x++)
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
                backgroundWorker.ReportProgress((int)((double)(j + 1) / CONST.bitmapHeight * 100) % 101);
            }

            backgroundWorker.ReportProgress(100);
            return transformedImage;
        }

        public static Color[,] Burkes(Color[,] currentImage, int Kr, int Kg, int Kb, BackgroundWorker backgroundWorker)
        {
            Color[] listOfAvailableColors = Colors.GetAvailableColors(Kr, Kg, Kb);
            Color[,] transformedImage = (Color[,])currentImage.Clone();
            for (int j = 0; j < CONST.bitmapHeight; j++)
            {
                for (int i = 0; i < CONST.bitmapWidth; i++)
                {
                    Color oldPixel = transformedImage[i, j];
                    Color newPixel = Colors.GetClosestColor(listOfAvailableColors, oldPixel, Kr, Kg, Kb);
                    transformedImage[i, j] = newPixel;
                    int redError = oldPixel.R - newPixel.R;
                    int greenError = oldPixel.G - newPixel.G;
                    int blueError = oldPixel.B - newPixel.B;

                    for (int x = BurkesMatrix.x; x <= 2 * BurkesMatrix.x; x++)
                    {
                        for (int y = 0; y <= 2 * BurkesMatrix.y; y++)
                        {
                            if (Index.IsCorrectIndex(i + y - BurkesMatrix.y, j + x - BurkesMatrix.x))
                            {
                                Color transformingColor = transformedImage[i + y - BurkesMatrix.y, j + x - BurkesMatrix.x];
                                int r = Values.Round255(transformingColor.R + ((redError * BurkesMatrix.values[x, y]) / BurkesMatrix.division));
                                int g = Values.Round255(transformingColor.G + ((greenError * BurkesMatrix.values[x, y]) / BurkesMatrix.division));
                                int b = Values.Round255(transformingColor.B + ((blueError * BurkesMatrix.values[x, y]) / BurkesMatrix.division));
                                transformedImage[i + y - BurkesMatrix.y, j + x - BurkesMatrix.x] = Color.FromArgb(transformingColor.A, r, g, b);
                            }
                        }
                    }
                }
                backgroundWorker.ReportProgress((int)((double)(j + 1) / CONST.bitmapHeight * 100) % 101);
            }

            backgroundWorker.ReportProgress(100);
            return transformedImage;
        }

        public static Color[,] Stucky(Color[,] currentImage, int Kr, int Kg, int Kb, BackgroundWorker backgroundWorker)
        {
            Color[] listOfAvailableColors = Colors.GetAvailableColors(Kr, Kg, Kb);
            Color[,] transformedImage = (Color[,])currentImage.Clone();
            for (int j = 0; j < CONST.bitmapHeight; j++)
            {
                for (int i = 0; i < CONST.bitmapWidth; i++)
                {
                    Color oldPixel = transformedImage[i, j];
                    //Color newPixel = Colors.GetClosestColor(oldPixel, Kr, Kg, Kb);
                    Color newPixel = Colors.GetClosestColor(listOfAvailableColors, oldPixel, Kr, Kg, Kb);
                    transformedImage[i, j] = newPixel;
                    int redError = oldPixel.R - newPixel.R;
                    int greenError = oldPixel.G - newPixel.G;
                    int blueError = oldPixel.B - newPixel.B;

                    for (int x = StuckyMatrix.x; x <= 2 * StuckyMatrix.x; x++)
                    {
                        for (int y = 0; y <= 2 * StuckyMatrix.y; y++)
                        {
                            if (Index.IsCorrectIndex(i + y - StuckyMatrix.y, j + x - StuckyMatrix.x))
                            {
                                Color transformingColor = transformedImage[i + y - StuckyMatrix.y, j + x - StuckyMatrix.x];
                                int r = Values.Round255(transformingColor.R + ((redError * StuckyMatrix.values[x, y]) / StuckyMatrix.division));
                                int g = Values.Round255(transformingColor.G + ((greenError * StuckyMatrix.values[x, y]) / StuckyMatrix.division));
                                int b = Values.Round255(transformingColor.B + ((blueError * StuckyMatrix.values[x, y]) / StuckyMatrix.division));
                                transformedImage[i + y - StuckyMatrix.y, j + x - StuckyMatrix.x] = Color.FromArgb(transformingColor.A, r, g, b);
                            }
                        }
                    }
                }
                backgroundWorker.ReportProgress((int)((double)(j + 1) / CONST.bitmapHeight * 100) % 101);
            }

            backgroundWorker.ReportProgress(100);
            return transformedImage;
        }
    }
}
