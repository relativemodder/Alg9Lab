using System;

namespace AlgLab9
{
    class OutOfMathRangeException : Exception
    {

    }
    internal class Program
    {
        public static double calculateFbyX(double x)
        {
            if (x < -2 || x > 4)
            {
                throw new OutOfMathRangeException();
            }

            if (x == 1)
            {
                throw new DivideByZeroException();
            }

            return Math.Log10(1 / (x - 1));
        }

        static void Main(string[] args)
        {
            Console.Write("n1=");
            int arrayALength = Convert.ToInt32(Console.ReadLine());

            Console.Write("n2=");
            int arrayBLength = Convert.ToInt32(Console.ReadLine());

            Console.Write("n3=");
            int arrayCLength = Convert.ToInt32(Console.ReadLine());


            if (arrayALength == arrayBLength 
                || arrayBLength == arrayCLength
                || arrayALength == arrayCLength)
            {
                Console.WriteLine("Должно быть n1 != n2 != n3!!!");
                return;
            }


            double[] arrayA = new double[arrayALength];
            double[] arrayB = new double[arrayBLength];
            double[] arrayC = new double[arrayCLength];

            Console.WriteLine("Начало ввода данных в массив A");

            for (int i = 0; i < arrayALength; i++)
            {
                Console.Write($"Введите значение x (индекс {i}): ");
                double x = Convert.ToDouble(Console.ReadLine());

                double resultFbyX = 0;

                try
                {
                    resultFbyX = calculateFbyX(x);
                }
                catch (Exception e) // I'm too lazy
                {
                    Console.WriteLine($"Иключение {e.ToString()}");
                    Console.WriteLine("\nВставляю 0.");
                    // nothing, leaves 0 as result
                }

                Console.WriteLine($"Результат f(x)={resultFbyX}");

                arrayA[i] = resultFbyX;
            }

            Console.WriteLine("Начало авто-ввода данных в массив B");

            Random rng = new Random();

            for (int i = 0; i < arrayBLength; i++)
            {
                double randomValue = rng.NextDouble() * rng.Next(-6, 6);

                Console.WriteLine("Случайное значение x " +
                    $"(индекс {i}): {randomValue}");

                arrayB[i] = randomValue;

                Thread.Sleep(300);
            }


            Console.WriteLine("Начало авто-ввода данных в массив C");

            for (int i = 0; i < arrayCLength; i++)
            {
                double resultValue;
                try
                {
                    double a_ith = arrayA[i];
                    double b_ith = arrayA[i - 1];

                    resultValue = Math.Sqrt(a_ith - b_ith);

                    Console.WriteLine($"Вычисленное значение ({i}) = {resultValue}");

                }
                catch(Exception e) {
                    Console.WriteLine($"Возникло исключение: {e.ToString()}");
                    Console.WriteLine("\n\nТогда вставляю 0.");

                    resultValue = 0d;
                }

                arrayC[i] = resultValue;

                Thread.Sleep(300);
            }

            Console.WriteLine("Итоговый результат:");

            Console.WriteLine($"A=[{string.Join(", ", arrayA)}]");
            Console.WriteLine($"B=[{string.Join(", ", arrayB)}]");
            Console.WriteLine($"C=[{string.Join(", ", arrayC)}]");

            Console.ReadLine();
        }
    }
}