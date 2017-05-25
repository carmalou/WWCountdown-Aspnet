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
            var diffInMinutes = (dt - now).TotalMinutes;
            var diffInHours = diffInMinutes / 60;
            var appendMinutes = diffInMinutes % 60;
            string hours = Math.Truncate(diffInHours).ToString() + " hours";
            string minutes = appendMinutes > 0 ? " and " + Math.Truncate(appendMinutes).ToString() + " minutes" : "";
            return hours + minutes;
        }

    }
}