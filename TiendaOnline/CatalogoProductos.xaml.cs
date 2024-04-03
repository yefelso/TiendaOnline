using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace TiendaOnline
{
    /// <summary>
    /// Lógica de interacción para CatalogoProductos.xaml
    /// </summary>
    public partial class CatalogoProductos : Window
    {
        private const string connectionString = "Data Source=(localdb)\\senati;Initial Catalog=Venta;Integrated Security=True";
        public CatalogoProductos()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT Nombre FROM Productos", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductoCombo.Items.Add(reader["Nombre"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selectedProduct = ProductoCombo.SelectedItem.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT Precio FROM Productos WHERE Nombre = @Nombre", connection);
                    command.Parameters.AddWithValue("@Nombre", selectedProduct);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Subtotal.Content = reader["Precio"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el precio del producto: " + ex.Message);
            }
        }
        private void CalcularSubtotal()
        {
            try
            {
                if (!string.IsNullOrEmpty(Subtotal.Content.ToString()) && !string.IsNullOrEmpty(Cantidad.Text))
                {
                    decimal precio = Convert.ToDecimal(Subtotal.Content);
                    int cantidad = Convert.ToInt32(Cantidad.Text);
                    decimal subtotal = precio * cantidad;
                    Subtotal.Content = subtotal.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el subtotal: " + ex.Message);
            }
        }
        private void Cantidad_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CalcularSubtotal();
        }
    }
}
