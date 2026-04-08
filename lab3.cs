using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace lab3
{
    public class Date : IComparable<Date>
    {
        protected int Day { get; set; }
        protected int Month { get; set; }
        protected int Year { get; set; }

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        public bool IsDateValid()
        {
            if (Year < 0 || Month < 1 || Month > 12 || Day < 1)
                return false;

            int[] daysInMonth = { 31, IsLeapYear(Year) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return Day <= daysInMonth[Month - 1];
        }

        public int CompareTo(Date other)
        {
            if (other == null) return 1;
            if (this.Year != other.Year) return this.Year.CompareTo(other.Year);
            if (this.Month != other.Month) return this.Month.CompareTo(other.Month);
            return this.Day.CompareTo(other.Day);
        }

        public static Date[] SortDates(Date[] dates)
        {
            Array.Sort(dates);
            return dates;
        }

        public override string ToString() => $"{Day:D2}.{Month:D2}.{Year}";

        public string ToFormatString()
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string str_month = "";
            if (this.Month >= 1 && this.Month <= 12) 
            { 
                str_month = months[this.Month - 1];
            }
            return $"{this.Day} {str_month} {this.Year}";
        }

        public int GetNumberBetween(Date other)
        {
            int thisTotalDays = this.Year * 365 + this.Month * 30 + this.Day;
            int otherTotalDays = other.Year * 365 + other.Month * 30 + other.Day;
            return Math.Abs(thisTotalDays - otherTotalDays);
        }

        public int getCentury()
        {
            return (Year + 99) / 100;
        }

        //Lab 4(task 1)
        public Date this[int daysToAdd]
        {
            get
            {
                DateTime current = new DateTime(Year, Month, Day);
                DateTime result = current.AddDays(daysToAdd);
                return new Date(result.Day, result.Month, result.Year);
            }
        }

        public static bool operator !(Date d)
        {
            int[] daysInMonth = { 31, (d.Year % 4 == 0 && d.Year % 100 != 0) || (d.Year % 400 == 0) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return d.Day < daysInMonth[d.Month - 1];
        }

        public static bool operator true(Date d)
        {
            return d.Day == 1 && d.Month == 1;
        }

        public static bool operator false(Date d)
        {
            return d.Day != 1 || d.Month != 1;
        }

        public static bool operator &(Date d1, Date d2)
        {
            return d1.Day == d2.Day && d1.Month == d2.Month && d1.Year == d2.Year;
        }
    }

    public class Document
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Date PublicationDate { get; set; }
        public Document(string title, string author, Date publicationDate)
        {
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
        }
        public override string ToString() => $"'{Title}' by {Author}, published on {PublicationDate}";
    }

    // Рахунок
    public class Bill : Document
    {
        public string[] Products { get; set; }
        public Date PaymentDate { get; set; }
        public Bill(string title, string author, Date pubDate, string[] products, Date payDate)
            : base(title, author, pubDate)
        {
            Products = products;
            PaymentDate = payDate;
        }
        public override string ToString()
        {
            string productsList = string.Join(", ", Products);
            return $"{base.ToString()} | Paid on: {PaymentDate} | Products: [{productsList}]";
        }
    }

    // Накладна
    public class Waybill : Document
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Date DeliveryDate { get; set; }
        public Waybill(int id, int amount, Date deliveryDate) : base($"Waybill #{id}", "Unknown", deliveryDate)
        {
            Id = id;
            Amount = amount;
            DeliveryDate = deliveryDate;
        }
        public override string ToString()
        {
            return $"{base.ToString()} | Amount: {Amount} | Delivery Date: {DeliveryDate}";
        }
    }


    public class Receipt : Document
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public Date PaymentDate { get; set; }
        public Receipt(int id, decimal amount, Date paymentDate) : base($"Receipt #{id}", "Unknown", paymentDate)
        {
            Id = id;
            Amount = amount;
            PaymentDate = paymentDate;
        }
        public override string ToString()
        {
            return $"{base.ToString()} | Amount: {Amount} | Payment Date: {PaymentDate}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter task: ");
                int task = int.Parse(Console.ReadLine());
                switch (task)
                {
                    case 1:
                        Date date1 = new Date(28, 02, 2021);
                        Date date2 = new Date(20, 02, 2021);
                        Date date3 = new Date(31, 04, 1921);
                        Date date4 = new Date(01, 01, 2021);

                        Console.WriteLine(date1.ToString());
                        Console.WriteLine(date2.ToString());
                        Console.WriteLine(date3.ToString());

                        Console.WriteLine(date2[3].ToString());
                        Console.WriteLine($"Is {date1.ToString()} last of the month? {!date1}");

                        if (date4)
                        {
                            Console.WriteLine($"{date4.ToString()} is the first day of the month!");
                        }
                        else
                        {
                            Console.WriteLine("It's not the first day of the month.");
                        }

                        if (date3)
                        {
                            Console.WriteLine($"{date3.ToString()} is the first day of the month!");
                        }
                        else
                        {
                            Console.WriteLine("It's not the first day of the month.");
                        }

                        Console.WriteLine($"Are {date1.ToString()} and {date2.ToString()} equal? {date1 & date2}");

                        break;
                    case 2:
                        Document doc1 = new Document("The Great Gatsby", "F. Scott Fitzgerald", new Date(10, 04, 1925));
                        Bill bill1 = new Bill("Bill #1", "John Doe", new Date(01, 01, 2022), new string[] { "Product A", "Product B" }, new Date(05, 01, 2022));
                        Waybill waybill1 = new Waybill(123, 50, new Date(15, 01, 2022));
                        Receipt receipt1 = new Receipt(456, 99m, new Date(20, 01, 2022));

                        Console.WriteLine(doc1.ToString());
                        Console.WriteLine(bill1.ToString());
                        Console.WriteLine(waybill1.ToString());
                        Console.WriteLine(receipt1.ToString());
                        break;
                    default:
                        Console.WriteLine("Invalid task number. Please enter a number between 1 and 2.");
                        break;
                }
            }
        }
    }
}
