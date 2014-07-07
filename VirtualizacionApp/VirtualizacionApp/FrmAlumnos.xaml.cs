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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Collections;

namespace VirtualizacionApp
{
    /// <summary>
    /// Lógica de interacción para FrmAlumnos.xaml
    /// </summary>
    public partial class FrmAlumnos : Window
    {
        public FrmAlumnos()
        {
            InitializeComponent();
            dtpFecha.SelectedDate = DateTime.Today;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader objReader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "/server.txt");
                String cadenaConexion = objReader.ReadLine();
                MySqlConnection conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
                MySqlCommand comando = new MySqlCommand("insert into Alumnos (Nombre, Apellido, FechaNacimiento) values (@nom,@ape,@fec)",conexion);
                comando.Parameters.AddWithValue("@nom", txtNombre.Text);
                comando.Parameters.AddWithValue("@ape", txtApellido.Text);
                comando.Parameters.AddWithValue("@fec", dtpFecha.SelectedDate);
                comando.ExecuteNonQuery();
                MessageBox.Show("registro exitosos");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
