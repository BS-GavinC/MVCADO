using Microsoft.AspNetCore.Mvc;
using MVCADO.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVCADO.Controllers
{
    public class FilmController : Controller
    {

        string connectionString = "Server=localhost\\SQLEXPRESS;Database=FilmDb;Trusted_Connection=True;";

        public IActionResult Index()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SELECT * FROM film";

            List<Film> films = new List<Film>();

            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {

                Film film = new Film();
                film.Id = (int)reader["id"];
                film.Name = (string)reader["name"];
                film.Release = (DateTime)reader["release"];
                film.Real = (string)reader["real"];

                films.Add(film);

            }



            sqlConnection.Close();

            return View(films);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Film film)
        {
            if (!ModelState.IsValid)
            {
                return View(film);
            }

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "INSERT INTO film(id, name, release, real) VALUES(@id, @name, @release, @real)";

            sqlCommand.Parameters.AddWithValue("@id", film.Id);

            sqlCommand.Parameters.AddWithValue("@name", film.Name);

            sqlCommand.Parameters.AddWithValue("@release", film.Release);

            sqlCommand.Parameters.AddWithValue("@real", film.Real);

            int result;

            sqlConnection.Open();

            result = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (result == 0)
            {
                ModelState.AddModelError("Custom", "Ca a pete");
                return View(film);
            }

            return RedirectToAction("Index");

            
        }

        
    }
}
