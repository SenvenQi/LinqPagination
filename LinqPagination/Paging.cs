using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace LinqPagination
{
    public abstract class Paging<T> : IPaging<T>
    {
        public virtual int PageIndex { get; set; } = 1;
        public virtual int PageSize { get; set; } = 10;
        public virtual int AvailCnt { get; set; }
        public virtual IList<Expression<Func<T, bool>>> Conditions { get; set; } = new List<Expression<Func<T, bool>>>();

        private IQueryable<T> _source;
        private IPaging<T> Self => this;
        private void AddFliter(IPaging<T> paging)
        {
            Conditions.EachDo(x => paging.Add(x));
        }

        IQueryable<T> IPaging<T>.PagingBy(IQueryable<T> source)
        {
            _source = source;
            AvailCnt = _source.Count();
            AddFliter(Self);
            Pagination();
            return _source;
        }

        void IPaging<T>.Add(Expression<Func<T, bool>> predicate)
            => _source = _source.Where(predicate);

        public void Pagination()
            => _source = _source.Skip((PageIndex - 1) * PageSize).Take(PageSize);


    }
}
