using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Movies
    {
        string Director { get; set; }
        double ImdbRating { get; set; }
        string Genre { get; set; }
        string ReleaseDate { get; set; } //Verify the dataType
        int RottenTomatoesRating { get; set; }
        string Title { get; set; }
    }
}
