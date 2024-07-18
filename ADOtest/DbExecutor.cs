﻿using ADOtest;
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
    }
}
