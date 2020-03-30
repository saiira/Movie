using Movie.Model;
using Movie.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Json;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace Movie.Service
{
    public class MovieService : IMovieService
    {
        readonly IHttpService _httpService;
        readonly MovieSettings _settings;
        public MovieService(IHttpService httpService, IOptions<MovieSettings> optionsAccessor)
        {
            _httpService = httpService;
            _settings = optionsAccessor.Value;
        }
        public SearchResult GetSearchResult(string searchPhrase)
        {
            try
            {
                string url = $@"{_settings.OmdbApiUrl}/?apiKey={_settings.OmdbApiKey}&s={searchPhrase.ToString().Trim()}";
                // $@"http://www.omdbapi.com/?apikey=51a1993c&s={searchPhrase.ToString().Trim()}"; // in appsetttings
                string jsonResult = _httpService.GetHttpResponse(url);
                SearchResult  searchResult=  JsonConvert.DeserializeObject<SearchResult>(jsonResult);
                return searchResult;
                //http://www.omdbapi.com/?apikey=51a1993c&s=Avengers
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public MovieDetail GetMovieDetail(string imdbID)
        {
            try
            {
                string url = $@"{_settings.OmdbApiUrl}/?apiKey={_settings.OmdbApiKey}&i={imdbID.ToString().Trim()}";
              //  string url = "http://www.omdbapi.com/?apikey=51a1993c&i=tt4154756"; // in appsetttings
                string jsonResult = _httpService.GetHttpResponse(url);
                MovieDetail movieDetail = JsonConvert.DeserializeObject<MovieDetail>(jsonResult);
                return movieDetail;
                
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
    }
}
