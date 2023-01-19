namespace HomeWork14_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICRUDFilms crud = new ADONETFilm();

            //crud.CreateFilm(new Film("LL",DateTime.Now));

            //crud.DeleteFilm(new Film("LL", DateTime.Now));

            //Film? film = crud.ReadFilmByName("Зоряні війни: Прихована загроза").Result;
            //Console.WriteLine("{0} {1} {2}", film.Guid, film.NameFilm, film.Date);

            //crud.UpdateFilm("Зоряні війни: Прихована загроза", new Film("Зоряні війни: Бракована партія", DateTime.Parse("2022-02-20")));

            //List<Film> list = crud.ReadFilms().Result;

            //foreach (Film film in list)
            //{
            //    Console.WriteLine("{0} {1} {2}", film.Guid, film.NameFilm, film.Date);
            //}
        }
    }
}