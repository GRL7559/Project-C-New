using Practic5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practic10
{
    internal class Cashier:ICRUD
    {
        public Cashier(int id)
        {
            while (true)
            {
                bool stop = false;
                string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                List<Product> products = Read<List<Product>>(syspath + "\\Products.json");
                List<CurrentProduct> currentproducts = new();
                foreach (Product product in products)
                {
                    if (currentproducts.Count != products.Count)
                    {
                        CurrentProduct currentproduct = new()
                        {
                            Id = product.Id,
                            Remains = product.Remains,
                            Price = product.Price,
                            Title = product.Title,
                            Currentquantity = 0
                        };
                        currentproducts.Add(currentproduct);
                    }
                }
                List<Employee> employees = new();
                if (File.Exists(syspath + "\\Employees.json"))
                {
                    employees = Read<List<Employee>>(syspath + "\\Employees.json");
                }
                string name = "Кассир";
                foreach (Employee employee in employees)
                {
                    if (employee.UserId == id)
                    {
                        name = employee.Name;
                    }
                }
                while (!stop)
                {
                    ICRUD_menu();
                    Console.SetCursorPosition(30, 0);
                    Console.WriteLine($"Добро пожаловать,{name}!");
                    Console.SetCursorPosition(100, 0);
                    Console.WriteLine("Роль:Кассир");
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine($"   {"ID",-22}{"Название",-25}{"Цена",-25}{"Количество",-24}");
                    Console.SetCursorPosition(101, 2);
                    Console.WriteLine("Enter - открыть");
                    Console.SetCursorPosition(101, 3);
                    Console.WriteLine("Escape - выйти");
                    Console.SetCursorPosition(101, 4);
                    Console.WriteLine("S - завершить");
                    double result = 0;
                    int maxpos = 2;
                    Console.SetCursorPosition(0, 3);
                    foreach (CurrentProduct currentproduct in currentproducts)
                    {
                        Console.WriteLine($"   {currentproduct.Id,-22}{currentproduct.Title,-25}{currentproduct.Price,-25}{currentproduct.Currentquantity,-24}");
                        result += currentproduct.Currentamount;
                        maxpos++;
                    }
                    Console.SetCursorPosition(101, 5);
                    Console.WriteLine("Итого:");
                    Console.SetCursorPosition(101, 6);
                    Console.WriteLine(new string(' ', 30));
                    Console.SetCursorPosition(101, 6);
                    Console.WriteLine($"{result}");
                    int[] pos = Arrows.Arrow(maxpos, 3);
                    switch (pos[0])
                    {
                        case (int)Arrows.Keys.Enter:
                            currentproducts[pos[1] - 3] = Open_product(currentproducts[pos[1] - 3], name);
                            break;
                        case (int)Arrows.Keys.Escape:
                            Console.Clear();
                            return;
                        case (int)Arrows.Keys.S:
                            Create_purchase(currentproducts);
                            stop = true;
                            break;
                        default: break;
                    }
                }
            }
        }
        private static void Create_purchase(List<CurrentProduct> currentproducts)
        {
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<Purchase> purchases = new();
            List<Product> products = Read<List<Product>>(syspath + "\\Products.json");
            List<Check> checks = Read<List<Check>>(syspath + "\\Checks.json");
            double result = 0; 
            foreach (CurrentProduct currentproduct in currentproducts) 
            {
                result += currentproduct.Currentamount;
            }
            Purchase purchase = new()
            {
                Products = currentproducts,
                Date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                Amount = result
            };
            purchases.Add(purchase);
            for (int i = 0; i < products.Count; i++)
            {
                products[i].Remains -= currentproducts[i].Currentquantity;
            }
            Check check = new()
            {
                PlMin = true,
                Name = $"Покупка",
                Amount = result,
                Date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            };
            while (true) 
            {
                Random random = new();
                int ID = random.Next(1, 101);
                bool unique = true;
                foreach (Check checki in checks)
                {
                    if (ID == checki.Id) unique = false;
                }
                if (unique)
                {
                    check.Id = ID;
                    break;
                }
            }
            checks.Add(check);
            Update(syspath + "\\Purchases.json", purchases);
            Update(syspath + "\\Products.json", products);
            Update(syspath + "\\Checks.json", checks);
        }
        private static CurrentProduct Open_product(CurrentProduct currentproduct,string name)
        {
            Console.Clear();
            ICRUD_menu();
            Console.SetCursorPosition(30, 0);
            Console.WriteLine($"Добро пожаловать,{name}!");
            Console.SetCursorPosition(100, 0);
            Console.WriteLine("Роль:Менеджер склада");
            Console.SetCursorPosition(101, 2);
            Console.WriteLine("RightArrow - добавить");
            Console.SetCursorPosition(101, 3);
            Console.WriteLine("LeftArrow - убавить");
            Console.SetCursorPosition(101, 4);
            Console.WriteLine("Escape - выйти");
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"  ID: {currentproduct.Id}");
                Console.WriteLine($"  Название: {currentproduct.Title}");
                Console.WriteLine($"  Цена: {currentproduct.Price}");
                Console.WriteLine($"  Выбранное количество: {currentproduct.Currentquantity}"); 
                int[] position = Arrows.Arrow(0, 0);
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("  ");
                switch (position[0])
                {
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        currentproduct.Currentamount = currentproduct.Price * currentproduct.Currentquantity;
                        return currentproduct;
                    case (int)Arrows.Keys.Right:
                        if (currentproduct.Currentquantity < currentproduct.Remains) currentproduct.Currentquantity += 1;
                        break;
                    case (int)Arrows.Keys.Left:
                        if (currentproduct.Currentquantity > 0) currentproduct.Currentquantity -= 1;
                        break;
                    default: break;
                }
            }
        }
    }
}
