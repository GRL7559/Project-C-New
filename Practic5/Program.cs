using System.Diagnostics;
using System.Reflection.Metadata;

namespace Practic5
{
    internal class Tortiki
    {
        public static string txtShape     = "";
        public static string txtSize      = "";
        public static string txtTaste     = "";
        public static string txtQuantity  = "";
        public static string txtGlaze     = "";
        public static string txtDecor     = "";
        public static Zakaz Zakazik = new("", "", "", "", "", "", 0, 0, 0, 0, 0, 0);
        public static void Change_zakaz(int parametrs, int parametrscost)
        {
            int[] CostsShape          = new int[] { 500, 1000, 1500 };
            int[] CostsSize           = new int[] { 500, 1000, 1500 };
            int[] CostsTaste          = new int[] { 500, 1000, 1500 };
            int[] CostsQuantity       = new int[] { 500, 1000, 1500 };
            int[] CostsGlaze          = new int[] { 500, 1000, 1500 };
            int[] CostsDecor          = new int[] { 500, 1000, 1500 };
            List<string> PoolShape    = new() { "Круг", "Квадрат", "Сердце" };
            List<string> PoolSize     = new() { "Маленький", "Средний", "Большой" };
            List<string> PoolTaste    = new() { "Шоколад", "Клубника", "Манго-гуава" };
            List<string> PoolQuantity = new() { "500 грамм", "1 килограмм", "1.5 килограмма" };
            List<string> PoolGlaze    = new() { "Шоколад", "Белый шоколад", "Карамельный ганаш" };
            List<string> PoolDecor    = new() { "Надпись глазурью", "Фигурка из мастики", "Фигурка из шоколада" };
            switch (parametrs) 
            {
                case 0:
                    Zakazik.CostShape    = CostsShape[parametrscost];
                    Zakazik.Shape        = PoolShape[parametrscost];
                    txtShape = $"{Zakazik.Shape} - {Zakazik.CostShape} ";
                    break;
                case 1:
                    Zakazik.CostSize     = CostsSize[parametrscost];
                    Zakazik.Size         = PoolSize[parametrscost];
                    txtSize              = $"{Zakazik.Size} - {Zakazik.CostSize} ";
                    break;
                case 2:
                    Zakazik.CostTaste    = CostsTaste[parametrscost];
                    Zakazik.Taste        = PoolTaste[parametrscost];
                    txtTaste             = $"{Zakazik.Taste} - {Zakazik.CostTaste} ";
                    break;
                case 3:
                    Zakazik.CostQuantity = CostsQuantity[parametrscost];
                    Zakazik.Quantity     = PoolQuantity[parametrscost];
                    txtQuantity          = $"{Zakazik.Quantity} - {Zakazik.CostQuantity} ";
                    break;
                case 4:
                    Zakazik.CostGlaze    = CostsGlaze[parametrscost];
                    Zakazik.Glaze        = PoolGlaze[parametrscost];
                    txtQuantity          = $"{Zakazik.Glaze} - {Zakazik.CostGlaze} ";
                    break;
                case 5:
                    Zakazik.CostDecor    = CostsDecor[parametrscost];
                    Zakazik.Decor        = PoolDecor[parametrscost];
                    txtDecor             = $"{Zakazik.Decor} - {Zakazik.CostDecor} ";
                    break;
            }
        }
        public static void Particulars(int parametrs)
        {
            Console.Clear();
            switch (parametrs)
            {
                case 0:
                    Console.WriteLine("Выбирете параметр торта");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("  Круг - 500");
                    Console.WriteLine("  Квадрат - 1000");
                    Console.WriteLine("  Сердце - 1500");
                    break;
                case 1:
                    Console.WriteLine("Выбирете параметр торта");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("  Маленький - 500");
                    Console.WriteLine("  Средний - 1000");
                    Console.WriteLine("  Большой - 1500");
                    break;
                case 2:
                    Console.WriteLine("Выбирете параметр торта");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("  Шоколад - 500");
                    Console.WriteLine("  Клубника - 1000");
                    Console.WriteLine("  Манго-гуава - 1500");
                    break;
                case 3:
                    Console.WriteLine("Выбирете параметр торта");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("  500 грамм - 500");
                    Console.WriteLine("  1 килограмм - 1000");
                    Console.WriteLine("  1.5 килограмма - 1500");
                    break;
                case 4:
                    Console.WriteLine("Выбирете параметр торта");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("  Шоколад - 500");
                    Console.WriteLine("  Белый шоколад - 1000");
                    Console.WriteLine("  Карамельный ганаш - 1500");
                    break;
                case 5:
                    Console.WriteLine("Выбирете параметр торта");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("  Надпись глазурью - 500");
                    Console.WriteLine("  Фигурка из мастики - 1000");
                    Console.WriteLine("  Фигурка из шоколада - 1500");
                    break;
            }
            Arrows Content = new(4,2,2);
            Content.Arrow();
        }
        public static void Menu()
        {
            int cost = Zakazik.CostShape + Zakazik.CostSize + Zakazik.CostTaste + Zakazik.CostQuantity + Zakazik.CostGlaze + Zakazik.CostDecor;
            Console.Clear();
            Console.WriteLine("Выбирете параметр торта");
            Console.WriteLine("-----------------------");
            Console.WriteLine("  Форма");
            Console.WriteLine("  Размер");
            Console.WriteLine("  Вкус");
            Console.WriteLine("  Количество");
            Console.WriteLine("  Глазурь");
            Console.WriteLine("  Декор");
            Console.WriteLine("  Завершить заказ");
            Console.WriteLine($"\nТекущая комплектация торта: {Zakazik.Shape} {Zakazik.Size} {Zakazik.Taste} {Zakazik.Quantity} {Zakazik.Glaze} {Zakazik.Decor}");
            Console.WriteLine($"Цена: {cost}"); 
            Arrows Piece = new(8,2,1);
            Piece.Arrow();
        }
        public static void Total()
        {
            Console.Clear();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!File.Exists(path + "\\Чек.txt"))
            {
                File.Create(path + "\\Чек.txt").Close();
            }
            DateTime time = DateTime.Now;
            string txt = ($"{txtShape}{txtSize}{txtTaste}{txtQuantity}{txtGlaze}{txtDecor}") ;
            File.AppendAllText(path + "\\Чек.txt",$"Заказ от {time}\n\t{txt}\n");
            ConsoleKeyInfo keyInfo;
            Console.WriteLine("Спасибо за заказ!\nСделать еще один заказ : Enter \nВыйти : Escape ");
            while(true)
            {
                keyInfo = Console.ReadKey(true);
                switch(keyInfo.Key) 
                {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.Enter:
                        Zakazik.CostShape       = 0;
                        Zakazik.CostSize        = 0;
                        Zakazik.CostTaste       = 0;
                        Zakazik.CostQuantity    = 0;
                        Zakazik.CostGlaze       = 0;
                        Zakazik.CostDecor       = 0;
                        Zakazik.Shape           = "";
                        Zakazik.Size            = "";
                        Zakazik.Taste           = "";
                        Zakazik.Quantity        = "";
                        Zakazik.Glaze           = "";
                        Zakazik.Decor           = "";
                        txtShape                = "";
                        txtSize                 = "";
                        txtTaste                = "";
                        txtQuantity             = "";
                        txtGlaze                = "";
                        txtDecor                = "";
                        Program.Main();
                        break;
                }
            }
        }
    }
    class Program
    {
        public static void Main()
        {
            while (true)
            {
                Tortiki.Menu();
            }
        }
    }
}