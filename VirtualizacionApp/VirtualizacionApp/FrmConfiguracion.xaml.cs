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
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Cadena = txtServer.Text + "\n" + txtUsuario.Text + "\n" + txtPassword.Password + "\n" + txtDatabase.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
