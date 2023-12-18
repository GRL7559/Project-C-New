using Practic5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic10
{
    class Administrator : ICRUD
    {
        public Administrator(int id)
        {
            while (true)
            {
                string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                List<User> users = Administrator_menu(syspath, id);
                Console.WriteLine($"   {"ID",-22}{"Логин",-25}{"Пароль",-25}{"Роль",-24}");
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
                foreach (User user in users)
                {
                    Console.WriteLine($"   {user.Id,-22}{user.Login,-25}{user.Password,-25}{(User.Roles)user.Role,-24}");
                    maxpos++;
                }
                int[] pos = Arrows.Arrow(maxpos, 3);
                switch (pos[0])
                {
                    case (int)Arrows.Keys.Enter:
                        Open_user(pos[1] - 3, id);
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.C:
                        Create_user(id);
                        break;
                    case (int)Arrows.Keys.S:
                        Search_User(id);
                        break;
                    default: break;
                }
            }

        }
        private static void Search_User(int id)
        {
            Console.Clear();
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<User> users = Administrator_menu(syspath, id);
            User searchuser = new();
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
                                            Console.WriteLine($"{searchuser.Id}");
                                        }
                                    }
                                    break;
                                }
                                break;
                            case 3:
                                Console.SetCursorPosition(9, 3);
                                Console.WriteLine(new string(' ', 90));
                                Console.SetCursorPosition(9, 3);
                                searchuser.Login = Console.ReadLine();
                                break;
                            case 4:
                                Console.SetCursorPosition(10, 4);
                                Console.WriteLine(new string(' ', 90));
                                Console.SetCursorPosition(10, 4);
                                searchuser.Password = Console.ReadLine();
                                break;
                            case 5:

                                while (true)
                                {
                                    Console.SetCursorPosition(8, 5);
                                    Console.WriteLine(' ');
                                    Console.SetCursorPosition(8, 5);
                                    int newRole;
                                    while (true)
                                    {
                                        try
                                        {
                                            Console.SetCursorPosition(8, 5);
                                            newRole = Convert.ToInt32(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.SetCursorPosition(8, 5);
                                            Console.WriteLine("Введено некорректное значение");
                                            Thread.Sleep(1000);
                                            Console.SetCursorPosition(8, 5);
                                            Console.WriteLine(new string(' ', 30));
                                            Console.SetCursorPosition(8, 5);
                                            Console.WriteLine($"{searchuser.Role}");
                                        }
                                    }
                                    if (newRole < 5 && newRole >= 0)
                                    {
                                        searchuser.Role = newRole;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(8, 5);
                                        Console.WriteLine("Такой роли не существует");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(8, 5);
                                        Console.WriteLine(new string(' ', 30));
                                        Console.SetCursorPosition(8, 5);
                                        Console.WriteLine($"{searchuser.Role}");
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
                        Func<User, User, bool> usercomparer = (searchuser, user) =>
                            (searchuser.Id == 0 || searchuser.Id == user.Id) &&
                            (string.IsNullOrEmpty(searchuser.Login) || searchuser.Login == user.Login) &&
                            (string.IsNullOrEmpty(searchuser.Password) || searchuser.Password == user.Password) &&
                            ((int)searchuser.Role == 0 || searchuser.Role == user.Role);
                        for (int i = 0; i < users.Count; i++)
                        {
                            if (usercomparer(searchuser, users[i]))
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
                            Open_user(index, id);
                            Console.Clear();
                            return;
                        }
                    default: break;
                }
            }
        }
        private static void Create_user(int id)
        {
            Console.Clear();
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<User> users = Administrator_menu(syspath, id);
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
            User newuser = new();
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"  ID: ");
                Console.WriteLine($"  Логин: ");
                Console.WriteLine($"  Пароль: ");
                Console.WriteLine($"  Роль: ");
                int[] position = Arrows.Arrow(5, 2);
                switch (position[0])
                {
                    case (int)Arrows.Keys.Enter:
                        newuser = Edit_user(users, newuser, position[1]);
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.S:
                        users.Add(newuser);
                        Update((syspath + "\\Users.json"), users);//функция апдейта
                        continue;
                    default: break;
                }
            }
        }
        private static void Open_user(int pos, int id)
        {
            Console.Clear();
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<User> users = Administrator_menu(syspath, id);
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
            Console.WriteLine($"  ID: {users[pos].Id}");
            Console.WriteLine($"  Логин: {users[pos].Login}");
            Console.WriteLine($"  Пароль: {users[pos].Password}");
            Console.WriteLine($"  Роль: {users[pos].Role}");
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"  ID: ");
                Console.WriteLine($"  Логин: ");
                Console.WriteLine($"  Пароль: ");
                Console.WriteLine($"  Роль: ");
                int[] position = Arrows.Arrow(5, 2);
                switch (position[0])
                {
                    case (int)Arrows.Keys.Enter:
                        users[pos] = Edit_user(users, users[pos], position[1]);
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.S:
                        Update((syspath + "\\Users.json"), users);
                        continue;
                    case (int)Arrows.Keys.Delete:
                        users.RemoveAt(pos);
                        Update((syspath + "\\Users.json"), users);
                        Console.Clear();
                        return;
                    default: break;
                }
            }

        }
        private static User Edit_user(List<User> users, User newuser, int position)
        {
            switch (position)
            {
                case 2:

                    while (true)
                    {
                        Console.SetCursorPosition(6, 2);
                        Console.WriteLine(new string(' ', 10));
                        Console.SetCursorPosition(6, 2);
                        Console.WriteLine($"{newuser.Id}");
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
                                Console.WriteLine($"{newuser.Id}");
                            }
                        }
                        bool unique = true;
                        foreach (var user in users)
                        {
                            if (user.Id == newId)
                            {
                                unique = false;
                            }
                        }
                        if (unique)
                        {
                            newuser.Id = newId;
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
                    Console.SetCursorPosition(9, 3);
                    Console.WriteLine(new string(' ', 90));
                    Console.SetCursorPosition(9, 3);
                    newuser.Login = Console.ReadLine();
                    break;
                case 4:
                    Console.SetCursorPosition(10, 4);
                    Console.WriteLine(new string(' ', 90));
                    Console.SetCursorPosition(10, 4);
                    newuser.Password = Console.ReadLine();
                    break;
                case 5:

                    while (true)
                    {
                        Console.SetCursorPosition(8, 5);
                        Console.WriteLine(' ');
                        Console.SetCursorPosition(8, 5);
                        int newRole;
                        while (true)
                        {
                            try
                            {
                                Console.SetCursorPosition(8, 5);
                                newRole = Convert.ToInt32(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.SetCursorPosition(8, 5);
                                Console.WriteLine("Введено некорректное значение");
                                Thread.Sleep(1000);
                                Console.SetCursorPosition(8, 5);
                                Console.WriteLine(new string(' ', 30));
                                Console.SetCursorPosition(8, 5);
                                Console.WriteLine($"{newuser.Role}");
                            }
                        }
                        if (newRole < 5 && newRole >= 0)
                        {
                            newuser.Role = newRole;
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(8, 5);
                            Console.WriteLine("Такой роли не существует");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(8, 5);
                            Console.WriteLine(new string(' ', 30));
                            Console.SetCursorPosition(8, 5);
                            Console.WriteLine($"{newuser.Role}");
                        }
                    }
                    break;
            }
            return newuser;
        }
        private static List<User> Administrator_menu(string syspath, int Id)
        {
            List<User> users = Read<List<User>>(syspath + "\\Users.json");
            List<Employee> employees = new();
            if (File.Exists(syspath + "\\Employees.json"))
            {
                employees = Read<List<Employee>>(syspath + "\\Employees.json");
            }
            ICRUD_menu();
            Console.SetCursorPosition(30, 0);
            string name = "Администратор";
            foreach (Employee employee in employees)
            {
                if (employee.UserId == Id)
                {
                    name = employee.Name;
                }
            }
            Console.WriteLine($"Добро пожаловать,{name}!");
            Console.SetCursorPosition(100, 0);
            Console.WriteLine("Роль:Администратор");
            Console.SetCursorPosition(0, 2);
            return users;
        }
    }
}
