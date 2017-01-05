using BrightIdeas.Models;
using Examine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Logging;
using UmbracoExamine;

namespace BrightIdeas.Controllers
{
    public class SearchController : Umbraco.Web.Mvc.SurfaceController
    {

        public void Ordering(SearchViewModel properties, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            var students = properties.AllResults;
            switch (sortOrder)
            {
                case "Name_desc":
                    students = students.OrderByDescending(p => p.Fields["price"]);
                    break;
                case "Date":
                    //students = students.OrderBy(s => s.EnrollmentDate);
                    break;
            }
            //return View(students.ToList());
        }

        // GET: Search
        [HttpGet]
        public ActionResult Search()
        {
            return PartialView("_SearchFormPartial");
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel model)
        {
            if (model.SearchTerm != null)
            {
                try
                {
                    int parsedInt;
                    //var searchlist = rep.Search(query);

                    //var model = new SearchViewModel()
                    //{
                    //    //SearchTerms = new Dictionary<string, string>(),
                    //    Location = "" + Request["Location"],//.ToLower(CultureInfo.InvariantCulture),
                    //    MinPrice = Convert.ToInt32(Request["MinPrice"]),
                    //    MaxPrice = Convert.ToInt32(Request["MaxPrice"]),

                    //    CurrentPage = int.TryParse(Request["p"], out parsedInt) ? parsedInt : 1,
                    model.CurrentPage = int.TryParse(Request["p"], out parsedInt) ? parsedInt : 1;
                    //    PageSize = 9,
                    //    RootContentNodeId = 1402,
                    //    PreviewLength = 250,
                    //    //HideFromSearchField = GetMacroParam(Model, "hideFromSearchField", "umbracoNaviHide"),
                    //    SearchFormLocation = "top"
                    //};

                    // Perform the search
                    var searcher = ExamineManager.Instance.CreateSearchCriteria();

                    var query = searcher.NodeTypeAlias("umbPropertyDetails");

                    query.And().Field("regionID", model.Location);
                    
                    if (model.MinPrice >= 0 && model.MaxPrice > 0)
                    {
                        var paddedLower = model.MinPrice.ToString("D6");
                        var paddedHigher = model.MaxPrice.ToString("D6");

                        query.And().Range("price", paddedLower, paddedHigher, true, true);
                    }

                    var results = ExamineManager.Instance.Search(query.Compile()).Where(x => (
                        !Umbraco.IsProtected(int.Parse(x.Fields["id"]), x.Fields["path"]) ||
                        (
                            Umbraco.IsProtected(int.Parse(x.Fields["id"]), x.Fields["path"]) &&
                            Umbraco.MemberHasAccess(int.Parse(x.Fields["id"]), x.Fields["path"])
                        )) && (
                            (x.Fields["__IndexType"] == IndexTypes.Content && Umbraco.TypedContent(int.Parse(x.Fields["id"])) != null) ||
                            (x.Fields["__IndexType"] == IndexTypes.Media && Umbraco.TypedMedia(int.Parse(x.Fields["id"])) != null)
                        ))
                    .ToList();

                    model.AllResults = results;
                    model.TotalResults = results.Count;
                    model.TotalPages = (int)Math.Ceiling((decimal)model.TotalResults / model.PageSize);
                    model.CurrentPage = Math.Max(1, Math.Min(model.TotalPages, model.CurrentPage));

                    // Page the results
                    model.PagedResults = model.AllResults.Skip(model.PageSize * (model.CurrentPage - 1)).Take(model.PageSize);

                    LogHelper.Debug<string>("[ezSearch] Searching Lucene with the following query: " + query);

                    //if (model.PagedResults.Any()) return PartialView("_SearchResultsPartial", model);
                    // No results found, so render no results view
                    //if (model.SearchFormLocation != "none")
                    //{
                    //    return PartialView("_SearchFormPartial");
                    //    //@RenderForm(model)
                    //}
                    //@RenderNoResults(model)

                    //var contentItem = Umbraco.TypedContent(result.Fields["id"]);

                    return PartialView("_SearchResultsPartial", model.AllResults);
                }
                catch (Exception ex)
                {
                    // handle exception
                    LogHelper.Error<string>("[ezSearch] Searching Lucene with the following query: ", ex);
                }
            }
            return PartialView("Error");
        }

        //public ActionResult RenderResults(SearchViewModel model)
        //{
        //    //< div class="ezsearch-results container features">
        //    //<div class="row">
        //    foreach(var result in model.PagedResults)
        //    {
        //        switch (result.Fields["__IndexType"])
        //        {
        //            case UmbracoExamine.IndexTypes.Content:
        //                var contentItem = Umbraco.TypedContent(result.Fields["id"]);
        //                    //@RenderContentResult(model, contentItem)
        //                    //return PartialView("_SearchResultsPartial", model, contentItem);
        //                    break;
        //            case UmbracoExamine.IndexTypes.Media:
        //                var mediaItem = Umbraco.TypedMedia(result.Fields["id"]);
        //                    //return PartialView("_SearchResultsPartial", model);
        //                    //@RenderMediaResult(model, mediaItem)
        //                    break;
        //        }
        //    }

        //    return View();
        //    //</div>
        //    //</div>
        //}

        //public ActionResult RenderNoResults(SearchViewModel model)
        //{
        //    //< div class="ezsearch-no-results">
        //        //<p>@FormatHtml(GetDictionaryValue("[ezSearch] No Results", "No results found for search term <strong>{0}</strong>."), model.SearchTerm)</p>
        //    //</div>
        //    return View();
        //}

    }
}