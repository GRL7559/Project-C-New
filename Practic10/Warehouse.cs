using Practic5;
namespace Practic10
{
    internal class Warehouse:ICRUD
    {
        public Warehouse(int id)
        {
            while (true)
            {
                string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                List<Product> products = Warehouse_menu(syspath, id);
                Console.WriteLine($"   {"ID",-22}{"Название",-25}{"Цена",-25}{"Остаток",-24}");
                Console.SetCursorPosition(101, 2);
                Console.WriteLine("Enter - открыть");
                Console.SetCursorPosition(101, 3);
                Console.WriteLine("Escape - выйти");
                Console.SetCursorPosition(101, 4);
                Console.WriteLine("C - создать");
                Console.SetCursorPosition(101, 5);
                Console.WriteLine("S - поиск");
                int maxpos = 2;
                Console.SetCursorPosition(0, 3);
                foreach (Product product in products)
                {
                    Console.WriteLine($"   {product.Id,-22}{product.Title,-25}{product.Price,-25}{product.Remains,-24}");
                    maxpos++;
                }
                int[] pos = Arrows.Arrow(maxpos, 3);
                switch (pos[0])
                {
                    case (int)Arrows.Keys.Enter:
                        if (maxpos > 3) Open_product(pos[1] - 3, id);
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.C:
                        Create_product(id);
                        break;
                    case (int)Arrows.Keys.S:
                        Search_product(id);
                        break;
                    default: break;
                }
            }

        }
        private static void Search_product(int id)
        {
            Console.Clear();
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<Product> products = Warehouse_menu(syspath, id);
            Product searchproduct = new();
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"  ID: ");
                Console.WriteLine($"  Название: ");
                Console.WriteLine($"  Цена: ");
                Console.WriteLine($"  Остаток: ");
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
                                    while (true)
                                    {
                                        try
                                        {
                                            Console.SetCursorPosition(6, 2);
                                            searchproduct.Id = Convert.ToInt32(Console.ReadLine());
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
                                            Console.WriteLine($"{searchproduct.Id}");
                                        }
                                    }
                                    break;
                                }
                                break;
                            case 3:
                                Console.SetCursorPosition(12, 3);
                                Console.WriteLine(new string(' ', 90));
                                Console.SetCursorPosition(12, 3);
                                searchproduct.Title = Console.ReadLine();
                                break;
                            case 4:
                                Console.SetCursorPosition(10, 4);
                                Console.WriteLine(new string(' ', 90));
                                Console.SetCursorPosition(10, 4);
                                while (true)
                                {
                                    try
                                    {
                                        Console.SetCursorPosition(10, 4);
                                        searchproduct.Price = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    }
                                    catch
                                    {
                                        Console.SetCursorPosition(10, 4);
                                        Console.WriteLine("Введено некорректное значение");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(10, 4);
                                        Console.WriteLine(new string(' ', 30));
                                        Console.SetCursorPosition(10, 4);
                                        Console.WriteLine($"{searchproduct.Price}");
                                    }
                                }
                                break;
                            case 5:
                                Console.SetCursorPosition(11, 5);
                                Console.WriteLine(' ');
                                Console.SetCursorPosition(11, 5);
                                while (true)
                                {
                                    try
                                    {
                                        Console.SetCursorPosition(11, 5);
                                        searchproduct.Remains = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    }
                                    catch
                                    {
                                        Console.SetCursorPosition(11, 5);
                                        Console.WriteLine("Введено некорректное значение");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(11, 5);
                                        Console.WriteLine(new string(' ', 30));
                                        Console.SetCursorPosition(11, 5);
                                        Console.WriteLine($"{searchproduct.Remains}");
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
                        Func<Product, Product, bool> productcomparer = (searchproduct, product) =>
                            (searchproduct.Id == 0 || searchproduct.Id == product.Id) &&
                            (string.IsNullOrEmpty(searchproduct.Title) || searchproduct.Title == product.Title) &&
                            (searchproduct.Price == 0 || searchproduct.Price == product.Price) &&
                            (searchproduct.Remains == 0 || searchproduct.Remains == product.Remains);
                        for (int i = 0; i < products.Count; i++)
                        {
                            if (productcomparer(searchproduct, products[i]))
                            {
                                index = i;
                            }
                        }
                        if (index == -1)
                        {
                            Console.SetCursorPosition(0, 7);
                            Console.WriteLine("Продукт не найден или недостаточно данных");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(0, 7);
                            Console.WriteLine(new string(' ', 50));
                            break;
                        }
                        else
                        {
                            Open_product(index, id);
                            Console.Clear();
                            return;
                        }
                    default: break;
                }
            }
        }
        private static void Create_product(int id)
        {
            Console.Clear();
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<Product> products = Warehouse_menu(syspath, id);
            Console.SetCursorPosition(101, 2);
            Console.WriteLine("Enter - изменить");
            Console.SetCursorPosition(101, 3);
            Console.WriteLine("S - сохранить");
            Console.SetCursorPosition(101, 4);
            Console.WriteLine("Escape - выйти");
            Product newproduct = new();
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"  ID: ");
                Console.WriteLine($"  Название: ");
                Console.WriteLine($"  Цена: ");
                Console.WriteLine($"  Остаток: ");
                int[] position = Arrows.Arrow(5, 2);
                switch (position[0])
                {
                    case (int)Arrows.Keys.Enter:
                        newproduct = Edit_product(products, newproduct, position[1]);
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.S:
                        products.Add(newproduct);
                        Update((syspath + "\\Products.json"), products);//функция апдейта
                        return;
                    default: break;
                }
            }
        }
        private static void Open_product(int pos, int id)
        {
            Console.Clear();
            string syspath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<Product> products = Warehouse_menu(syspath, id);
            Console.SetCursorPosition(101, 2);
            Console.WriteLine("Enter - изменить");
            Console.SetCursorPosition(101, 3);
            Console.WriteLine("S - сохранить");
            Console.SetCursorPosition(101, 4);
            Console.WriteLine("Delete - удалить");
            Console.SetCursorPosition(101, 5);
            Console.WriteLine("Escape - выйти");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"  ID: {products[pos].Id}");
            Console.WriteLine($"  Название: {products[pos].Title}");
            Console.WriteLine($"  Цена: {products[pos].Price}");
            Console.WriteLine($"  Остаток: {products[pos].Remains}");
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"  ID: ");
                Console.WriteLine($"  Название: ");
                Console.WriteLine($"  Цена: ");
                Console.WriteLine($"  Остаток: ");
                int[] position = Arrows.Arrow(5, 2);
                switch (position[0])
                {
                    case (int)Arrows.Keys.Enter:
                        products[pos] = Edit_product(products, products[pos], position[1]);
                        break;
                    case (int)Arrows.Keys.Escape:
                        Console.Clear();
                        return;
                    case (int)Arrows.Keys.S:
                        Update((syspath + "\\Products.json"), products);
                        return;
                    case (int)Arrows.Keys.Delete:
                        products.RemoveAt(pos);
                        Update((syspath + "\\Products.json"), products);
                        Console.Clear();
                        return;
                    default: break;
                }
            }

        }
        private static Product Edit_product(List<Product> products, Product newproduct, int position)
        {
            switch (position)
            {
                case 2:

                    while (true)
                    {
                        Console.SetCursorPosition(6, 2);
                        Console.WriteLine(new string(' ', 30));
                        Console.SetCursorPosition(6, 2);
                        Console.WriteLine($"{newproduct.Id}");
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
                                Console.WriteLine($"{newproduct.Id}");
                            }
                        }
                        bool unique = true;
                        foreach (var user in products)
                        {
                            if (user.Id == newId)
                            {
                                unique = false;
                            }
                        }
                        if (unique)
                        {
                            newproduct.Id = newId;
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
                    newproduct.Title = Console.ReadLine();
                    break;
                case 4:
                    Console.SetCursorPosition(8, 4);
                    Console.WriteLine(new string(' ', 30));
                    Console.SetCursorPosition(8, 4);
                    int newPrice;
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(8, 4);
                            newproduct.Price = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.SetCursorPosition(8, 4);
                            Console.WriteLine("Введено некорректное значение");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(8, 4);
                            Console.WriteLine(new string(' ', 30));
                            Console.SetCursorPosition(8, 4);
                            Console.WriteLine($"{newproduct.Price}");
                        }
                    }
                    break;
                case 5:
                    int newRemains;
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(11, 5);
                            newproduct.Remains = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.SetCursorPosition(11, 5);
                            Console.WriteLine("Введено некорректное значение");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(11, 5);
                            Console.WriteLine(new string(' ', 30));
                            Console.SetCursorPosition(11, 5);
                            Console.WriteLine($"{newproduct.Remains}");
                        }
                    }
                    break;
            }
            return newproduct;
        }
        private static List<Product> Warehouse_menu(string syspath, int Id)
        {
            List<Product> products = Read<List<Product>>(syspath + "\\Products.json");
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
            return products;
        }
    }
}