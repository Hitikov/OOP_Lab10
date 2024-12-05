using Microsoft.VisualBasic;
using PrintingLibrary;

namespace Project
{
    internal class Program
    {
        
        static private void Task1()
        {
            Printing printing1 = new Printing();
            printing1.Init();
            printing1.Show();
            
            Printing printing2 = new Printing();
            printing2.RandomInit();
            printing2.Show();

            Console.WriteLine(printing1.Equals(printing2));


            Book book1 = new Book();
            book1.RandomInit();
            book1.Show();

            Book book2 = new Book(book1);
            book2.Show();

            Console.WriteLine(book1.Equals(book2));


            Magazine magazine = new Magazine();
            magazine.RandomInit();
            magazine.Show();

            EdManual edManual = new EdManual();
            edManual.RandomInit();
            edManual.Show();

        }

        static Printing[] CreateArrayPrintings(int arrlen)
        {

            Random rand = new Random();

            Printing[] printings = new Printing[arrlen];

            int pos;

            for (int i = 0; i < arrlen; i++)
            {
                pos = rand.Next(4);

                switch (pos)
                {
                    case 0:
                        Printing addprint = new Printing();
                        addprint.RandomInit();
                        printings[i] = addprint;
                        break;
                    case 1:
                        Book addbook = new Book();
                        addbook.RandomInit();
                        printings[i] = addbook;
                        break;
                    case 2:
                        Magazine addmagaz = new Magazine();
                        addmagaz.RandomInit();
                        printings[i] = addmagaz;
                        break;
                    case 3:
                        EdManual addmanual = new EdManual();
                        addmanual.RandomInit();
                        printings[i] = addmanual;
                        break;
                }
            }

            return printings;
        }

        static void Task2()
        {
            int arrlen = 100;

            int currentYear = DateAndTime.Year(DateTime.Today);
            int yearOffset = 2;
            
            int yearcellar = currentYear - yearOffset;

            string? author = "Борисов";
            int authorcount = 0;

            int edManualCount = 0;

            Printing[] printings = CreateArrayPrintings(arrlen);

            ShowArray(printings);
            Console.WriteLine();

            Console.WriteLine("Запросы");
            Console.WriteLine();

            Console.WriteLine("Наименования журналов от " + yearcellar + " года выпуска:");

            for (int i = 0; i < arrlen; i++)
            {
                if (printings[i] is Magazine)
                {
                    if (printings[i].Year >= yearcellar)
                    {
                        Console.WriteLine(printings[i].Name);
                    }    
                }

                if (printings[i] is EdManual)
                {
                    ++edManualCount;
                }

                if (printings[i] is Book p)
                {
                    if (p.Author == author)
                    {
                        ++authorcount;
                    }
                }
            }

            Console.WriteLine("Колличество учебников: " + edManualCount);

            Console.WriteLine("Колличество книг с автором " + author + ": " + authorcount);
        }

        static void SearchBinnaryYear(Printing[] printings, int targetYear)
        {
            int r_index = printings.Length;
            int l_index = 0;
            int mid_index;

            do
            {
                mid_index = (l_index + r_index) / 2;
                
                if (printings[mid_index].Year < targetYear)
                {
                    l_index = mid_index + 1;
                }
                else if (printings[mid_index].Year > targetYear)
                {
                    r_index = mid_index - 1;
                }

            } while (printings[mid_index].Year != targetYear && (l_index < r_index));

            if (printings[mid_index].Year == targetYear)
            {
                Console.WriteLine("Найденный элемент: ");
                printings[mid_index].Show();
            }
            else
            {
                Console.WriteLine("Элемента с заданым годом не найдено");
            }
        }

        static void ShowArray(IInit[] printings)
        {
            foreach (IInit elem in printings)
            {
                if (elem is Printing print)
                    print.Show();
                if (elem is NumberPair pair)
                    pair.Show();
            }
        }

        static IInit[] CreateArrayIInit(int arrlen)
        {
            Random rand = new Random();

            IInit[] printings = new IInit[arrlen];

            int pos;

            for (int i = 0; i < arrlen; i++)
            {
                pos = rand.Next(5);

                switch (pos)
                {
                    case 0:
                        Printing addprint = new Printing();
                        addprint.RandomInit();
                        printings[i] = addprint;
                        break;
                    case 1:
                        Book addbook = new Book();
                        addbook.RandomInit();
                        printings[i] = addbook;
                        break;
                    case 2:
                        Magazine addmagaz = new Magazine();
                        addmagaz.RandomInit();
                        printings[i] = addmagaz;
                        break;
                    case 3:
                        EdManual addmanual = new EdManual();
                        addmanual.RandomInit();
                        printings[i] = addmanual;
                        break;
                    case 4:
                        NumberPair addpair = new NumberPair();
                        addpair.RandomInit();
                        printings[i] = addpair;
                        break;
                }
            }

            return printings;
        }

        static void Task3()
        {
            int arrlen = 10;

            Printing[] printings = CreateArrayPrintings(arrlen);
            
            Array.Sort(printings);

            Console.WriteLine("Сортировка по дате издания");
            ShowArray(printings);

            Console.WriteLine();

            
            Array.Sort(printings, new SortByName());

            Console.WriteLine("Сортировка по имени");
            ShowArray(printings);

            Console.WriteLine();

            Array.Sort(printings);
            string? buf = Console.ReadLine();

            if (int.TryParse(buf, out int targetYear))
                SearchBinnaryYear(printings, targetYear);

            Console.WriteLine();

            IInit[] initArray = CreateArrayIInit(arrlen);
            ShowArray(initArray);

            Console.WriteLine();
            Printing basePrinting = new Printing("Изначальная", 2000);

            Printing shallowCopy = basePrinting.ShallowCopy();
            Printing printingClone = (Printing) basePrinting.Clone();

            Console.WriteLine("Оригинал");
            basePrinting.Show();
            Console.WriteLine();

            Console.WriteLine("Поверхностная копия");
            shallowCopy.Show();
            Console.WriteLine();
            
            Console.WriteLine("Клон оригинала");
            printingClone.Show();
            Console.WriteLine();
        }
        
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }
    }
}
