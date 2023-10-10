namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> collection = new List<int>() { 1, 2, 3, 4, 5 };

            IEnumerator<int> enumerator = collection.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            ForEach(item => Console.WriteLine($"Foreaching {item}"), collection);
        }
        static void ForEach<T>(Action<T> callback, IEnumerable<T> collection)
        {
            IEnumerator<T> enumerator = collection.GetEnumerator();

            while (enumerator.MoveNext())
            {
                callback(enumerator.Current);
            }
        }
    }
}