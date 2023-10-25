using System;

namespace bebra
{
    class Bus : auto
    {
        private int passenger;

        public Bus(string initialNom, double initialFuel, double initialRas, int initialSpeed, double initiialProbeg, 
            double initialx, int initialPassenger) : 
            base(initialNom, initialFuel, initialRas, initialSpeed, initiialProbeg, initialx)
        {
            this.passenger = initialPassenger;
        }
        
        public override void Out()
        {
            base.Out();
            Console.WriteLine($"Пассажиров в автобусе: {passenger} чел.");
        }
        
        public void AddPassengers(int numberPassengers)
        {
            if (numberPassengers > 0)
            {
                if (passenger + numberPassengers <= 50)
                {
                    passenger += numberPassengers;
                    UpdateParameters();
                    Console.WriteLine($"Добавлено {numberPassengers} пассажиров. Всего пассажиров: {passenger} чел.");
                }
                else
                {
                    Console.WriteLine("Превышено максимальное количество пассажиров (50 чел.).");
                }
            }
            else
            {
                Console.WriteLine("Количество пассажиров должно быть положительным числом.");
            }
        }

        public void RemovePassengers(int numberPassengers)
        {
            if (numberPassengers > 0 && numberPassengers <= passenger)
            {
                passenger -= numberPassengers;
                UpdateParameters();
                Console.WriteLine($"Высажено {numberPassengers} пассажиров. Всего пассажиров: {passenger} чел.");
            }
            else
            {
                Console.WriteLine("Количество пассажиров для высадки должно быть положительным числом и не превышать текущее количество пассажиров.");
            }
        }

        private void UpdateParameters()
        {
            speed -= (int)(speed * 0.01 * passenger);

            ras += 0.1 * passenger;
        }
    }
}