using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbumAPI.Models;
using AlbumAPI.Models.Interface;

namespace AlbumAPI.Services
{
    public class AlbumService
    {
        public IAlbum GetAlbum(string albumtype)
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
    }
}
