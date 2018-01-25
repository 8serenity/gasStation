using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Создать приложение бензоколонка.
//Суть приложения заключается в том, что кассир может отмечать, сколько бензина (и какого) он продал.
//Помимо этого есть также встроенная возможность продавать съестное (бургеры, напитки, шоколад).
//Всё это должно учитываться в одной программе и после оформления заказа показывать полную сумму.


namespace GasStation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> gasTypes = new List<string>();
            List<string> productTypes = new List<string>();

            gasTypes.Add("АИ-92");
            gasTypes.Add("АИ-95");
            gasTypes.Add("АИ-98");
            gasTypes.Add("ДТ");

            productTypes.Add("Burger");
            productTypes.Add("Red Bull");
            productTypes.Add("Snickers");
            
            

            gasType.ItemsSource = gasTypes;
            productType1.ItemsSource = productTypes;
            productType2.ItemsSource = productTypes;
            productType3.ItemsSource = productTypes;
        }

        private void buttonClick1(object sender, RoutedEventArgs e)
        {
            productChoosePanel2.Visibility = Visibility.Visible;
            addButton2.Visibility = Visibility.Visible;
        }

        private void buttonClick2(object sender, RoutedEventArgs e)
        {
            productChoosePanel3.Visibility = Visibility.Visible;
        }

        private void calculateClick(object sender, RoutedEventArgs e)
        {
            double sumGas = 0, sumProduct = 0;
            switch (gasType.SelectedValue.ToString())
            {
                case "АИ-92": sumGas = 158 * Int32.Parse(gasAmount.Text);
                    break;
                case "АИ-95":
                    sumGas = 178 * Int32.Parse(gasAmount.Text);
                    break;
                case "АИ-98":
                    sumGas = 198 * Int32.Parse(gasAmount.Text);
                    break;
                case "ДТ":
                    sumGas = 160 * Int32.Parse(gasAmount.Text);
                    break;
            }

            if (productType1.SelectedValue != null)
            {
                switch (productType1.SelectedValue.ToString())
                {
                    case "Burger":
                        sumProduct += 1190 * Int32.Parse(productAmount1.Text);
                        break;
                    case "Red Bull":
                        sumProduct += 590 * Int32.Parse(productAmount1.Text);
                        break;
                    case "Snickers":
                        sumProduct += 250 * Int32.Parse(productAmount1.Text);
                        break;
                }
            }

            if (productType2.SelectedValue != null)
            {
                switch (productType2.SelectedValue.ToString())
                {
                    case "Burger":
                        sumProduct += 1190 * Int32.Parse(productAmount2.Text);
                        break;
                    case "Red Bull":
                        sumProduct += 590 * Int32.Parse(productAmount2.Text);
                        break;
                    case "Snickers":
                        sumProduct += 250 * Int32.Parse(productAmount2.Text);
                        break;
                }

            }

            if (productType3.SelectedValue != null)
            {
                switch (productType3.SelectedValue.ToString())
                {
                    case "Burger":
                        sumProduct += 1190 * Int32.Parse(productAmount3.Text);
                        break;
                    case "Red Bull":
                        sumProduct += 590 * Int32.Parse(productAmount3.Text);
                        break;
                    case "Snickers":
                        sumProduct += 250 * Int32.Parse(productAmount3.Text);
                        break;
                }
            }



            Calculate calculateWindow = new Calculate();
            calculateWindow.sumText.Text += "\n" + (sumGas + sumProduct).ToString();
            calculateWindow.Show();
        }
    }
}
