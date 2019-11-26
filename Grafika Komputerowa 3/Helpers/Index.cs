using Grafika_Komputerowa_3.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_Komputerowa_3.Helpers
{
    public static class Index
    {
        public static bool IsCorrectIndex(int xIndex, int yIndex)
        {
            if(xIndex < 0 || xIndex >= CONST.bitmapWidth || yIndex < 0 || yIndex >= CONST.bitmapHeight)
            {
                return false;
            }
            return true;
        }
    }
}
