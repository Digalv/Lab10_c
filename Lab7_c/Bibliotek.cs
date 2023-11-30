using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_c
{
    public class Bibliotek
    {
        Dictionary<int, Buch> bucherDict = new Dictionary<int, Buch>();


        public Dictionary<int, Buch> BucherDict
        {
            get => bucherDict;
            set => bucherDict = value;
        }
        public void AddBuch(Buch neuBuch)
        {
            if (neuBuch is not null)
            {
                if (!bucherDict.ContainsKey(neuBuch.Id))
                {
                    bucherDict.Add(neuBuch.Id, neuBuch);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Dieses Buch ist im Dictionary");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Not valid Buch");
            }
        }
        public void RemoveBuch(int id)
        {
            if (bucherDict.ContainsKey(id))
            {
                bucherDict.Remove(id);
            }
            else { throw new ArgumentOutOfRangeException("Incorrect id"); }
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var buch in bucherDict)
            {
                str.Append(buch + "\n");
            }
            return str.ToString();
        }
    }
}
