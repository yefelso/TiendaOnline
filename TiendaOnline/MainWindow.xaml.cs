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

namespace TiendaOnline
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login LoginVWindow = new Login();
            LoginVWindow.Show();
        }

        private void IngresarAdmin_Click(object sender, RoutedEventArgs e)
        {
            LoginAdmin AdminLoginWindow = new LoginAdmin();
            AdminLoginWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login LoginV = new Login();
            LoginV.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AcercaD DAacerca = new AcercaD();
            DAacerca.Show();
        }

        private void Catalogo_Click(object sender, RoutedEventArgs e)
        {
            CatalogoProductos ProductosCatalogo = new CatalogoProductos();
            ProductosCatalogo.Show();
        }
    }
}