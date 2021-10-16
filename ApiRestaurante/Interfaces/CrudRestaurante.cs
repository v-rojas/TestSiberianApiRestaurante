
using ApiRestaurante.DBConnection;
using ApiRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApiRestaurante.Interfaces
{
    public class CrudRestaurante : ICrudRestaurante
    {
        public List<Restaurante> SpMetodos(Restaurante restaurante)
        {
            List<Restaurante> lista = new List<Restaurante>();
            using (ConexionSQL sql = new ConexionSQL())
            {
                try
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "SP_Restaurantes";
                    sql.Comando.Parameters.AddWithValue("@codigo", restaurante.Codigo);
                    sql.Comando.Parameters.AddWithValue("@IDRestaurante", restaurante.IDRestaurante);
                    sql.Comando.Parameters.AddWithValue("@NombreRestaurante", restaurante.NombreRestaurante);
                    sql.Comando.Parameters.AddWithValue("@IDCiudad", restaurante.IDCiudad);
                    sql.Comando.Parameters.AddWithValue("@NumeroAforo", restaurante.NumeroAforo);
                    sql.Comando.Parameters.AddWithValue("@Telefono", restaurante.Telefono);
                    using (IDataReader reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                        {
                            Restaurante r = new Restaurante
                            {
                                IDRestaurante = reader["IDRestaurante"].ToString(),
                                NombreRestaurante = reader["NombreRestaurante"].ToString(),
                                IDCiudad = reader["IDCiudad"].ToString(),
                                NombreCiudad = reader["NombreCiudad"].ToString(),
                                NumeroAforo = reader["NumeroAforo"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                FechaCreacion = reader["FechaCreacion"].ToString()
                            };
                            lista.Add(r);
                        }
                    }
                    sql.CerrarConexion();
                }
                catch (SqlException exSQL)
                {
                    sql.CerrarConexion();
                    throw exSQL;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sql.CerrarConexion();
                }
            }
            return lista;
        }
    }
}
