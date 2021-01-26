using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow
{
    public class ApplicationSettings
    {
        public string JWT_Secret { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
