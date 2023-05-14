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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoVariant7.Pages;

namespace DemoVariant7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result=App.Context.Users.ToList().FirstOrDefault(s=>s.UserPassword==passwordTexBox.Text && s.UserLogin==loginTexBox.Text);
            if(result != null )
            {
                ProductList product = new ProductList();
                product.UserFio.Content = $"{result.UserSurname} {result.UserName} {result.UserPatronymic}";
                product.Show();
                this.Close();
                MessageBox.Show("Вы успешно авторизовались");
            }
            else
            {
                MessageBox.Show("Вы ввели не верный логин или пароль");
            }
        }

        private void selectGuest_Click(object sender, RoutedEventArgs e)
        {

            ProductList product = new ProductList();
            product.Show();
            this.Close();
        }
    }
}
