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
    /// Lógica de interacción para RegistrarAdmin.xaml
    /// </summary>
    public partial class RegistrarAdmin : Window
    {
        private const string connectionString = "Data Source=(localdb)\\senati;Initial Catalog=TIENDA;Integrated Security=True";
        public RegistrarAdmin()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nombre = Name.Text;
            string email = Email.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Admin (Nombre, Correo, Contrasena) VALUES (@Nombre, @Email, @Password)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Usuario registrado correctamente.");
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el usuario.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }

        }
        private void LimpiarCampos()
        {
            Name.Text = "";
            Email.Text = "";
            PasswordBox.Password = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginAdmin AdminLoginWindow = new LoginAdmin();
            AdminLoginWindow.Show();
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
