using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AlbumAPI.Models;
using AlbumAPI.Models.Interface;

namespace AlbumAPI.Services
{
    public class AlbumService
    {
        public IAlbum CreateAlbum(string albumtype)
        {
            switch (albumtype)
            {
                case null:
                    return null;
                case "Landscape":
                    return Landscape.Instance;
                case "People":
                    return People.Instance;
                case "Tech":
                    return Tech.Instance;
            }
            return null;
        }

        public List<string> GetLandscape(IAlbum landScape)
        {
            //IAlbum _landScape = Landscape.Instance;
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
                baseData = landScape.GetAll();
                return landScape.GetAll();
            }
            else
            {
                //filter newData added
                var newData = baseData.Except(listLandscapeExample.ToList<string>()).ToList();
                if (newData != null)
                {
                    foreach (var item in newData)
                    {
                        landScape.Add(item);
                    }
                }
                return landScape.GetAll();
            }
        }

        public List<string> GetPeople(IAlbum people)
        {
            //IAlbum _people = People.Instance;
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

                baseData = people.GetAll();
                return people.GetAll();
            }
            else
            {
                //filter newData added
                var newData = baseData.Except(listPeopleExample.ToList<string>()).ToList();
                if (newData != null)
                {
                    foreach (var item in newData)
                    {
                        people.Add(item);
                    }
                }
                return people.GetAll();
            }
        }

        public List<string> GetTech(IAlbum tech)
        {
            //IAlbum _tech = Tech.Instance;
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
                baseData = tech.GetAll();
                return tech.GetAll();
            }
            else
            {
                //filter newData added
                var newData = baseData.Except(listTechExample.ToList<string>()).ToList();
                if (newData != null)
                {
                    foreach (var item in newData)
                    {
                        tech.Add(item);
                    }
                }
                return tech.GetAll();
            }
        }
    }
}
