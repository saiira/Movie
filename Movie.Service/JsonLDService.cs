using Movie.Model;
using Movie.Model.JsonLD;
using Movie.Service.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Service
{
    public class JsonLDService : IJsonLDService
    {
        public string CreateJsonLDSummary(SearchResult searchResult)
        {
            StructuredData structuredData = new StructuredData();
            
            List<ItemListElement> itemListElements = new List<ItemListElement>();
            int itemElementCounter = 0;
            foreach (var movie in searchResult.Search)
            {
                Item item = new Item();
                item.name = movie.Title;
                item.image = movie.Poster;

                ItemListElement itemListElement = new ItemListElement();
                itemListElement.position = (itemElementCounter++).ToString();
                itemListElement.item = item;

                itemListElements.Add(itemListElement);

            }
            structuredData.itemListElement = itemListElements;

            string jsonLD = JsonConvert.SerializeObject(structuredData);
            return jsonLD;

        }

        public string CreateJsonLDMovie(MovieDetail movieDetail)
        {
         // return string.Empty;
           
            StructuredData structuredData = new StructuredData();

            List<ItemListElement> itemListElements = new List<ItemListElement>();
            int itemElementCounter = 0;
          //  foreach (var movie in movieDetail)
            {
                Item item = new Item();
                item.name = movieDetail.Title;
                item.image = movieDetail.Poster;
                item.dateCreated = movieDetail.Released;
               
                Director director = new Director();
                director.name = movieDetail.Director;
                item.director = director;

                Review review = new Review();

                ReviewRating reviewRating = new ReviewRating();
                reviewRating.ratingValue = movieDetail.Ratings[0].Value;
                review.reviewRating = reviewRating;

                Author author = new Author();
                author.name = movieDetail.Writer;
                review.author = author;

                review.reviewBody = movieDetail.Response;

                AggregateRating aggregateRating = new AggregateRating();
                aggregateRating.bestRating = movieDetail.Ratings[0].Value;
                aggregateRating.ratingValue = movieDetail.Rated;
                aggregateRating.ratingCount = movieDetail.Ratings.Length.ToString();
                review.aggregateRating = aggregateRating;

                item.review = review;

                
            

                ItemListElement itemListElement = new ItemListElement();
                itemListElement.position = (itemElementCounter++).ToString();
                itemListElement.item = item;

                itemListElements.Add(itemListElement);

            }
            structuredData.itemListElement = itemListElements;

            string jsonLD = JsonConvert.SerializeObject(structuredData);
            return jsonLD;
           

        }
    }
}
