using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MVC_Contactos.Data
{
    public class ConexionData
    {
        string cadenaSql = "";

        public ConexionData()
        {
            //Obtenemos la cadena de conexión
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSql = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string GetCadenaSQL()
        {
            return cadenaSql;
        }
    }
}
