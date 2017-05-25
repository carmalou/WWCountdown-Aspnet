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
                    return Content(movie_data.Event + " will arrive in " + movie_data.Date);
            }
            catch(Exception err)
            {
                throw new Exception("Everything is broken.", err);
            }
        }

    }
}