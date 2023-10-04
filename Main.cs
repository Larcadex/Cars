using System;

namespace bebra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер координатной прямой: ");
            double coordinateLineSize = double.Parse(Console.ReadLine());
            Console.Clear();
            auto[] myCar = new auto[2];
            myCar[0] = new auto("Машина - 1", 50, 8, 50, 0, 0);
            myCar[1] = new auto("Машина - 2", 50, 8, 50, 0, coordinateLineSize);

            while (true)
            {
                if (myCar[0].CheckCollision(myCar[1]) <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nМашины столкнулись!");
                    Console.WriteLine("\nПрограмма завершена.");
                    return;
                }

                double distanceBetweenCars = Math.Abs(myCar[0].GetX() - myCar[1].GetX());

                Console.WriteLine($"\nРасстояние между машинами: {distanceBetweenCars:F2} км\n");

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine($"Информация о {myCar[i].GetNom()}:");
                    myCar[i].Out();
                    Console.WriteLine();
                }

                int selectedCar = 0;

                Console.WriteLine("\nВыберите машину:");
                Console.WriteLine("1. Машина - 1");
                Console.WriteLine("2. Машина - 2");

                ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);

                switch (keyInfo1.Key)
                {
                    case ConsoleKey.D1:
                        selectedCar = 0;
                        break;
                    case ConsoleKey.D2:
                        selectedCar = 1;
                        break;
                }

                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Поехать");
                Console.WriteLine("2 - Увеличить скорость");
                Console.WriteLine("3 - Уменьшить скорость");
                Console.WriteLine("4 - Остановка");
                Console.WriteLine("5 - Заправить автомобиль");
                Console.WriteLine("6 - Вывести информацию");
                Console.WriteLine("7 - Выход");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.Write("\nВведите желаемое расстояние: ");
                        double distance = double.Parse(Console.ReadLine());
                        Console.Clear();
                        int direction = (selectedCar == 1) ? -1 : 1;
                        myCar[selectedCar].Move(distance, direction);
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.Write("\nВВведите скорость для ускорения: ");
                        int sum_speed = int.Parse(Console.ReadLine());
                        Console.Clear();
                        myCar[selectedCar].Razgon(sum_speed);
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.Write("\nВВведите скорость для замедления: ");
                        int sum_speed1 = int.Parse(Console.ReadLine());
                        Console.Clear();
                        myCar[selectedCar].Tormoz(sum_speed1);
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("\nАвтомобиль остановлен.");
                        myCar[selectedCar].Ostanovka();
                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.Write("\nВВведите количество бензина для дозаправки: ");
                        double top = double.Parse(Console.ReadLine());
                        Console.Clear();
                        myCar[selectedCar].Zapravka(top);
                        break;

                    case ConsoleKey.D6:
                        Console.Clear();
                        myCar[selectedCar].Out();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\nВНеверный выбор. Повторите попытку.");
                        break;

                    case ConsoleKey.D7:
                        Console.Clear();
                        Console.WriteLine("\nВПрограмма завершена.");
                        return;
                }
            }
        }
    }
}