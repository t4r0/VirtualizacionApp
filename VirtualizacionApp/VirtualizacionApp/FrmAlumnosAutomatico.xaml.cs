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
using System.Collections;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Timers;
using System.Threading;

namespace VirtualizacionApp
{
    /// <summary>
    /// Lógica de interacción para FrmAlumnosAutomatico.xaml
    /// </summary>
    public partial class FrmAlumnosAutomatico : Window
    {
        ArrayList nombres = new ArrayList();
        ArrayList apellidos = new ArrayList();
        System.Windows.Threading.DispatcherTimer timerInsertar = new System.Windows.Threading.DispatcherTimer();
        


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // code goes here
            insertRandom();
        }
        public FrmAlumnosAutomatico()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timerInsertar.Start();
            txtLog.Text += "Iniciado \n";
        }


        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //carga datos de los archivos de texto
            String[] tmpNombres = Properties.Resources.nombres.Split('\n');
            for (int i = 0; i < tmpNombres.Length; i++)
            {
                nombres.Add(tmpNombres[i]);
            }
            String[] tmpApellidos = Properties.Resources.apellidos.Split('\n');
            for (int i = 0; i < tmpApellidos.Length; i++)
            {
                apellidos.Add(tmpApellidos[i]);
            }
            timerInsertar.Tick += new EventHandler(dispatcherTimer_Tick);
            timerInsertar.Interval = new TimeSpan(0, 0, 5);
        }


        private DateTime fechaRandom()
        {
            Random numero = new Random();
            String fecha;
            fecha = numero.Next(1990, 2000).ToString();
            fecha += "/" + numero.Next(1, 12);
            fecha += "/" + numero.Next(1, 28);
            return Convert.ToDateTime(fecha);
        }

        private String nombreRandom()
        {
            Random numero = new Random();
            return nombres[numero.Next(0, nombres.Count - 1)].ToString();
        }

        private String apellidoRandom()
        {
            Random numero = new Random();
            return apellidos[numero.Next(0, apellidos.Count - 1)].ToString();
        }

        private void insertRandom()
        {
            String nombre = nombreRandom();
            String apellido = apellidoRandom();
            DateTime fecha = fechaRandom();
            try
            {
                MySqlConnection conexion = new MySqlConnection(FuncionesVarias.GetCadena());
                conexion.Open();
                MySqlCommand comando = new MySqlCommand("insert into Alumnos (Nombre, Apellido, FechaNacimiento) values (@nom,@ape,@fec)", conexion);
                comando.Parameters.AddWithValue("@nom", nombre);
                comando.Parameters.AddWithValue("@ape", apellido);
                comando.Parameters.AddWithValue("@fec", fecha);
                comando.ExecuteNonQuery();
                txtLog.Text += "Registro ingresado: " + nombre + " " + apellido + " " + String.Format("{0:dd/MM/yyyy}", fecha) + "\n";
            }
            catch (MySqlException ex)
            {
                txtLog.Text += ex.Message;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            timerInsertar.Stop();
            txtLog.Text += "Detenido \n";
        }
    }
}
