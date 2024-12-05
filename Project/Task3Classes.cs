using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PrintingLibrary;

namespace Project
{
    internal class NumberPair : IInit
    {
        int first;
        int second;

        public int First
        {
            get { return first; }
            set { first = value; }
        }
      
        public int Second
        {
            get { return second; }
            set { second = value; }
        }

        public NumberPair()
        {
            first = 0;
            second = 0;
        }

        public NumberPair(int first, int second)
        {
            First = first;
            Second = second;
        }

        public NumberPair(NumberPair pair)
        {
            First = pair.First;
            Second = pair.Second;
        }

        public void Show()
        {
            Console.WriteLine("Пара: " + First + ", " + Second);
        }

        public void Init()
        {
            Console.WriteLine("Введите первое число: ");

            string? buf = Console.ReadLine();

            if (buf == null || !int.TryParse(buf, out int first))
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            Console.WriteLine("Введите второе число: ");

            buf = Console.ReadLine();

            if (buf == null || !int.TryParse(buf, out int second))
            {
                Console.WriteLine("Некорректный ввод");
                throw new ArgumentException();
            }

            First = first;
            Second = second;
        }

        public void RandomInit()
        {
            Random rnd = new Random();

            int first = rnd.Next(0, 21);
            int second = rnd.Next(-10, 11);

            First = first;
            Second = second;
        }

    }
}
