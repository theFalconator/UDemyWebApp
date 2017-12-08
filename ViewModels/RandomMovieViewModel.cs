using System.Collections.Generic;
using UDemyWebApplication.Models;

namespace UDemyWebApplication.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer>  Customers { get; set; }
    }
}