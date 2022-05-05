using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJhawks.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int GP { get; set; }
        public int AB { get; set; }
        public int H { get; set; }
        public int R { get; set; }
        public int RBI { get; set; }
        public int DBL { get; set; }
        public int TPL { get; set; }
        public int HR { get; set; }
        public float SLG { get; set; }
        public int BB { get; set; }
        public int K { get; set; }
        public int IP { get; set; }
        public int Walks { get; set; }
        public int Strikeouts { get; set; }
        public int BALL { get; set; }
        public int STRK { get; set; }
        public int PT { get; set; }
        public int PO { get; set; }
        public int A { get; set; }
        public int E { get; set; }
        public int FP { get; set; }
        public int SB { get; set; }
        public int CS { get; set; }
        public int SBP { get; set; }
        public float AVG { get; set; }
        public float WHIP { get; set; }
        public float ERA { get; set; }
        public float OBP { get; set; }
        public float OPS { get; set; }
        public float FIP { get; set; }
        public int CCS { get; set; }
    }
}
