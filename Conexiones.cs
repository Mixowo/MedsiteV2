using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MedsiteV2
{
    public class Conexiones
    {

        private SqlConnection cn = new SqlConnection("Data Source=LAP_EDUARDO;Initial Catalog=SALUD_VITAL2;Integrated Security=True");

        public SqlConnection AbrirConexion()
        {
            if (cn.State == System.Data.ConnectionState.Closed)
                cn.Open();
            return cn;
        }

        public void CerrarConexion()
        {
            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }
    }
}
