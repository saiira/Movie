using Movie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Web.Models
{
    public class MovieDetailViewModel
    {
       

        public string JsonLDMovie { get; set; }
        public MovieDetail MovieDetail { get; set; }
        public string Message { get; set; }
    }
}
