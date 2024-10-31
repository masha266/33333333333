using System.Data;

namespace lib_10
{
    public static class VisualArray
    {
        //Метод для двухмерного массива
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            if (matrix != null)
            {
                for (int i = 0; i < matrix.GetLength(1); i++) // добавить защиту открытия
                {
                    res.Columns.Add("Элемент №" + (i + 1), typeof(T));
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    var row = res.NewRow();

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        row[j] = matrix[i, j];
                    }

                    res.Rows.Add(row);
                }
            }

            return res;
        }
    }
}
