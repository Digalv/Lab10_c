using System;
using System.Threading.Tasks;

namespace Lab7_c
{
    public class ParallelArrayProcessing
    {
        public static void FillArrayParallel(Buch[] array, int start, int end)
        {
            Parallel.For(start, end, i =>
            {
                
                Random rand = new Random();
                array[i] = new Buch(
                    $"Name{i}",
                    $"Author",
                    rand.Next(1, 1000),
                    rand.Next(1, 1000000)
                );
            });
        }

        public static void ParallelSort(Buch[] array, string sortByField, int numThreads)
        {
            
            int chunkSize = array.Length / numThreads;
            Task[] tasks = new Task[numThreads];

            for (int i = 0; i < numThreads; i++)
            {
                int start = i * chunkSize;
                int end = (i == numThreads - 1) ? array.Length : (i + 1) * chunkSize;

                tasks[i] = Task.Factory.StartNew(() =>
                {
                    Array.Sort(array, start, end - start, Comparer<Buch>.Create((x, y) => Compare(x, y, sortByField)));
                });
            }

            
            Task.WaitAll(tasks);
        }

        private static int Compare(Buch x, Buch y, string sortByField)
        {
            switch (sortByField)
            {
                case "Name":
                    return string.Compare(x.Name, y.Name);
                case "Author":
                    return string.Compare(x.Author, y.Author);
                case "Pages":
                    return x.Pages.CompareTo(y.Pages);
                case "Id":
                    return x.Id.CompareTo(y.Id);
                default:
                    throw new ArgumentException("Invalid field for sorting.");
            }
        }
    }
}
