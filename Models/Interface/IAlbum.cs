using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Models.Interface
{
    public interface IAlbum
    {
        List<string> GetAll();
        string GetById(int id);
        void Add(string item);
    }
}
