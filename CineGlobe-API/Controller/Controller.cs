using CineGlobe_API.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGlobe_API.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        [HttpGet("getmovies")]
        public ActionResult GetMissingImages()
        {
            //No authorisation checks against this call for simplicity.
            var movieDataLogic = new DataLogic();                
            var data = movieDataLogic.GetFilmData();
            return Ok(data);
        }
    }
}
