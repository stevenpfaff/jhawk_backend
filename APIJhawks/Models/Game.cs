using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJhawks.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public string Date { get; set; }
    
    }
}
