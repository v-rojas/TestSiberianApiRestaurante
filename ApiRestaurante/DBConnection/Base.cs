using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace ApiRestaurante.DBConnection
{
    public class Base : DbContext
    {
        private IConfiguration _configuration;
        public Base(IConfiguration configuration)
        {
            _configuration = configuration;
        }
     
        public Base()
        {
        }

        public SqlConnection GetConexion()
        {
            try
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("appsettings.json", optional: false);
                _configuration = builder.Build();
                var sql = _configuration.GetConnectionString("ConnStr").ToString();
                return new SqlConnection(sql);
            }
            catch (SqlException exSQL)
            {
                throw exSQL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
