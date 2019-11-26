using Grafika_Komputerowa_3.Constans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_Komputerowa_3.Helpers
{
    public static class Colors
    {
        public static Color[,,] GetAllAvailableColors(int Kr, int Kg, int Kb)
        {
            Color[,,] colors = new Color[256, 256, 256];
            Parallel.For(0, 256, r =>
            {
                for (int g = 0; g < 256; g++)
                {
                    for (int b = 0; b < 256; b++)
                    {
                        int R = GetColorNearby(r, Kr);
                        int G = GetColorNearby(g, Kg);
                        int B = GetColorNearby(b, Kb);
                        colors[r, g, b] = Color.FromArgb(R, G, B);
                    }
                }
            });
            return colors;
        }

        public static int GetColorNearby(int value, int K)
        {
            int parts = (K - 1) * 2;
            double amountInPart = (double)255 / parts;
            int whichPart = (int)(value / amountInPart);
            int i = whichPart / 2 + whichPart % 2;
            return (int)(i * 2 * amountInPart);
        }

        public static Color GetClosestColor(Color[,,] allColors, Color color)
        {
            return allColors[color.R, color.G, color.B];
        }

        public static Color[,,] GetAllAvailableColors(Color[,] image, int K, BackgroundWorker backgroundWorker)
        {
            int[,,] amount = new int[256, 256, 256];
            (Color, int)[] colorAmount = new (Color, int)[256 * 256 * 256];
            for(int i=0; i < CONST.bitmapWidth; i++)
            {
                for (int j = 0; j < CONST.bitmapHeight; j++)
                {
                    amount[image[i, j].R, image[i, j].G, image[i, j].B]++;
                }
            }

            backgroundWorker.ReportProgress(5);
            Parallel.For(0, 256, i =>
            {
                for (int j = 0; j < 256; j++)
                {
                    for (int k = 0; k < 256; k++)
                    {
                        colorAmount[i * 256 * 256 + j * 256 + k] = (Color.FromArgb(i, j, k), amount[i, j, k]);
                    }
                }
            });

            backgroundWorker.ReportProgress(40);
            (Color, int)[] sortedColors = colorAmount.OrderByDescending(x => x.Item2).ToArray();
            Color[] availableColors = new Color[K];
            for(int i=0;i<K;i++)
            {
                availableColors[i] = sortedColors[i].Item1;
            }

            Color[,,] colors = new Color[256, 256, 256];
            object SyncObject = new object();
            double index = 40;
            Parallel.For(0, 256, r =>
            {
                for (int g = 0; g < 256; g++)
                {
                    for (int b = 0; b < 256; b++)
                    {
                        colors[r, g, b] = GetClosestColor(availableColors, r, g, b);
                    }
                }

                lock(SyncObject)
                {
                    index += (double)60 / 256;
                    backgroundWorker.ReportProgress((int)index);
                }
            });

            return colors;
        }
        public static Color GetClosestColor(Color[] availableColors, int R, int G, int B)
        {
            Color closestColor = Color.FromArgb(0, 0, 0);
            double distance = double.MaxValue;
            for(int i=0;i<availableColors.Length;i++)
            {
                int diffR = R - availableColors[i].R;
                int diffG = G - availableColors[i].G;
                int diffB = B - availableColors[i].B;
                double currentDistance = Math.Pow(diffR, 2) + Math.Pow(diffG, 2) + Math.Pow(diffB, 2);
                if(currentDistance < distance)
                {
                    distance = currentDistance;
                    closestColor = availableColors[i];
                }
            }

            return closestColor;
        }
    }
}
