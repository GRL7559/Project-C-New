using Practic5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic10
{
    internal class Accountant:ICRUD
    {
        public Accountant(int id)
        {
            double result = 0;
            while (true)
            {
                string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                List<Check> сhecks = Accountant_menu(syspath, id);
                Console.WriteLine($"   {"ID",-10}{"Название",-25}{"Сумма",-25}{"Доход/Выплата",-24}{"Дата",-15}");
                Console.SetCursorPosition(101, 3);
                Console.WriteLine("Enter - открыть");
                Console.SetCursorPosition(101, 4);
                Console.WriteLine("Escape - выйти");
                Console.SetCursorPosition(101, 5);
                Console.WriteLine("C - создать");
                Console.SetCursorPosition(101, 6);
                Console.WriteLine("S - поиск");
                Console.SetCursorPosition(101, 7);
                Console.WriteLine("Итого:");
                int maxpos = 2;
                Console.SetCursorPosition(0, 3);
                foreach (Check сheck in сhecks)
                {
                    if (сheck.PlMin)
                    {
                        result += сheck.Amount;
                        Console.WriteLine($"   {сheck.Id,-10}{сheck.Name,-25}{сheck.Amount,-25}{"Доход",-24}{сheck.Date,-15}");
                    }
                    else
                    {
                        result -= сheck.Amount;
                        Console.WriteLine($"   {сheck.Id,-10}{сheck.Name,-25}{сheck.Amount,-25}{"Выплата",-24}{сheck.Date,-15}");
                    }
                    maxpos++;
                }
                Console.SetCursorPosition(101, 8);
                Console.WriteLine($"{result}");
                int[] pos = Arrows.Arrow(maxpos, 3);
                switch (pos[0])
                {
                    case (int)Arrows.Keys.Enter:
                        Open_сheck(pos[1] - 3, id);
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.C:
                        Create_сheck(id);
                        break;
                    case (int)Arrows.Keys.S:
                        Search_сheck(id);
                        break;
                    default: break;
                }
            }

        }
        private static void Search_сheck(int id)
        {
            Console.Clear();
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<Check> сhecks = Accountant_menu(syspath, id);
            Check searchсheck = new();
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"  ID: ");
                Console.WriteLine($"  Название: ");
                Console.WriteLine($"  Сумма: ");
                int[] pos = Arrows.Arrow(4, 2);
                switch (pos[0])
                {
                    case (int)Arrows.Keys.Enter:
                        switch (pos[1])
                        {
                            case 2:

                                while (true)
                                {
                                    Console.SetCursorPosition(6, 2);
                                    Console.WriteLine(new string(' ', 10));
                                    Console.SetCursorPosition(6, 2);
                                    int newId;
                                    while (true)
                                    {
                                        try
                                        {
                                            Console.SetCursorPosition(6, 2);
                                            newId = Convert.ToInt32(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.SetCursorPosition(6, 2);
                                            Console.WriteLine("Введено некорректное значение");
                                            Thread.Sleep(1000);
                                            Console.SetCursorPosition(6, 2);
                                            Console.WriteLine(new string(' ', 30));
                                            Console.SetCursorPosition(6, 2);
                                            Console.WriteLine($"{searchсheck.Id}");
                                        }
                                    }
                                    break;
                                }
                                break;
                            case 3:
                                Console.SetCursorPosition(12, 3);
                                Console.WriteLine(new string(' ', 30));
                                Console.SetCursorPosition(12, 3);
                                searchсheck.Name = Console.ReadLine();
                                break;
                            case 4:
                                while (true)
                                {
                                    try
                                    {
                                        Console.SetCursorPosition(9, 4);
                                        searchсheck.Amount = Convert.ToDouble(Console.ReadLine());
                                        break;
                                    }
                                    catch
                                    {
                                        Console.SetCursorPosition(9, 4);
                                        Console.WriteLine("Введено некорректное значение");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(9, 4);
                                        Console.WriteLine(new string(' ', 30));
                                        Console.SetCursorPosition(9, 4);
                                        Console.WriteLine($"{searchсheck.Amount}");
                                    }
                                }
                                break;
                            case 5:
                                while (true)
                                {
                                    try
                                    {
                                        Console.SetCursorPosition(17, 5);
                                        searchсheck.PlMin = Convert.ToBoolean(Console.ReadLine());
                                        break;
                                    }
                                    catch
                                    {
                                        Console.SetCursorPosition(17, 5);
                                        Console.WriteLine("Введено некорректное значение");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(17, 5);
                                        Console.WriteLine(new string(' ', 40));
                                        Console.SetCursorPosition(17, 5);
                                    }
                                }
                                break;
                        }
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.S:
                        int index = -1;
                        Func<Check, Check, bool> checkcomparer = (searchcheck, check) =>
                            (searchcheck.Id == 0 || searchcheck.Id == check.Id) &&
                            (string.IsNullOrEmpty(searchcheck.Name) || searchcheck.Name == check.Name) &&
                            (searchcheck.Amount == 0.0 || searchcheck.Amount == check.Amount);
                        for (int i = 0; i < сhecks.Count; i++)
                        {
                            if (checkcomparer(searchсheck, сhecks[i]))
                            {
                                index = i;
                            }
                        }
                        if (index == -1)
                        {
                            Console.SetCursorPosition(0, 7);
                            Console.WriteLine("Пользователь не найден или недостаточно данных");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(0, 7);
                            Console.WriteLine(new string(' ', 50));
                            break;
                        }
                        else
                        {
                            Open_сheck(index, id);
                            Console.Clear();
                            return;
                        }
                    default: break;
                }
            }
        }
        private static void Create_сheck(int id)
        {
            Console.Clear();
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<Check> сhecks = Accountant_menu(syspath, id);
            Console.SetCursorPosition(101, 2);
            Console.WriteLine("Enter - изменить");
            Console.SetCursorPosition(101, 3);
            Console.WriteLine("S - сохранить");
            Console.SetCursorPosition(101, 4);
            Console.WriteLine("Delete - удалить");
            Console.SetCursorPosition(101, 5);
            Console.WriteLine("Escape - выйти");
            Check newсheck = new();
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"  ID: ");
                Console.WriteLine($"  Название: ");
                Console.WriteLine($"  Сумма: ");
                Console.WriteLine($"  Доход/Выплата: ");
                int[] position = Arrows.Arrow(5, 2);
                switch (position[0])
                {
                    case (int)Arrows.Keys.Enter:
                        newсheck = Edit_сheck(сhecks, newсheck, position[1]);
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.S:
                        сhecks.Add(newсheck);
                        Update((syspath + "\\Checks.json"), сhecks);//функция апдейта
                        continue;
                    default: break;
                }
            }
        }
        private static void Open_сheck(int pos, int id)
        {
            Console.Clear();
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<Check> сhecks = Accountant_menu(syspath, id);
            Console.SetCursorPosition(101, 2);
            Console.WriteLine("Enter - изменить");
            Console.SetCursorPosition(101, 3);
            Console.WriteLine("S - сохранить");
            Console.SetCursorPosition(101, 4);
            Console.WriteLine("Delete - удалить");
            Console.SetCursorPosition(101, 5);
            Console.WriteLine("Escape - выйти");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"  ID: {сhecks[pos].Id}");
            Console.WriteLine($"  Название: {сhecks[pos].Name}");
            Console.WriteLine($"  Сумма: {сhecks[pos].Amount}");
            Console.WriteLine($"  Доход/Выплата: {сhecks[pos].PlMin}");
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"  ID: ");
                Console.WriteLine($"  Название: ");
                Console.WriteLine($"  Сумма: ");
                Console.WriteLine($"  Доход/Выплата: ");
                int[] position = Arrows.Arrow(5, 2);
                switch (position[0])
                {
                    case (int)Arrows.Keys.Enter:
                        сhecks[pos] = Edit_сheck(сhecks, сhecks[pos], position[1]);
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.S:
                        Update((syspath + "\\Checks.json"), сhecks);
                        continue;
                    case (int)Arrows.Keys.Delete:
                        сhecks.RemoveAt(pos);
                        Update((syspath + "\\Checks.json"), сhecks);
                        Console.Clear();
                        return;
                    default: break;
                }
            }

        }
        private static Check Edit_сheck(List<Check> сhecks, Check newсheck, int position)
        {
            switch (position)
            {
                case 2:

                    while (true)
                    {
                        Console.SetCursorPosition(6, 2);
                        Console.WriteLine(new string(' ', 10));
                        Console.SetCursorPosition(6, 2);
                        Console.WriteLine($"{newсheck.Id}");
                        int newId;
                        while (true)
                        {
                            try
                            {
                                Console.SetCursorPosition(6, 2);
                                newId = Convert.ToInt32(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.SetCursorPosition(6, 2);
                                Console.WriteLine("Введено некорректное значение");
                                Thread.Sleep(1000);
                                Console.SetCursorPosition(6, 2);
                                Console.WriteLine(new string(' ', 30));
                                Console.SetCursorPosition(6, 2);
                                Console.WriteLine($"{newсheck.Id}");
                            }
                        }
                        bool unique = true;
                        foreach (var сheck in сhecks)
                        {
                            if (сheck.Id == newId)
                            {
                                unique = false;
                            }
                        }
                        if (unique)
                        {
                            newсheck.Id = newId;
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(6, 2);
                            Console.WriteLine("Такой ID уже существует");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(6, 2);
                            Console.WriteLine(new string(' ', 30));
                        }
                    }
                    break;
                case 3:
                    Console.SetCursorPosition(12, 3);
                    Console.WriteLine(new string(' ', 30));
                    Console.SetCursorPosition(12, 3);
                    newсheck.Name = Console.ReadLine();
                    break;
                case 4:
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(9, 4);
                            newсheck.Amount = Convert.ToDouble(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.SetCursorPosition(9, 4);
                            Console.WriteLine("Введено некорректное значение");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(9, 4);
                            Console.WriteLine(new string(' ', 30));
                            Console.SetCursorPosition(9, 4);
                            Console.WriteLine($"{newсheck.Amount}");
                        }
                    }
                    break;
                case 5:
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(17, 5);
                            newсheck.PlMin = Convert.ToBoolean(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.SetCursorPosition(17, 5);
                            Console.WriteLine("Введено некорректное значение");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(17, 5);
                            Console.WriteLine(new string(' ', 40));
                            Console.SetCursorPosition(17, 5);
                        }
                    }
                    break;
            }
            return newсheck;
        }
        private static List<Check> Accountant_menu(string syspath, int Id)
        {
            List<Check> сhecks = Read<List<Check>>(syspath + "\\Checks.json");
            List<Employee> employees = new();
            if (File.Exists(syspath + "\\Employees.json"))
            {
                employees = Read<List<Employee>>(syspath + "\\Employees.json");
            }
            ICRUD_menu();
            Console.SetCursorPosition(30, 0);
            string name = "Бухгалтер";
            foreach (Employee employee in employees)
            {
                if (employee.UserId == Id)
                {
                    name = employee.Name;
                }
            }
            Console.WriteLine($"Добро пожаловать,{name}!");
            Console.SetCursorPosition(100, 0);
            Console.WriteLine("Роль:Бухгалтер");
            Console.SetCursorPosition(0, 2);
            return сhecks;
        }
    }
}
