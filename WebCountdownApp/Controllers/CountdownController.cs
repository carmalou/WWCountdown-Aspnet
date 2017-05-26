using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace WebCountdownApp.Controllers
{
    public class CountdownController : Controller
    {
        public ContentResult TimeRemaining()
        {
            var movie_data = new Movie();
            try
            {
                using (StreamReader sr = new StreamReader(Server.MapPath("~/config.json")))
                {
                    movie_data = JsonConvert.DeserializeObject<Movie>(sr.ReadToEnd());
                }
                string movie_name = movie_data.Event;
                string howLong = HoursRemaining(movie_data.Date);
                return Content(movie_name + " will arrive in " + howLong);
            }
            catch(Exception err)
            {
                throw new Exception("Everything is broken.", err);
            }
        }

        public static string HoursRemaining(string day)
        {
            DateTime dt = Convert.ToDateTime(day);
            DateTime now = DateTime.Now;
            var diffInMilliseconds = (dt - now).TotalMilliseconds;
            var diffInSeconds = Math.Truncate(diffInMilliseconds / 1000);
            var diffInMinutes = Math.Truncate(diffInSeconds / 60);
            var diffInHours = Math.Truncate(diffInMinutes / 60);
            var appendSeconds = diffInSeconds % 60;
            var appendMinutes = diffInMinutes % 60;
            string hours = diffInHours > 0 ? diffInHours.ToString() + " hours" : "0 hours";
            string minutes = appendMinutes > 0 ? " and " + appendMinutes.ToString() + " minutes" : " and 0 minutes";
            string seconds = appendSeconds > 0 ? " and " + appendSeconds.ToString() + " seconds" : " and 0 seconds";
            return hours + minutes + seconds;
        }

    }
}