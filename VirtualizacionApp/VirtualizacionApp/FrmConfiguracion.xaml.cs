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
            StreamReader objReader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "/server.txt");
            String cadenaConexion = objReader.ReadLine();
            ArrayList parametros = new ArrayList();
            while (cadenaConexion != null)
            {
                parametros.Add(cadenaConexion);
                cadenaConexion = objReader.ReadLine();
            }
            objReader.Close();
            txtServer.Text = parametros[0].ToString();
            txtUsuario.Text = parametros[1].ToString();
            txtPassword.Password = parametros[2].ToString();
            txtDatabase.Text = parametros[3].ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StreamWriter nuevo = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory + "/server.txt");
            nuevo.WriteLine(txtServer.Text);
            nuevo.WriteLine(txtUsuario.Text);
            nuevo.WriteLine(txtPassword.Password);
            nuevo.WriteLine(txtDatabase.Text);
            nuevo.Close();
        }
    }
}
