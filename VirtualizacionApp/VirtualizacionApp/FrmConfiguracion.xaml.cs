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
using System.IO;
using System.Collections;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace VirtualizacionApp
{
    /// <summary>
    /// Lógica de interacción para FrmConfiguracion.xaml
    /// </summary>
    public partial class FrmConfiguracion : Window
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            String[] tmpConexion = Properties.Settings.Default.Cadena.Split('\n');
            ArrayList parametros = new ArrayList();
            for (int i = 0; i < tmpConexion.Length; i++)
            {
                parametros.Add(tmpConexion[i]);
            }
            txtServer.Text = parametros[0].ToString();
            txtUsuario.Text = parametros[1].ToString();
            txtPassword.Password = parametros[2].ToString();
            txtDatabase.Text = parametros[3].ToString();
            txtIntervalo.Text = Properties.Settings.Default.Intervalo.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.Cadena = txtServer.Text + "\n" + txtUsuario.Text + "\n" + txtPassword.Password + "\n" + txtDatabase.Text;
                Properties.Settings.Default.Intervalo = Convert.ToInt16(txtIntervalo.Text);
                Properties.Settings.Default.Save();
                MessageBox.Show("Configuraciones guardadas correctamente");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error verifique el valor de los campos");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(FuncionesVarias.GetCadena());
                conexion.Open();
                MessageBox.Show("Conexion exitosa");
            }
            catch
            {
                MessageBox.Show("Conexion no correcta");
            }
        }
    }
}
