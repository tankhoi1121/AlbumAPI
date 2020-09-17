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
        enum Categorry
        {
            Landscape,
            People,
            Tech
        }

        [HttpGet]
        public List<string> Index()
        {
            IAlbum _landScape = Landscape.Instance,
                _people = People.Instance,
                _tech = Tech.Instance;


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
            List<string> baseData = null;
            var listLandscapeExample = Directory
                .GetFiles
                (@"C:\Users\khoin\source\repos\AlbumAPI\AlbumAPI\wwwroot\Landscape\");
            if (baseData == null)
            {

                //foreach (var path in listLandscapeExample)
                //{
                //    _landScape.Add(prefix + Categorry.Landscape + "/" + Path.GetFileName(path));
                //}
                baseData = _landScape.GetAll();
                return _landScape.GetAll();
            }
            else
            {
                //filter newData added
                var newData = baseData.Except(listLandscapeExample.ToList<string>()).ToList();
                if (newData != null)
                {
                    foreach (var item in newData)
                    {
                        _landScape.Add(item);
                    }
                }
                return _landScape.GetAll();
            }
        }

        [HttpGet("People")]
        public List<string> GetPeopleAlbum()
        {
            IAlbum _people = People.Instance;
            List<string> baseData = null;
            var listPeopleExample = Directory
                .GetFiles
                (@"C:\Users\khoin\source\repos\AlbumAPI\AlbumAPI\wwwroot\People\");
            if (baseData == null)
            {

                //foreach (var path in listPeopleExample)
                //{
                //    _people.Add(prefix + Categorry.People + "/" + Path.GetFileName(path));

                //}

                baseData = _people.GetAll();
                return _people.GetAll();
            }
            else
            {
                //filter newData added
                var newData = baseData.Except(listPeopleExample.ToList<string>()).ToList();
                if (newData != null)
                {
                    foreach (var item in newData)
                    {
                        _people.Add(item);
                    }
                }
                return _people.GetAll();
            }
        }

        [HttpGet("Tech")]
        public List<string> GetTechAlbum()
        {
            IAlbum _tech = Tech.Instance;
            List<string> baseData = null;

            var listTechExample = Directory
            .GetFiles
            (@"C:\Users\khoin\source\repos\AlbumAPI\AlbumAPI\wwwroot\Tech\");

            if (baseData == null)
            {
                //foreach (var path in listTechExample)
                //{
                //    _tech.Add(prefix + Categorry.Tech + "/" + Path.GetFileName(path));
                //}
                baseData = _tech.GetAll();
                return _tech.GetAll();
            }
            else
            {
                //filter newData added
                var newData = baseData.Except(listTechExample.ToList<string>()).ToList();
                if (newData != null)
                {
                    foreach (var item in newData)
                    {
                        _tech.Add(item);
                    }
                }
                return _tech.GetAll();
            }
        }

    }
}
