using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_Komputerowa_3.Helpers
{
    public static class Colors
    {
        public static int GetClosestColor(int original, int K)
        {
            if (original > 127)
            {
                int z = 4;
            }
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
    }
}
