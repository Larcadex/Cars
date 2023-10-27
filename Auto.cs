using System;

namespace cars
{
    class auto
    {
        protected string nom;
        protected double bak;
        protected double ras;
        protected int speed;
        protected double probeg;
        protected double x;
        

        public auto(string nom, double bak, double ras, int speed, double probeg, double x)
        {
            this.bak = bak;
            this.speed = speed;
            this.nom = nom;
            this.ras = ras;
            this.probeg = probeg;
            this.x = x;
        }
        public double check_collision(auto other_car)
        {
            return other_car.x - x;
        }
        
        public double get_x()
        {
            return x;
        }

        public virtual void Out()
        {
            Console.WriteLine($"Номер авто: {nom}");
            Console.WriteLine($"Количество бензина в баке: {bak} л");
            Console.WriteLine($"Расход топлива на 100 км: {ras:F2} л/100км");
            Console.WriteLine($"Текущая скорость: {speed:F2} км/ч");
            Console.WriteLine($"Пробег: {probeg:F2} км");
        }

        protected void zapravka(double top)
        {
            bak += top;
            Console.WriteLine($"\nБак заправлен, в баке находится: {bak}");
        }

        protected void move(double distance, int direction)
        {
            double km_on_lit = 100 / ras;
            double rashod = Math.Abs(distance) * (ras / 100);
            double time = 0;

            if (speed == 0)
            {
                Console.WriteLine("\nНедостаточно скорости для поездки.");
            }
            else
            {
                if (bak >= rashod)
                {
                    bak -= rashod;
                    probeg += Math.Abs(distance);
                    x += direction * Math.Abs(distance);
                    time = Math.Abs(distance) / speed;
                    Console.WriteLine($"\nПроехано {Math.Abs(distance):F2} км со скоростью {speed} за {time:F2} ч. Остаток топлива: {bak:F2}\nОбщий пробег: {probeg:F2}");
                }
                else
                {
                    double distance1 = bak * km_on_lit;
                    probeg += distance1;
                    bak = 0;
                    x += direction * distance1;
                    time = Math.Abs(distance1) / speed;
                    Console.WriteLine($"\nПроехано {distance1:F2} км со скоростью {speed} за {time:F2} ч. Топливо закончилось. Автомобиль остановлен\nОбщий пробег: {probeg:F2}");
                    Console.Write("Желаете дозаправить машину?:\n1. Да\n2. Нет ");
                    
                    ConsoleKeyInfo keyInfo3 = Console.ReadKey(true);
                    
                    if (keyInfo3.Key == ConsoleKey.D1)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите количество топлива для дозаправки: ");
                        double topUpAmount = double.Parse(Console.ReadLine());
                        zapravka(topUpAmount);
                        Console.Clear();
                        Console.WriteLine($"Машина дозаправлена на {topUpAmount:F2} л.");
                        move(distance - distance1, direction);
                    }
                }
            }
        }

        protected void ostanovka()
        {
            speed = 0;
        }

        protected void razgon(int sum_speed)
        {
            if (bak >= 1.0)
            {
                speed += sum_speed;
                ras += 0.1;
                Console.WriteLine($"\nАвтомобиль разгоняется до скорости {speed} км/ч. Расход топлива увеличен.");
            }
            else
            {
                Console.WriteLine("\nНедостаточно топлива для разгона.");
            }
        }

        protected void stop(int sum_speed)
        {
            speed -= sum_speed;
            ras -= 0.1;
            Console.WriteLine($"\nАвтомобиль замедляется до скорости {speed} км/ч. Расход топлива уменьшен.");
        }

    }
}
