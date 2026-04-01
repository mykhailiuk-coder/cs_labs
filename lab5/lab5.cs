using System;
using System.Linq;

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

    public int CompareTo(Date other)
    {
        if (other == null) return 1;
        if (Year != other.Year) return Year.CompareTo(other.Year);
        if (Month != other.Month) return Month.CompareTo(other.Month);
        return Day.CompareTo(other.Day);
    }

    public override string ToString()
    {
        return $"{Day:D2}.{Month:D2}.{Year}";
    }
}

abstract public class Document
{
    public string Title { get; set; }
    public string Author { get; set; }
    public Date PublicationDate { get; set; }

    public Document() 
    { 
        Console.WriteLine("Document created.");
        Title = "Untitled";
        Author = "Unknown";
        PublicationDate = new Date(1, 1, 2000);
    }

    public Document(string title) : this()
    {
        Console.WriteLine("Document created.");
        Title = title;
        Author = "Unknown";
        PublicationDate = new Date(1, 1, 2000);
    }

    public Document(string title, string author, Date publicationDate)
    {
        Console.WriteLine("Document created.");
        Title = title;
        Author = author;
        PublicationDate = publicationDate;
    }

    ~Document() 
    { 
        Console.WriteLine("Document '{0}' is being destroyed.", Title);
    }

    public abstract void Show();
}

// Рахунок
public class Bill : Document
{
    public string[] Products { get; set; }
    public Date PaymentDate { get; set; }
    public Bill(string title, string author, Date pubDate, string[] products, Date payDate)
        : base(title, author, pubDate)
    {
        Console.WriteLine("Bill created.");
        Products = products;
        PaymentDate = payDate;
    }

    public Bill(string title, string author, Date pubDate) : base(title, author, pubDate)
    {
        Console.WriteLine("Bill created.");
        Products = new string[0];
        PaymentDate = new Date(1, 1, 2000);
    }

    public Bill(string title) : base(title)
    {
        Console.WriteLine("Bill created.");
        Products = new string[0];
        PaymentDate = new Date(1, 1, 2000);
    }

    ~Bill() 
    { 
        Console.WriteLine("Bill '{0}' is being destroyed.", Title);
    }

    public override void Show()
    {
        string productsList = string.Join(", ", Products);
        Console.WriteLine($"{base.ToString()} | Paid on: {PaymentDate} | Products: [{productsList}]");
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
        Console.WriteLine("Waybill created.");
        Id = id;
        Amount = amount;
        DeliveryDate = deliveryDate;
    }
    public Waybill(int id) : base($"Waybill #{id}")
    {
        Console.WriteLine("Waybill created.");
        Amount = 0;
        DeliveryDate = new Date(1, 1, 2000);
    }
    public Waybill() : base("Waybill")
    {
        Console.WriteLine("Waybill created.");
        Amount = 0;
        DeliveryDate = new Date(1, 1, 2000);
    }
    ~Waybill() 
    { 
        Console.WriteLine("Waybill '{0}' is being destroyed.", Title);
    }
    public override void Show()
    {
        Console.WriteLine($"{base.ToString()} | Amount: {Amount} | Delivery Date: {DeliveryDate}");
    }
}


public class Receipt : Document
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public Date PaymentDate { get; set; }
    public Receipt(int id, decimal amount, Date paymentDate) : base($"Receipt #{id}", "Unknown", paymentDate)
    {
        Console.WriteLine("Receipt created.");
        Id = id;
        Amount = amount;
        PaymentDate = paymentDate;
    }

    public Receipt(int id) : base($"Receipt #{id}")
    {
        Console.WriteLine("Receipt created.");
        Amount = 0;
        PaymentDate = new Date(1, 1, 2000);
    }   

    public Receipt() : base("Receipt")
    {
        Console.WriteLine("Receipt created.");
        Amount = 0;
        PaymentDate = new Date(1, 1, 2000);
    }

    ~Receipt() 
    { 
        Console.WriteLine("Receipt '{0}' is being destroyed.", Title);
    }

    public override void Show()
    {
        Console.WriteLine($"{base.ToString()} | Amount: {Amount} | Payment Date: {PaymentDate}");
    }
}

public abstract class Software
{
    public string name;
    public string Description;

    public struct Version
    {
        public string Code { get; set; }
        public Date ReleaseDate { get; set; }
        public Version(string code, Date releaseDate)
        {
            Code = code;
            ReleaseDate = releaseDate;
        }
    }

    public Version version;

    public Software(string name, string description, string code, Date releaseDate)
    {
        this.name = name;
        Description = description;
        version = new Version(code, releaseDate);
    }

    public bool canBeUsedOnDate(Date date)
    {
        if (date == null) return false;
        return date.CompareTo(version.ReleaseDate) >= 0;
    }

    public abstract void ShowInfo();
}

public class FreeSoftware : Software
{
    int functionalityLevel;
    string manufacturer;
    public FreeSoftware(string name, string description, string code, Date releaseDate, int functionalityLevel, string manufacturer) : base(name, description, code, releaseDate)
    {
        this.functionalityLevel = functionalityLevel;
        this.manufacturer = manufacturer;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Free Software: {name}\nDescription: {Description}\nVersion: {version.Code} (Released on: {version.ReleaseDate})\nFunctionality Level: {functionalityLevel}\nManufacturer: {manufacturer}");
    }
}

public class PartiallyFreeSoftware : Software
{
    decimal price;
    string vendor;
    public PartiallyFreeSoftware(string name, string description, string code, Date releaseDate, decimal price, string vendor) : base(name, description, code, releaseDate)
    {
        this.price = price;
        this.vendor = vendor;
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"Partially Free Software: {name}\nDescription: {Description}\nVersion: {version.Code} (Released on: {version.ReleaseDate})\nPrice: ${price}\nVendor: {vendor}");
    }
}

public class PaidSoftware : Software
{
    decimal price;
    Date expirationDate;
    Date installDate;
    string vendor;
    public PaidSoftware(string name, string description, string code, Date releaseDate, decimal price, string vendor, Date expirationDate, Date installDate) : base(name, description, code, releaseDate)
    {
        this.price = price;
        this.vendor = vendor;
        this.expirationDate = expirationDate;
        this.installDate = installDate;
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"Paid Software: {name}\nDescription: {Description}\nVersion: {version.Code} (Released on: {version.ReleaseDate})\nPrice: ${price}\nVendor: {vendor}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Bill bill = new Bill("Electricity Bill", "John Doe", new Date(10, 1, 2024), new string[] { "Electricity" }, new Date(10, 1, 2024));
        Waybill waybill = new Waybill(123, 50, new Date(5, 1, 2024));
        Receipt receipt = new Receipt(456, 100.50m, new Date(15, 1, 2024));
        var documents = new Document[] { bill, waybill, receipt };
        documents = documents.OrderBy(d => d.PublicationDate).ToArray();
        foreach (var document in documents)
        {
            document.Show();
        }

        FreeSoftware free = new FreeSoftware("LibreApp", "Open-source utility", "1.0.0", new Date(01, 01, 2020), 5, "OpenCommunity");
        PartiallyFreeSoftware partial = new PartiallyFreeSoftware("FreemiumApp", "Has premium features", "1.2.3", new Date(06, 01, 2021), 19.99m, "AcmeCorp");
        PaidSoftware paid = new PaidSoftware("ProApp", "Commercial software", "2.0.0", new Date(01, 06, 2022), 99.99m, "SoftVendor", new Date(01, 06, 2023), new Date(01, 01, 2024));

        var softwares = new Software[] { free, partial, paid };

        foreach (var software in softwares) 
        {
            software.ShowInfo();
        }
    }
}
