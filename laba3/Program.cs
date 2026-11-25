using System;
using System.Diagnostics;
using System.Globalization;

namespace Lab3_OP
{
    class Program
    {
        static double ProverkaDouble()
        {
            while (true)
            {
                string b = Console.ReadLine();
                if (double.TryParse(b, out double a))
                {
                    return a;
                }
                Console.WriteLine("Введите корректное число: ");
            }

        }
        static int ProverkaInt()
        {
            while (true)
            {
                string b = Console.ReadLine();
                if (int.TryParse(b, out int a))
                {
                    return a;
                }
                Console.WriteLine("Введите корректное число: ");
            }

        }
        static double Calcfunc(double a, double b)
        {
            double f = Math.Round((Math.Pow(Math.Log(b), 2) / (Math.Cos(a) - 1)), 2);
            return f;
        }
        static void Counter(double f, double answer)
        {
            int c = 3;
            while (c != 0)
            {
                c -= 1;
                if (answer == f)
                {
                    Console.WriteLine("Вы угадали! =)"); c = 0;
                }
                else if (c == 0)
                {
                    Console.WriteLine("Попытки закончились(. Правильный ответ: {0}", f);
                }
                else
                {
                    Console.WriteLine("Ответ неверный =(. Попробуй еще раз (Количество попыток {0}): ", c);
                    answer = ProverkaDouble();

                }
            }
        }
        static void SecondOne()
        { Console.WriteLine("Абишева Диана Аделькановна \nГруппа 6106-090301D\n"); }
        static int LengthArray()
        {
            Console.Write("Введите длину массива: ");
            int l = ProverkaInt();
            while (l <= 0)
            {
                Console.Write("Введите длину массива больше 0: ");
                l = ProverkaInt();
            }
            return l;
        }
        static int[] FillArray(int length)
        {
            Random b = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = b.Next(-50, 51);
            }
            return array;

        }
        static void RevealArray(int[] array, int length)
        {
            if (length > 10)
            {
                Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10");
            }
            else
            {
                string a = "";
                for (int i = 0; i < length; i++)
                {
                    a += array[i].ToString();
                    a += " ";
                }
                Console.WriteLine(a);
            }
        }
        static int[] CopyArray(int[] array)
        {
            int[] copyarray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                copyarray[i] = array[i];
            }
            return copyarray;
        }
        static int[] BubbleSort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }
        static int[] MixingSort(int[] array)
        {
            int low = 0, up = array.Length - 1;
            int last, temp;
            bool isSwapped = true;
            while (isSwapped)
            {
                isSwapped = false;

                last = -1;
                for (int i = low; i < up; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        last = i;
                        isSwapped = true;
                    }
                }
                up = last;
                last = array.Length;
                isSwapped = false;

                for (int i = up - 1; i >= low; i--)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        last = i;
                        isSwapped = true;
                    }
                }
                low = last + 1;
            }
            return array;
        }
        static bool FourthOne(string exit)
        {
            while (true)
            {
                if (exit == "Д")
                {
                    Console.WriteLine("Goodbye");
                    return false;
                }
                else if (exit == "Н")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Выбери Д или Н");
                    exit = Console.ReadLine();
                }
            }
        }
        static void Main(string[] args)
        {
            int num;
            bool exitproga = true;
            while (exitproga)
            {
                Console.WriteLine("Привет! Выбери один из пунктов: \n 1. Отгадай ответ \n 2. Об авторе \n 3. Сортировка массива \n 4. Выход \n");
                num = ProverkaInt();
                switch (num)
                {
                    case 1:
                        const double PI = Math.PI;
                        double a;
                        Console.WriteLine("Введите число a:");
                        a = ProverkaDouble();
                        double b;
                        Console.WriteLine("Введите число b:");
                        b = ProverkaDouble();
                        while ((Math.Cos(a) - 1) == 0)
                        {
                            Console.WriteLine("При данном числе а будет происходить деление на ноль. Введите другое число а:\n");
                            a = ProverkaDouble();
                        }
                        while (b <= 0)
                        {
                            Console.WriteLine("При данном числе b нельзя получить ответ. Введите другое число b:\n");
                            b = ProverkaDouble();
                        }
                        Console.WriteLine("Угадай результат математической функции: (Ln(b))^2 / (Cos(a) - 1)\n");
                        a = a * PI / 180;
                        double answer = ProverkaDouble();
                        double f = Calcfunc(a, b);
                        Counter(f, answer);
                        break;
                    case 2:
                        SecondOne();
                        break;
                    case 3:
                        int len = LengthArray();
                        int[] array = FillArray(len);
                        Console.Write("Массив: ");
                        RevealArray(array, len);

                        int[] copy1 = CopyArray(array);
                        int[] copy2 = CopyArray(array);

                        Stopwatch sw = new Stopwatch();

                        sw.Restart();
                        copy1 = BubbleSort(copy1);
                        sw.Stop();
                        double bubbleMs = sw.Elapsed.TotalMilliseconds;

                        sw.Restart();
                        copy2 = MixingSort(copy2);
                        sw.Stop();
                        double mixingMs = sw.Elapsed.TotalMilliseconds;

                        Console.Write("Сортировка пузырьком: ");
                        RevealArray(copy1, len);
                        Console.WriteLine($"Затраченное время: {bubbleMs} мс");

                        Console.Write("Сортировка перемешиванием: ");
                        RevealArray(copy2, len);
                        Console.WriteLine($"Затраченное время: {mixingMs} мс");
                        break;
                    case 4:
                        Console.WriteLine("Выйти из программы: Д\nОстаться: Н");
                        string exit = Console.ReadLine();
                        exitproga = FourthOne(exit);
                        break;
                    default:
                        Console.WriteLine("Выбери один из предложенных пунктов!");
                        break;
                }
            }
        }
    }
}