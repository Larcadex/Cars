using System;

namespace cars
{
    class Truck : auto
    {
        private double weight;

        public Truck(string nom, double bak, double ras, int speed, double probeg, double x, double weight) : base(nom, bak, ras, speed, probeg, x)
        {
            this.weight = weight;
        }

        public override void Out()
        {
            base.Out();
            Console.WriteLine($"Груз в грузовике: {weight} т.");
        }

        private void add_weight(double num_weight)
        {
            if (num_weight > 0)
            {
                if (weight + num_weight <= 50)
                {
                    weight += num_weight;
                    if (weight < 10)
                    {
                        speed -= 2;
                        ras += 0.2;
                    }
                    else if (weight >= 10 && weight < 20)
                    {
                        speed -= 3;
                        ras += 0.3;
                    }
                    else if (weight >= 20 && weight < 30)
                    {
                        speed -= 4;
                        ras += 0.4;
                    }
                    else if (weight >= 30 && weight < 40)
                    {
                        speed -= 5;
                        ras += 0.5;
                    }
                    else if (weight >= 40 && weight <= 50)
                    {
                        speed -= 6;
                        ras += 0.6;
                    }

                   
                    Console.WriteLine($"Добавлен груз: {num_weight} т. Всего груза: {weight} т. Скорость и расход изменены.");
                }
                else
                {
                    Console.WriteLine("Превышено максимальное количество груза.");
                }
            }
            else
            {
                Console.WriteLine("Вес груза должен быть положительным числом.");
            }
        }

        private void remove_weight(double num_weight)
        {
            if (num_weight > 0 && num_weight <= weight)
            {
                weight -= num_weight;
                if (weight < 10)
                {
                    speed += 6;
                    ras -= 0.6;
                }
                else if (weight >= 10 && weight < 20)
                {
                    speed += 5;
                    ras -= 0.5;
                }
                else if (weight >= 20 && weight < 30)
                {
                    speed += 4;
                    ras -= 0.4;
                }
                else if (weight >= 30 && weight < 40)
                {
                    speed += 3;
                    ras -= 0.3;
                }
                else if (weight >= 40 && weight <= 50)
                {
                    speed += 2;
                    ras -= 0.2;
                }

                Console.WriteLine($"Выгружено груза: {num_weight} т. Всего груза: {weight} т. Скорость и расход изменены.");
            }
            else
            {
                Console.WriteLine("Вес груза для выгрузки должен быть положительным числом и не превышать текущий вес груза.");
            }
        }
        
        public void choise(string action, double parameter = 0)
        {
            switch (action.ToLower())
            {
                case "zapravka":
                    zapravka(parameter);
                    break;
                case "move":
                    move(parameter, -1); 
                    break;
                case "ostanovka":
                    ostanovka();
                    break;
                case "razgon":
                    razgon((int)parameter);
                    break;
                case "stop":
                    stop((int)parameter);
                    break;
                case "add_weight":
                    add_weight((byte)parameter);
                    break;
                case "remove_weight":
                    remove_weight((byte)parameter);
                    break;
            }
        }


    }
}
