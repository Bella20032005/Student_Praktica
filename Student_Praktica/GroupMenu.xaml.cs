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
    /// Логика взаимодействия для GroupMenu.xaml
    /// </summary>
    public partial class GroupMenu : Page
    {
        User user1 = new User();
        public GroupMenu(User user)
        {
            InitializeComponent();
            user1 = user;
            ListGroup.ItemsSource = App.Connection.Group.Where(i => i.ID_Department == user1.ID_Department).ToList();
            this.DataContext = this;

        }

        private void ListGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var _sel = App.Connection.Group.ToList();
            if (_sel != null)
            {
                if (ListGroup.SelectedItem != null)
                {
                NavigationService.Navigate(new PageShowStudent(_sel));
                }
            }
               
        }
    }
}
