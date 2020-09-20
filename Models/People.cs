using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Models
{
    using Interface;
    public sealed class People : IAlbum
    {
        List<string> _people = new List<string>();
        private static readonly People _instancePeople = new People();

        static People()
        {

        }

        private People()
        {

        }

        public static People Instance
        {
            get
            {
                return _instancePeople;
            }
        }


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
