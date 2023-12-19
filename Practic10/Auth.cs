using Newtonsoft.Json;
using Practic5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practic10
{
    internal class Auth
    {
        static string GetPassword()
        {
            string password = "";
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key != ConsoleKey.Enter)
                {
                    if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password[..^1]; // Удалить последний символ из строки
                        Console.Write("\b \b"); // Стереть последний символ
                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        password += keyInfo.KeyChar;
                        Console.Write("*");
                    }
                }
            } while (keyInfo.Key != ConsoleKey.Enter);

            return password;
        }
        public static User AuthUser() 
        {
            string login = "";
            string password = "";
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<Purchase> purchases = new();
            List<Check> checks = new();
            List<CurrentProduct> currentproducts = new();
            List<Product> products = new();
            List<Employee> employees = new();
            List<User> users = new() { new User() { Id = 1, Login = "Administrator", Password = "123", Role = 0 } };
            Console.WriteLine("Здравствуйте, пожалуйста, авторизуйтесь.");
            Console.WriteLine("  Введите логин: ");
            Console.WriteLine("  Введите пароль: ");
            Console.WriteLine("  Завершить авторизацию");
            while (true)
            {
                int[] pos = Arrows.Arrow(3, 1);
                switch (pos[0])
                {
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();    
                        Console.SetCursorPosition(0, 0);
                        Environment.Exit(0);
                        break;
                    case (int)Arrows.Keys.Enter:
                        switch (pos[1])
                        {
                            case 1:
                                Console.SetCursorPosition(18, 1);
                                Console.Write(new string (' ', login.Length));
                                Console.SetCursorPosition(18, 1);
                                login = Console.ReadLine();
                                break; 
                            case 2:
                                Console.SetCursorPosition(19, 2);
                                Console.Write(new string(' ', password.Length));
                                Console.SetCursorPosition(19, 2);
                                password = GetPassword();
                                break; 
                            case 3:
                                Console.SetCursorPosition(0, 5);
                                if (password != "" | login != "")
                                {
                                    if (File.Exists(syspath + "\\Users.json"))
                                    {
                                       users = JSON.Deserialization<List<User>>(syspath + "\\Users.json");
                                    }
                                    else
                                    {
                                        JSON.Serialization(syspath + "\\Users.json", users);
                                    }
                                    if (!File.Exists(syspath + "\\Employees.json"))
                                    {
                                        JSON.Serialization(syspath + "\\Employees.json", employees);
                                    }
                                    if (!File.Exists(syspath + "\\Products.json"))
                                    {
                                        JSON.Serialization(syspath + "\\Products.json", products);
                                    }
                                    if (!File.Exists(syspath + "\\CurrentProducts.json"))
                                    {
                                        JSON.Serialization(syspath + "\\CurrentProducts.json", currentproducts);
                                    }
                                    if (!File.Exists(syspath + "\\Checks.json"))
                                    {
                                        JSON.Serialization(syspath + "\\Check.json", checks);
                                    }
                                    if (!File.Exists(syspath + "\\Purchases.json"))
                                    {
                                        JSON.Serialization(syspath + "\\Purchases.json", purchases);
                                    }
                                    foreach (User user in users)
                                    {
                                        if (password == user.Password && login == user.Login)
                                        {
                                            Console.Clear(); 
                                            return user;
                                        }
                                        else Console.WriteLine("Пользователь не найден");
                                    }
                                }else Console.WriteLine("Введите логин и пароль");
                                break;
                        }
                        break;
                    default:break;
                }
            }
        }
    }
}
