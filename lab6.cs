using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab6
{
    // Task 1
    public interface IShowable
    {
        void Show();
    }

    public interface IDocument : IShowable
    {
        string Title { get; set; }
        string Author { get; set; }
        Date PublicationDate { get; set; }
    }

    public class Date : IComparable<Date>, ICloneable
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Date(int day, int month, int year)
        {
            Day = day; Month = month; Year = year;
        }

        public int CompareTo(Date other)
        {
            if (other == null) return 1;
            if (Year != other.Year) return Year.CompareTo(other.Year);
            if (Month != other.Month) return Month.CompareTo(other.Month);
            return Day.CompareTo(other.Day);
        }

        public object Clone() => new Date(Day, Month, Year);

        public override string ToString() => $"{Day:D2}.{Month:D2}.{Year}";
    }
    public abstract class BaseDocument : IDocument, ICloneable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Date PublicationDate { get; set; }

        public BaseDocument(string title, string author, Date date)
        {
            Title = title;
            Author = author;
            PublicationDate = date;
        }

        protected BaseDocument(string title)
        {
            Title = title;
        }

        public abstract void Show();
        public abstract object Clone();
    }

    // Task 4
    public class Bill : BaseDocument, IEnumerable
    {
        private string[] strings;

        public string[] Products { get; set; }
        public Date PaymentDate { get; set; }

        public Bill(string title, string author, Date pubDate, string[] products, Date payDate)
            : base(title, author, pubDate)
        {
            Console.WriteLine("Bill created.");
            Products = products;
            PaymentDate = payDate;
        }

        public Bill(string title) : base(title)
        {
            Products = new string[0];
            PaymentDate = new Date(1, 1, 2000);
        }

        public Bill(string title, string author, Date date, string[] strings) : base(title, author, date)
        {
            this.strings = strings;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (string product in Products)
            {
                yield return product;
            }
        }

        public override void Show()
        {
            string productsList = string.Join(", ", Products);
            Console.WriteLine($"{Title} | Paid on: {PaymentDate} | Products Count: {Products.Length}");
        }

        public void CalculateTotalItems()
        {
            int count = Products?.Length ?? strings?.Length ?? 0;
            Console.WriteLine($"[Bill] {Title}. Total products: {count}");
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        ~Bill()
        {
            Console.WriteLine("Bill '{0}' is being destroyed.", Title);
        }
    }

    public class Waybill : BaseDocument
    {
        public int Amount { get; set; }

        public Waybill(string title, string author, Date date, int amount)
            : base(title, author, date) => Amount = amount;

        public override void Show() =>
            Console.WriteLine($"[Waybill] {Title}. Deliver to: {Author}. Amount: {Amount}");

        public void PrintShippingLabel() => Console.WriteLine($"SHIPPING LABEL: {Title} | Qty: {Amount}");

        public override object Clone() => new Waybill(Title, Author, (Date)PublicationDate.Clone(), Amount);
    }

    public class Receipt : BaseDocument
    {
        public decimal Sum { get; set; }

        public Receipt(string title, string author, Date date, decimal sum)
            : base(title, author, date) => Sum = sum;

        public override void Show() =>
            Console.WriteLine($"[Receipt] {Title}. Paid: {Sum} UAH on {PublicationDate}");

        public void ApplyDiscount(decimal percent) => Console.WriteLine($"Discount applied. New sum: {Sum * (1 - percent / 100)}");

        public override object Clone() => new Receipt(Title, Author, (Date)PublicationDate.Clone(), Sum);
    }

    // Task 2
    public interface ISoftware : ICloneable
    {
        string Name { get; set; }
        string Manufacturer { get; set; }
        void ShowInfo();
        bool IsUsable(Date currentDate); 
    }

    public class FreeSoftware : ISoftware
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        public FreeSoftware(string name, string manufacturer)
        {
            Name = name;
            Manufacturer = manufacturer;
        }

        public void ShowInfo() =>
            Console.WriteLine($"[Вільне ПЗ] Назва: {Name}, Виробник: {Manufacturer}");

        public bool IsUsable(Date currentDate) => true; 

        public object Clone() => new FreeSoftware(Name, Manufacturer);
    }

    public class Shareware : ISoftware
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public Date InstallDate { get; set; }
        public int TrialPeriodDays { get; set; } 

        public Shareware(string name, string manufacturer, Date installDate, int trialDays)
        {
            Name = name;
            Manufacturer = manufacturer;
            InstallDate = installDate;
            TrialPeriodDays = trialDays;
        }

        public void ShowInfo() =>
            Console.WriteLine($"[Умовно-безкоштовне] {Name}, Виробник: {Manufacturer}, Встановлено: {InstallDate}, Тріал: {TrialPeriodDays} днів");

        public bool IsUsable(Date currentDate)
        {
            return currentDate.CompareTo(InstallDate) >= 0;
        }

        public object Clone() => new Shareware(Name, Manufacturer, (Date)InstallDate.Clone(), TrialPeriodDays);
    }

    public class CommercialSoftware : ISoftware
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public Date InstallDate { get; set; }
        public int UsePeriodDays { get; set; }

        public CommercialSoftware(string name, string manufacturer, decimal price, Date installDate, int usePeriod)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            InstallDate = installDate;
            UsePeriodDays = usePeriod;
        }

        public void ShowInfo() =>
            Console.WriteLine($"[Комерційне] {Name}, Ціна: {Price}грн, Виробник: {Manufacturer}, Строк: {UsePeriodDays} днів");

        public bool IsUsable(Date currentDate) => currentDate.CompareTo(InstallDate) >= 0;

        public object Clone() => new CommercialSoftware(Name, Manufacturer, Price, (Date)InstallDate.Clone(), UsePeriodDays);
    }

    // Task 3
    public class ArrayProcessingException : Exception
    {
        public ArrayProcessingException() : base("Помилка при обробці масиву.") { }
        public ArrayProcessingException(string message) : base(message) { }
        public ArrayProcessingException(string message, Exception inner) : base(message, inner) { }
    }

    public class ArrayHelper
    {
        public static int GetMinimum(int[] arr, int size)
        {
            try
            {
                if (arr == null || arr.Length == 0 || size <= 0)
                {
                    throw new ArrayProcessingException("Масив порожній або вказано некоректний розмір (size <= 0).");
                }

                int min = arr[0];

                for (int i = 0; i < size; i++)
                {
                    if (arr[i] < min)
                    {
                        min = arr[i];
                    }
                }
                return min;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Критична помилка: Спроба звернення до елемента поза межами масиву.");
                throw new ArrayProcessingException("Параметр 'size' перевищує реальну кількість елементів у масиві.", ex);
            }
            catch (ArrayProcessingException ex)
            {
                Console.WriteLine($"Помилка бізнес-логіки: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Непередбачувана помилка: {ex.Message}");
                throw;
            }
        }
    }

    // Task 4


    class Program
    {
        static void Main()
        {
            // Task 1
            IShowable[] items = new IShowable[]
            {
                new Bill("Internet Services", "ISP", new Date(1, 4, 2026), new[] { "Fiber 100", "Router Rent" }),
                new Waybill("Cargo #45", "Main Warehouse", new Date(5, 4, 2026), 500),
                new Receipt("Tax Payment", "State", new Date(2, 4, 2026), 1200.50m)
            };

            Console.WriteLine("--- Interface Methods Call (Show) ---");
            foreach (var item in items)
            {
                item.Show();
            }

            Console.WriteLine("\n--- Specific Methods Call (Type Pattern) ---");
            InvokeSpecificMethods(items);

            // Task 2
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Date today = new Date(6, 4, 2026);
            Console.WriteLine($"Поточна дата: {today}\n");

            ISoftware[] database = new ISoftware[]
            {
            new FreeSoftware("Ubuntu", "Canonical"),
            new Shareware("WinRAR", "RARLab", new Date(1, 3, 2026), 40),
            new CommercialSoftware("MS Office", "Microsoft", 4500, new Date(1, 1, 2026), 365),
            new Shareware("Total Commander", "Ghisler", new Date(1, 1, 2020), 30), 
            new CommercialSoftware("Adobe Photoshop", "Adobe", 12000, new Date(20, 5, 2026), 30) 
            };

            Console.WriteLine("--- Повна база програмного забезпечення ---");
            foreach (var sw in database)
            {
                sw.ShowInfo();
            }

            Console.WriteLine("\n--- Програми, доступні для використання на сьогодні ---");
            var usableSoftware = database.Where(sw => sw.IsUsable(today));

            foreach (var sw in usableSoftware)
            {
                Console.WriteLine($"- {sw.Name} (Виробник: {sw.Manufacturer})");
            }

            // Task 3
            // Коректні дані
            try
            {
                int[] arr1 = { 5, 2, 8, 1, 9 };
                Console.WriteLine($"Мінімум: {ArrayHelper.GetMinimum(arr1, 5)}");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            Console.WriteLine("----------------------------------");

            // Порожній масив 
            try
            {
                int[] arr2 = { };
                ArrayHelper.GetMinimum(arr2, 0);
            }
            catch (ArrayProcessingException e)
            {
                Console.WriteLine($"Перехоплено власний виняток: {e.Message}");
            }

            Console.WriteLine("----------------------------------");

            // Вихід за межі 
            try
            {
                int[] arr3 = { 10, 20 };
                ArrayHelper.GetMinimum(arr3, 5);
            }
            catch (ArrayProcessingException e)
            {
                Console.WriteLine($"Результат обробки IndexOutOfRangeException: {e.Message}");
                if (e.InnerException != null)
                    Console.WriteLine($"Першопричина (Inner): {e.InnerException.GetType().Name}");
            }
        }

        static void InvokeSpecificMethods(IShowable[] array)
        {
            foreach (var item in array)
            {
                switch (item)
                {
                    case Bill bill:
                        bill.CalculateTotalItems();
                        break;
                    case Waybill waybill:
                        waybill.PrintShippingLabel();
                        break;
                    case Receipt receipt:
                        receipt.ApplyDiscount(10); 
                        break;
                    default:
                        Console.WriteLine("Unknown document type.");
                        break;
                }
            }
        }
    }
}
