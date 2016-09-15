using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamWH.Models;
namespace ExamWH.Controllers
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
        //Get the average of the Customers stake
        public float GetHistoryBetAverage(int CustomerID)
        {

            var retValue = BetList.Settled.Where(x => x.Customer == CustomerID)
                               .Average(x => x.Stake);

            return retValue;
        }

        //get the sum of the customers stake
        public float GetHistoryBetSum(int CustomerID)
        {
            var retValue = BetList.Settled.Where(x => x.Customer == CustomerID)
                               .Sum(x => x.Stake);

            return retValue;
        }

        private void CheckUnusual(List<Bet> list)
        {
            foreach (var item in list)
            {
                float average = GetHistoryBetAverage(item.Customer);
                float tentimes = GetHistoryBetAverage(item.Customer) * 10;
                float thirtytimes = GetHistoryBetAverage(item.Customer) * 30;

                if (item.Stake > tentimes || item.Stake > thirtytimes)
                    item.HighRisk = true;
            }

            BetList.Unsettled = list;
        }

        private void SetBetlist(bool set)
        {
            List<Bet> list = new List<Bet>();
            BetList = new Models.BetList();
            CSVFileHandler file = new CSVFileHandler();
            BetList.Settled = file.ExtractCSVFile("Settled.csv");
            list = file.ExtractCSVFile("Unsettled.csv",false);

            CheckUnusual(list);
            list = null;

        }
    }
}