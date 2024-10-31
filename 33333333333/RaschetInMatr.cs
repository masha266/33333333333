using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33333333333
{
    public class RaschetInMatr
    {
        public static int ColumnInMatr(int[,] matr)
        {
            int max = 0;
            int c = -1;

            for (int j = 0; j < matr.GetLength(1); j++)
            {
                int m = 0;
                for (int i = 0; i < matr.GetLength(0) - 1; i++)
                {
                    if (matr[i, j] == matr[i + 1, j])
                    {
                        m++;
                    }
                }

                if (m > max)
                {
                    max = m;
                    c = j + 1;
                }
            }

            if (c != -1)
                return c;
            else return 0;
        }
    }
}
