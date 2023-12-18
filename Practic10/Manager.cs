using Practic5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic10
{
    class Manager : ICRUD
    {
        public Manager(int id)
        {
            while (true)
            {
                string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                List<Employee> employees = Manager_menu(syspath, id);
                Console.WriteLine($"   {"ID",-22}{"Имя",-25}{"Фамилия",-25}{"Роль",-24}");
                Console.SetCursorPosition(101, 3);
                Console.WriteLine("Enter - открыть");
                Console.SetCursorPosition(101, 4);
                Console.WriteLine("Escape - выйти");
                Console.SetCursorPosition(101, 5);
                Console.WriteLine("C - создать");
                Console.SetCursorPosition(101, 6);
                Console.WriteLine("S - поиск");
                int maxpos = 2;
                Console.SetCursorPosition(0, 3);
                foreach (Employee employee in employees)
                {
                    Console.WriteLine($"   {employee.Id,-22}{employee.Name,-25}{employee.Surname,-25}{(User.Roles)employee.Role,-24}");
                    maxpos++;
                }
                int[] pos = Arrows.Arrow(maxpos, 3);
                switch (pos[0])
                {
                    case (int)Arrows.Keys.Enter:
                        Open_employee(pos[1] - 3, id);
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.C:
                        Create_employee(id);
                        break;
                    case (int)Arrows.Keys.S:
                        Search_employee(id);
                        break;
                    default: break;
                }
            }

        }
        private static void Search_employee(int id)
        {
            Console.Clear();
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<Employee> employees = Manager_menu(syspath, id);
            Employee searchemployee = new();
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"  ID: ");
                Console.WriteLine($"  Логин: ");
                Console.WriteLine($"  Пароль: ");
                Console.WriteLine($"  Роль: ");
                int[] pos = Arrows.Arrow(5, 2);
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
                                    Console.WriteLine($"{searchemployee.Id}");
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
                                            Console.WriteLine($"{searchemployee.Id}");
                                        }
                                    }
                                    break;
                                }
                                break;
                            case 3:
                                int newAge;
                                while (true)
                                {
                                    try
                                    {
                                        Console.SetCursorPosition(11, 3);
                                        newAge = Convert.ToInt32(Console.ReadLine());
                                        searchemployee.Age = newAge;
                                        break;
                                    }
                                    catch
                                    {
                                        Console.SetCursorPosition(11, 3);
                                        Console.WriteLine("Введено некорректное значение");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(11, 3);
                                        Console.WriteLine(new string(' ', 30));
                                        Console.SetCursorPosition(11, 3);
                                        Console.WriteLine($"{searchemployee.Age}");
                                    }
                                }
                                break;
                            case 4:
                                while (true)
                                {
                                    Console.SetCursorPosition(11, 4);
                                    Console.WriteLine(new string(' ', 90));
                                    Console.SetCursorPosition(11, 4);
                                    string newSurname = Console.ReadLine();
                                    if (newSurname != "")
                                    {
                                        searchemployee.Surname = newSurname;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(11, 4);
                                        Console.WriteLine("Фамилия не может быть пустой ");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(11, 4);
                                        Console.WriteLine(new string(' ', 30));
                                        Console.SetCursorPosition(11, 4);
                                        Console.WriteLine($"{searchemployee.Surname}"); 
                                    }
                                }
                                break;
                            case 5:
                                while (true)
                                {
                                    Console.SetCursorPosition(7, 5);
                                    Console.WriteLine(new string(' ', 90));
                                    Console.SetCursorPosition(7, 5);
                                    string newName = Console.ReadLine();
                                    if (newName != "")
                                    {
                                        searchemployee.Name = newName;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(7, 5);
                                        Console.WriteLine("Имя не может быть пустой ");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(7, 5);
                                        Console.WriteLine(new string(' ', 30));
                                        Console.SetCursorPosition(7, 5);
                                        Console.WriteLine($"{searchemployee.Name}"); //поменять сеткурсоры
                                    }
                                }
                                break;
                            case 6:
                                Console.SetCursorPosition(12, 6);
                                Console.WriteLine(new string(' ', 90));
                                Console.SetCursorPosition(12, 6);
                                searchemployee.Firstname = Console.ReadLine();
                                break;
                            case 7:
                                while (true)
                                {
                                    Console.SetCursorPosition(11, 7);
                                    Console.WriteLine(' ');
                                    Console.SetCursorPosition(11, 7);
                                    int newPasport;
                                    while (true)
                                    {
                                        try
                                        {
                                            Console.SetCursorPosition(11, 7);
                                            newPasport = Convert.ToInt32(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.SetCursorPosition(11, 7);
                                            Console.WriteLine("Введено некорректное значение");
                                            Thread.Sleep(1000);
                                            Console.SetCursorPosition(11, 7);
                                            Console.WriteLine(new string(' ', 30));
                                            Console.SetCursorPosition(11, 7);
                                            Console.WriteLine($"{searchemployee.Pasport}");
                                        }
                                    }
                                    int lenth = Convert.ToString(newPasport).Length;
                                    if (lenth == 11)
                                    {
                                        searchemployee.Pasport = newPasport;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(11, 7);
                                        Console.WriteLine("Введите серию и номер паспорта");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(11, 7);
                                        Console.WriteLine(new string(' ', 90));
                                        Console.SetCursorPosition(11, 7);
                                        Console.WriteLine($"{searchemployee.Role}");
                                    }
                                }
                                break;
                            case 8:
                                while (true)
                                {
                                    Console.SetCursorPosition(8, 8);
                                    Console.WriteLine(' ');
                                    Console.SetCursorPosition(8, 8);
                                    int newRole;
                                    while (true)
                                    {
                                        try
                                        {
                                            Console.SetCursorPosition(8, 8);
                                            newRole = Convert.ToInt32(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.SetCursorPosition(8, 8);
                                            Console.WriteLine("Введено некорректное значение");
                                            Thread.Sleep(1000);
                                            Console.SetCursorPosition(8, 8);
                                            Console.WriteLine(new string(' ', 30));
                                            Console.SetCursorPosition(8, 8);
                                            Console.WriteLine($"{searchemployee.Role}");
                                        }
                                    }
                                    if (newRole < 5 && newRole >= 0)
                                    {
                                        searchemployee.Role = newRole;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(8, 8);
                                        Console.WriteLine("Такой роли не существует");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(8, 8);
                                        Console.WriteLine(new string(' ', 30));
                                        Console.SetCursorPosition(8, 8);
                                        Console.WriteLine($"{searchemployee.Role}");
                                    }
                                }
                                break;
                            case 9:
                                while (true)
                                {
                                    try
                                    {
                                        Console.SetCursorPosition(12, 9);
                                        searchemployee.Salary = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    }
                                    catch
                                    {
                                        Console.SetCursorPosition(12, 9);
                                        Console.WriteLine("Введено некорректное значение");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(12, 9);
                                        Console.WriteLine(new string(' ', 30));
                                        Console.SetCursorPosition(12, 9);
                                        Console.WriteLine($"{searchemployee.Salary}");
                                    }
                                }
                                break;
                            case 10:
                                while (true)
                                {
                                    Console.SetCursorPosition(19, 10);
                                    Console.WriteLine(' ');
                                    Console.SetCursorPosition(19, 10);
                                    int newUserId;
                                    while (true)
                                    {
                                        try
                                        {
                                            Console.SetCursorPosition(19, 10);
                                            newUserId = Convert.ToInt32(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.SetCursorPosition(19, 10);
                                            Console.WriteLine("Введено некорректное значение");
                                            Thread.Sleep(1000);
                                            Console.SetCursorPosition(19, 10);
                                            Console.WriteLine(new string(' ', 30));
                                            Console.SetCursorPosition(19, 10);
                                            Console.WriteLine($"{searchemployee.UserId}");
                                        }
                                    }
                                    List<User> users = new();
                                    bool confirm = false;
                                    foreach (User user in users)
                                    {
                                        if (newUserId == user.Id)
                                        {
                                            confirm = true;
                                            break;
                                        }
                                    }
                                    if (confirm)
                                    {
                                        searchemployee.UserId = newUserId;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(19, 10);
                                        Console.WriteLine("пользователя с таким ID не существует");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(19, 10);
                                        Console.WriteLine(new string(' ', 90));
                                        Console.SetCursorPosition(19, 10);
                                        Console.WriteLine($"{searchemployee.UserId}");
                                    }
                                }
                                break;
                            case 11:
                                Console.SetCursorPosition(29, 11);
                                Console.WriteLine("Вы не можете изменить этот параметр");
                                Thread.Sleep(1000);
                                Console.SetCursorPosition(29, 11);
                                Console.WriteLine(new string(' ', 35));
                                Console.SetCursorPosition(29, 11);
                                Console.WriteLine($"{searchemployee.Date}"); //сделать ввод даты с клавиатуры
                                break;
                        }
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.S:
                        int index = -1;
                        Func<Employee, Employee, bool> employeecomparer = (searchEmployee, employee) =>
                            (searchEmployee.Id == 0 || searchEmployee.Id == employee.Id) &&
                            (searchEmployee.Age == 0 || searchEmployee.Age == employee.Age) &&
                            (string.IsNullOrEmpty(searchEmployee.Surname) || searchEmployee.Surname == employee.Surname) &&
                            (string.IsNullOrEmpty(searchEmployee.Name) || searchEmployee.Name == employee.Name) &&
                            (searchEmployee.Firstname == null || searchEmployee.Firstname == employee.Firstname) &&
                            (searchEmployee.Pasport == 0 || searchEmployee.Pasport == employee.Pasport) &&
                            (searchEmployee.Role == 0 || searchEmployee.Role == employee.Role) &&
                            (searchEmployee.Salary == 0 || searchEmployee.Salary == employee.Salary) &&
                            (searchEmployee.UserId == 0 || searchEmployee.UserId == employee.UserId) &&
                            (searchEmployee.Date == default || searchEmployee.Date == employee.Date);
                        for (int i = 0; i < employees.Count; i++)
                        {
                            if (employeecomparer(searchemployee, employees[i]))
                            {
                                index = i;
                            }
                        }
                        if (index == -1)
                        {
                            Console.SetCursorPosition(0, 12);
                            Console.WriteLine("Сотрудник не найден или недостаточно данных");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(0, 12);
                            Console.WriteLine(new string(' ', 50));
                            break;
                        }
                        else
                        {
                            Open_employee(index, id);
                            Console.Clear();
                            return;
                        }
                    default: break;
                }
            }
        }
        private static void Create_employee(int id)
        {
            Console.Clear();
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<Employee> employees = Manager_menu(syspath, id);
            Console.SetCursorPosition(101, 2);
            Console.WriteLine("Enter - изменить");
            Console.SetCursorPosition(101, 3);
            Console.WriteLine("S - сохранить");
            Console.SetCursorPosition(101, 4);
            Console.WriteLine("Delete - удалить");
            Console.SetCursorPosition(101, 5);
            Console.WriteLine("Escape - выйти");
            Console.SetCursorPosition(101, 6);
            Console.WriteLine("Роли :");
            Console.SetCursorPosition(101, 7);
            Console.WriteLine("0 - Админимстратор");
            Console.SetCursorPosition(101, 8);
            Console.WriteLine("1 - Менеджер");
            Console.SetCursorPosition(101, 9);
            Console.WriteLine("2 - Бухгалтер");
            Console.SetCursorPosition(101, 10);
            Console.WriteLine("3 - Зав.Складом");
            Console.SetCursorPosition(101, 11);
            Console.WriteLine("4 - Кассир");
            Employee newemployee = new();
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"  ID: ");
                Console.WriteLine($"  Возраст: ");
                Console.WriteLine($"  Фамилия: ");
                Console.WriteLine($"  Имя: ");
                Console.WriteLine($"  Отчество: ");
                Console.WriteLine($"  Паспорт: ");
                Console.WriteLine($"  Роль: ");
                Console.WriteLine($"  Зарплата: ");
                Console.WriteLine($"  ID пользователя: ");
                Console.WriteLine($"  Дата последнего изменения: ");
                int[] position = Arrows.Arrow(11, 2);
                switch (position[0])
                {
                    case (int)Arrows.Keys.Enter:
                        newemployee = Edit_employee(employees, newemployee, position[1]);
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.S:
                        employees.Add(newemployee);
                        Update((syspath + "\\Users.json"), employees);
                        continue;
                    default: break;
                }
            }
        }
        private static void Open_employee(int pos, int id)
        {
            Console.Clear();
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<Employee> employees = Manager_menu(syspath, id);
            Console.SetCursorPosition(101, 2);
            Console.WriteLine("Enter - изменить");
            Console.SetCursorPosition(101, 3);
            Console.WriteLine("S - сохранить");
            Console.SetCursorPosition(101, 4);
            Console.WriteLine("Delete - удалить");
            Console.SetCursorPosition(101, 5);
            Console.WriteLine("Escape - выйти");
            Console.SetCursorPosition(101, 6);
            Console.WriteLine("Роли :");
            Console.SetCursorPosition(101, 7);
            Console.WriteLine("0 - Админимстратор");
            Console.SetCursorPosition(101, 8);
            Console.WriteLine("1 - Менеджер");
            Console.SetCursorPosition(101, 9);
            Console.WriteLine("2 - Бухгалтер");
            Console.SetCursorPosition(101, 10);
            Console.WriteLine("3 - Зав.Складом");
            Console.SetCursorPosition(101, 11);
            Console.WriteLine("4 - Кассир");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"  ID: {employees[pos].Id}");
            Console.WriteLine($"  Возраст: {employees[pos].Age}");
            Console.WriteLine($"  Фамилия: {employees[pos].Surname}");
            Console.WriteLine($"  Имя: {employees[pos].Name}");
            Console.WriteLine($"  Отчество: {employees[pos].Firstname}");
            Console.WriteLine($"  Паспорт: {employees[pos].Pasport}");
            Console.WriteLine($"  Роль: {employees[pos].Role}");
            Console.WriteLine($"  Зарплата: {employees[pos].Salary}");
            Console.WriteLine($"  ID пользователя: {employees[pos].UserId}");
            Console.WriteLine($"  Дата последнего изменения: {employees[pos].Date}");
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"  ID: ");
                Console.WriteLine($"  Возраст: ");
                Console.WriteLine($"  Фамилия: ");
                Console.WriteLine($"  Имя: ");
                Console.WriteLine($"  Отчество: ");
                Console.WriteLine($"  Паспорт: ");
                Console.WriteLine($"  Роль: ");
                Console.WriteLine($"  Зарплата: ");
                Console.WriteLine($"  ID пользователя: ");
                Console.WriteLine($"  Дата последнего изменения: ");
                int[] position = Arrows.Arrow(11, 2);
                switch (position[0])
                {
                    case (int)Arrows.Keys.Enter:
                        employees[pos] = Edit_employee(employees, employees[pos], position[1]);
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.S:
                        Update((syspath + "\\Employees.json"), employees);
                        continue;
                    case (int)Arrows.Keys.Delete:
                        employees.RemoveAt(pos);
                        Update((syspath + "\\Employees.json"), employees);
                        Console.Clear();
                        return;
                    default: break;
                }
            }
        }
        private static Employee Edit_employee(List<Employee> employees, Employee newemployee, int position)
        {
            switch (position)
            {
                case 2:
                    while (true)
                    {
                        Console.SetCursorPosition(6, 2);
                        Console.WriteLine(new string(' ', 10));
                        Console.SetCursorPosition(6, 2);
                        Console.WriteLine($"{newemployee.Id}");
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
                                Console.WriteLine($"{newemployee.Id}");
                            }
                        }
                        bool unique = true;
                        foreach (var employee in employees)
                        {
                            if (employee.Id == newId)
                            {
                                unique = false;
                            }
                        }
                        if (unique)
                        {
                            newemployee.Id = newId;
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
                    int newAge;
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(11, 3);
                            newAge = Convert.ToInt32(Console.ReadLine());
                            newemployee.Age = newAge;
                            break;
                        }
                        catch
                        {
                            Console.SetCursorPosition(11, 3);
                            Console.WriteLine("Введено некорректное значение");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(11, 3);
                            Console.WriteLine(new string(' ', 30));
                            Console.SetCursorPosition(11, 3);
                            Console.WriteLine($"{newemployee.Age}");
                        }
                    }
                    break;
                case 4:
                    while (true)
                    {
                        Console.SetCursorPosition(11, 4);
                        Console.WriteLine(new string(' ', 90));
                        Console.SetCursorPosition(11, 4);
                        string newSurname = Console.ReadLine();
                        if (newSurname != "")
                        {
                            newemployee.Surname = newSurname;
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(11, 4);
                            Console.WriteLine("Фамилия не может быть пустой ");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(11, 4);
                            Console.WriteLine(new string(' ', 30));
                            Console.SetCursorPosition(11, 4);
                            Console.WriteLine($"{newemployee.Surname}"); //поменять сеткурсоры
                        }
                    }
                    break;
                case 5:
                    while (true)
                    {
                        Console.SetCursorPosition(7, 5);
                        Console.WriteLine(new string(' ', 90));
                        Console.SetCursorPosition(7, 5);
                        string newName = Console.ReadLine();
                        if (newName != "")
                        {
                            newemployee.Name = newName;
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(7, 5);
                            Console.WriteLine("Имя не может быть пустой ");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(7, 5);
                            Console.WriteLine(new string(' ', 30));
                            Console.SetCursorPosition(7, 5);
                            Console.WriteLine($"{newemployee.Name}"); //поменять сеткурсоры
                        }
                    }
                    break;
                case 6:
                    Console.SetCursorPosition(12, 6);
                    Console.WriteLine(new string(' ', 90));
                    Console.SetCursorPosition(12, 6);
                    newemployee.Firstname = Console.ReadLine();
                    break;
                case 7:
                    while (true)
                    {
                        Console.SetCursorPosition(11, 7);
                        Console.WriteLine(' ');
                        Console.SetCursorPosition(11, 7);
                        int newPasport;
                        while (true)
                        {
                            try
                            {
                                Console.SetCursorPosition(11, 7);
                                newPasport = Convert.ToInt32(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.SetCursorPosition(11, 7);
                                Console.WriteLine("Введено некорректное значение");
                                Thread.Sleep(1000);
                                Console.SetCursorPosition(11, 7);
                                Console.WriteLine(new string(' ', 30));
                                Console.SetCursorPosition(11, 7);
                                Console.WriteLine($"{newemployee.Pasport}");
                            }
                        }
                        int lenth = Convert.ToString(newPasport).Length;
                        if (lenth == 11)
                        {
                            newemployee.Pasport = newPasport;
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(11, 7);
                            Console.WriteLine("Введите серию и номер паспорта");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(11, 7);
                            Console.WriteLine(new string(' ', 90));
                            Console.SetCursorPosition(11, 7);
                            Console.WriteLine($"{newemployee.Role}");
                        }
                    }
                    break;
                case 8:
                    while (true)
                    {
                        Console.SetCursorPosition(8, 8);
                        Console.WriteLine(' ');
                        Console.SetCursorPosition(8, 8);
                        int newRole;
                        while (true)
                        {
                            try
                            {
                                Console.SetCursorPosition(8, 8);
                                newRole = Convert.ToInt32(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.SetCursorPosition(8, 8);
                                Console.WriteLine("Введено некорректное значение");
                                Thread.Sleep(1000);
                                Console.SetCursorPosition(8, 8);
                                Console.WriteLine(new string(' ', 30));
                                Console.SetCursorPosition(8, 8);
                                Console.WriteLine($"{newemployee.Role}");
                            }
                        }
                        if (newRole < 5 && newRole >= 0)
                        {
                            newemployee.Role = newRole;
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(8, 8);
                            Console.WriteLine("Такой роли не существует");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(8, 8);
                            Console.WriteLine(new string(' ', 30));
                            Console.SetCursorPosition(8, 8);
                            Console.WriteLine($"{newemployee.Role}");
                        }
                    }
                    break;
                case 9:
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(12, 9);
                            newemployee.Salary = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.SetCursorPosition(12, 9);
                            Console.WriteLine("Введено некорректное значение");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(12, 9);
                            Console.WriteLine(new string(' ', 30));
                            Console.SetCursorPosition(12, 9);
                            Console.WriteLine($"{newemployee.Salary}");
                        }
                    }
                    break;
                case 10:
                    while (true)
                    {
                        Console.SetCursorPosition(19, 10);
                        Console.WriteLine(' ');
                        Console.SetCursorPosition(19, 10);
                        int newUserId;
                        while (true)
                        {
                            try
                            {
                                Console.SetCursorPosition(19, 10);
                                newUserId = Convert.ToInt32(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.SetCursorPosition(19, 10);
                                Console.WriteLine("Введено некорректное значение");
                                Thread.Sleep(1000);
                                Console.SetCursorPosition(19, 10);
                                Console.WriteLine(new string(' ', 30));
                                Console.SetCursorPosition(19, 10);
                                Console.WriteLine($"{newemployee.UserId}");
                            }
                        }
                        List<User> users = new();
                        bool confirm = false;
                        foreach (User user in users)
                        {
                            if (newUserId == user.Id)
                            {
                                confirm = true;
                                break;
                            }
                        }
                        if (confirm)
                        {
                            newemployee.UserId = newUserId;
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(19, 10);
                            Console.WriteLine("пользователя с таким ID не существует");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(19, 10);
                            Console.WriteLine(new string(' ',90));
                            Console.SetCursorPosition(19, 10);
                            Console.WriteLine($"{newemployee.UserId}");
                        }
                    }
                    break;
                case 11:
                    Console.SetCursorPosition(29, 11);
                    Console.WriteLine("Вы не можете изменить этот параметр");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(29, 11);
                    Console.WriteLine(new string(' ', 35));
                    Console.SetCursorPosition(29, 11);
                    Console.WriteLine($"{newemployee.Date}");
                    break;
            }
            newemployee.Date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return newemployee;
        }
        private static List<Employee> Manager_menu(string syspath, int Id)
        {
            List<Employee> employees = Read<List<Employee>>(syspath + "\\Employees.json");
            ICRUD_menu();
            Console.SetCursorPosition(30, 0);
            string name = "Менеджер";
            foreach (Employee employee in employees)
            {
                if (employee.UserId == Id)
                {
                    name = employee.Name;
                }
            }
            Console.WriteLine($"Добро пожаловать,{name}!");
            Console.SetCursorPosition(100, 0);
            Console.WriteLine("Роль:Менеджер");
            Console.SetCursorPosition(0, 2);
            return employees;
        }
    }
}