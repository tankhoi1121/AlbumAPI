using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlbumAPI.Models;
using AlbumAPI.Models.Interface;
using System.IO;

namespace AlbumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        readonly string prefix = "http://localhost:5000/";
        enum Categorry
        {
            Landscape,
            People,
            Tech
        }
        [HttpGet]
        public List<string> Index()
        {
            IAlbum _landScape = new Landscape();
            IAlbum _people = new People();
            IAlbum _tech = new Tech();

            var listLandscapeExample = Directory
               .GetFiles
               (@"C:\Users\khoin\source\repos\AlbumAPI\AlbumAPI\wwwroot\Landscape\");

            var listPeopleExample = Directory
              .GetFiles
              (@"C:\Users\khoin\source\repos\AlbumAPI\AlbumAPI\wwwroot\People\");

            var listTechExample = Directory
              .GetFiles
              (@"C:\Users\khoin\source\repos\AlbumAPI\AlbumAPI\wwwroot\Tech\");

            foreach (var path in listLandscapeExample)
            {
                _landScape.Add(prefix + Categorry.Landscape + "/" + Path.GetFileName(path));

            }

            foreach (var path in listPeopleExample)
            {
                _people.Add(prefix + Categorry.People + "/" + Path.GetFileName(path));

            }

            foreach (var path in listTechExample)
            {
                _tech.Add(prefix + Categorry.Tech + "/" + Path.GetFileName(path));
            }

            List<string> res = new List<string>();
            res.AddRange(_landScape.GetAll());
            res.AddRange(_people.GetAll());
            res.AddRange(_tech.GetAll());
            return res;
        }
    }
}
