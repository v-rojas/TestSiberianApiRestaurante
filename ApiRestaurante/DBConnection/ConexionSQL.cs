using System;
using System.Data;
using System.Data.SqlClient;

namespace ApiRestaurante.DBConnection
{
    public class ConexionSQL : IDisposable
    {        
        private SqlConnection laConexion;
        public SqlCommand Comando { get; set; }

        private Base conexion = new Base();

        public ConexionSQL()
        {
            laConexion = conexion.GetConexion();
            Comando = new SqlCommand();
        }

        public void AbrirConexion()
        {
            if (laConexion.State != ConnectionState.Open)
                laConexion.Open();
        }

        public void CerrarConexion()
        {
            if (laConexion.State != ConnectionState.Closed)
                laConexion.Close();
        }

        public IDataReader EjecutaReader()
        {
            IDataReader respuesta;
            AbrirConexion();
            Comando.Connection = laConexion;
            respuesta = Comando.ExecuteReader(CommandBehavior.CloseConnection);
            return respuesta;
        }

        public int EjecutaQuery()
        {
            int respuesta;
            try
            {
                AbrirConexion();
                Comando.Connection = laConexion;
                respuesta = Comando.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (SqlException exSQL)
            {              
                throw exSQL;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return respuesta;
        }

        public void Dispose()
        {
            CerrarConexion();
            laConexion = null;
        }
    }
}
