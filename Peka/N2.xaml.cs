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

namespace Peka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class N2 : Window
    {
        VHODEntities db = new VHODEntities();
        public N2()
        {
            InitializeComponent();

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            SingUp SingUp = new SingUp();
            SingUp.ShowDialog();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            VHOD emp = db.VHOD.SingleOrDefault(c => c.Login == Login.Text);
            if (emp == null)
            {
                MessageBox.Show("Такого пользователя не существует");
                return;
            }
            Func f = new Func();
            if (f.CheckPassword(emp.Password, f.GetHashPassword(Password.Password)))
            {
                MessageBox.Show($"Здравствуйте, {emp.Login}");
                N4 N4 = new N4();
                this.Close();
                N4.Show();
            }
            else
            {
                MessageBox.Show("Пароль неверный!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {    
            MainWindow c = new MainWindow();
            c.Show();
            this.Close();
        }
    }
}