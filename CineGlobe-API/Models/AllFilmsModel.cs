using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGlobe_API.Models
{
    public class AllFilmsModel
    {
        public AllFilmsModel(DateTime releasedate, string title, string overview, string popularity, 
                        string vote_count, string vote_average, string original_language, string genre, string poster_url)
        {
            ReleaseDate = releasedate;
            Title = title;
            Overview = overview;
            Popularity = popularity;
            VoteCount = vote_count;
            VoteAverage = vote_average;
            OriginalLanguage = original_language;
            Genre = genre;
            PosterUrl = poster_url;

        }

        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Popularity { get; set; }
        public string VoteCount { get; set; }
        public string VoteAverage { get; set; }
        public string OriginalLanguage { get; set; }
        public string Genre { get; set; }
        public string PosterUrl { get; set; }


    }
}
