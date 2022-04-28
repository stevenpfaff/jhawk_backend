using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJhawks.Models
{
    public class Game
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string HomeScore { get; set; }
        public string AwayScore { get; set; } 
    }
}
