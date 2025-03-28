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
    /// Логика взаимодействия для AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        public static List<Student> students { get; set; }

        public AdminMenuPage()
        {
            InitializeComponent();
            refresh();
           
        }
        private void refresh()
        {
            students = new List<Student>(App.Connection.Student.ToList());
            ListAllStudent.ItemsSource = students.ToList();
            LblCounter.Content = students.Count;
        }



        private void ClEventAddNewStudent(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStudent());

        }

        private void TxtSerch_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            if (TxtSerch.Text != "")
            {
                students = students.Where(z => z.Name.Contains(TxtSerch.Text) || z.Surname.Contains(TxtSerch.Text) || z.Patromic.Contains(TxtSerch.Text) || z.Phone.Contains(TxtSerch.Text)).ToList();
                ListAllStudent.ItemsSource = students.ToList();
                LblCounter.Content = students.Count;
            }
            else
            {
                refresh();
            }
        } 
        
        private void Button_Click_Delit(object sender, RoutedEventArgs e)
        {
            if(ListAllStudent.SelectedItem != null)
            {
                var _sel = (ListAllStudent.SelectedItem as Student);
                if (System.Windows.MessageBox.Show($"вы уверенны, что хотите удалить \n{_sel.Name.ToString()}", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    App.Connection.Student.Remove(_sel);
                    App.Connection.SaveChanges();
                    refresh();

                }
            }
            else 
            {
                 MessageBox.Show("Выберите студента"); 
            }

        }
    }
}
