using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace VirtualizacionApp
{
    static class FuncionesVarias
    {
        public static String GetCadena(){
            String[] tmpConexion = Properties.Settings.Default.Cadena.Split('\n');
            ArrayList parametros = new ArrayList();
            for (int i = 0; i < tmpConexion.Length; i++)
            {
                parametros.Add(tmpConexion[i]);
            }
            return "server=" + parametros[0].ToString() + ";uid=" + parametros[1].ToString() + ";pwd=" 
                + parametros[2].ToString() + ";database=" + parametros[3].ToString()+";";
        }

    }
}
