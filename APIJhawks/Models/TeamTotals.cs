using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJhawks.Models
{
    public class TeamTotals
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public int R { get; set; }
        public int RA { get; set; }
        public int RD { get; set; }
        public int H { get; set; }
        public float BA { get; set; }
        public float OBP { get; set; }
        public float SLG { get; set; }
        public float OPS { get; set; }
        public float INN { get; set; }
        public float ERA { get; set; }
        public float WHIP { get; set; }
        public int BB { get; set; }
        public int K { get; set; }
        public float FIP { get; set; }
        public int FP { get; set; }

    }
}
