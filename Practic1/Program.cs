bool stop = true;
while (stop == true)
{
    Console.WriteLine("Введите наименование операции из приведенного ниже списка,которую вы хотите выполнить \n (Ввод производится с учётом регистра) \n Сложение  \n Вычитание \n Умножение \n Деление \n Степень \n Квадратный корень \n Процент \n Факториал \n Завершить работу ");
    string a = Console.ReadLine();
    switch (a)
    {
        case "Сложение":
            bool test = true;
            while (test == true)
            {
                try
                {
                    double Sum1;
                    double Sum2;
                    Console.WriteLine("Введите первое слагаемое");
                    Sum1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите второе слагаемое");
                    Sum2 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Результат: ");
                    Console.WriteLine(Sum1 + Sum2);
                }
                catch
                {
                    Console.WriteLine("Введите целое или вещественное число ");
                    continue;
                }
                test = false;
            }
            break;
        case "Вычитание":
            bool test1 = true;
            while (test1 == true)
            {
                try
                {
                    double Sub1;
                    double Sub2;
                    Console.WriteLine("Введите уменьшаемое");
                    Sub1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите второе вычитаемое");
                    Sub2 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Результат: ");
                    Console.WriteLine(Sub1 - Sub2);
                }
                catch
                {
                    Console.WriteLine("Введите целое или вещественное число ");
                    continue;
                }
                test1 = false;
            }
            break;
        case "Умножение":
            bool test2 = true;
            while (test2 == true)
            {
                try
                {
                    double Mul1;
                    double Mul2;
                    Console.WriteLine("Введите первый множитель");
                    Mul1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите второй множитель");
                    Mul2 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Результат: ");
                    Console.WriteLine(Mul1 * Mul2);
                }
                catch
                {
                    Console.WriteLine("Введите целое или вещественное число ");
                    continue;
                }
                test2 = false;
            }
            break;
        case "Деление":
            bool test3 = true;
            while (test3 == true)
            {
                try
                {
                    double Div1;
                    double Div2;
                    Console.WriteLine("Введите делимое");
                    Div1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите делитель");
                    Div2 = Convert.ToDouble(Console.ReadLine());
                    if (Div2 == 0)
                    {
                        Console.WriteLine("Деление на 0 недопустимо");
                        continue;
                    }
                    else
                    {
                        Console.Write("Результат: ");
                        Console.WriteLine(Div1 / Div2);
                    }
                }
                catch
                {
                    Console.WriteLine("Введите целое или вещественное число ");
                    continue;
                }
                test3 = false;
            }
            break;
        case "Степень":
            bool test4 = true;
            while (test4 == true)
            {
                try
                {
                    double NumD;
                    int Deg;
                    Console.WriteLine("Введите число , которое нужно возвести в степень ");
                    NumD = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите степень числа");
                    Deg = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Результат: ");
                    Console.WriteLine(Math.Pow(NumD, Deg));
                }
                catch
                {
                    Console.WriteLine("Введите целое или вещественное число / целый показатель степени ");
                    continue;
                }
                test4 = false;
            }
            break;
        case "Квадратный корень":
            bool test5 = true;
            while (test5 == true)
            {
                try
                {
                    double NumR;
                    Console.WriteLine("Введите число , корень которого нужно вычислить ");
                    NumR = Convert.ToDouble(Console.ReadLine());
                    if (NumR < 0)
                    {
                        Console.WriteLine("Подкоренное выражение не может быть меньше 0");
                    }
                    else
                    {
                        Console.Write("Результат: ");
                        Console.WriteLine(Math.Sqrt(NumR));
                    }
                }
                catch
                {
                    Console.WriteLine("Введите целое или вещественное число ");
                    continue;
                }
                test5 = false;
            }
            break;
        case "Процент":
            bool test6 = true;
            while (test6 == true)
            {
                try
                {
                    double NumP;
                    double Per;
                    Console.WriteLine("Введите число , процент которого нужно вычислить ");
                    NumP = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите количство процентов ");
                    Per = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Результат: ");
                    Console.WriteLine((NumP / 100) * Per);
                }
                catch
                {
                    Console.WriteLine("Введите целое или вещественное число ");
                    continue;
                }
                test6 = false;
            }
            break;
        case "Факториал":
            bool test7 = true;
            while (test7 == true)
            {
                try
                {
                    int NumF;
                    Console.WriteLine("Введите число , факториал которого нужно вычислить ");
                    NumF = Convert.ToInt32(Console.ReadLine());
                    if (NumF < 0)
                    {
                        Console.WriteLine("Факториала отрицательного числа не существует");
                        continue;
                    }
                    else
                    {
                        int Factorial = 1;
                        for (int i = 1; i < NumF + 1; i++)
                        {
                            Factorial = Factorial * i;
                        }
                        Console.Write("Результат: ");
                        Console.WriteLine(Factorial);
                    }
                }
                catch
                {
                    Console.WriteLine("Введите целое число ");
                    continue;
                }
                test7 = false;
            }
            break;
        case "Завершить работу":
            stop = false;
            break;
        default:
            Console.WriteLine("Вы ввели некорректное значение");
            break;
    }
}