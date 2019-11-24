using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_Komputerowa_3.Constans
{
    public static class FloydSteinbergMatrix
    {
        public const int x = 1;
        public const int y = 1;
        public const int division = 16;
        public static readonly int[,] values =
        {
            { 0, 0, 0 },
            { 0, 0, 7 },
            { 3, 5, 1 }
        };
    }

    public static class BurkesMatrix
    {
        public const int x = 2;
        public const int y = 1;
        public const int division = 32;
        public static readonly int[,] values =
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 8, 4 },
            { 2, 4, 8, 4, 2 }
        };
    }

    public static class StuckyMatrix
    {
        public const int x = 2;
        public const int y = 2;
        public const int division = 42;
        public static readonly int[,] values =
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 8, 4 },
            { 2, 4, 8, 4, 2 },
            { 1, 2, 4, 2, 1 }
        };
    }
}
