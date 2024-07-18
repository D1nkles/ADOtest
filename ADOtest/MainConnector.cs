using ADOtest.Configurations;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ADOtest
{
    public class MainConnector
    {
        public SqlConnection connection;
        public async Task<bool> ConnectAsync()
        {
            bool result;
            try
            {
                connection = new SqlConnection(ConnectionString.MsSqlConnection);
                await connection.OpenAsync();
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public async void DisconnectAsync()
        {
            if (connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }
}
