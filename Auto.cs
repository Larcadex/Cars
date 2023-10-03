using System;
namespace bebra
{
    class auto
    {
        private string nom;
        private double bak;
        private double ras;
        private double ost;
        private int speed;
        private double probeg;

        public auto(double initialFuel, int initialSpeed)
        {
            this.bak = initialFuel;
            this.speed = initialSpeed;
        }

        public void Info(string nom, double bak, double ras, int speed, double probeg)
        {
            this.nom = nom;
            this.bak = bak;
            this.ras = ras;
            this.ost = bak;
            this.speed = speed;
            this.probeg = probeg;
        }

        public void Out()
        {
            Console.WriteLine($"Номер авто: {nom}");
            Console.WriteLine($"Количество бензина в баке: {ost} л");
            Console.WriteLine($"Расход топлива на 100 км: {ras:F2} л/100км");
            Console.WriteLine($"Текущая скорость: {speed:F2} км/ч");
            Console.WriteLine($"Пробег: {probeg:F2} км");
        }

        public void Zapravka(double top)
        {
            ost += top;
            Console.WriteLine($"Бак заправлен, в баке находится: {ost}");
        }


        public void Move(int speed)
        {
            if (speed <= 0)
            {
                Console.WriteLine("Скорость должна быть больше нуля.");
                return;
            }

            Console.Write("Введите расстояние: ");
            double distance = double.Parse(Console.ReadLine());


            double kmNalitr = 100/ ras;
            double rashod = distance * (ras / 100);



            if (ost >= rashod && ost != 0 && speed != 0)
            {
                ost -= rashod;
                probeg += distance;
                Console.WriteLine($"Проехано {distance:F2} км со скоростью {this.speed}. Остаток топлива: {ost:F2}\nОбщий пробег: {probeg:F2}");
                this.speed = speed;
                
            }
            else if (ost <= rashod && ost != 0 && speed != 0)
            {
                double distance1;
                distance1 = ost * kmNalitr;
                probeg += distance1;
                ost = 0;
                Console.WriteLine($"Проехано {distance1:F2} км со скоростью {this.speed}. Топливо закончилось.\nОбщий пробег: {probeg:F2}");
                this.speed = 0;
            }
            else if (ost == 0)
            {
                Console.WriteLine("Недостаточно топлива для поездки.");
            }
            else if (speed == 0)
            {
                Console.WriteLine("Недостаточно скорости для поездки.");
            }
        }

        private double Ostatok()
        {
            return ost;
        }

        public void Ostanovka()
        {
            Console.WriteLine("Автомобиль остановлен.");
            speed = 0; 
        }

        public void Razgon(int sum_speed)
        {
            if (ost >= 1.0)
            {
                speed += sum_speed;
                ras += 0.1;
                ost -= 1.0;
                Console.WriteLine($"Автомобиль разгоняется до скорости {speed} км/ч. Расход топлива увеличен.");
            }
            else
            {
                Console.WriteLine("Недостаточно топлива для разгона.");
            }
        }
        public void Tormoz(int sum_speed1)
        {
            speed -= sum_speed1; 
            ras -= 0.1;
            ost += 1.0;
            Console.WriteLine($"Автомобиль замедляется до скорости {speed} км/ч. Расход топлива уменьшен.");
        }
    }
}