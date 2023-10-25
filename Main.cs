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
            Bus bus = new Bus("Автобус", 50, 8, 50, 0, 0, 0);
            Truck truck = new Truck("Грузовик", 50, 8, 50, 0, coordinateLineSize, 0);
            while (true)
            {
                if (bus.CheckCollision(truck) <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nМашины столкнулись!");
                    Console.WriteLine("\nПрограмма завершена.");
                    return;
                }

                double distanceBetweenCars = Math.Abs(bus.GetX() - truck.GetX());

                Console.WriteLine($"\nРасстояние между машинами: {distanceBetweenCars:F2} км\n");


                Console.WriteLine("\nВыберите машину:");
                Console.WriteLine("1. Автобус");
                Console.WriteLine("2. Грузовик");

                ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);

                switch (keyInfo1.Key)
                {
                    case ConsoleKey.D1:
                        menu_bus(bus);
                        break;
                    case ConsoleKey.D2:
                        menu_truck(truck);
                        break;
                }
            }
            
            
        }

        static void menu_bus(Bus bus)
        {
            Console.Clear();
            bus.Out();
            
            Console.WriteLine("\n\nВыберите действие:");
                Console.WriteLine("1 - Поехать");
                Console.WriteLine("2 - Увеличить скорость");
                Console.WriteLine("3 - Уменьшить скорость");
                Console.WriteLine("4 - Остановка");
                Console.WriteLine("5 - Заправить автомобиль");
                Console.WriteLine("6 - Вывести информацию");
                Console.WriteLine("Q - Добавить пассажиров");
                Console.WriteLine("R - Высадить пассажиров");
                Console.WriteLine("7 - Выход");
                

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.Write("\nВведите желаемое расстояние: ");
                        double distance = double.Parse(Console.ReadLine());
                        Console.Clear();
                        int direction = 1;
                        bus.Move(distance, direction);
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.Write("\nВВведите скорость для ускорения: ");
                        int sum_speed = int.Parse(Console.ReadLine());
                        Console.Clear();
                        bus.Razgon(sum_speed);
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.Write("\nВВведите скорость для замедления: ");
                        int sum_speed1 = int.Parse(Console.ReadLine());
                        Console.Clear();
                        bus.Tormoz(sum_speed1);
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("\nАвтомобиль остановлен.");
                        bus.Ostanovka();
                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.Write("\nВВведите количество бензина для дозаправки: ");
                        double top = double.Parse(Console.ReadLine());
                        Console.Clear();
                        bus.Zapravka(top);
                        break;

                    case ConsoleKey.D6:
                        Console.Clear();
                        bus.Out();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\nВНеверный выбор. Повторите попытку.");
                        break;

                    case ConsoleKey.D7:
                        Console.Clear();
                        Console.WriteLine("\nВПрограмма завершена.");
                        return;
                    
                    case ConsoleKey.Q:
                        Console.Clear();
                        Console.Write("\nВВведите количество пассажиров: ");
                        int pass = int.Parse(Console.ReadLine());
                        Console.Clear();
                        bus.AddPassengers(pass);
                        break;
                    
                    case ConsoleKey.R:
                        Console.Clear();
                        Console.Write("\nВВведите количество пассажиров: ");
                        int pass1 = int.Parse(Console.ReadLine());
                        Console.Clear();
                        bus.RemovePassengers(pass1);
                        break;
                }
                
            
        }
        
        static void menu_truck(Truck truck)
        {
            Console.Clear();
            truck.Out();
            
            Console.WriteLine("\n\nВыберите действие:");
                Console.WriteLine("1 - Поехать");
                Console.WriteLine("2 - Увеличить скорость");
                Console.WriteLine("3 - Уменьшить скорость");
                Console.WriteLine("4 - Остановка");
                Console.WriteLine("5 - Заправить автомобиль");
                Console.WriteLine("6 - Вывести информацию");
                Console.WriteLine("Q - Добавить груз");
                Console.WriteLine("R - Выгрузить груз");
                Console.WriteLine("7 - Выход");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.Write("\nВведите желаемое расстояние: ");
                        double distance = double.Parse(Console.ReadLine());
                        Console.Clear();
                        int direction = -1;
                        truck.Move(distance, direction);
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.Write("\nВВведите скорость для ускорения: ");
                        int sum_speed = int.Parse(Console.ReadLine());
                        Console.Clear();
                        truck.Razgon(sum_speed);
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.Write("\nВВведите скорость для замедления: ");
                        int sum_speed1 = int.Parse(Console.ReadLine());
                        Console.Clear();
                        truck.Tormoz(sum_speed1);
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("\nАвтомобиль остановлен.");
                        truck.Ostanovka();
                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.Write("\nВВведите количество бензина для дозаправки: ");
                        double top = double.Parse(Console.ReadLine());
                        Console.Clear();
                        truck.Zapravka(top);
                        break;

                    case ConsoleKey.D6:
                        Console.Clear();
                        truck.Out();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\nВНеверный выбор. Повторите попытку.");
                        break;

                    case ConsoleKey.D7:
                        Console.Clear();
                        Console.WriteLine("\nВПрограмма завершена.");
                        return;
                    
                    case ConsoleKey.Q:
                        Console.Clear();
                        Console.Write("\nВВведите вес груза: ");
                        int cargo = int.Parse(Console.ReadLine());
                        Console.Clear();
                        truck.AddCargo(cargo);
                        break;
                    
                    case ConsoleKey.R:
                        Console.Clear();
                        Console.Write("\nВВведите вес груза: ");
                        int cargo1 = int.Parse(Console.ReadLine());
                        Console.Clear();
                        truck.RemoveCargo(cargo1);
                        break;
                }
            
        }
        
    }
}