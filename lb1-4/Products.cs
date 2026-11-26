using System;

namespace Task4
{
    // ===== Версія А: публічні поля, без перевірок і без властивостей =====
    public class ProductA
    {
        public string Name;
        public decimal Price;
        public int Quantity;

        public decimal TotalCost() => Price * Quantity;
    }

    // ===== Версія Б: приватні поля + публічні властивості з валідацією =====
    public class ProductB
    {
        private string _name = "Без назви";
        private decimal _price;
        private int _quantity;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Назва не може бути порожньою.");
                _name = value.Trim();
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0m)
                    throw new ArgumentOutOfRangeException(nameof(value), "Ціна не може бути від'ємною.");
                _price = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0 || value > 10000)
                    throw new ArgumentOutOfRangeException(nameof(value), "Кількість має бути в межах 0–10000.");
                _quantity = value;
            }
        }

        public decimal TotalCost() => Price * Quantity;
    }
}