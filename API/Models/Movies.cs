using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Movies : IComparable
    {
        public string Director { get; set; }
        public double ImdbRating { get; set; }
        public string Genre { get; set; }
        public string ReleaseDate { get; set; } 
        public int RottenTomatoesRating { get; set; }
        public string Title { get; set; }

        public int CompareTo(object obj)
        {
            return Title.CompareTo(((Movies)obj).Title);
        }
    }
}
