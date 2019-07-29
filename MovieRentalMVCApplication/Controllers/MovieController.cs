using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalMVCApplication.Models;
using System.Data.Entity;
using MovieRentalMVCApplication.ViewModel;

namespace MovieRentalMVCApplication.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext _context;
        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();//eager loading

            return View(movies);
        }
        public MovieController()
        {

            _context = new ApplicationDbContext();

        }


        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        
        public ActionResult Details(int? id)
        {


            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
        public ActionResult Edit(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("New", viewModel);
        }

        // GET: Movie

        public ActionResult New()
        {

            var genre = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = _context.Genres.ToList()
            };


            return View(viewModel);
        }
             [HttpPost]
       public ActionResult Save(Movie movie)
       {
            //_context.SaveChanges();//link to entity
            //    //return RedirectToAction("Index", "Customer");
            //if (ModelState.IsValid)
            //{
            //    var viewModel = new NewMovieViewModel
            //    {
            //        Movie = movie,
            //        Genres = _context.Genres.ToList()
            //};

            //    return View("new", viewModel);
            //}

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
              var movieindb = _context.Movies.Single(c => c.Id == movie.Id);
                movieindb.MovieName = movie.MovieName;
                movieindb.DateAdded = movie.DateAdded;
                movieindb.GenreId = movie.GenreId;
               movieindb.DateReleased = movie.DateReleased;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
          }


           //public actionresult delete(int? id)
           //{
           //     customer customer = _context.customers.find(id);
           //     _context.customers.remove(customer);
               
           //   return redirecttoaction("index");

        }
    }

