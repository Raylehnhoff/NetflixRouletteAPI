using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace NetflixRouletteAPI
{
    public class NetflixRouletteAPI
    {
        #region private propertie
        private const string API_BASE_URL = "http://netflixroulette.net/api/api.php";
        #endregion
        public NetflixRouletteAPI()
        {

        }
        public MediaObject GetData(string title)
        {
            return getData(title,null);
        }
        public MediaObject GetData(string title, int? year)
        {
            return getData(title, year);
        }
        private MediaObject getData(string title, int? year)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.BaseAddress = API_BASE_URL;
                    StringBuilder UrlBuilder = new StringBuilder();
                    //The first token is always a ?, so we can start there.
                    UrlBuilder.Append("?");
                    if (!string.IsNullOrEmpty(title))
                    {
                        UrlBuilder.AppendFormat("title={0}", title);
                    }
                    if (!string.IsNullOrEmpty(title) && year.HasValue)
                    {
                        UrlBuilder.Append("&");
                    }
                    if (year.HasValue)
                    {
                        UrlBuilder.AppendFormat("year={0}", year.Value);
                    }

                    Stream stream = client.OpenRead(UrlBuilder.ToString());
                    var reader = new StreamReader(stream);
                    MediaObject media = JsonConvert.DeserializeObject<MediaObject>(reader.ReadToEnd());
                    if (string.IsNullOrEmpty(media.show_title))
                    {
                        media.success = false;
                        media.mediatype = MediaObject.MediaType.Error;
                    }
                    else
                    {
                        media.success = true;
                    }
                    return media;
                }
            }
            catch (Exception ex)
            {
                return new MediaObject() { success = false, mediatype = MediaObject.MediaType.Error };
            }
        }
    }
}
