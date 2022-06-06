using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dockerdemocrud.Models
{
    public class Movie
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Actors { get; set; }
    }

    public class Movies
    {
        public int mid { get; set; }
        public string mname { get; set; }
        public string mdescription  { get; set; }
        public string mactors { get; set; }
    }
}
