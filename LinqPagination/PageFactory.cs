namespace LinqPagination
{
    /// <summary>
    /// Paging工厂
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageFactory<T> : Paging<T>
    {
        public PageFactory() { }

        public PageFactory(int pageSize,int pageIndex) {
            PageSize = pageSize;
            PageIndex = pageIndex;
        }
    }
}
