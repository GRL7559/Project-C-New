using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Practic5
{
    internal class Order
    {
        public string Shape { get; set; }
        public string Size { get; set; }
        public string Taste { get; set; }
        public string Quantity { get; set; }
        public string Glaze { get; set; }
        public string Decor { get; set; }
        public int CostShape { get; set; }
        public int CostSize { get; set; }
        public int CostTaste { get; set; }
        public int CostQuantity { get; set; }
        public int CostGlaze { get; set; }
        public int CostDecor { get; set; }
        public Order(string shape, string size, string taste, string quantity, string glaze, string decor, int costshape, int costsize, int costtaste, int costquantity, int costglaze, int costdecor)
        {
            Shape = shape;
            Size = size;
            Taste = taste;
            Quantity = quantity;
            Glaze = glaze;
            Decor = decor;
            CostShape = costshape;
            CostSize = costsize;
            CostTaste = costtaste;
            CostQuantity = costquantity;
            CostGlaze = costglaze;
            CostDecor = costdecor;
        }
        public static void Menu()
        {
            Tortiki.cost = Tortiki.Zakazik.CostShape + Tortiki.Zakazik.CostSize + Tortiki.Zakazik.CostTaste + Tortiki.Zakazik.CostQuantity + Tortiki.Zakazik.CostGlaze + Tortiki.Zakazik.CostDecor;
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
            Console.WriteLine($"\nТекущая комплектация торта: {Tortiki.Zakazik.Shape} {Tortiki.Zakazik.Size} {Tortiki.Zakazik.Taste} {Tortiki.Zakazik.Quantity} {Tortiki.Zakazik.Glaze} {Tortiki.Zakazik.Decor}");
            Console.WriteLine($"Цена: {Tortiki.cost}");
            Arrows.Arrow(8, 2, 1);
        }
        private static void ChoiseParticulars(int parametrs)
        {
            switch (parametrs)
            {
                case 0:
                    Console.WriteLine($"  {Tortiki.Circle.Product} - {Tortiki.Circle.Cost}");
                    Console.WriteLine($"  {Tortiki.Square.Product} - {Tortiki.Square.Cost}");
                    Console.WriteLine($"  {Tortiki.Heart.Product} - {Tortiki.Heart.Cost}");
                    break;
                case 1:
                    Console.WriteLine($"  {Tortiki.Small.Product} - {Tortiki.Small.Cost}");
                    Console.WriteLine($"  {Tortiki.Middle.Product} - {Tortiki.Middle.Cost}");
                    Console.WriteLine($"  {Tortiki.Huge.Product} - {Tortiki.Huge.Cost}");
                    break;
                case 2:
                    Console.WriteLine($"  {Tortiki.Chocolate.Product} - {Tortiki.Chocolate.Cost}");
                    Console.WriteLine($"  {Tortiki.Strawberry.Product} - {Tortiki.Strawberry.Cost}");
                    Console.WriteLine($"  {Tortiki.Mango_guava.Product} - {Tortiki.Mango_guava.Cost}");
                    break;
                case 3:
                    Console.WriteLine($"  {Tortiki.Halfkg.Product} - {Tortiki.Halfkg.Cost}");
                    Console.WriteLine($"  {Tortiki.Kg.Product} - {Tortiki.Kg.Cost}");
                    Console.WriteLine($"  {Tortiki.Kgg.Product} - {Tortiki.Kgg.Cost}");
                    break;
                case 4:
                    Console.WriteLine($"  {Tortiki.Chocolate_g.Product} - {Tortiki.Chocolate_g.Cost}");
                    Console.WriteLine($"  {Tortiki.White_chocolate.Product} - {Tortiki.White_chocolate.Cost}");
                    Console.WriteLine($"  {Tortiki.Caramel.Product} - {Tortiki.Caramel.Cost}");
                    break;
                case 5:
                    Console.WriteLine($"  {Tortiki.Title.Product} - {Tortiki.Title.Product}");
                    Console.WriteLine($"  {Tortiki.Mastic.Product} - {Tortiki.Mastic.Product}");
                    Console.WriteLine($"  {Tortiki.Chocolate_f.Product} - {Tortiki.Chocolate_f.Product}");
                    break;
            }
        }
        public static void Particulars(int parametrs)
        {
            Console.Clear();
            Console.WriteLine("Выбирете параметр торта");
            Console.WriteLine("-----------------------");
            ChoiseParticulars(parametrs);
            Arrows.Arrow(4, 2, 2);
        }
    }
}