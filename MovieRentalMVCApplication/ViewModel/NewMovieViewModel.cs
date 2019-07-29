using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalMVCApplication.Models;

namespace MovieRentalMVCApplication.ViewModel
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres{ get; set; }//better the to list can bring all the data inside 
        public Movie Movie { get; set; }
    }
}