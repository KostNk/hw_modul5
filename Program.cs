using System;
using System.Xml.Linq;

class MainClass
{

    static void Main(string[] args)
    {
        Console.WriteLine("Какой номер задания?");
        var hw = Console.ReadLine();
        if (hw == "5.6.1")
        {
            var UserData = GetUserData();

            ShowUserData(UserData);

        }
        else
        {
            Console.WriteLine("Введите строку для эха");
            var str = Console.ReadLine();

            Console.WriteLine("Укажите глубину эха");
            var deep = int.Parse(Console.ReadLine());

            Echo(str, deep);

            Console.ReadKey();
        }
    }

    static void ShowUserData((string, string, double age, string[], string[]) UserData)
    {
        Console.WriteLine("Всё про тебя знаем, ты {0} {1}, тебе {2} лет", UserData.Item1, UserData.Item2, UserData.age);
        for (int i=0;i<UserData.Item4.Length;i++)
        {
            Console.WriteLine("Твоего питомца N {0} зовут {1}", i + 1, UserData.Item4[i]);
        }
        for (int i = 0; i < UserData.Item5.Length; i++)
        {
            Console.WriteLine("Твой любимый цвет N {0} называется {1}", i + 1, UserData.Item5[i]);
        }
    }

    static void SaveArray(int Num, bool isPet, string[] Array)
    {

        for (int i = 0; i < Num; i++)
        {
            Console.WriteLine("{0} N {1}?", (isPet) ? "Как зовут питомца" : "Какой любимый цвет", i + 1);
            Array[i] = Console.ReadLine();
        }
    }

    static bool CheckData((string, string, double age, string[], string[]) User)
    {
        if (User.age < 0.0 || User.age > 120.0)
        {
            Console.WriteLine("Возраст {0}  не корректный", User.age);
            return false;
        }
        if (User.Item4.Length <= 0)
        {
            Console.WriteLine("Питомцев маловато у вас {0}", User.Item4.Length);
            return false;
        }
        if (User.Item5.Length <= 0)
        {
            Console.WriteLine("Цветов маловато у вас {0}", User.Item5.Length);
            return false;
        }
        return true;
    }

    static (string, string, double age, string[], string[])  GetUserData()
    {
        string Name, LastName, Pet;
        double age;
        int ColorNum;
        string[] PetArray;
        string[] ColorArray;
        
        while (true)
        {
            Console.WriteLine("Ваше имя?");
            Name = Console.ReadLine();

            Console.WriteLine("Фамилия?");
            LastName = Console.ReadLine();

            Console.WriteLine("Возраст?");
            age = double.Parse(Console.ReadLine());

            Console.WriteLine("У вас есть питомец? Можно ответить Да или Нет");
            while (true)
            {
                Pet = Console.ReadLine();
                if (Pet == "Да")
                {
                    Console.WriteLine("Сколько их?");
                    var PetNum = int.Parse(Console.ReadLine());
                    PetArray = new string[PetNum];
                    SaveArray(PetNum, true, PetArray);
                    break;
                }
                else if (Pet == "Нет")
                {
                    PetArray = new string[1];
                    PetArray[0] = "нет питомцев";
                    break;
                }
                else
                    Console.WriteLine("Ну я ж преупреждал. Можно ответить только Да или Нет. Так есть питомец-то?");
            }

            Console.WriteLine("Сколько любимых цветов? Только целое число больше 0");
            ColorNum = int.Parse(Console.ReadLine());
            ColorArray = new string[ColorNum];
            SaveArray(ColorNum, false, ColorArray);

            if (CheckData((Name, LastName, age, PetArray, ColorArray)) == false)
            {
                Console.WriteLine("Ну что же вы неправильно данные ввели, давайте заново!");
            }
            else
                break;
        }
        return (Name, LastName, age, PetArray, ColorArray);
    }

    static void Echo(string phrase, int deep)
    {
        var modif = phrase;
        if (modif.Length > 2)
        {
            modif = modif.Remove(0, 2);
        }
        else
            return;
        Console.BackgroundColor = (ConsoleColor)deep;
        Console.WriteLine("..." + modif);

        if (deep > 1)
        {
            Echo(modif, deep - 1);
        }
    }
}