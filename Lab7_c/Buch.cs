using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_c
{
    public class Buch
    {
        private string _name;
        private string _author;
        private int _pages;
        public int _id;


        public Buch(string name, string author, int pages, int id)
        {
            Name = name;
            Author = author;
            Pages = pages;
            Id = id;
        }

        public string Name
        {
            get { return _name; }
            init
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value.Trim();
                }
                else
                {
                    throw new ArgumentNullException("Incorrect name.");
                }
            }
        }
        public string Author
        {
            get { return _author; }
            init
            {
                if (!string.IsNullOrEmpty(value))
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (Char.IsNumber(value[i]))
                        {
                            throw new ArgumentNullException("Incorrect author.");
                        }
                    }
                    _author = value.Trim();
                }
                else
                {
                    throw new ArgumentNullException("Incorrect author.");
                }
            }
        }
        public int Pages
        {
            get { return _pages; }
            init
            {
                if (value > 0)
                {
                    _pages = value;
                }
                else
                {
                    throw new ArgumentNullException("Incorrect count of pages.");
                }
            }
        }
        public int Id
        {
            get { return _id; }
            init
            {
                if (value > 0)
                {
                    _id = value;
                }
                else
                {
                    throw new ArgumentNullException("Incorrect count of pages.");
                }
            }
        }
        public override string ToString()
        {
            return $"\nName: {Name}\n" +
                   $"Id: {Id}\n" +
                   $"Author: {Author}\n" +
                   $"Pages: {Pages}\n";
        }
    }
}
