using Movie.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Service.Interface
{
    public interface IMovieService
    {
        SearchResult GetSearchResult(string searchPhrase);
        MovieDetail GetMovieDetail(string imdbID);
    }
}
