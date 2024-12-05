using Microsoft.VisualBasic;
using System;
using System.Collections;

namespace PrintingLibrary
{

    public interface IInit
    {
        void Init();
        void RandomInit();
    }

    public class SortByName : IComparer
    {
        public int Compare(object? objx, object? objy)
        {
            if (objx is Printing px && objy is Printing py)
            {
                return string.Compare(px.Name,
                                      py.Name,
                                      StringComparison.Ordinal);
            }
            else
                throw new ArgumentException("Некорректное значение параметра");
        }
    }

    public class Printing : IInit, IComparable, ICloneable
    {
        protected static int yearCelling = DateAndTime.Year(DateTime.Today);

        protected static string[] possibleNamePart1 =
        [
            "дешовых",
            "дорогостоящих",
            "технологичных",
            "простых",
            "сложных",
            "характеристика 1",
            "характеристика 2",
            "характеристика 3",
            "характеристика 4",
            "характеристика 5",
            "характеристика 6",
            "характеристика 7",
            "характеристика 8",
            "характеристика 9",
            "характеристика 10",
        ];
        protected static string[] possibleNamePart2 =
        [
            "автомобилях",
            "имплантах",
            "короблях",
            "компьютерах",
            "двигателях",
            "объект 1",
            "объект 2",
            "объект 3",
            "объект 4",
            "объект 5",
            "объект 6",
            "объект 7",
            "объект 8",
            "объект 9",
            "объект 10",

        ];

        private string? name;
        private int year;

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

        public override string ToString()
        {
            return Name + ", " + Year;
        }

        public virtual void Show()
        {
            Console.WriteLine("Печатное изд.: " + Name + ", " + Year);
        }

        public void Init()
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

            if (bufyear == null || !int.TryParse(bufyear, out intyear))
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            Name = bufname;
            Year = intyear;
        }

        public void RandomInit()
        {
            Random rnd = new Random();

            string? name = "О " + possibleNamePart1[rnd.Next(possibleNamePart1.Length)] + " " + possibleNamePart2[rnd.Next(possibleNamePart2.Length)];
            int year = rnd.Next(1990, yearCelling + 1);

            Name = name;
            Year = year;
        }

        public override bool Equals(object? obj)
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

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public int CompareTo(object? obj)
        {
            if (obj is Printing p)
            {
                return Year.CompareTo(p.Year);
            }
            else
                throw new ArgumentException("Некорректное значение параметра");
        }
    
        public object Clone()
        {
            return new Printing("Копия " + this.name, this.year);
        }

        public Printing ShallowCopy()
        {
            return (Printing)this.MemberwiseClone();
        }
    }

    public class Book : Printing
    {
        protected static string[] possibleAuthor =
        [
            "Авдеев",
            "Борисов",
            "Волынец",
            "Горкин",
            "Дедько"
        ];

        private string? author;

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

        public Printing BasePrinting
        {
            get
            {
                return new Printing(Name, Year);
            }
        }

        public override string ToString()
        {
            return Name + ", " + Author + ", " + Year;
        }

        override public void Show()
        {
            Console.WriteLine("Книга: " + Name + ", " + Author + ", " + Year);
        }

        public new void Init()
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

            if (bufyear == null || !int.TryParse(bufyear, out intyear))
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

            Name = bufname;
            Year = intyear;
            Author = bufauthor;
        }
        
        public new void RandomInit()
        {
            Random rnd = new Random();

            string? name = "О " + possibleNamePart1[rnd.Next(possibleNamePart1.Length)] + " " + possibleNamePart2[rnd.Next(possibleNamePart2.Length)];
            int year = rnd.Next(1990, yearCelling + 1);
            string author = possibleAuthor[rnd.Next(possibleAuthor.Length)];

            Name = name;
            Year = year;
            Author = author;
        }
        
        override public bool Equals(object? obj)
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

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public new object Clone()
        {
            return new Book("Копия " + this.Name, this.Year, this.Author);
        }

        public new Book ShallowCopy()
        {
            return (Book)this.MemberwiseClone();
        }
    }

    public class Magazine : Printing
    {
        private int volume;

        public int Volume
        {
            get { return volume; }
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);
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

        public Printing BasePrinting
        {
            get
            {
                return new Printing(Name, Year);
            }
        }

        public override string ToString()
        {
            return Name + ", " + Volume + ", " + Year;
        }

        override public void Show()
        {
            Console.WriteLine("Журнал: " + Name + ", ч." + Volume + ", " + Year);
        }

        public new void Init()
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

            if (bufyear == null || !int.TryParse(bufyear, out intyear))
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            Console.WriteLine("Введите номер издания: ");

            string? bufvol = Console.ReadLine();
            int intvol;

            if (bufyear == null || !int.TryParse(bufvol, out intvol))
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            Name = bufname;
            Year = intyear;
            Volume = intvol;
        }

        public new void RandomInit()
        {
            Random rnd = new Random();

            string? name = "О " + possibleNamePart1[rnd.Next(possibleNamePart1.Length)] + " " + possibleNamePart2[rnd.Next(possibleNamePart2.Length)];
            int year = rnd.Next(1990, yearCelling + 1);
            int volume = rnd.Next(1, 11);

            Name = name;
            Year = year;
            Volume = volume;
        }
        
        override public bool Equals(object? obj)
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

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public new object Clone()
        {
            return new Magazine("Копия " + this.Name, this.Year, this.Volume);
        }

        public new Magazine ShallowCopy()
        {
            return (Magazine)this.MemberwiseClone();
        }

    }

    public class EdManual : Printing
    {
        protected static string[] possibleField =
        [
            "Физика",
            "Экономика",
            "Химия"
        ];

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

        public Printing BasePrinting
        {
            get
            {
                return new Printing(Name, Year);
            }
        }

        public override string ToString()
        {
            return Name + ", " + Field + ", " + Year;
        }

        override public void Show()
        {
            Console.WriteLine("Учебник: " + Name + ", " + Field + ", " + Year);
        }

        public new void Init()
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

            if (bufyear == null || !int.TryParse(bufyear, out intyear))
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

            Name = bufname;
            Year = intyear;
            Field = buffield;
        }

        public new void RandomInit()
        {
            Random rnd = new Random();

            string? name = "О " + possibleNamePart1[rnd.Next(possibleNamePart1.Length)] + " " + possibleNamePart2[rnd.Next(possibleNamePart2.Length)];
            int year = rnd.Next(1990, yearCelling + 1);
            string field = possibleField[rnd.Next(possibleField.Length)];

            Name = name;
            Year = year;
            Field = field;
        }

        override public bool Equals(object? obj)
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

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public new object Clone()
        {
            return new EdManual("Копия " + this.Name, this.Year, this.Field);
        }

        public new EdManual ShallowCopy()
        {
            return (EdManual)this.MemberwiseClone();
        }

    }
}
