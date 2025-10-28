using System;
using System.Text.RegularExpressions;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 
    class Program
    {
        static void Main(string[] args)
        {
            // Заданий текст для пошуку UUID
            string text = @"
                Тестовий текст з різними ідентифікаторами:
                UUID 1: 123e4567-e89b-12d3-a456-426614174000
                UUID 2: 550e8400-e29b-41d4-a716-446655440000
                Невалідний: 12345-67890
                UUID 3: a1b2c3d4-e5f6-7890-abcd-ef1234567890
                Текст без UUID
                UUID 4: 00000000-0000-0000-0000-000000000000
                Ще один невалідний: 123e4567-e89b-12d3-a456
            ";

            Console.WriteLine("Заданий текст:");
            Console.WriteLine(text);
            Console.WriteLine("\n" + new string('=', 60) + "\n");

            // Регулярний вираз для пошуку UUID
            // UUID має формат: 8-4-4-4-12 шістнадцяткових символів
            string pattern = @"\b[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}\b";

            // Створення об'єкта Regex
            Regex regex = new Regex(pattern);

            // Пошук всіх збігів
            MatchCollection matches = regex.Matches(text);

            // Виведення результатів
            Console.WriteLine($"Знайдено UUID ідентифікаторів: {matches.Count}\n");

            if (matches.Count > 0)
            {
                int counter = 1;
                foreach (Match match in matches)
                {
                    Console.WriteLine($"{counter}. {match.Value}");
                    counter++;
                }
            }
            else
            {
                Console.WriteLine("UUID ідентифікатори не знайдені.");
            }

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
