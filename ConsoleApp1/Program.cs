using ADOtest;
using ADOtestModule;
using ConsoleModule;
using Microsoft.Data.SqlClient;
using System.Data;
class Program 
{
    static void Main(string[] args)
    {
        //data = db.SelectAll(tablename);

        //Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);

        //foreach (DataColumn column in data.Columns) 
        //{
        //    Console.Write($"{column.ColumnName}\t");
        //}

        //Console.WriteLine();

        //foreach (DataRow row in data.Rows)
        //{
        //    var cells = row.ItemArray;
        //    foreach (var cell in cells)
        //    {
        //        Console.Write($"{cell}\t");
        //    }
        //    Console.WriteLine();
        //}

        Manager manager = new Manager();

        manager.Connect();

        manager.ShowData();

        Console.Write("Введите логин для удаления:");
        var countDeleted = manager.DeleteUserByLogin(Console.ReadLine());

        Console.WriteLine($"Строк удалено: {countDeleted}");

        manager.ShowData();

        Console.Write("Введите имя нового пользователя:");
        var newUserName = Console.ReadLine();
        Console.Write("Введите логин нового пользователя:");
        var newUserLogin = Console.ReadLine();
        var countAdded = manager.AddNewUser(newUserName, newUserLogin);

        Console.WriteLine($"Строк добавлено: {countAdded}");
        
        manager.ShowData();

        manager.Disconnect();

        Console.ReadKey();
    }
}
