using ADOtest;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ADOtestModule
{
    public class DbExecutor
    {
        private MainConnector connector;

        public DbExecutor(MainConnector connector)
        {
            this.connector = connector;
        }

        public DataTable SelectAll(string table)
        {
            var selectcommandtext = "select * from " + table;
            var adapter = new SqlDataAdapter(
            selectcommandtext,
            connector.GetConnection()
            );
            var ds = new DataSet();
            adapter.Fill(ds);
            return ds.Tables[0];
        }

        public SqlDataReader SelectAllCommandReader(string table) 
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "select * from " + table,
                Connection = connector.GetConnection()
            };
            
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                return reader;
            }

            return null;
        }

        public int DeleteByColumnCommand(string table, string column, string value) 
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "delete from " + table + " where " + column + " = '" + value+ "'",
                Connection = connector.GetConnection()
            };

            return command.ExecuteNonQuery();
        }

        public int UpdateByColumn(string login, string newName) 
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdatingUserNameProc",
                Connection = connector.GetConnection()
            };

            command.Parameters.Add(new SqlParameter("@Login", login));
            command.Parameters.Add(new SqlParameter("@NewName", newName));
            
            return command.ExecuteNonQuery();
        }

        public int AddNewUser(string name, string login) 
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddingUserProc",
                Connection = connector.GetConnection()
            };

            command.Parameters.Add(new SqlParameter("@Name", name));
            command.Parameters.Add(new SqlParameter("@Login", login));

            return command.ExecuteNonQuery();
        }
    }
}
