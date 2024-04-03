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
    /// Lógica de interacción para LoginAdmin.xaml
    /// </summary>
    public partial class LoginAdmin : Window
    {
        private const string connectionString = "Data Source=(localdb)\\senati;Initial Catalog=Venta;Integrated Security=True";
        public LoginAdmin()
        {
            InitializeComponent();
        }

        private void Ingresar_Click_1(object sender, RoutedEventArgs e)
        {
            string email = Email.Text;
            string password = PasswordBox.Password;

            if (VerificarCredenciales(email, password))
            {
                MessageBox.Show("¡Inicio de sesión exitoso!");
                // Aquí podrías abrir la ventana principal de tu aplicación o realizar otras acciones
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos. Por favor, inténtelo de nuevo.");
            }
        }

        private bool VerificarCredenciales(string email, string password)
        {
            bool credencialesCorrectas = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Admin WHERE Correo = @Email AND Contrasena = @Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        credencialesCorrectas = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar las credenciales: " + ex.Message);
            }

            return credencialesCorrectas;
        }

        private void Registrarse_Click(object sender, RoutedEventArgs e)
        {
            RegistrarAdmin AdminRegistrarWindow = new RegistrarAdmin();
            AdminRegistrarWindow.Show();
        }
    }
}
