using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamWH.Models
{
    public class BetList
    {
        public BetList() {
            Settled = new List<Bet>();
            Unsettled = new List<Bet>();
        }
        public List<Bet> Settled { get; set; }

        public List<Bet> Unsettled { get; set; }


    }
}