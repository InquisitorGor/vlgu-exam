using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.src
{
    class Tour
    {
        private string destination;
        private int durationInHours;
        private decimal price;

        public Tour(string destination, int durationInHours, decimal price)
        {
            this.destination = destination;
            this.durationInHours = durationInHours;
            this.price = price;
        }

        public Tour()
        {
        }

        public string Destination { get => destination; set => destination = value; }
        public int DurationInHours { get => durationInHours; set => durationInHours = value; }
        public decimal Price { get => price; set => price = value; }

        public override string ToString()
        {
            return "Destination: " + destination + " duration (in hours): " + durationInHours + " price: " + price;
        }
    }
}
