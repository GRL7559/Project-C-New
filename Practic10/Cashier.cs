using Practic5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic10
{
    internal class Cashier:ICRUD
    {
        public Cashier(int id)
        {
            double result=0;
            while (true)
            {
                string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                List<CurrentProduct> currentproducts = Cashier_menu(syspath, id);
                Console.WriteLine($"   {"ID",-22}{"Название",-25}{"Цена",-25}{"Количество",-24}");
                Console.SetCursorPosition(101, 3);
                Console.WriteLine("Enter - открыть");
                Console.SetCursorPosition(101, 4);
                Console.WriteLine("Escape - выйти");
                Console.SetCursorPosition(101, 5);
                Console.WriteLine("S - завершить");
                int maxpos = 2;
                Console.SetCursorPosition(0, 3);
                foreach (CurrentProduct currentproduct in currentproducts)
                {
                    Console.WriteLine($"   {currentproduct.Id,-22}{currentproduct.Title,-25}{currentproduct.Price,-25}{currentproduct.Currentquantity,-24}");
                    maxpos++;
                    result += currentproduct.Price*currentproduct.Currentquantity;
                }
                Console.SetCursorPosition(101, 6);
                Console.WriteLine("Итого");
                Console.SetCursorPosition(101, 7);
                Console.WriteLine($"{result}"); 
                int[] pos = Arrows.Arrow(maxpos, 3);
                switch (pos[0])
                {
                    case (int)Arrows.Keys.Enter:
                        currentproducts[pos[1] - 3].Currentquantity = Open_product(currentproducts[pos[1] - 3],id);
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.S:
                        Create_purchase(currentproducts, result);
                        break;
                    default: break;
                }
            }

        }
        private static void Create_purchase(List<CurrentProduct> currentproducts, double result)
        {
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<Purchase> purchases = new();
            List<Product> products = Read<List<Product>>(syspath + "\\Products.json");
            List<Check> checks = Read<List<Check>>(syspath + "\\Checks.json");
            Purchase purchase = new();
            if (purchases[0].Number != 0) purchase.Number = purchases[-1].Number + 1;
            else purchase.Number = 1;
            purchase.Products = currentproducts;
            purchase.Date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            purchase.Amount = result;
            purchases.Add(purchase);
            for (int i = 0; i < products.Count; i++)
            {
                products[i].Remains -= currentproducts[i].Currentquantity;
            }
            Check check = new()
            {
                PlMin = true,
                Name = $"Покупка №{purchase.Number}",
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
        private static int Open_product(CurrentProduct currentproduct,int id)
        {
            Console.Clear();
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Cashier_menu(syspath,id);
            Console.SetCursorPosition(101, 2);
            Console.WriteLine("UpArrow - добавить");
            Console.SetCursorPosition(101, 3);
            Console.WriteLine("DownArrow - убавить");
            Console.SetCursorPosition(101, 4);
            Console.WriteLine("Escape - выйти");
            while (true)
            {
                Console.WriteLine($"  ID: {currentproduct.Id}");
                Console.WriteLine($"  Название: {currentproduct.Title}");
                Console.WriteLine($"  Цена: {currentproduct.Price}");
                Console.WriteLine($"  Выбранное количество: {currentproduct.Currentquantity}"); 
                int[] position = Arrows.Arrow(currentproduct.Remains, 0);
                currentproduct.Currentquantity = position[1];
                switch (position[0])
                {
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return currentproduct.Currentquantity;
                    default: break;
                }
            }

        }
        private static List<CurrentProduct> Cashier_menu(string syspath, int Id)
        {
            List<Product> products = Read<List<Product>>(syspath + "\\Products.json");
            List<CurrentProduct> currentproducts = new();
            foreach (Product product in products)
            {
                if (currentproducts.Count != products.Count)
                {
                    CurrentProduct currentproduct = new();
                    currentproduct.Remains = product.Remains;
                    currentproduct.Price = product.Price;
                    currentproduct.Title = product.Title;
                    currentproduct.Currentquantity = 0;
                    currentproducts.Add(currentproduct);
                }
            }
            List<Employee> employees = new();
            if (File.Exists(syspath + "\\Employees.json"))
            {
                employees = Read<List<Employee>>(syspath + "\\Employees.json");
            }
            ICRUD_menu();
            Console.SetCursorPosition(30, 0);
            string name = "Менеджер склада";
            foreach (Employee employee in employees)
            {
                if (employee.UserId == Id)
                {
                    name = employee.Name;
                }
            }
            Console.WriteLine($"Добро пожаловать,{name}!");
            Console.SetCursorPosition(100, 0);
            Console.WriteLine("Роль:Менеджер склада");
            Console.SetCursorPosition(0, 2);
            return currentproducts;
        }
    }
}
