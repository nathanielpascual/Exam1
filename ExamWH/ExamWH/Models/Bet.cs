using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamWH.Models
{
    public class Bet
    {
        public int Customer { get; set; }

        public int Event { get; set; }

        public int Participant { get; set; }

        public float Stake { get; set; }

        public float ToWin { get; set; }

        public float Won { get; set; }

        public bool hasWon { get; set; }
    }
}