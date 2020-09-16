using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Models
{
    using Interface;
    public class Landscape : IAlbum
    {
        List<string> _landScape = new List<string>();

        public void Add(string item)
        {
            _landScape.Add(item);
        }

        public List<string> GetAll()
        {
            return _landScape;
        }

        public string GetById(int id)
        {
            return _landScape[id];
        }

    }
}
