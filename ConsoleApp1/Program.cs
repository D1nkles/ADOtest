using ConsoleModule;
public enum Commands
{
    stop,
    add,
    delete,
    update,
    show
}

class Program 
{
    static Manager manager = new Manager();
    static void Add() 
    {
        Console.Write("Введите имя нового пользователя: ");
        var newUserName = Console.ReadLine();
        Console.Write("Введите логин нового пользователя: ");
        var newUserLogin = Console.ReadLine();
        var countAdded = manager.AddNewUser(newUserName, newUserLogin);

        Console.WriteLine($"Строк добавлено: {countAdded}");

        manager.ShowData();
    }

    static void Delete() 
    {
        Console.Write("Введите логин для удаления: ");
        var countDeleted = manager.DeleteUserByLogin(Console.ReadLine());

        Console.WriteLine($"Строк удалено: {countDeleted}");

        manager.ShowData();
    }

    static void Update() 
    {
        Console.Write("Введите логин пользователя, имя которого вы хотите изменить: ");
        var userLogin = Console.ReadLine();
        Console.Write("Введите новое имя пользователя: ");
        var userNewName = Console.ReadLine();
        var countUpdated = manager.UpdateUserNameByLogin(userLogin, userNewName);

        Console.WriteLine($"Строк изменено: {countUpdated}");

        manager.ShowData();
    }

    static void Main(string[] args)
    {
        string command;

        manager.Connect();

        Console.WriteLine("Список команд для работы консоли:");
        Console.WriteLine(Commands.stop + ": прекращение работы");
        Console.WriteLine(Commands.add + ": добавление данных");
        Console.WriteLine(Commands.delete + ": удаление данных");
        Console.WriteLine(Commands.update + ": обновление данных");
        Console.WriteLine(Commands.show + ": просмотр данных");

        do
        {
            Console.Write("Введите команду: ");
            command = Console.ReadLine();
            Console.WriteLine();

            switch (command)
            {
                case nameof(Commands.show):
                    manager.ShowData();
                    break;
                case nameof(Commands.add):
                    Add();
                    break;
                case nameof(Commands.delete): 
                    Delete();
                    break;
                case nameof(Commands.update): 
                    Update(); 
                    break;
                case nameof(Commands.stop):
                    Console.WriteLine("Выход из программы...");
                    break;
                default:
                    Console.WriteLine("Вы ввели неверную команду...");
                    break;
            }
        }
        while (command != nameof(Commands.stop));

        manager.Disconnect();

        Console.ReadKey();
    }
}
