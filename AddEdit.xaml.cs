using prac17.models;
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

namespace prac17
{
    /// <summary>
    /// Логика взаимодействия для AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Window
    {
        public AddEdit()
        {
            InitializeComponent();
        }
        
        Devyatkinv11pr17Context _db = new Devyatkinv11pr17Context();
        Участники _Devyatkin;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Data.devyatkin == null) 
            {
                WindowAddEdit.Title = "Добавление записи";
                btnAddEdit.Content = "Добавить";
                _Devyatkin = new Участники();
            }
            else
            {
                WindowAddEdit.Title = "Измененик записи";
                btnAddEdit.Content = "Изменить";
                _Devyatkin = _db.Участникиs.Find(Data.devyatkin.Id);
            }
            WindowAddEdit.DataContext = _Devyatkin;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (tbF.Text.Length == 0 ) errors.AppendLine("Введите фамилию");
            if (tbN.Text.Length == 0) errors.AppendLine("Введите имя");
            if (tbO.Text.Length == 0) errors.AppendLine("Введите отчество");
            if (tbFTR.Text.Length == 0) errors.AppendLine("Введите фамилию тренера");
            if (tbCity.Text.Length == 0) errors.AppendLine("Введите город");
            if (tbEstimation.Text.Length == 0) errors.AppendLine("Введите оценку");
            if (tbDance.Text.Length == 0) errors.AppendLine("Введите танец");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {
                if (Data.devyatkin == null)
                {
                    _db.Участникиs.Add(_Devyatkin);
                    _db.SaveChanges();
                }
                else
                {
                    _db.SaveChanges();
                }
                this.Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
