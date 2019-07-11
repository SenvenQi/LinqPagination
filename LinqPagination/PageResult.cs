using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqPagination
{
    public class PageResult<T> : IPageResult<T>
    {
        public static PageResult<T> New(int sourceCount, int pageCount, IQueryable<T> results)
            => new PageResult<T>(sourceCount, pageCount, results);
        private PageResult(int sourceCount,int pageCount, IQueryable<T> results)
        {
            SourceCount = sourceCount;
            PageCount = pageCount;
            Results = results.ToList();
        }
        public int SourceCount { get; }

        public int PageCount { get;}

        public IList<T> Results { get; }
    }
}
