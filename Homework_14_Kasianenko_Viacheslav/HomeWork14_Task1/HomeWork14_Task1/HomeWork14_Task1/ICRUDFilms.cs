using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork14_Task1
{
    public interface ICRUDFilms
    {
        public Task CreateFilm(Film film);
        public Task<Film> ReadFilmByName(string nameFilm);
        public Task<List<Film>> ReadFilms();
        public Task UpdateFilm(string nameChangeFilm,Film film);
        public Task DeleteFilm(Film film);
    }
}
