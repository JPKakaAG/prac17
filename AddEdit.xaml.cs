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
        
        DevyatkinV11Pr17Context _db = new DevyatkinV11Pr17Context();
        Участники _Devyatkin;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Data.devyatkin == null) 
            {
                WindowAddEdit.Title = "Добавление записи";
                btnAddEdit.Content = "Добавить";
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
