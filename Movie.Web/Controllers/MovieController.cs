using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movie.Model;
using Movie.Service.Interface;
using Movie.Web.Models;

namespace Movie.Web.Controllers
{
    public class MovieController : Controller
    {
        readonly IMovieService _movieService;
        readonly IJsonLDService _jsonLDService;

        public MovieController(IMovieService movieService, IJsonLDService jsonLDService)
        {
            _movieService = movieService;
            _jsonLDService = jsonLDService;
        }
        public IActionResult Index()
        {
            return View("~/Views/Movie/Search.cshtml");
        }
        public IActionResult Search(string s)
        {
           if(string.IsNullOrEmpty(s))
            {
                return View("~/Views/Movie/Search.cshtml");
            }
           else
            {
                MovieViewModel movieViewModel =  SearchMovie(s);
                
                return View("~/Views/Movie/Search.cshtml", movieViewModel);
            }
            
        }

        [HttpPost]
        public IActionResult Search(MovieViewModel movieViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    movieViewModel.Message = "Error : ";
                    var modelErrors = new List<string>();
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var modelError in modelState.Errors)
                        {
                            modelErrors.Add(modelError.ErrorMessage);
                        }
                    }
                    foreach (string s in modelErrors)
                    {
                        movieViewModel.Message += $"\n\n{s}<br/>";
                    }

                    return View("~/Views/Movie/Search.cshtml", movieViewModel);
                }
                movieViewModel = SearchMovie(movieViewModel.SearchPhrase);
                /*
                SearchResult searchResult = _movieService.GetSearchResult(movieViewModel.SearchPhrase);
                if ((searchResult != null) && (searchResult.Search.Count() > 0))
                {
                    string jsonLD = _jsonLDService.CreateJsonLDSummary(searchResult);
                    movieViewModel.JsonLDSummary = jsonLD;
                    movieViewModel.SearchResult = searchResult;
                }
                */
            }
            catch (Exception ex)
            {

            }
            return View("~/Views/Movie/Search.cshtml", movieViewModel);
        }

        public IActionResult GetMovieDetail(string imdbID)
        {
            try
            {
                MovieDetailViewModel movieDetailViewModel = new MovieDetailViewModel();
                if (string.IsNullOrEmpty(imdbID))
                {
                    MovieViewModel movieViewModel = new MovieViewModel();
                    movieViewModel.Message = "Please try clicking the link again";// could be user remove the imdID from url
                    return View("~/Views/Movie/Search.cshtml", movieViewModel);
                }
                imdbID = imdbID.Trim();
                MovieDetail movieDetail = _movieService.GetMovieDetail(imdbID);
                if (movieDetail != null)
                {
                    string jsonLD = _jsonLDService.CreateJsonLDMovie(movieDetail);
                    movieDetailViewModel.JsonLDMovie = jsonLD;
                    movieDetailViewModel.MovieDetail = movieDetail;
                }
                else
                {
                    movieDetailViewModel.Message = "There is some error. Please try again later";
                }

                return View("~/Views/Movie/Detail.cshtml", movieDetailViewModel);
            }
            catch (Exception ex)
            {

            }
            return View("~/Views/Movie/Detail.cshtml", null);
        }

        private MovieViewModel SearchMovie(string movieSearchPhrase)
        {
            try
            {
                if(string.IsNullOrEmpty(movieSearchPhrase))
                {
                    return null;
                }
                MovieViewModel movieViewModel = new MovieViewModel();
                movieViewModel.SearchPhrase = movieSearchPhrase;
                SearchResult searchResult = _movieService.GetSearchResult(movieSearchPhrase);
                if ((searchResult != null) && (searchResult.Search.Count() > 0))
                {
                    string jsonLD = _jsonLDService.CreateJsonLDSummary(searchResult);
                    movieViewModel.JsonLDSummary = jsonLD;
                    movieViewModel.SearchResult = searchResult;
                    return movieViewModel;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}