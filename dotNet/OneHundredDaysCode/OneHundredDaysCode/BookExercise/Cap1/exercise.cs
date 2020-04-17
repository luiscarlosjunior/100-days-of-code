using System;
using System.Collections.Generic;
using System.Text;

namespace OneHundredDaysCode.BookExercise.Cap1
{
    class exercise
    {
        public static void CelsiusToFahrenheit(float celsius)
        {
            // Set the formula
            float fahrenheit = 0.0f;

            fahrenheit = (9 * celsius + 160) / 5;

            Console.WriteLine(fahrenheit);
        }

        public static void FahrenheitToCelsius(float fahrenheit)
        {
            float celsius;

            celsius = (float)(5.0 / 9.0) * (fahrenheit - 32);

            Console.WriteLine(celsius);
        }
        
        public static void CalculateArea(float area, float height)
        {
            float volume;

            volume = MathF.PI * MathF.Pow(area, 2f) * height;

            Console.WriteLine(volume);
        }

        /// <summary>
        /// Retorna a quantidade de gás desperdiçada em 
        /// um carro que desperdiça 1 litro por 12 quilômetros
        /// </summary>
        /// <param name="time">Time wasted</param>
        /// <param name="velocity">Velocity averaged</param>
        public static void GasCarWaste(float time, float velocity)
        {
            float distance;

            distance = time * velocity;

            float litersUsed;

            litersUsed = distance / 12;

            Console.WriteLine(litersUsed);
        }

        public static void OverduePayment(float value, float rate, float timeInDays)
        {
            float payment;

            payment = value + (value * (rate / 100) * timeInDays);

            Console.WriteLine(payment);
        }
        
        public static void SwapValue(int number1, int number2)
        {
            // Swap by Xor operation
            number1 = number1 ^ number2;
            number2 = number2 ^ number1;
            number1 = number1 ^ number2;

            Console.WriteLine(number1 + " " + number2);
        }
    

    }
}
