using System.Collections.Generic;

namespace LinqPagination
{
    public class PageResult<T> : IPageResult<T>
    {
        public static PageResult<T> New(int sourceCount, int pageCount, int pageIndex, IList<T> results)
            => new PageResult<T>(sourceCount, pageCount, pageIndex, results);

        private PageResult(int sourceCount,int pageCount,int pageIndex, IList<T> results)
        {
            SourceCount = sourceCount;
            PageCount = pageCount;
            Results = results;
            PageIndex = pageIndex;
        }
        public PageResult()
        {

        }
        public int PageIndex { get; set; }

        public int SourceCount { get; set; }

        public int PageCount { get; set; }

        public IList<T> Results { get; set; }
    }
}
