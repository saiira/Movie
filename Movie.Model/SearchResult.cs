using System;
using System.Collections.Generic;

namespace Movie.Model
{
    public class SearchResult
    {
       public Movie[] Search { get; set; }
       public int totalResults { get; set; }
       public bool Response { get; set; }
    
       
    }
}
