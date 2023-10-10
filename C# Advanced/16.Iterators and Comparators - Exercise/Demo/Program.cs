using System;
using System.Collections;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CustomHallEnumerator enumerator = new(new List<int> { 1, 2, 3 });
            //while(enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //}
            CustomHall seats = new(new List<int> { 1, 2, 3 });
            foreach (var seat in seats)
            {
                Console.WriteLine(seat);
            }
        }
    }
    class CustomHall : IEnumerable<int>
    {
        private List<int> seats;

        public CustomHall(List<int> seats)
        {
            this.seats = seats;
        }

        public IEnumerator<int> GetEnumerator()
        {
            //return new CustomHallEnumerator(seats);
            //foreach (var seat in seats)
            //{
            //    yield return seat;
            //}
            for (int i = seats.Count - 1; i >= 0; i--)
            {
                yield return seats[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class CustomHallEnumerator : IEnumerator<int>
    {
        private List<int> seats;
        private int index = -1;

        public CustomHallEnumerator(List<int> seats)
        {
            this.seats = seats;
        }
        public int Current => seats[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            index++;
            return index < seats.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}