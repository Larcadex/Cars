using System;
namespace bebra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество бензина для начальной заправки бака: ");
            float zalit = float.Parse(Console.ReadLine());
            Console.Write("Введите начальную скорость для поездки: ");
            int speed = int.Parse(Console.ReadLine());
            auto myCar = new auto(zalit, speed);
            myCar.Info("ABC123", zalit, 8.5f, speed, 0);

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Поехать");
                Console.WriteLine("2 - Увеличить скорость");
                Console.WriteLine("3 - Уменьшить скорость");
                Console.WriteLine("4 - Остановка");
                Console.WriteLine("5 - Заправить автомобиль");
                Console.WriteLine("6 - Вывести информацию");
                Console.WriteLine("7 - Выход\n");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        myCar.Move(speed);
                        break;

                    case ConsoleKey.D2:
                        Console.Write("Введите скорость для ускорения: ");
                        int sum_speed = int.Parse(Console.ReadLine());
                        myCar.Razgon(sum_speed);
                        break;

                    case ConsoleKey.D3:
                        Console.Write("Введите скорость для замедления: ");
                        int sum_speed1 = int.Parse(Console.ReadLine());
                        myCar.Tormoz(sum_speed1);
                        break;

                    case ConsoleKey.D4:

                        myCar.Ostanovka();
                        break;

                    case ConsoleKey.D5:
                        Console.Write("Введите количество бензина для дозаправки: ");
                        double top = double.Parse(Console.ReadLine());
                        myCar.Zapravka(top);
                        break;

                    case ConsoleKey.D6:
                        myCar.Out();
                        break;

                    case ConsoleKey.D7:
                        Console.WriteLine("Программа завершена.");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Повторите попытку.");
                        break;
                }
            }
        }
    }
}