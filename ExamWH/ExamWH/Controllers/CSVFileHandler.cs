using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamWH.Models;
using System.IO;
namespace ExamWH.Controllers
{
    public class CSVFileHandler:FileHandler
    {
        public List<Bet> ExtractCSVFile(string FileName, bool Settled = true)
        {
            List<Bet> list = new List<Bet>();

            StreamReader reader = ExtractFile(System.Web.HttpContext.Current.Server.MapPath("/Files/" + FileName));
            int index = 0;
            while (!reader.EndOfStream)
            {
                index++;
                var line = reader.ReadLine();

                if (index > 1)
                {
                    var values = line.Split(',');

                    list.Add(new Bet()
                    {
                        Customer = Convert.ToInt16(values[0]),
                        Event = Convert.ToInt16(values[1]),
                        Participant = Convert.ToInt16(values[2]),
                        Stake = Convert.ToSingle(values[3]),
                        Won = (Settled ? Convert.ToSingle(values[4]) : 0),
                        ToWin = (!Settled ? Convert.ToSingle(values[4]) : 0),
                        hasWon = (Convert.ToSingle(values[4]) > 0 ? true : false),
                        HighRisk = false
                    });
                }
            }

            reader.Close();
            reader.Dispose();

            return list;
        }
    }
}