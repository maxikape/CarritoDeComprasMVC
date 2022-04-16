using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daos
{
    public class DaoDb
    {
        static private string CadenaConexion = "Data Source= DESKTOP-P9QCAB9;Initial Catalog= CarritoDB;Integrated Security = True";
        private readonly SqlConnection Conexion = new SqlConnection(CadenaConexion);
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
            {
                if (string.IsNullOrEmpty(Conexion.ConnectionString))
                {
                    Conexion.ConnectionString = CadenaConexion;
                }
                Conexion.Open();
            }
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
