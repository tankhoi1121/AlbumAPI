using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Models
{
    using Interface;
    public class Tech : IAlbum
    {
        List<string> _techImgs = new List<string>();

        private static readonly Tech _instanceTech = new Tech();

        static Tech()
        {

        }

        private Tech()
        {

        }

        public static Tech Instance
        {
            get
            {
                return _instanceTech;
            }
        }

        public void Add(string item)
        {
            _techImgs.Add(item);
        }

        public List<string> GetAll()
        {
            return _techImgs;
        }

        public string GetById(int id)
        {
            return _techImgs[id];
        }
    }
}
