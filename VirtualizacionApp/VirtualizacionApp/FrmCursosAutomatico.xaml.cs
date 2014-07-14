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
    /// Lógica de interacción para FrmCursosAutomatico.xaml
    /// </summary>
    public partial class FrmCursosAutomatico : Window
    {
        ArrayList cursos = new ArrayList();
        ArrayList apellidos = new ArrayList();
        System.Windows.Threading.DispatcherTimer timerInsertar = new System.Windows.Threading.DispatcherTimer();

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // code goes here
            insertRandom();
        }

        private void insertRandom()
        {
            String curso = cursoRandom();
            Random numero = new Random();
            int creditos = numero.Next(1, 10);
            try
            {
                MySqlConnection conexion = new MySqlConnection(FuncionesVarias.GetCadena());
                conexion.Open();
                MySqlCommand comando = new MySqlCommand("insert into Curso(Curso, Creditos) values (@cur,@cre)", conexion);
                comando.Parameters.AddWithValue("@cur", curso);
                comando.Parameters.AddWithValue("@cre", creditos);
                comando.ExecuteNonQuery();
                txtLog.Text += "Registro ingresado, Curso:" + curso + " Creditos: " + creditos.ToString()+ "\n";
            }
            catch (MySqlException ex)
            {
                txtLog.Text += ex.Message;
            }
        }

        public FrmCursosAutomatico()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timerInsertar.Start();
            txtLog.Text += "Iniciado \n";
        }

        private String cursoRandom()
        {
            Random numero = new Random();
            return cursos[numero.Next(0, cursos.Count - 1)].ToString();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            String[] tmpcursos =  Properties.Resources.cursos.Split('\n');
            for (int i = 0; i < tmpcursos.Length; i++)
            {
                cursos.Add(tmpcursos[i]);
            }
            timerInsertar.Tick += new EventHandler(dispatcherTimer_Tick);
            timerInsertar.Interval = new TimeSpan(0, 0, 5);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            timerInsertar.Stop();
            txtLog.Text += "Detenido \n";
        }
    }
}
