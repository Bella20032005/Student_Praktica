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

namespace Student_Praktica
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
            CmbUser.ItemsSource = App.Connection.User.ToList();
            CmbDepartment.ItemsSource = App.Connection.Department.ToList();
            this.DataContext = this;
        }

        private void ClEventAutho(object sender, RoutedEventArgs e)
        {
            try
            {
                var userName = CmbUser.SelectedItem as User;
                var department = CmbDepartment.SelectedItem as Department;
                var _sel = App.Connection.User.Where(z => z.Name == userName.Name && z.Department.Name == department.Name && z.Password == TxtPassword.Password).FirstOrDefault();
                if (_sel != null)
                {
                    if (_sel.ID_Role == 1)
                    {
                        MessageBox.Show($"Добро пожаловать");
                         NavigationService.Navigate(new GroupMenu(_sel));
                    }
                    if (_sel.ID_Role == 2 )
                    {
                        NavigationService.Navigate(new AdminMenuPage());
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Неправильные данные");
            }

        }
    }
}
