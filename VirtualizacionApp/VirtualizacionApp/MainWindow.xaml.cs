﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VirtualizacionApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new FrmAlumnos().Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new FrmAlumnosAutomatico().Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new FrmConfiguracion().Show();
        }

        private void btn_cursos_Click(object sender, RoutedEventArgs e)
        {
            new FrmCursos().Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new FrmCursosAutomatico().Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.cursos);
        }
    }
}
