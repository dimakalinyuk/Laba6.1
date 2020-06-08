using System;
using System.Collections;

namespace Dima_OOP_6
{
    class Metereology : IComparable
    {
        public DateTime date;
        public float temp;
        public float tisk;
        public Metereology(DateTime date, float temp, float tisk)
        {
            this.date = date;
            this.temp = temp;
            this.tisk = tisk;
        }
        public int CompareTo(object pers)
        {
            Metereology p = (Metereology)pers;
            if (this.temp < p.temp) return 1;
            if (this.temp > p.temp) return -1; return 0;
        }
        public void info()
        {
            Console.WriteLine("{0, -15}{1, -10}{2, -15}", date.ToShortDateString(), temp, tisk);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть кількість днів: ");
            int n = int.Parse(Console.ReadLine());
            Metereology[] m = new Metereology[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Дата: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Температура: ");
                float temp = float.Parse(Console.ReadLine());
                Console.Write("Тиск: ");
                float tisk = float.Parse(Console.ReadLine());
                m[i] = new Metereology(date, temp, tisk);
            }
            Array.Sort(m);
            foreach (Metereology elem in m) elem.info();

            float max1 = 0;
            int index = 0;

            for (int i = 0; i < n; i++)
            {
                if (i != 0)
                {
                    if ((m[i].temp - m[i - 1].temp) > max1)
                    {
                        max1 = m[i].temp - m[i - 1].temp;
                        index = i;

                    }
                }
            }

            Console.WriteLine("два дні з найбільшим перепадом температури повітря\n");
            Console.WriteLine("{0, -15}{1, -10}{2, -15}", m[index - 1].date.ToShortDateString(), m[index - 1].temp, m[index - 1].tisk);
            Console.WriteLine("{0, -15}{1, -10}{2, -15}", m[index].date.ToShortDateString(), m[index].temp, m[index].tisk);

        }
    }
}
