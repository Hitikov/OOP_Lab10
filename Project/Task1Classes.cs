using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Project
{
    class Printing
    {
        protected static int yearCelling = 2024;

        protected static string[] possibleNamePart1 = ["дешовых", "дорогостоящих", "технологичных", "простых", "сложных" ];
        protected static string[] possibleNamePart2 = ["автомобилях", "имплантах", "короблях", "компьютерах", "двигателях" ];

        protected string? name;
        protected int year;

        public string? Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Year
        {
            get { return year; } 
            set 
            {
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, yearCelling);
                year = value;
            } 
        }

        public Printing()
        {
            Name = "NoName";
            Year = 0;
        }

        public Printing(string? name, int year)
        {
            Name = name;
            Year = year;
        }

        public Printing(Printing other)
        {
            Name = other.Name;
            Year = other.Year;
        }

        public virtual void Show()
        {
            Console.WriteLine("Наименование печатного издания: ", Name);
            Console.WriteLine("Год издания: ", Year);
        }

        public static Printing Init()
        {
            Console.WriteLine("Введите наименование печатного издания: ");

            string? bufname = Console.ReadLine();
            
            if (bufname == null)
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            Console.WriteLine("Введите год издания: ");

            string? bufyear = Console.ReadLine();
            int intyear;

            if (bufyear == null || int.TryParse(bufyear, out intyear))
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            return new Printing(bufname, intyear);
        }

        public static Printing RandomInit()
        {
            Random rnd = new Random();

            string? name = "О " + possibleNamePart1[rnd.Next(possibleNamePart1.Length)] + " " + possibleNamePart2[rnd.Next(possibleNamePart2.Length)];
            int year = rnd.Next(1990, yearCelling + 1);

            return new Printing(name, year);
        }

        public virtual bool CustEquals(object obj)
        {
            if (obj is Printing p)
            {
                if (p.Name == Name && p.Year == Year)
                {
                    return true;
                }
            }

            return false;
        }
    }

    class Book : Printing
    {
        protected static string[] possibleAuthor = ["Авдеев", "Борисов", "Волынец", "Горкин", "Дедько"];

        protected string? author;

        public string? Author
        {
            get { return author; }
            set { author = value; }
        }

        public Book() : base()
        {
            author = null;
        }

        public Book(string? name, int year, string? author) : base(name, year)
        {
            Author = author;
        }

        public Book(Book book) : base(book)
        {
            Author = book.Author;
        }

        override public void Show()
        { 
            Console.WriteLine("Наименование книги: ", Name);
            Console.WriteLine("Год издания: ", Year);
            Console.WriteLine("Автор", Author);
        }

        public static new Book Init()
        {
            Console.WriteLine("Введите наименование книги: ");

            string? bufname = Console.ReadLine();

            if (bufname == null)
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            Console.WriteLine("Введите год издания: ");

            string? bufyear = Console.ReadLine();
            int intyear;

            if (bufyear == null || int.TryParse(bufyear, out intyear))
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            Console.WriteLine("Введите фамилию автора: ");

            string? bufauthor = Console.ReadLine();

            if (bufauthor == null)
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            return new Book(bufname, intyear, bufauthor);
        }

        public static new Book RandomInit()
        {
            Random rnd = new Random();

            string? name = "О " + possibleNamePart1[rnd.Next(possibleNamePart1.Length)] + " " + possibleNamePart2[rnd.Next(possibleNamePart2.Length)];
            int year = rnd.Next(1990, yearCelling + 1);
            string author = possibleAuthor[rnd.Next(possibleAuthor.Length)];

            return new Book(name, year, author);
        }
        override public bool CustEquals(object obj)
        {
            if (obj is Book p)
            {
                if (p.Name == Name && p.Year == Year && p.Author == Author)
                {
                    return true;
                }
            }

            return false;
        }
    }

    class Magazine : Printing
    {
        protected int volume;

        public int Volume
        {
            get { return volume; }
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, 1);
                volume = value;
            }
        }

        public Magazine() : base()
        {
            Volume = 0;
        }

        public Magazine(string? name, int year, int volume) : base(name, year)
        {
            Volume = volume;
        }

        public Magazine(Magazine magazine) : base(magazine)
        {
            Volume = magazine.Volume;
        }

        override public void Show()
        {
            Console.WriteLine("Наименование журнала: ", Name);
            Console.WriteLine("Год издания: ", Year);
            Console.WriteLine("Номер издания", Volume);
        }

        public static new Magazine Init()
        {
            Console.WriteLine("Введите наименование книги: ");

            string? bufname = Console.ReadLine();

            if (bufname == null)
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            Console.WriteLine("Введите год издания: ");

            string? bufyear = Console.ReadLine();
            int intyear;

            if (bufyear == null || int.TryParse(bufyear, out intyear))
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            Console.WriteLine("Введите номер издания: ");

            string? bufvol = Console.ReadLine();
            int intvol;

            if (bufyear == null || int.TryParse(bufvol, out intvol))
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            return new Magazine(bufname, intyear, intvol);
        }

        public static new Magazine RandomInit()
        {
            Random rnd = new Random();

            string? name = "О " + possibleNamePart1[rnd.Next(possibleNamePart1.Length)] + " " + possibleNamePart2[rnd.Next(possibleNamePart2.Length)];
            int year = rnd.Next(1990, yearCelling + 1);
            int volume = rnd.Next(1, 11);

            return new Magazine(name, year, volume);
        }
        override public bool CustEquals(object obj)
        {
            if (obj is Magazine p)
            {
                if (p.Name == Name && p.Year == Year && p.Volume == Volume)
                {
                    return true;
                }
            }

            return false;
        }

    }

    class EdManual : Printing
    {
        protected static string[] possibleField = ["Механика", "Экономика", "Химия"];

        protected string? field;

        public string? Field
        {
            get { return field; }
            set { field = value; }
        }

        public EdManual() : base()
        {
            Field = null;
        }

        public EdManual(string? name, int year, string? field) : base(name, year)
        {
            Field = field;
        }

        public EdManual(EdManual manual) : base(manual)
        {
            Field = manual.Field;
        }

        override public void Show()
        {
            Console.WriteLine("Наименование книги: ", Name);
            Console.WriteLine("Год издания: ", Year);
            Console.WriteLine("Научная область", Field);
        }

        public static new EdManual Init()
        {
            Console.WriteLine("Введите наименование книги: ");

            string? bufname = Console.ReadLine();

            if (bufname == null)
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            Console.WriteLine("Введите год издания: ");

            string? bufyear = Console.ReadLine();
            int intyear;

            if (bufyear == null || int.TryParse(bufyear, out intyear))
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            Console.WriteLine("Введите научную область: ");

            string? buffield = Console.ReadLine();

            if (buffield == null)
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            return new EdManual(bufname, intyear, buffield);
        }

        public static new EdManual RandomInit()
        {
            Random rnd = new Random();

            string? name = "О " + possibleNamePart1[rnd.Next(possibleNamePart1.Length)] + " " + possibleNamePart2[rnd.Next(possibleNamePart2.Length)];
            int year = rnd.Next(1990, yearCelling + 1);
            string author = possibleField[rnd.Next(possibleField.Length)];

            return new EdManual(name, year, author);
        }
        override public bool CustEquals(object obj)
        {
            if (obj is EdManual p)
            {
                if (p.Name == Name && p.Year == Year && p.Field == Field)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
