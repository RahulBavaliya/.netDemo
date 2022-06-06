using dockerdemocrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dockerdemocrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly String connectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        List<Movie> movies = new List<Movie>();
        List<Movies> movieslist = new List<Movies>();

        public IActionResult Index()
        {
            //context.Movie.ToList();
            var m = "a";//we need to return list of movie 

            for(int i = 0; i < 25; i++)
            {
                Movie movie = new Movie();
                movie.Id = i.ToString()+1;
                movie.Name = "ABCD";
                movie.Actors = "Don't know";
                movies.Add(movie);
            }
            



            var m1 = movies.ToList();

            return View(m1);
        }

        [HttpGet]
        [Route("home/getMovieList")]
        public List<Movie> getMovieList()
        {
            var m = "a";//we need to return list of movie 

            for (int i = 0; i < 25; i++)
            {
                Movie movie = new Movie();
                movie.Id = i.ToString() + 1;
                movie.Name = "ABCD"+i;
                movie.Actors = "Don't know"+i;
                movies.Add(movie);
            }
            return movies;




            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                  
                    Movies movie = new Movies();
                    movie.mid = Convert.ToInt32(rdr["mid"]);
                    movie.mname = rdr["mname"].ToString();
                    movie.mdescription = rdr["mdescription"].ToString();
                    movie.mdescription = rdr["mactors"].ToString();

                    movieslist.Add(movie);
                }
            }

        }


        [HttpPost]
        [Route("home/sendData")]
        public List<Movie> sendData([FromBody()] Movie movie1)
        {
            var m = movie1;//we need to return list of movie 
            for (int i = 0; i < 25; i++)
            {
                Movie movie = new Movie();
                movie.Id = i.ToString() + 1;
                movie.Name = "ABCD" + i;
                movie.Actors = "Don't know" + i;
                movies.Add(movie);
            }

            movies.Add(movie1);
            return movies;
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


       

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie m)
        {
            if (ModelState.IsValid)
            {
                // we need to pass as a parameter as movie object m
                //Add new data into db using sp or qeury
                movies.Add(m);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

       
        public IActionResult Update(int id)
        {
            //var pc = context.Movie.Where(a => a.Id == id).FirstOrDefault();
            var pc = "sdf";//we need to update movie object data in db 
            return View(pc);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Movie m)
        {
            if (ModelState.IsValid)
            {
                
                var pc = "sdf";//we need to update movie object data in db 

                return RedirectToAction("Index");
            }
            else
                return View(m);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            //var pc = context.Movie.Where(a => a.Id == id).FirstOrDefault();
            //context.Remove(pc);
            //await context.SaveChangesAsync();

            //we need to delete data from db where id 

            return RedirectToAction("Index");
        }
    }
}
