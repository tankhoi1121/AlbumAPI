using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlbumAPI.Models;
using AlbumAPI.Models.Interface;
using AlbumAPI.Services;
using System.IO;

namespace AlbumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        readonly string prefix = "http://localhost:5000/";
        private readonly AlbumService _albumService;
        List<IAlbum> _album;
        public AlbumController()
        {
            _albumService = new AlbumService();
            _album = new List<IAlbum>();
            foreach (string item in Enum.GetNames(typeof(Categorry)))
            {
                _album.Add(_albumService.CreateAlbum(item));
            }
        }
        enum Categorry
        {
            Landscape,
            People,
            Tech
        }

        [HttpGet]
        public List<string> Index()
        {
            //IAlbum _landScape = Landscape.Instance,
            //    _people = People.Instance,
            //    _tech = Tech.Instance;


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
                _album[0].Add(prefix + Categorry.Landscape + "/" + Path.GetFileName(path));

            }

            foreach (var path in listPeopleExample)
            {
                _album[1].Add(prefix + Categorry.People + "/" + Path.GetFileName(path));

            }

            foreach (var path in listTechExample)
            {
                _album[2].Add(prefix + Categorry.Tech + "/" + Path.GetFileName(path));
            }


            res.AddRange(this.GetLandscapeAlbum());
            res.AddRange(this.GetPeopleAlbum());
            res.AddRange(this.GetTechAlbum());
            return res;
        }

        [HttpGet("Landscape")]
        public List<string> GetLandscapeAlbum()
        {
            return _albumService.GetLandscape(_album[0]);
        }

        [HttpGet("People")]
        public List<string> GetPeopleAlbum()
        {
            return _albumService.GetPeople(_album[1]);
        }

        [HttpGet("Tech")]
        public List<string> GetTechAlbum()
        {
            return _albumService.GetTech(_album[2]);
        }

    }
}
