using Movie.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Web.Models
{
    public class MovieViewModel
    {
        [Required(ErrorMessage = "Please enter the movie name to search")]
        public string SearchPhrase { get; set; }

        public string JsonLDSummary { get; set; }
        public SearchResult SearchResult { get; set; }
        public string Message { get; set; }
    }
}
