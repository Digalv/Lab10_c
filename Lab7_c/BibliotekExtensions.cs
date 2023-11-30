using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab7_c
{
    public static class BibliotekExtensions
    {
        public class BibliotekSorter
        {
            public delegate bool CompareDelegate(Buch left, Buch right);

            public static Bibliotek SortByName(Bibliotek bibliotek)
            {
                return Sort(bibliotek, (b1, b2) => String.Compare(b1.Name, b2.Name, StringComparison.Ordinal) < 0);
            }

            public static Bibliotek SortByPages(Bibliotek bibliotek)
            {
                return Sort(bibliotek, (b1, b2) => b1.Pages < b2.Pages);
            }

            private static Bibliotek Sort(Bibliotek bibliotek, CompareDelegate compareDelegate)
            {
                if (bibliotek == null || bibliotek.BucherDict == null || bibliotek.BucherDict.Count == 0)
                {
                    throw new ArgumentNullException("В сортировку нужно подавать непустой объект bibliotek с непустым словарем");
                }

                List<Buch> buchList = new List<Buch>(bibliotek.BucherDict.Values);

                buchList.Sort((left, right) => compareDelegate(left, right) ? -1 : 1);

                Bibliotek sortedBibliotek = new Bibliotek();
                foreach (var buch in buchList)
                {
                    sortedBibliotek.AddBuch(buch);
                }

                return sortedBibliotek;
            }
            public static Bibliotek FilterByMinPages(Bibliotek bibliotek, int minPages)
            {
                if (bibliotek == null || bibliotek.BucherDict == null)
                {
                    throw new ArgumentNullException("В фильтрацию нужно подавать непустой объект bibliotek с непустым словарем");
                }

                IEnumerable<Buch> filteredBucher = bibliotek.BucherDict.Values.Where(buch => buch.Pages >= minPages);

                Bibliotek filteredBibliotek = new Bibliotek();
                foreach (var buch in filteredBucher)
                {
                    filteredBibliotek.AddBuch(buch);
                }

                return filteredBibliotek;
            }
        }
    }
}
