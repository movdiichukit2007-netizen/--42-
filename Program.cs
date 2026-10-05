using System;

namespace ExceptionsLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Програма для перевірки введення чисел (Обробка винятків) ===\n");

            bool isCorrect = false;
            int validNumber = 0;

            // Цикл повторюється доти, доки користувач не введе правильне число
            while (!isCorrect)
            {
                Console.Write("Будь ласка, введіть ціле число: ");
                string? input = Console.ReadLine();

                try
                {
                    // Перетворення рядка в число за допомогою Int32.Parse (без TryParse)
                    validNumber = Int32.Parse(input!);

                    // Якщо винятків не виникло — фіксуємо успіх
                    isCorrect = true;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("❌ Помилка: рядок не може бути порожнім (null)!");
                    Console.WriteLine("Спробуйте ще раз.\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine("❌ Помилка: введене значення не є числом!");
                    Console.WriteLine("Спробуйте ще раз.\n");
                }
                catch (OverflowException) when (input != null && input.Trim().StartsWith("-"))
                {
                    Console.WriteLine("❌ Помилка: значення менше за мінімально допустиме для Int32 (-2 147 483 648)!");
                    Console.WriteLine("Спробуйте ще раз.\n");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("❌ Помилка: значення більше за максимально допустиме для Int32 (2 147 483 647)!");
                    Console.WriteLine("Спробуйте ще раз.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Невідома помилка: {ex.Message}");
                    Console.WriteLine("Спробуйте ще раз.\n");
                }
                finally
                {
                    Console.WriteLine("--- [Блок finally]: Спробу введення опрацьовано ---");
                }
            }

            // Виведення фінального результату
            Console.WriteLine($"\n✅ Успішно! Ви ввели коректне число: {validNumber}");
        }
    }
}
