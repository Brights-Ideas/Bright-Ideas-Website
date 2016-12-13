using Examine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core;
using UmbracoExamine;

namespace BrightIdeas.Controllers
{
    public class SearchController : Umbraco.Web.Mvc.SurfaceController
    {
        private void init()
        {
            //initDictionaryLookup();
            //ExamineManager.Instance.IndexProviderCollection[Helpers]
        }
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Index(string sortOrder)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            //var students = from s in db.Students
                           //select s;
            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        students = students.OrderByDescending(s => s.LastName);
            //        break;
            //    case "Date":
            //        students = students.OrderBy(s => s.EnrollmentDate);
            //        break;
            //    case "date_desc":
            //        students = students.OrderByDescending(s => s.EnrollmentDate);
            //        break;
            //    default:
            //        students = students.OrderBy(s => s.LastName);
            //        break;
            //}
            //return View(students.ToList());
        //}
    }
}