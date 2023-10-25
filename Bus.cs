using System;

namespace cars
{
    class Bus : auto
    {
        private byte passenger;

        public Bus(string nom, double bak, double ras, int speed, double probeg, double x, byte passenger) : base(nom, bak, ras, speed, probeg, x)
        {
            this.passenger = passenger;
        }

        public override void Out()
        {
            base.Out();
            Console.WriteLine($"Пассажиров в автобусе: {passenger} чел.");
        }

        public void add_passanger(byte num_passenger)
        {
            if (passenger + num_passenger <= 50)
            {
                passenger += num_passenger;
                if (passenger < 10)
                {
                    speed -= 2;
                    ras += 0.2;
                }
                else if (passenger >= 10 && passenger < 20)
                {
                    speed -= 3;
                    ras += 0.3;
                }
                else if (passenger >= 20 && passenger < 30)
                {
                    speed -= 4;
                    ras += 0.4;
                }
                else if (passenger >= 30 && passenger < 40)
                {
                    speed -= 5;
                    ras += 0.5;
                }
                else if (passenger >= 40 && passenger <= 50)
                {
                    speed -= 6;
                    ras += 0.6;
                }
                Console.WriteLine($"Добавлено {num_passenger} пассажиров. Всего пассажиров: {passenger} чел. Скорость и расход изменены.");
            }
            else
            {
                Console.WriteLine("Превышено максимальное количество пассажиров (50 чел.).");
            }
        }

        public void remove_passanger(byte num_passenger)
        {
            if (num_passenger > 0 && num_passenger <= passenger)
            {
                passenger -= num_passenger;
                if (passenger < 10)
                {
                    speed += 6;
                    ras -= 0.6;
                }
                else if (passenger >= 10 && passenger < 20)
                {
                    speed += 5;
                    ras -= 0.5;
                }
                else if (passenger >= 20 && passenger < 30)
                {
                    speed += 4;
                    ras -= 0.4;
                }
                else if (passenger >= 30 && passenger < 40)
                {
                    speed += 3;
                    ras -= 0.3;
                }
                else if (passenger >= 40 && passenger <= 50)
                {
                    speed += 2;
                    ras -= 0.2;
                }

                Console.WriteLine($"Высажено {num_passenger} пассажиров. Всего пассажиров: {passenger} чел. Скорость и расход изменены.");
            }
            else
            {
                Console.WriteLine("Количество пассажиров для высадки не должно превышать текущее количество пассажиров.");
            }
        }
    }
}
