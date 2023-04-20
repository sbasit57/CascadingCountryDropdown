using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryMenu.Controllers
{
    public class HomeController : Controller
    {
        CountryMenuEntities db = new CountryMenuEntities();
        public ActionResult Index()
        {
            List<Country> CountryList = db.Countries.ToList();
            ViewBag.CountryList = new SelectList(CountryList, "CountryId", "CountryName");
            return View();
        }

        public JsonResult GetStateList(int CountryId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<State> Statelist = db.States.Where(x => x.CountryId == CountryId).ToList();
            return Json(Statelist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}