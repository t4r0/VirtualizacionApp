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
            StreamReader objReader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "/server.txt");
            String cadenaConexion = objReader.ReadLine();
            ArrayList parametros= new ArrayList();
            while (cadenaConexion != null)
            {
                parametros.Add(cadenaConexion);
                cadenaConexion = objReader.ReadLine();
            }
            objReader.Close();
            return "server=" + parametros[0].ToString() + ";uid=" + parametros[1].ToString() + ";pwd=" 
                + parametros[2].ToString() + ";database=" + parametros[3].ToString()+";";
        }

    }
}
