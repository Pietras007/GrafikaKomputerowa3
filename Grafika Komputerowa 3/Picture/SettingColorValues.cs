using Grafika_Komputerowa_3.Constans;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

        public static void SetColorsToGraphics(this Graphics graphics, Color[,] colorToPaint)
        {
            if (colorToPaint != null)
            {
                using (Bitmap processedBitmap = new Bitmap(CONST.bitmapWidth, CONST.bitmapHeight))
                {
                    unsafe
                    {
                        BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

                        int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
                        int heightInPixels = bitmapData.Height;
                        int widthInBytes = bitmapData.Width * bytesPerPixel;
                        byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                        Parallel.For(0, heightInPixels, y =>
                        {
                            byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                            for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                            {
                                currentLine[x] = colorToPaint[x / 4, y].B;
                                currentLine[x + 1] = colorToPaint[x / 4, y].G;
                                currentLine[x + 2] = colorToPaint[x / 4, y].R;
                                currentLine[x + 3] = colorToPaint[x / 4, y].A;
                            }
                        });
                        processedBitmap.UnlockBits(bitmapData);
                    }
                    graphics.DrawImage(processedBitmap, 0, 0);
                }
            }
        }
    }
}
