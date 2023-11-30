using Lab7_c;
using static Lab7_c.BibliotekExtensions;
using static System.Formats.Asn1.AsnWriter;

internal class Program
{
    private static void Main(string[] args)
    {
        Buch[] books = new Buch[1000000];

       
        ParallelArrayProcessing.FillArrayParallel(books, 0, books.Length);

        
        Console.WriteLine("First few books:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(books[i]);
        }

        
        ParallelArrayProcessing.ParallelSort(books, "Id", 4);

        
        Console.WriteLine("--------------------------------------------");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(books[i]);
        }
    }
}