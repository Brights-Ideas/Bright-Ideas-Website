using BrightIdeas.Models;
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
        [HttpGet]
        public ActionResult Search()
        {
            return PartialView("_SearchFormPartial");
        }

        [HttpPost]
        public ActionResult Search(string query)
        {
            if (query != null)
            {
                try
                {
                    int parsedInt;
                    //var searchlist = rep.Search(query);

                    var model = new SearchViewModel()
                    {
                        //NewsList = new List<NewsViewModel>()
                        //SearchTerms = new Dictionary<string, string>(),
                        Location = "" + Request["Location"],//.ToLower(CultureInfo.InvariantCulture),
                        MinPrice = Convert.ToInt32(Request["MinPrice"]),
                        MaxPrice = Convert.ToInt32(Request["MaxPrice"]),

                        CurrentPage = int.TryParse(Request["p"], out parsedInt) ? parsedInt : 1,

                        PageSize = 9,
                        RootContentNodeId = 1402,
                        //RootMediaNodeId = GetMacroParam(Model, "rootMediaNodeId", s => int.Parse(s), -1),
                        //IndexType = GetMacroParam(Model, "indexType", s => s.ToLower(CultureInfo.InvariantCulture), ""),
                        //SearchFields = GetMacroParam(Model, "searchFields", s => SplitToList(s), new List<string> { "nodeName", "metaTitle", "metaDescription", "metaKeywords", "bodyText" }),
                        //PreviewFields = GetMacroParam(Model, "previewFields", s => SplitToList(s), new List<string> { "bodyText" }),
                        PreviewLength = 250,
                        //HideFromSearchField = GetMacroParam(Model, "hideFromSearchField", "umbracoNaviHide"),
                        //SearchFormLocation = "top"
                    };

                    return PartialView("_SearchResultsPartial", model);
                }
                catch (Exception ex)
                {
                    // handle exception
                }
            }
            return PartialView("Error");
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