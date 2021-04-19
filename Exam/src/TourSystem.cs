using Exam.src;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Exam
{
    class TourSystem
    {
        private Tour[] tours;
        private int size;

        public int Size { get => size; set => size = value; }
        internal Tour[] Tours { get => tours; set => tours = value; }

        static void Main(string[] args)
        {
            TourSystem tourSystem = new TourSystem();
            Console.WriteLine("Input array size: ");
            string size = Console.ReadLine();
            while (!Int32.TryParse(size, out tourSystem.size))
            {
                Console.WriteLine("Incorrect size. Input a number: ");
                size = Console.ReadLine();
            }
            tourSystem.Tours = new Tour[tourSystem.size];
            for(int i = 0; i < tourSystem.size; i++)
            {
                Console.WriteLine((i + 1) + " tour");
                Console.WriteLine("Input destination: ");
                string destination = Console.ReadLine();
                while(destination == null || destination == "")
                {
                    Console.WriteLine("Incorrect input type. Input destination:");
                    destination = Console.ReadLine();
                }
                Console.WriteLine("Input duration (in hours): ");
                int durationInHours;
                while (!Int32.TryParse(Console.ReadLine(), out durationInHours))
                {
                    Console.WriteLine("Incorrect input type. Input duration (in hours):");
                }
                Console.WriteLine("Input price: ");
                decimal price;
                while (!Decimal.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("Incorrect input type. Input price:");
                }
                tourSystem.Tours[i] = new Tour(destination, durationInHours, price);
            }
            Console.WriteLine("Array sorting ... Done: ");
            tourSystem.sortArray();
            Console.WriteLine("Saving array to file ");
            tourSystem.saveToFile();

        }
        public void sortArray()
        {
            tours = tours.AsQueryable<Tour>().OrderByDescending(tour => tour.DurationInHours).ThenByDescending(tour => tour.Price).ToArray();
        }
        public void saveToFile()
        {
            using (StreamWriter writer = new StreamWriter("D:\\Users\\stu-pksp117\\source\\repos\\Exam\\Exam\\src\\tours.txt"))
            {
                for (int i = 0; i < size; i++)
                {
                    writer.WriteLine(tours[i].ToString());
                }
            }

        }

    }
}
