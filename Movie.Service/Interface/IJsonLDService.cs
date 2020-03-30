using Movie.Model;
using Movie.Model.JsonLD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Service.Interface
{
    public interface IJsonLDService
    {
        string CreateJsonLDSummary(SearchResult searchResult);
        string CreateJsonLDMovie(MovieDetail movieDetail);
    }
}
