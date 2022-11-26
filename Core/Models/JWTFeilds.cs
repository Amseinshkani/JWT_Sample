using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    [Serializable]
    public class JWTFeilds
    {
        //Base64
        public string Token { get; set; }
        public string UserName { get; set; }
        public int ExpireTime { get; set; }
    }
}
