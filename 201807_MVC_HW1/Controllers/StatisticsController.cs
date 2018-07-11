using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _201807_MVC_HW1.Models;

namespace _201807_MVC_HW1.Controllers
{
    public class StatisticsController : Controller
    {
        private 客戶統計資訊Repository statisticRepo;

        public StatisticsController()
        {
            statisticRepo = RepositoryHelper.Get客戶統計資訊Repository();
        }
        
        // GET: Statistics
        public ActionResult Index()
        {
            var data = statisticRepo.All().ToList();
            return View(data);
        }
    }
}