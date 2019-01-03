using TesteStore.Shared;
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace TesteStore.Infra.StoreContexts.DataContexts
{
    public class TesteDataContext : IDisposable
    {

        public MySqlConnection _Connection { get; set; }
        public object Connection { get; internal set; }

        public TesteDataContext()
        {
            try
            {
                this._Connection = new MySqlConnection(Settings.ConnectionString);
                this._Connection.Open();
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
           
        }

        public void Dispose()
        {
            if (this._Connection.State != ConnectionState.Closed)
                this._Connection.Close();
        }
    }
}
