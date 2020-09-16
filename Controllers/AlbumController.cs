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
            IAlbum _landScape = Landscape.Instance;
            IAlbum _people = People.Instance;
            IAlbum _tech = Tech.Instance;

            var listLandscapeExample = Directory
               .GetFiles
               (@"C:\Users\khoin\source\repos\AlbumAPI\AlbumAPI\wwwroot\Landscape\");

            var listPeopleExample = Directory
              .GetFiles
              (@"C:\Users\khoin\source\repos\AlbumAPI\AlbumAPI\wwwroot\People\");

            var listTechExample = Directory
              .GetFiles
              (@"C:\Users\khoin\source\repos\AlbumAPI\AlbumAPI\wwwroot\Tech\");

            List<string> res = new List<string>();


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


            res.AddRange(this.GetLandscapeAlbum());
            res.AddRange(this.GetPeopleAlbum());
            res.AddRange(this.GetTechAlbum());
            return res;
        }

        [HttpGet("Landscape")]
        public List<string> GetLandscapeAlbum()
        {
            IAlbum _landScape = Landscape.Instance;
            if (_landScape.GetAll() == null)
            {
                var listLandscapeExample = Directory
                .GetFiles
                (@"C:\Users\khoin\source\repos\AlbumAPI\AlbumAPI\wwwroot\Landscape\");
                foreach (var path in listLandscapeExample)
                {
                    _landScape.Add(prefix + Categorry.Landscape + "/" + Path.GetFileName(path));
                }
                return _landScape.GetAll();
            }
            else
            {
                return _landScape.GetAll();
            }
        }

        [HttpGet("People")]
        public List<string> GetPeopleAlbum()
        {
            IAlbum _people = People.Instance;
            if (_people.GetAll() == null)
            {
                var listPeopleExample = Directory
                .GetFiles
                (@"C:\Users\khoin\source\repos\AlbumAPI\AlbumAPI\wwwroot\People\");
                foreach (var path in listPeopleExample)
                {
                    _people.Add(prefix + Categorry.People + "/" + Path.GetFileName(path));

                }
                return _people.GetAll();
            }
            else
            {
                return _people.GetAll();
            }
        }

        [HttpGet("Tech")]
        public List<string> GetTechAlbum()
        {
            IAlbum _tech = Tech.Instance;

            if (_tech.GetAll() == null)
            {
                var listTechExample = Directory
                .GetFiles
                (@"C:\Users\khoin\source\repos\AlbumAPI\AlbumAPI\wwwroot\Tech\");



                foreach (var path in listTechExample)
                {
                    _tech.Add(prefix + Categorry.Tech + "/" + Path.GetFileName(path));
                }
                return _tech.GetAll();
            }
            else
            {
                return _tech.GetAll();
            }
        }

    }
}
