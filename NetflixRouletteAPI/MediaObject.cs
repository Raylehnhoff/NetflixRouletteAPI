using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixRouletteAPI
{
    /// <summary>
    /// The MediaObject corresponds to a deserialized JSON Response from the API
    /// </summary>
    public class MediaObject
    {
        /// <summary>
        /// Enum corresponding to the underlying mediatype from the API. Movie = 0, TVShow = 1, Error = -1
        /// </summary>
        public enum MediaType : int
        {
            Movie = 0,
            TVShow = 1,
            Error = -1
        }
        #region properties
        /// <summary>
        /// Returns True if the API request was successful.
        /// </summary>
        public bool success { get; set; }
        public int unit { get;set;}
        public int show_id {get;set;}
        public string show_title {get;set;}
        public int release_year {get;set;}
        /// <summary>
        /// Rating, out of 5
        /// </summary>
        public decimal rating{get;set;}
        public string category{get;set;}
        public string show_cast{get;set;}
        public string director{get;set;}
        public string summary{get;set;}
        /// <summary>
        /// URL to the movie poster image
        /// </summary>
        public string poster{get;set;}
        public MediaType mediatype { get; set; }
        #endregion
        public MediaObject()
        {

        }
    }
}
