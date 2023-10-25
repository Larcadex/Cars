using System;

namespace bebra
{
    class auto
    {
        protected string nom;
        protected double bak;
        protected double ras;
        protected int speed;
        protected double probeg;
        protected double x;

        public auto(string initialNom, double initialFuel, double initialRas, int initialSpeed, double initiialProbeg, double initialx)
        {
            this.bak = initialFuel;
            this.speed = initialSpeed;
            this.nom = initialNom;
            this.ras = initialRas;
            this.probeg = initiialProbeg;
            this.x = initialx;
        }

        public void Info(string nom, double bak, double ras, int speed, double probeg, double x)
        {
            this.nom = nom;
            this.bak = bak;
            this.ras = ras;
            this.speed = speed;
            this.probeg = probeg;
            this.x = x;
        }

        public string GetNom()
        {
            return nom;
        }

        public double GetX()
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

        public void Zapravka(double top)
        {
            bak += top;
            Console.WriteLine($"\nБак заправлен, в баке находится: {bak}");
        }

        public void Move(double distance, int direction)
        {
            double kmNalitr = 100 / ras;
            double rashod = Math.Abs(distance) * (ras / 100);

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
                    Console.WriteLine($"\nПроехано {Math.Abs(distance):F2} км со скоростью {speed}. Остаток топлива: {bak:F2}\nОбщий пробег: {probeg:F2}");
                }
                else
                {
                    double distance1 = bak * kmNalitr;
                    probeg += distance1;
                    bak = 0;
                    x += direction * distance1;
                    Console.WriteLine($"\nПроехано {distance1:F2} км со скоростью {speed}. Топливо закончилось. Автомобиль остановлен\nОбщий пробег: {probeg:F2}");
                    speed = 0;
                }
            }
        }

        public void Ostanovka()
        {
            speed = 0;
        }

        public void Razgon(int sum_speed)
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

        public void Tormoz(int sum_speed1)
        {
            speed -= sum_speed1;
            ras -= 0.1;
            Console.WriteLine($"\nАвтомобиль замедляется до скорости {speed} км/ч. Расход топлива уменьшен.");
        }

        public double CheckCollision(auto otherCar)
        {
            double distanceBetweenCars = otherCar.x - x;
            return distanceBetweenCars;
        }

    }
}
