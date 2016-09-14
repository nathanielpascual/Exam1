using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamWH.Models;
namespace ExamWH.App_Code
{
    public class EvaluateBet
    {
        public BetList BetList { get; set; }
        public EvaluateBet(bool setBet)
        {
            BetList = new BetList();

            if (setBet)
                SetBetlist(setBet);
        }

        public float GetHistoryBetAverage(int CustomerID)
        {

            var retValue = BetList.Settled.Where(x => x.Customer == CustomerID)
                               .Average(x => x.Stake);

            return retValue;
        }

        public float GetHistoryBetSum(int CustomerID)
        {
            var retValue = BetList.Settled.Where(x => x.Customer == CustomerID)
                               .Sum(x => x.Stake);

            return retValue;
        }

        private void SetBetlist(bool set)
        {

            BetList BetList = new Models.BetList();
            CSVFileHandler file = new CSVFileHandler();
            BetList.Settled  = file.ExtractCSVFile("Settled.csv");
            BetList.Unsettled = file.ExtractCSVFile("Unsettled.csv");
           
        }

    }
}