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
            using (DevyatkinV11Pr17Context _db = new DevyatkinV11Pr17Context())
            {
                int selectedIndex = dg1.SelectedIndex;
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
    }
}