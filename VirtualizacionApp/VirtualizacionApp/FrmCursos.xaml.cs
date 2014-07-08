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
        }

        private void btn_ingresar_curso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader objReader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "/server.txt");
                String cadenaConexion = objReader.ReadLine();
                MySqlConnection conexion = new MySqlConnection(cadenaConexion);
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
    }
}
