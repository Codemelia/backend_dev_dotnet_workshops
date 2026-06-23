using AdoSqlWorkshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace AdoSqlWorkshop.Controllers
{
    public class LecturerController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        // IConfiguration is automatically provided by the .NET DI container
        public LecturerController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        // Lecturers page
        public IActionResult Index()
        {
            List<Lecturer> lecturers = [];

            using (SqlConnection conn = new(connectionString))
            {

                conn.Open();

                string sqll = @"SELECT * FROM Lecturers";
                SqlCommand cmdl = new(sqll, conn);
                SqlDataReader rdrl = cmdl.ExecuteReader();

                while (rdrl.Read())
                {
                    Lecturer lecturer = parseToLecturer(rdrl);
                    lecturers.Add(lecturer);
                }

                conn.Close();

            }

            return View("Lecturers", lecturers);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Helper to parse lecturer
        private Lecturer parseToLecturer(SqlDataReader reader)
        {
            return new Lecturer() // Map returned data to course model
            {
                Id = Convert.ToInt32(reader["Id"]),
                FirstName = Convert.ToString(reader["FirstName"]),
                LastName = Convert.ToString(reader["LastName"]),
                Username = Convert.ToString(reader["Username"])
            };
        }
    }

}
