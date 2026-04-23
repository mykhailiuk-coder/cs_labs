using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Введіть номер завдання (1-3) або 'exit' для виходу: ");
            int choice = int.Parse(Console.ReadLine()!.Trim());
            switch (choice) {
                case 1:
                    string inputPath = @"D:\cs_tasks\lab8\lab8\message.txt";
                    string resultsPath = @"D:\cs_tasks\lab8\lab8\emails.txt";
                    string outputPath = @"D:\cs_tasks\lab8\lab8\result.txt";

                    string pattern = @"\b[a-zA-Z0-9._%+-]+@ukr\.net\b";

                    try
                    {
                        if (!File.Exists(inputPath))
                        {
                            Console.WriteLine("Помилка: Вхідний файл не знайдено!");
                            return;
                        }

                        string content = File.ReadAllText(inputPath);

                        var matches = Regex.Matches(content, pattern);

                        File.WriteAllLines(resultsPath, matches.Cast<Match>().Select(m => m.Value));

                        Console.WriteLine($"Знайдено адрес: {matches.Count}");
                        Console.WriteLine($"Список адрес збережено у: {resultsPath}");

                        Console.WriteLine("\nВведіть адресу, яку потрібно ВИЛУЧИТИ:");
                        string toDelete = Console.ReadLine()!;

                        Console.WriteLine("Введіть адресу, яку потрібно ЗАМІНИТИ:");
                        string toReplace = Console.ReadLine()!;
                        Console.WriteLine("На що замінити?");
                        string replacement = Console.ReadLine()!;

                        string updatedContent = content;

                        if (!string.IsNullOrEmpty(toDelete))
                        {
                            updatedContent = updatedContent.Replace(toDelete, "");
                        }

                        if (!string.IsNullOrEmpty(toReplace))
                        {
                            updatedContent = updatedContent.Replace(toReplace, replacement);
                        }

                        File.WriteAllText(outputPath, updatedContent);
                        Console.WriteLine($"\nОброблений текст збережено у: {outputPath}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Сталася помилка: {ex.Message}");
                    }
                    break;
            }
        }
    }
}
