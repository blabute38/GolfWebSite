using Golf.Global.Implementations;
using PagedList;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Golf.ViewModels.Golfers
{
    public class GolferSearchViewModel
    {
        public IPagedList<GolferViewModel> Golfers { get; set; }
        public string SearchString { get; set; }
        public Class? ClassSearch { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string FirstNameSortOrder { get; set; }
        public string LastNameSortOrder { get; set; }
        public string BirthdateSortOrder { get; set; }
        public string ClassSortOrder { get; set; }

        private int? _page { get; set; }
        public int? Page
        {
            get
            {
                if (SearchString != null)
                    return 1;
                else
                    return _page;
            }
            set
            {
                _page = value;
            }
        }
        public int PageSize { get; set; } = 10;
        public int PageNumber
        {
            get
            {
                return (Page ?? 1);
            }
            set
            {

            }
        }

    }
}
