using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika_Komputerowa_3.Picture
{
    public static class SettingColorValues
    {
        public static Color[,] GetColorsTable(this Bitmap bitmap, int width, int height)
        {
            Color[,] colorTable = new Color[width, height];
            for(int i=0;i<width;i++)
            {
                for(int j=0;j<height;j++)
                {
                    colorTable[i, j] = bitmap.GetPixel(i, j);
                }
            }

            return colorTable;
        }

        public static void SetColorsToGraphics(this Graphics graphics, Color[,] colors)
        {

        }
    }
}
