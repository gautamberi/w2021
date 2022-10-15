using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class ImageFeedService
    {
        private HttpClient client; 

        public ImageFeedService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.flickr.com/");
        }

        public ImageFeed GetFeed(string tags)
        {
            if (string.IsNullOrEmpty(tags))
            {
                tags = "tajmahal";
            }
            ImageFeed feed = new ImageFeed();

            // load the response object from the API
            var response = client.GetAsync("/services/feeds/photos_public.gne?tagmode=any&format=json&_=1450853406890&nojsoncallback=1&tags=" + tags).Result;

            try
            {
                // get json string from the http response object 
                string json = response.Content.ReadAsStringAsync().Result;

                // convert the JSON object (string) to the ImageFeed class in Models 
                feed = JsonConvert.DeserializeObject<ImageFeed>(json);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return feed;
        }
    }
}