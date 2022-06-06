using dockerdemocrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

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
        public List<Movies> getMovieList()
        {
            //var m = "a";//we need to return list of movie 

            //for (int i = 0; i < 25; i++)
            //{
            //    Movie movie = new Movie();
            //    movie.Id = i.ToString() + 1;
            //    movie.Name = "ABCD"+i;
            //    movie.Actors = "Don't know"+i;
            //    movies.Add(movie);
            //}
            //return movies;

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                DataTable dtbl = new DataTable();
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("getMovie", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dtbl);
                for (int i = 0; i < dtbl.Rows.Count; i++)
                {



                    Movies movie = new Movies();
                    movie.mid = Convert.ToInt32(dtbl.Rows[i]["mid"]);
                    movie.mname = dtbl.Rows[i]["mname"].ToString();
                    movie.mdescription = dtbl.Rows[i]["mdescription"].ToString();
                    movie.mdescription = dtbl.Rows[i]["mactors"].ToString();

                    movieslist.Add(movie);

                }
            }
                
            return movieslist;

            
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
