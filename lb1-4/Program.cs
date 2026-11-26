using System;

namespace Task4
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ---------- Версія А ----------
            Console.WriteLine("=== Версія А (публічні поля) ===");
            var a = new ProductA();

            a.Name = "Ноутбук";        // коректно
            a.Price = 25000m;          // коректно
            a.Quantity = 2;            // коректно
            Console.WriteLine($"Коректні дані:      {a.Name}, {a.Price}, {a.Quantity}, сума = {a.TotalCost()}");

            a.Price = -500m;           // некоректно
            a.Name = "";               // некоректно
            a.Quantity = 99999;        // некоректно (поза діапазоном)
            Console.WriteLine($"Некоректні дані:    '{a.Name}', {a.Price}, {a.Quantity}, сума = {a.TotalCost()}");

            // ---------- Версія Б ----------
            Console.WriteLine("\n=== Версія Б (властивості з валідацією) ===");
            var b = new ProductB();

            b.Name = "Ноутбук";        // коректно
            b.Price = 25000m;          // коректно
            b.Quantity = 2;            // коректно
            Console.WriteLine($"Коректні дані:      {b.Name}, {b.Price}, {b.Quantity}, сума = {b.TotalCost()}");

            Try("Price = -500", () => b.Price = -500m);
            Try("Name = \"\"", () => b.Name = "");
            Try("Quantity = 99999", () => b.Quantity = 99999);
            Console.WriteLine($"Стан після спроб:   {b.Name}, {b.Price}, {b.Quantity}, сума = {b.TotalCost()}");

            Console.WriteLine("\nГотово. Натисніть Enter...");
            Console.ReadLine();
        }

        static void Try(string action, Action act)
        {
            try { act(); Console.WriteLine($"[УСПІХ]   {action}"); }
            catch (Exception ex) { Console.WriteLine($"[ВИНЯТОК] {action} -> {ex.GetType().Name}"); }
        }
    }
}