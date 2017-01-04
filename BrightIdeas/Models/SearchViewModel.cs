using Examine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrightIdeas.Models
{
    public class SearchViewModel
    {
        // Query Parameters

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string Location { get; set; }
        public string SearchTerm { get; set; }
        //public Dictionary<string, string> SearchTerms { get; set; }
        public int CurrentPage { get; set; }

        // Options
        public int RootContentNodeId { get; set; }
        public int RootMediaNodeId { get; set; }
        public string IndexType { get; set; }

        public int PreviewLength { get; set; }
        public int PageSize { get; set; }

        // Results
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }

        public IEnumerable<SearchResult> AllResults { get; set; }
        public IEnumerable<SearchResult> PagedResults { get; set; }
    }
}