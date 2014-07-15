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
    /// Lógica de interacción para FrmCursos.xaml
    /// </summary>
    public partial class FrmCursos : Window
    {
        public FrmCursos()
        {
            InitializeComponent();
            //btn_detener.Visibility = Visibility.Hidden;
        }

        private void btn_ingresar_curso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(FuncionesVarias.GetCadena());
                conexion.Open();
                MySqlCommand comando = new MySqlCommand("insert into Curso (Curso, Creditos) values (@curso,@creditos)", conexion);
                comando.Parameters.AddWithValue("@curso", txt_curso.Text);
                comando.Parameters.AddWithValue("@creditos", txt_credito.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("Curso agregado exitosamente!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_automatico_Click(object sender, RoutedEventArgs e)
        {
            //txt_credito.IsEnabled = false;
            //txt_curso.IsEnabled = false;
            //btn_ingresar_curso.Visibility = Visibility.Hidden;
            //btn_detener.Visibility = Visibility.Visible;


        }

        private void btn_detener_Click(object sender, RoutedEventArgs e)
        {
            //txt_credito.IsEnabled = true;
            //txt_curso.IsEnabled = true;
            //btn_ingresar_curso.Visibility = Visibility.Visible;
            //btn_detener.Visibility = Visibility.Hidden;
        }
    }
}
