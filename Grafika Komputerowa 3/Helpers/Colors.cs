using Grafika_Komputerowa_3.Constans;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_Komputerowa_3.Helpers
{
    public static class Colors
    {
        public static Color[] GetAvailableColors(int Kr, int Kg, int Kb)
        {
            Color[] colors = new Color[Kr * Kg * Kb];
            Parallel.For(0, Kr, i =>
            //for(int i=0;i<Kr;i++)
            {
                for (int j = 0; j < Kg; j++)
                {
                    for (int k = 0; k < Kb; k++)
                    {
                        int colR = GetColor(i, Kr);
                        int colG = GetColor(j, Kg);
                        int colB = GetColor(k, Kb);
                        colors[i * Kg * Kb + j * Kb + k] = Color.FromArgb(colR, colG, colB);
                    }
                }
            });

            return colors;
        }

        public static Color GetClosestColor(Color[] colorsTab, Color color, int Kr, int Kg, int Kb)
        {
            int indexColor = -1;
            if (Kr * Kg * Kb > 200)
            {
                int[] index = new int[CONST.threadsNumber];
                double[] distance = new double[CONST.threadsNumber];
                Parallel.For(0, CONST.threadsNumber, thread =>
                {
                    distance[thread] = double.MaxValue;
                    for (int i = thread; i < colorsTab.Length; i += CONST.threadsNumber)
                    {
                        int redDiff = color.R - colorsTab[i].R;
                        int greenDiff = color.G - colorsTab[i].G;
                        int blueDiff = color.B - colorsTab[i].B;
                        double currentDistance = Math.Pow(redDiff, 2) + Math.Pow(greenDiff, 2) + Math.Pow(blueDiff, 2);
                        if (currentDistance < distance[thread])
                        {
                            distance[thread] = currentDistance;
                            index[thread] = i;
                        }
                    }
                });

                double min = double.MaxValue;
                for (int i = 0; i < CONST.threadsNumber; i++)
                {
                    if (distance[i] < min)
                    {
                        min = distance[i];
                        indexColor = index[i];
                    }
                }
            }
            else
            {
                double distance2 = double.MaxValue;
                for (int i = 0; i < colorsTab.Length; i++)
                {
                    int redDiff = color.R - colorsTab[i].R;
                    int greenDiff = color.G - colorsTab[i].G;
                    int blueDiff = color.B - colorsTab[i].B;
                    double currentDistance = Math.Pow(redDiff, 2) + Math.Pow(greenDiff, 2) + Math.Pow(blueDiff, 2);
                    if (currentDistance < distance2)
                    {
                        distance2 = currentDistance;
                        indexColor = i;
                    }
                }
            }

            return colorsTab[indexColor];
        }

        public static Color GetClosestColor(Color color, int Kr, int Kg, int Kb)
        {
            Color closestColor = Color.FromArgb(0, 0, 0);
            double distance = int.MaxValue;

            for (int i = 0; i < Kr; i++)
            {
                for (int j = 0; j < Kg; j++)
                {
                    for (int k = 0; k < Kb; k++)
                    {
                        int colR = GetColor(i, Kr);
                        int colG = GetColor(j, Kg);
                        int colB = GetColor(k, Kb);
                        int redDiff = color.R - colR;
                        int greenDiff = color.G - colG;
                        int blueDiff = color.B - colB;
                        double currentDistance = Math.Pow(redDiff, 2) + Math.Pow(greenDiff, 2) + Math.Pow(blueDiff, 2);
                        if (currentDistance < distance)
                        {
                            distance = currentDistance;
                            closestColor = Color.FromArgb(color.A, colR, colG, colB);
                        }
                    }
                }
            }

            return closestColor;
        }

        private static int GetColor(int i, int K)
        {
            double parts = (K - 1) * 2;
            double amountInPart = 255 / parts;
            return (int)(i * 2 * amountInPart);
        }
    }
}
