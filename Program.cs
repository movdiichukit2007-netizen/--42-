using System;

namespace ExceptionsLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Будь ласка, введіть ціле число: ");
            string? input = Console.ReadLine();

            try
            {
                int number = Int32.Parse(input!);
                Console.WriteLine($"Ви ввели число: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("❌ Помилка: введене значення не є числом!");
            }
        }
    }
}
