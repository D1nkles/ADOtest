﻿using ADOtest;
using ADOtestModule;
using System.Data;
class Program 
{
    static void Main(string[] args)
    {
        var connector = new MainConnector();

        var result = connector.ConnectAsync();

        var data = new DataTable();

        if (result.Result)
        {
            Console.WriteLine("Подключено успешно!");

            var db = new DbExecutor(connector);
            var tablename = "NetworkUser";

            Console.WriteLine("Получаем данные таблицы " + tablename);

            data = db.SelectAll(tablename);

            Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);

            foreach (DataColumn column in data.Columns) 
            {
                Console.Write($"{column.ColumnName}\t");
            }

            Console.WriteLine();

            foreach (DataRow row in data.Rows)
            {
                var cells = row.ItemArray;
                foreach (var cell in cells)
                {
                    Console.Write($"{cell}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Отключаем БД!");
            connector.DisconnectAsync();
        }
        else
        {
            Console.WriteLine("Ошибка подключения!");
        }

        Console.ReadKey();

    }
}
