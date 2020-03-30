using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Model.JsonLD
{
    public class Item
    {
        public string @type { get; set; } = "Movie";//@type
        public string url { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string dateCreated { get; set; }
        public Director director { get; set; }
        public Review review { get; set; }
        
    }
    public class Director
    {
        public string @type { get; set; } = "Person";//@type
        public string name { get; set; }
    }
    public class Review
    {
        public string @type { get; set; } = "Review"; //@type
        public ReviewRating reviewRating { get; set; }
        public Author author { get; set; }
        public string reviewBody { get; set; }
        public AggregateRating aggregateRating { get; set; }
    }
    public class ReviewRating
    {
        public string @type { get; set; } = "Rating"; //@type
        public string ratingValue { get; set; }
        
    }
    public class Author
    {
        public string @type { get; set; } = "Person";//@type
        public string name { get; set; }

    }

    public class AggregateRating
    {
        public string @type { get; set; } = "AggregateRating";//@type
        public string ratingValue { get; set; }
        public string bestRating { get; set; }
        public string ratingCount { get; set; }

    }

}
