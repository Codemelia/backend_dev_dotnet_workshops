using AdoSqlWorkshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace AdoSqlWorkshop.Controllers
{
    public class CourseController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        // IConfiguration is automatically provided by the .NET DI container
        public CourseController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        // Handles index page - displays list of courses
        public IActionResult Index(int? lectId)
        {
            List<Course> courses = [];
            CoursesByLecturerViewModel vm = new();

            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();

                if (lectId is not null && lectId >= 0)
                {
                    string sqll = @"
                    SELECT Id, FirstName, LastName, Username
                    FROM Lecturers
                    WHERE Id = @LectId";

                    using (SqlCommand cmdl = new(sqll, conn))
                    {
                        cmdl.Parameters.AddWithValue("@LectId", lectId.Value);

                        using (SqlDataReader rdrl = cmdl.ExecuteReader())
                        {
                            if (rdrl.Read())
                            {
                                vm.Lecturer = parseToLecturer(rdrl);
                            }
                        }
                    }
                }

                string sqlc = @"
                    SELECT c.Id, c.Code, c.Name, c.Description
                    FROM Courses c";

                if (lectId is not null && lectId >= 0)
                {
                    sqlc += @"
                        INNER JOIN LecturerCourses lc
                            ON c.Id = lc.CourseId
                        WHERE lc.LecturerId = @LectId";
                }

                using (SqlCommand cmdc = new(sqlc, conn))
                {
                    if (lectId is not null && lectId >= 0)
                    {
                        cmdc.Parameters.AddWithValue("@LectId", lectId.Value);
                    }

                    using (SqlDataReader rdrc = cmdc.ExecuteReader())
                    {
                        while (rdrc.Read())
                        {
                            Course course = parseToCourse(rdrc);
                            courses.Add(course);
                        }
                    }
                }
            }

            vm.Courses = courses;

            return View("Courses", vm);
        }

        // indiv course details view
        public IActionResult Details(int id)
        {
            // New course (empty)
            Course course = new Course();

            // Use sql connection to retrieve course
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();

                string sql = "SELECT * FROM Courses WHERE Id = @Id";

                SqlCommand cmd = new(sql, conn);

                SqlParameter idParam = new()
                {
                    ParameterName = "@Id",
                    Value = id
                };
                cmd.Parameters.Add(idParam); // Add variable Id to SQL query

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    course = parseToCourse(reader);
                }

                conn.Close();

            }

            return View("Details", course);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Helper to parse course
        private Course parseToCourse(SqlDataReader reader)
        {
            return new Course()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Code = Convert.ToString(reader["Code"]),
                Name = Convert.ToString(reader["Name"]),
                Description = Convert.ToString(reader["Description"])
            };
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
