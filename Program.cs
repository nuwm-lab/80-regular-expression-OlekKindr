using System;
using System.Collections.Generic;
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
        // Регулярні вирази для різних типів шаблонів
        private static readonly string UuidPattern = @"\b[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}\b";
        private static readonly string DatePattern = @"\b\d{2}[./-]\d{2}[./-]\d{4}\b";
        private static readonly string IpAddressPattern = @"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";
        private static readonly string EmailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";

        // Колекція патернів для пошуку
        private static readonly Dictionary<string, string> Patterns = new Dictionary<string, string>
        {
            { "UUID", UuidPattern },
            { "Дата", DatePattern },
            { "IP-адреса", IpAddressPattern },
            { "Email", EmailPattern }
        };

        static void Main(string[] args)
        {
            // Заданий текст для пошуку різних шаблонів
            string text = @"
                Тестовий текст з різними ідентифікаторами:
                UUID 1: 123e4567-e89b-12d3-a456-426614174000
                UUID 2: 550e8400-e29b-41d4-a716-446655440000
                Дата створення: 28.10.2025
                IP-адреса сервера: 192.168.1.100
                Контактний email: user@example.com
                Невалідний UUID: 12345-67890
                UUID 3: a1b2c3d4-e5f6-7890-abcd-ef1234567890
                Інша дата: 01-12-2024
                Локальна IP: 127.0.0.1
                Email підтримки: support@company.org
                UUID 4: 00000000-0000-0000-0000-000000000000
                Невалідна IP: 256.300.1.1
                Дата: 15/06/2023
                Ще один невалідний UUID: 123e4567-e89b-12d3-a456
            ";

            PrintHeader();
            Console.WriteLine("Заданий текст:");
            Console.WriteLine(text);
            PrintSeparator();

            // Пошук та виведення результатів для кожного типу шаблону
            SearchAndDisplayAllPatterns(text);

            PrintFooter();
        }

        /// <summary>
        /// Виконує пошук всіх типів шаблонів у тексті та виводить результати
        /// </summary>
        /// <param name="text">Текст для аналізу</param>
        private static void SearchAndDisplayAllPatterns(string text)
        {
            int totalMatches = 0;

            foreach (var pattern in Patterns)
            {
                string patternType = pattern.Key;
                string patternRegex = pattern.Value;

                MatchCollection matches = FindMatches(text, patternRegex);
                totalMatches += matches.Count;

                PrintMatches(patternType, matches);
            }

            PrintSeparator();
            Console.WriteLine($"Загальна кількість знайдених збігів: {totalMatches}");
        }

        /// <summary>
        /// Знаходить всі збіги у тексті за заданим шаблоном
        /// </summary>
        /// <param name="text">Текст для пошуку</param>
        /// <param name="pattern">Регулярний вираз</param>
        /// <returns>Колекція знайдених збігів</returns>
        private static MatchCollection FindMatches(string text, string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.Matches(text);
        }

        /// <summary>
        /// Виводить результати пошуку для конкретного типу шаблону
        /// </summary>
        /// <param name="patternType">Тип шаблону</param>
        /// <param name="matches">Знайдені збіги</param>
        private static void PrintMatches(string patternType, MatchCollection matches)
        {
            Console.WriteLine($"\n{patternType}:");
            Console.WriteLine(new string('-', 60));

            if (matches.Count > 0)
            {
                Console.WriteLine($"Знайдено: {matches.Count}\n");

                int counter = 1;
                foreach (Match match in matches)
                {
                    Console.WriteLine($"  {counter}. {match.Value}");
                    counter++;
                }
            }
            else
            {
                Console.WriteLine($"{patternType} не знайдено.");
            }
        }

        /// <summary>
        /// Виводить заголовок програми
        /// </summary>
        private static void PrintHeader()
        {
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("Пошук шаблонів у тексті за допомогою Regular Expressions");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();
        }

        /// <summary>
        /// Виводить роздільник
        /// </summary>
        private static void PrintSeparator()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();
        }

        /// <summary>
        /// Виводить футер програми
        /// </summary>
        private static void PrintFooter()
        {
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
