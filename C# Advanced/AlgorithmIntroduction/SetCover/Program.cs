using System;

namespace SetCover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            List<int[]> list = new List<int[]> { array };
            List<int> ints= new List<int> {3, 4 };
            
        }
        static List<int[]> ChooseSets(List<int[]> sets, List<int> universe)
        {
            List<int[]> selectedSets = new List<int[]>();
            while (universe.Count > 0)
            {
                int[] current = sets.OrderByDescending(set => set.Count(universe.Contains)).First();
                selectedSets.Add(current);
                sets.Remove(current);

                foreach (var item in current)
                {
                    universe.Remove(item);
                }
            }
            return selectedSets;
        }
    }
}