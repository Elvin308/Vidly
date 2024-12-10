using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MoviesFormViewModel
    {
        public Movie Movie {  get; set; }
        public IEnumerable<Genre> Genre { get; set; }
    }
}