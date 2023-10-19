using System.Diagnostics;
using System.Reflection.Metadata;

namespace Practic5
{
    internal class Tortiki
    {
        public static int cost;
        public static string txtShape               = "";
        public static string txtSize                = "";
        public static string txtTaste               = "";
        public static string txtQuantity            = "";
        public static string txtGlaze               = "";
        public static string txtDecor               = "";
        public static Order Zakazik                 = new("", "", "", "", "", "", 0, 0, 0, 0, 0, 0);
        public static Paragraph Circle              = new(500, "Круг");
        public static Paragraph Square              = new(1000, "Квадрат");
        public static Paragraph Heart               = new(1500, "Сердце");
        public static Paragraph Small               = new(500, "Маленький");
        public static Paragraph Middle              = new(1000, "Средний");
        public static Paragraph Huge                = new(1500, "Большой");
        public static Paragraph Chocolate           = new(500, "Шоколад");
        public static Paragraph Strawberry          = new(1000, "Клубника");
        public static Paragraph Mango_guava         = new(1500, "Манго-гуава");
        public static Paragraph Halfkg              = new(500, "500 грамм");
        public static Paragraph Kg                  = new(1000, "1 килограмм");
        public static Paragraph Kgg                 = new(1500, "1.5 килограмма");
        public static Paragraph Chocolate_g         = new(500, "Шоколад");
        public static Paragraph White_chocolate     = new(1000, "Белый шоколад");
        public static Paragraph Caramel             = new(1500, "Карамельный ганаш");
        public static Paragraph Title               = new(500, "Надпись глазурью");
        public static Paragraph Mastic              = new(1000, "Фигурка из мастики");
        public static Paragraph Chocolate_f         = new(1500, "Фигурка из шоколада");
        public static void Change_zakaz(int parametrs, int parametrscost)
        {
            switch (parametrs) 
            {
                case 0:
                    switch(parametrscost)
                    {
                        case 0:
                            Zakazik.CostShape       = Circle.Cost;
                            Zakazik.Shape           = Circle.Product;
                            break;
                        case 1:
                            Zakazik.CostShape       = Square.Cost;
                            Zakazik.Shape           = Square.Product;
                            break;
                        case 2:
                            Zakazik.CostShape       = Heart.Cost;
                            Zakazik.Shape           = Heart.Product;
                            break;
                    }
                    txtShape                        = $"{Zakazik.Shape} - {Zakazik.CostShape} ";
                    break;
                case 1:
                    switch (parametrscost)
                    {
                        case 0:
                            Zakazik.CostSize        = Small.Cost;
                            Zakazik.Size            = Small.Product;
                            break;
                        case 1:
                            Zakazik.CostSize        = Middle.Cost;
                            Zakazik.Size            = Middle.Product;
                            break;
                        case 2:
                            Zakazik.CostSize        = Huge.Cost;
                            Zakazik.Size            = Huge.Product;
                            break;
                    }
                    txtSize                         = $"{Zakazik.Size} - {Zakazik.CostSize} ";
                    break;
                case 2:
                    switch (parametrscost)
                    {
                        case 0:
                            Zakazik.CostTaste       = Chocolate.Cost;
                            Zakazik.Taste           = Chocolate.Product;
                            break;
                        case 1:
                            Zakazik.CostTaste       = Strawberry.Cost;
                            Zakazik.Taste           = Strawberry.Product;
                            break;
                        case 2:
                            Zakazik.CostTaste       = Mango_guava.Cost;
                            Zakazik.Taste           = Mango_guava.Product;
                            break;
                    }
                    txtTaste                        = $"{Zakazik.Taste} - {Zakazik.CostTaste} ";
                    break;
                case 3:
                    switch (parametrscost)
                    {
                        case 0:
                            Zakazik.CostQuantity    = Halfkg.Cost;
                            Zakazik.Quantity        = Halfkg.Product;
                            break;
                        case 1:
                            Zakazik.CostQuantity    = Kg.Cost;
                            Zakazik.Quantity        = Kg.Product;
                            break;
                        case 2:
                            Zakazik.CostQuantity    = Kgg.Cost;
                            Zakazik.Quantity        = Kgg.Product;
                            break;
                    }
                    txtQuantity                     = $"{Zakazik.Quantity} - {Zakazik.CostQuantity} ";
                    break;
                case 4:
                    switch (parametrscost)
                    {
                        case 0:
                            Zakazik.CostGlaze       = Chocolate_g.Cost;
                            Zakazik.Glaze           = Chocolate_g.Product;
                            break;
                        case 1:
                            Zakazik.CostGlaze       = White_chocolate.Cost;
                            Zakazik.Glaze           = White_chocolate.Product;
                            break;
                        case 2:
                            Zakazik.CostGlaze       = Caramel.Cost;
                            Zakazik.Glaze           = Caramel.Product;
                            break;
                    }
                    txtQuantity                     = $"{Zakazik.Glaze} - {Zakazik.CostGlaze} ";
                    break;
                case 5:
                    switch (parametrscost)
                    {
                        case 0:
                            Zakazik.CostDecor       = Title.Cost;
                            Zakazik.Decor           = Title.Product;
                            break;
                        case 1:
                            Zakazik.CostDecor       = Mastic.Cost;
                            Zakazik.Decor           = Mastic.Product;
                            break;
                        case 2:
                            Zakazik.CostDecor       = Chocolate_f.Cost;
                            Zakazik.Decor           = Chocolate_f.Product;
                            break;
                    }
                    txtDecor                        = $"{Zakazik.Decor} - {Zakazik.CostDecor} ";
                    break;
            }
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
            File.AppendAllText(path + "\\Чек.txt",$"Заказ от {time}\n\t{txt}\n\tОбщая сумма: {cost}\n");
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
                Order.Menu();
            }
        }
    }
}