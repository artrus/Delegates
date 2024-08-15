// See https://aka.ms/new-console-template for more information
using Delegates;
using System;


internal class Program
{
    public static void Main()
    {
        //Поиск самого возрастного человека
        List<Person> persons =
        [
            new Person("Alex", 35),
            new Person("Andrey", 19),
            new Person("Sergey", 18),
            new Person("Maks", 44),
            new Person("Ruslan", 25),
        ];

        var older = persons.GetMax<Person>(Converters.ConvertToPersonAge); 

        Console.WriteLine($"Older chel - {older.Name}. Age={older.Age} \n\r");


        //Поиск самого большого файла
        Finder finder = new Finder();   //Класс поиска по файлам

        finder.FileFound += DisplayMessage; //Событие при нахождении каждого файла в каталоге
        finder.FinderEnd += DisplayMessage; //Событие при успешном поиске в каталоге самого большого файла
        finder.Cancel += CancelFind;        //Событие, в котором можно отменить поиск

        finder.MaxSizeFileFind(@"d:\Projects\OTUS\DZ5\TestCatalog\");   


    }

    private static void DisplayMessage(string message) => Console.WriteLine(message);

    private static bool CancelFind(int i)
    {
        if (i > 3)  //чисто для проверки отмены поиска на 3 файле
            return true;
        return false;
    }
}
