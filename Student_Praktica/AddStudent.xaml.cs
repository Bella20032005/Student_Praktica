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
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Page
    {
        public AddStudent()
        {
            InitializeComponent();
            CmbDepartment.ItemsSource = App.Connection.Department.ToList();
        }

         public static Boolean AddNewStudent(string _name, string _surname, string _patromic, int _department, int _group, string _tipe_study, string _phone)
         {
            try
            {
                var existingWorker = App.Connection.Student.FirstOrDefault(w => w.Phone == _phone);
                if (existingWorker != null)
                {
                    MessageBox.Show("Студент с таким номером телефона уже есть");
                    return false;
                }
                var _new = new Student()
                {
                    Name = _name,
                    Patromic = _surname,
                    Surname = _patromic,
                    ID_Dartment = _department,
                    ID_Group = _group,
                    Type_of_study = _tipe_study,
                    Phone = _phone
                };
                App.Connection.Student.Add(_new);
                App.Connection.SaveChanges();
                MessageBox.Show("Регистрация студента прошла успешно");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
         }

        private void ClEventAddNewUser(object sender, RoutedEventArgs e)
        {
            if (TxtName.Text != "" && TxtSurname.Text != "" && TxtPatromic.Text != "" && CmbDepartment.Text != "" && TxtGroup.Text != "" && TxtTypeEdication.Text != "" && TxtPhone.Text != "")
            {
                
                
                    var answer = AddStudent.AddNewStudent(TxtName.Text, TxtSurname.Text, TxtPatromic.Text, (CmbDepartment.SelectedItem as Department).ID, Convert.ToInt16(TxtGroup.Text), TxtTypeEdication.Text, TxtPhone.Text);
                      if (answer == true)
                      {
                         NavigationService.Navigate(new AdminMenuPage());
                      }
                
            }
        }

        private void CLEventRevers(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
