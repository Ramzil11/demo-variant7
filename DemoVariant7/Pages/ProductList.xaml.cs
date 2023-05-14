using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DemoVariant7.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        public ProductList()
        {
            InitializeComponent();
            SortComboBox.ItemsSource = new List<String> { "по возрастанию", "по убыванию" };
            FiltComboBox.ItemsSource = new List<String> { "Все  диапазоны", "0-9,99%","10-14,99%","15% и более" };
            SortComboBox.SelectedIndex = 0;
            FiltComboBox.SelectedIndex = 0;
            showProduct();
        }
        void showProduct()
        {
            var prod = App.Context.Products.ToList();
            int countStock = prod.Count();
            if (!String.IsNullOrEmpty(serchTextBox.Text))
            {
                prod = prod.Where(s => s.ProductName.ToLower().Contains(serchTextBox.Text.ToLower())).ToList();
            }
            switch (SortComboBox.SelectedIndex)
            {
                case 0:
                    prod=prod.OrderBy(s=> s.ProductCost).ToList();
                    break;
                case 1:
                    prod = prod.OrderByDescending(s => s.ProductCost).ToList();
                    break;
            }
            switch (FiltComboBox.SelectedIndex)
            {
                case 1:
                    prod = prod.Where(s => s.ProductDiscountAmount>0 && s.ProductDiscountAmount<9.99).ToList();
                    break;
                case 2:
                    prod = prod.Where(s => s.ProductDiscountAmount > 10 && s.ProductDiscountAmount < 14.99).ToList();
                    break;
                case 3:
                    prod = prod.Where(s => s.ProductDiscountAmount > 15).ToList();
                    break;
            }
            list.ItemsSource = prod;
            CountPageLabel.Content = $"{prod.Count()} из {countStock}";
        }

        private void breakButton_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
            this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            App.Context.Products.ToList().ForEach(s => App.Context.Entry(s).Reload());
            showProduct();
        }

        private void serchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            showProduct();
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showProduct();
        }

        private void FiltComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showProduct();
        }
    }
}
