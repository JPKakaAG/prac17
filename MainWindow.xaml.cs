using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using prac17.models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prac17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBInDataGrid();
        }
        
       void LoadDBInDataGrid() 
       {
            using (Devyatkinv11pr17Context _db = new Devyatkinv11pr17Context())
            {
                int selectedIndex = dg1.SelectedIndex;
                _db.Участникиs.Load();
                dg1.ItemsSource = _db.Участникиs.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == dg1.Items.Count) selectedIndex--;
                    dg1.SelectedIndex = selectedIndex;
                    dg1.ScrollIntoView(dg1.SelectedItem);
                }
                dg1.Focus();
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Data.devyatkin = null;
            AddEdit f = new AddEdit();
            f.Owner = this;
            f.ShowDialog();
            LoadDBInDataGrid();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(dg1.SelectedItem != null) 
            {
                Data.devyatkin = (Участники)dg1.SelectedItem;
                AddEdit f = new AddEdit();
                f.Owner = this;
                f.ShowDialog();
                LoadDBInDataGrid();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes) 
            { 
                try
                {
                    Участники row = (Участники)dg1.SelectedItem;
                    if (row != null) 
                    { 
                        using(Devyatkinv11pr17Context _db = new Devyatkinv11pr17Context())
                        {
                            _db.Участникиs.Remove(row);
                            _db.SaveChanges();
                        }
                        LoadDBInDataGrid();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else dg1.Focus();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            List<Участники> listitem = (List<Участники>)dg1.ItemsSource;
            var filtered = listitem.Where(p => p.Фамилия.Contains(tbFind.Text));
            if (filtered.Count() > 0)
            {
                var item = filtered.First();
                dg1.SelectedItem = item;
                dg1.ScrollIntoView(item);
                dg1.Focus();
            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (tbFilter.Text.IsNullOrEmpty()==false)
            {
                using (Devyatkinv11pr17Context _db = new Devyatkinv11pr17Context())
                {
                    var filter = _db.Участникиs.Where(p => p.Фамилия == tbFilter.Text);
                    dg1.ItemsSource = filter.ToList();
                }

            }
            else 
            {
                LoadDBInDataGrid();
            }
        }
    }
}