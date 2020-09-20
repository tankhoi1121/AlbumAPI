using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Models
{
    public class ResModel
    {
        private static readonly ResModel _instanceResModel = new ResModel();
        private List<string> res = new List<string>();
        static ResModel()
        {

        }
        private ResModel()
        {

        }

        public static ResModel Instance
        {
            get
            {
                return _instanceResModel;
            }
        }

        public List<string> ResList
        {
            get { return res; }
        }
    }
}
