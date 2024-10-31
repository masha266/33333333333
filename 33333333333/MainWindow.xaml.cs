using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using lib_10;

namespace _33333333333
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        int[,] matr;
        int value, value1;
        bool f, c;

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана целочисленная матрица размера M × N. Найти номер первого из ее столбцов, содержащих максимальное количество одинаковых элементов.  \nРазарботчик: Тюшевская Маша ИСП-31");
        }

        public void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //Заполнение
        public void miFill_Click(object sender, RoutedEventArgs e)
        {
            f = Int32.TryParse(kolsto.Text, out value);
            c = Int32.TryParse(stroki.Text, out value1);
            if (f && c == true)
            {
                WorkWithMassiv.InitMas(out matr, value1, value);
                dataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
            else MessageBox.Show("Введите корректные значения");
        }

        //Создание
        public void miCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                 f = Int32.TryParse(kolsto.Text, out value);
                 c = Int32.TryParse(stroki.Text, out value1);
                 if (f && c == true)
                 {
                     matr = new int[value1, value]; // добавить защиту на отрицательные значения
                     dataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
                 }
                 else MessageBox.Show("Введиет корректные значания");
            }catch (Exception ex) { MessageBox.Show($"Произошла ошибка. Возможно вы ввели отрицательное число"); }
            
        }


        //Очистка
        public void miClear_CLick(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            WorkWithMassiv.ClearMas(ref matr);
            kolsto.Clear();
            stroki.Clear();
            tbSum.Clear();

        }

        //Сохранение
        private void Save_CLick(object sender, RoutedEventArgs e)
        {
            WorkWithMassiv.SaveMas(matr);
        }

        //Открытие
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            WorkWithMassiv.OpenMas(ref matr);
            dataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
        }


        //Проверка на корректность значений и обновление данных
        public void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {


            DataGrid grid = sender as DataGrid;
            if (grid != null)
            {
                int rowIndex = e.Row.GetIndex();
                int columnIndex = e.Column.DisplayIndex;

                TextBox editedTextbox = e.EditingElement as TextBox;
                if (editedTextbox != null)
                {
                    int newValue;
                    if (int.TryParse(editedTextbox.Text, out newValue)) // проверка
                    {
                        // Обновляем значение в матрице matr
                        matr[rowIndex, columnIndex] = newValue;
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное числовое значение.");
                        // Возвращаем предыдущее значение в ячейку
                        editedTextbox.Text = matr[rowIndex, columnIndex].ToString();
                    }
                }
            }

        }
        //Расчет
        public void miCalc_CLick(object sender, RoutedEventArgs e)
        {
            if (matr != null) // условие, что введено не пустое значение
            {
                tbSum.Text = Convert.ToString(RaschetInMatr.ColumnInMatr(matr));
            }
            else MessageBox.Show("Введите значения");
        }
    }
}