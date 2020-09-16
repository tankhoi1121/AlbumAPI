using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Models
{
    using Interface;
    public class People : IAlbum
    {
        List<string> _people = new List<string>();
        public void Add(string item)
        {
            _people.Add(item);
        }

        public List<string> GetAll()
        {
            return _people;
        }

        public string GetById(int id)
        {
            return _people[id];
        }
    }
}
