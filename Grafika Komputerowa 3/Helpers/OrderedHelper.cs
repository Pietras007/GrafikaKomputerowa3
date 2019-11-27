using Grafika_Komputerowa_3.Constans;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_Komputerowa_3.Helpers
{
    public static class OrderedHelper
    {
        public static int GetClosestN(int K)
        {
            int[] tab = { 2, 3, 4, 6, 8, 12, 16 };
            int n = -1;
            for(int i=0;i< tab.Length;i++)
            {
                if(tab[i] * tab[i] * (K - 1) >= 256)
                {
                    n = tab[i];
                    break;
                }
            }
            return n;
        }

        public static int GetColorForOrdered(int color, int n, Random random, int x, int y)
        {
            int i = random.Next(n);
            int j = random.Next(n);
            if (n == 2)
            {
                return GetColorFromMatrix(color, i, j, n, D2.values, x, y);
            }
            else if(n == 3)
            {
                return GetColorFromMatrix(color, i, j, n, D3.values, x, y);
            }
            else if (n == 4)
            {
                return GetColorFromMatrix(color, i, j, n, D4.values, x, y);
            }
            else if (n == 6)
            {
                return GetColorFromMatrix(color, i, j, n, D6.values, x, y);
            }
            else if (n == 8)
            {
                return GetColorFromMatrix(color, i, j, n, D8.values, x, y);
            }
            else if (n == 12)
            {
                return GetColorFromMatrix(color, i, j, n, D12.values, x, y);
            }
            else if (n == 16)
            {
                return GetColorFromMatrix(color, i, j, n, D16.values, x, y);
            }
            return -1;
        }

        private static int GetColorFromMatrix(int color, int i, int j, int n, int[,] values, int x, int y)
        {
            if (x == -1 && y == -1)
            {
                int n2 = (int)Math.Pow(n, 2);
                int col = color / n2;
                int re = color % n2;
                if (re > values[i, j] || color == 255)
                {
                    col++;
                }

                var value = (int)(col * n2);
                return value;
            }
            else
            {
                int n2 = (int)Math.Pow(n, 2);
                int col = color / n2;
                int re = color % n2;
                int _i = x % n;
                int _j = y % n;
                if (re > values[_i, _j] || color == 255)
                {
                    col++;
                }

                var value = (int)(col * n2);
                return value;
            }
        }
    }
}
