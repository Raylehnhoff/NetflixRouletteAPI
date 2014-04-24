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
            using (var client = new WebClient())
            {
                client.BaseAddress = API_BASE_URL;
                Stream stream = client.OpenRead(string.Format("?title={0}", System.Web.HttpUtility.UrlEncode(title)));
                var reader = new StreamReader(stream);
                MediaObject media = JsonConvert.DeserializeObject<MediaObject>(reader.ReadToEnd());
                return media;
            }
        }
        public MediaObject GetData(string title, int year)
        {
            using (var client = new WebClient())
            {
                client.BaseAddress = API_BASE_URL;
                Stream stream = client.OpenRead(string.Format("?title={0}&year={1}", System.Web.HttpUtility.UrlEncode(title), year));
                var reader = new StreamReader(stream);
                MediaObject media = JsonConvert.DeserializeObject<MediaObject>(reader.ReadToEnd());
                return media;
            }
        }
    }
}
