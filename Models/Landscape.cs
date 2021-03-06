﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Models
{
    using Interface;
    public sealed class Landscape : IAlbum
    {
        List<string> _landScape = new List<string>();

        private static readonly Landscape _instanceLandscape = new Landscape();

        static Landscape()
        {

        }

        private Landscape()
        {

        }

        public static Landscape Instance
        {
            get
            {
                return _instanceLandscape;
            }
        }

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
