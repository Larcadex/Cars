using System;

namespace cars
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


            double a = 0;
            int b = 0;
            byte c = 0;
            while (true)
            {
                if (bus.check_collision(truck) <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nМашины столкнулись!");
                    Console.WriteLine("\nПрограмма завершена.");
                    return;
                }

                double cars_distance = Math.Abs(bus.get_x() - truck.get_x());

                Console.WriteLine($"\nРасстояние между машинами: {cars_distance:F2} км\n");


                Console.WriteLine("\nВыберите машину:");
                Console.WriteLine("1. Автобус");
                Console.WriteLine("2. Грузовик");

                ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);

                switch (keyInfo1.Key)
                {
                    case ConsoleKey.D1:
                        menu_bus(bus, a, b, c);
                        break;
                    case ConsoleKey.D2:
                        menu_truck(truck, a, b);
                        break;
                }
            }
            
            
        }

        static void menu_bus(Bus bus, double a, int b, byte c)
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
                        a = double.Parse(Console.ReadLine());
                        Console.Clear();
                        int direction = 1;
                        bus.move(a, direction);
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.Write("\nВВведите скорость для ускорения: ");
                         b = int.Parse(Console.ReadLine());
                        Console.Clear();
                        bus.razgon(b);
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.Write("\nВВведите скорость для замедления: ");
                        b = int.Parse(Console.ReadLine());
                        Console.Clear();
                        bus.stop(b);
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("\nАвтомобиль остановлен.");
                        bus.ostanovka();
                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.Write("\nВВведите количество бензина для дозаправки: ");
                        a = double.Parse(Console.ReadLine());
                        Console.Clear();
                        bus.zapravka(a);
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
                        c = byte.Parse(Console.ReadLine());
                        Console.Clear();
                        bus.add_passanger(c);
                        break;
                    
                    case ConsoleKey.R:
                        Console.Clear();
                        Console.Write("\nВВведите количество пассажиров: ");
                        c = byte.Parse(Console.ReadLine());
                        Console.Clear();
                        bus.remove_passanger(c);
                        break;
                }
                
            
        }
        
        static void menu_truck(Truck truck, double a, int b)
        {
            Console.Clear();
            truck.Out();
            
            Console.WriteLine("\n\nВыберите действие:");
                Console.WriteLine("1 - Поехать");
                Console.WriteLine("2 - Увеличить скорость");
                Console.WriteLine("3 - Уменьшить скорость");
                Console.WriteLine("4 - Остановка");
                Console.WriteLine("5 - Заправить автомобиль");
                Console.WriteLine("Q - Добавить груз");
                Console.WriteLine("R - Выгрузить груз");
                Console.WriteLine("6 - Выход");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.Write("\nВведите желаемое расстояние: ");
                        a = double.Parse(Console.ReadLine());
                        Console.Clear();
                        int direction = -1;
                        truck.move(a, direction);
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.Write("\nВВведите скорость для ускорения: ");
                        b = int.Parse(Console.ReadLine());
                        Console.Clear();
                        truck.razgon(b);
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.Write("\nВВведите скорость для замедления: ");
                        b = int.Parse(Console.ReadLine());
                        Console.Clear();
                        truck.stop(b);
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("\nАвтомобиль остановлен.");
                        truck.ostanovka();
                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.Write("\nВВведите количество бензина для дозаправки: ");
                        a = double.Parse(Console.ReadLine());
                        Console.Clear();
                        truck.zapravka(a);
                        break;

                    case ConsoleKey.D6:
                        Console.Clear();
                        Console.WriteLine("\nВПрограмма завершена.");
                        return;
                    
                    case ConsoleKey.Q:
                        Console.Clear();
                        Console.Write("\nВВведите вес груза: ");
                        a = double.Parse(Console.ReadLine());
                        Console.Clear();
                        truck.add_weight(a);
                        break;
                    
                    case ConsoleKey.R:
                        Console.Clear();
                        Console.Write("\nВВведите вес груза: ");
                        a = double.Parse(Console.ReadLine());
                        Console.Clear();
                        truck.remove_weight(a);
                        break;
                    
                    default:
                        Console.Clear();
                        Console.WriteLine("\nВНеверный выбор. Повторите попытку.");
                        break;
                }
            
        }
        
    }
}