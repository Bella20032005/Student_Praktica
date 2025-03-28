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
    /// Логика взаимодействия для PageShowStudent.xaml
    /// </summary>
    public partial class PageShowStudent : Page
    {
        public static List<Student> students { get; set; }
        Student student1 = new Student();
        Group group1 = new Group();
        public PageShowStudent(Group group)
        {
            InitializeComponent();
            group1 = group;
            refresh();
            this.DataContext = this;
        }

        private void refresh()
        {
            
            ListApp.ItemsSource = App.Connection.Student.Where(i => i.ID_Group == group1.ID).ToList();
            students = new List<Student>();
            LblCounter.Content = students.Count;
            this.DataContext = this;
        }
        private void Button_Click_Order_by_Fio(object sender, RoutedEventArgs e)
        {
            ListApp.ItemsSource = students.OrderBy(z => z.Name).ToList();

        }

        private void TxtSerch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtSerch.Text != "")
            {
                students = students.Where(z => z.Name.Contains(TxtSerch.Text) || z.Surname.Contains(TxtSerch.Text) || z.Patromic.Contains(TxtSerch.Text) || z.Phone.Contains(TxtSerch.Text)).ToList();
                ListApp.ItemsSource = students.ToList();
                LblCounter.Content = students.Count;
            }
            else
            {
                refresh();
            }
        }

        private void Button_Click_Order_by_Phone(object sender, RoutedEventArgs e)
        {
            ListApp.ItemsSource = students.OrderBy(z => z.Phone).ToList();

        }

        private void CMBTarget_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CMBTarget.SelectedValue != null)
            {
                var _sel = (CMBTarget.SelectedValue as ComboBoxItem).Content;
                switch (_sel.ToString())
                {
                    case "Очно":
                        {
                            refresh();
                            students = students.Where(z => z.Type_of_study == "Очно").ToList();
                            ListApp.ItemsSource = students.ToList();
                            LblCounter.Content = students.Count;
                            break;
                        }
                    case "Заочно":
                        {
                            refresh();
                            students = students.Where(z => z.Type_of_study == "Заочно").ToList();
                            ListApp.ItemsSource = students.ToList();
                            LblCounter.Content = students.Count;
                            break;
                        }
                    case "все":
                        {
                            refresh();
                            break;
                        }
                }
            }
        }
    }
}
