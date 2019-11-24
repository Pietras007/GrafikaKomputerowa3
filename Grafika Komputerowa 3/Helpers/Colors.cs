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
        public static int GetClosestColor(int original, int K)
        {
            double parts = (K - 1) * 2;
            double amountInPart = 255 / parts;
            for (int i = 0; i < parts; i++)
            {
                if (original < (i + 1) * amountInPart)
                {
                    if (i % 2 == 0)
                    {
                        return (int)(i * amountInPart);
                    }
                    else
                    {
                        return (int)((i + 1) * amountInPart);
                    }
                }
            }

            return int.MinValue;
        }

        public static Color GetClosestColor(Color color, int Kr, int Kg, int Kb)
        {
            Color closestColor = Color.FromArgb(0, 0, 0);
            double distance = int.MaxValue;

            for (int i = 0; i < Kr; i++)
            {
                for (int j = 0; j < Kr; j++)
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
