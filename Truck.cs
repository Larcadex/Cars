using System;

namespace bebra
{
    class Truck : auto
    {
        private double weight;

        public Truck(string initialNom, double initialFuel, double initialRas, int initialSpeed, double initialProbeg,
            double initialX, double initialWeight) :
            base(initialNom, initialFuel, initialRas, initialSpeed, initialProbeg, initialX)
        {
            this.weight = initialWeight;
        }

        public override void Out()
        {
            base.Out();
            Console.WriteLine($"Груз в грузовике: {weight} .");
        }

        public void AddCargo(double numberWeight)
        {
            if (numberWeight > 0)
            {
                if (weight + numberWeight <= 50)
                {
                    weight += numberWeight;
                    UpdateParameters();
                    Console.WriteLine($"Добавлен груз: {numberWeight}. Всего груза: {weight}1000.");
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

        public void RemoveCargo(double removedWeight)
        {
            if (removedWeight > 0 && removedWeight <= weight)
            {
                weight -= removedWeight;
                UpdateParameters();
                Console.WriteLine($"Выгружено груза: {removedWeight}. Всего груза: {weight}.");
            }
            else
            {
                Console.WriteLine("Вес груза для выгрузки должен быть положительным числом и не превышать текущий вес груза.");
            }
        }

        private void UpdateParameters()
        {
            speed -= (int)(speed * 0.01 * weight);
            ras += 0.1 * weight;
        }
    }
}
