using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamWH.Models;
using ExamWH;
namespace ExamWH.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            EvaluateBet evaluate = new EvaluateBet(true);
           
            return View(evaluate.BetList.Unsettled);
        }
    }
}