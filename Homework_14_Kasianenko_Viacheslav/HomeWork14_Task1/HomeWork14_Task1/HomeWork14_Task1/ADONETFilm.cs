using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeWork14_Task1
{
    public class ADONETFilm : ICRUDFilms
    {
        private string connectionString = @"Data Source=HOME-PC\SQLEXPRESS01;Initial Catalog=CinemaSigmaUA;Integrated Security=True";
        public async Task CreateFilm(Film film)
        {
            string sqlExpression = "INSERT INTO Films (GuidFilm, NameFilm, YearFilm) VALUES (default,@NameFilm, @YearFilm)";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlExpression,connection);
            SqlParameter nameParam = new SqlParameter("@NameFilm", film.NameFilm);

            SqlParameter dateParam = new SqlParameter("@YearFilm",System.Data.SqlDbType.Date);
            dateParam.Value = film.Date;

            command.Parameters.Add(nameParam);
            command.Parameters.Add(dateParam);

            command.Connection = connection;
            try
            {
                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException ex)
            {
                throw new ArgumentException("Couldn`t create");
            }
            finally
            {
                connection.Close();
            }
        }

        public async Task DeleteFilm(Film film)
        {
            string sqlExpression = "DELETE FROM Films WHERE NameFilm = @NameFilm AND YearFilm = @YearFilm";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            SqlParameter nameParam = new SqlParameter("@NameFilm", film.NameFilm);

            SqlParameter dateParam = new SqlParameter("@YearFilm", System.Data.SqlDbType.Date);
            dateParam.Value = film.Date;

            command.Parameters.Add(nameParam);
            command.Parameters.Add(dateParam);

            command.Connection = connection;
            try
            {
                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException ex)
            {
                throw new ArgumentException("Couldn`t delete");
            }
            finally
            {
                connection.Close();
            }
        }

        public async Task<Film> ReadFilmByName(string nameFilm)
        {
            string sqlExpression = "SELECT * FROM Films WHERE NameFilm = @NameFilm";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            SqlParameter nameParam = new SqlParameter("@NameFilm", nameFilm);

            command.Parameters.Add(nameParam);

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader =  await command.ExecuteReaderAsync();

                await reader.ReadAsync();

                return new Film((Guid)reader.GetValue(0), (string)reader.GetValue(1), (DateTime)reader.GetValue(2));
            }
            catch (SqlException ex)
            {
                throw new ArgumentException("Couldn`t read");
            }
            finally
            {
                connection.Close();
            }
        }

        public async Task<List<Film>> ReadFilms()
        {
            string sqlExpression = "SELECT * FROM Films";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                List<Film> list = new List<Film>();

                while (reader.Read())
                {
                    list.Add(new Film((Guid)reader.GetValue(0), (string)reader.GetValue(1), (DateTime)reader.GetValue(2)));
                }

                return list;
            }
            catch (SqlException ex)
            {
                throw new ArgumentException("Couldn`t read");
            }
            finally
            {
                connection.Close();
            }
        }

        public async Task UpdateFilm(string nameChangeFilm,  Film film)
        {
            string sqlExpression = "Update Films set NameFilm= @NameFilm, YearFilm = @YearFilm WHERE GuidFilm = (SELECT TOP(1) GuidFilm From Films where NameFilm = @NameFilmChange)";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter nameChange = new SqlParameter("@NameFilmChange", nameChangeFilm);

            SqlParameter nameParam = new SqlParameter("@NameFilm", film.NameFilm);

            SqlParameter dateParam = new SqlParameter("@YearFilm", System.Data.SqlDbType.Date);
            dateParam.Value = film.Date;

            command.Parameters.Add(nameParam);
            command.Parameters.Add(dateParam);
            command.Parameters.Add(nameChange);


            command.Connection = connection;
            try
            {
                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException ex)
            {
                throw new ArgumentException("Couldn`t Update");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
