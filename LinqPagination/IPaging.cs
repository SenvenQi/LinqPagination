namespace LinqPagination
{
    public interface IPaging
    {
        /// <summary>
        /// 页码
        /// </summary>
        int PageIndex { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        int PageSize { get; set; }
        /// <summary>
        /// 数据源总条数
        /// </summary>
        int AvailCnt { get; set; }
    }
}
