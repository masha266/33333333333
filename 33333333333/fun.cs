using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _33333333333
{
    public class WorkWithMassiv
    {

        public static void InitMas(out int[,] matr, int row, int column) // заполнение
        {
                Random Rnd = new Random();
                matr = new Int32[row, column]; 
            try
            {
                for (int i = 0; i < matr.GetLength(0); i++)
                    for (int j = 0; j < matr.GetLength(1); j++) matr[i, j] = Rnd.Next(7);
            }
            catch (Exception ex) { MessageBox.Show($"Произошла ошибка. Возможно вы ввели отрицательное число"); }
        }



        public static void ClearMas(ref int[,] matr)
        {
            matr = null;
        }


        public static void SaveMas(int[,] matr) // сохранение
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) |*.*| Текстовые файлы | *.txt*";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {
                StreamWriter outfile = new StreamWriter(save.FileName, false);
                outfile.WriteLine(matr.GetLength(0));
                outfile.WriteLine(matr.GetLength(1));
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        outfile.WriteLine(matr[i, j]);
                    }
                }
                outfile.Close();
            }
            else MessageBox.Show("Не удалось открыть окно");
        }

       
        public static void OpenMas(ref int[,] matr) // открытие
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) |*.*| Текстовые файлы | *.txt*";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);
                int row = Convert.ToInt32(file.ReadLine());
                int col = Convert.ToInt32(file.ReadLine());
                matr = new int[row, col];
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        string a = file.ReadLine();
                        bool f1;
                        int value;
                        f1 = int.TryParse(a, out value);
                        if (f1)
                        {
                            matr[i, j] = value;

                        }
                        else MessageBox.Show("Некоректные значения");
                    }
                }
                file.Close();
            }
            else MessageBox.Show("Ничего не было открыто");
        }
    }
}
