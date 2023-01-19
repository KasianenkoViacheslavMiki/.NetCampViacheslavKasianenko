using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork14_Task1
{
    public class Film
    {
        string nameFilm;
        DateTime date;

        public Film(string nameFilm, DateTime date)
        {
            NameFilm = nameFilm;
            Date = date;
        }

        public Film(Guid guid, string nameFilm, DateTime date)
        {
            Guid = guid;
            NameFilm = nameFilm;
            Date = date;
        }

        public Guid Guid { get; set; }

        public string NameFilm { get => nameFilm; set => nameFilm = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
