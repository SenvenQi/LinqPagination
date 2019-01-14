快速开始
 * 安装LinqPagination
    在Nuget中搜索 LinqPagination安装即可
     或者使用包管理器命令行工具
     **Install-Package LinqPagination -Version 1.0.0**


**使用前请using LinqPagination;**
返回分页后的查询结果IQueryable\<T>
 * linq分页扩展
      > **IQueryable<T> datas = new List<T>().AsQueryable();**
      > **IQueryable<T> result = datas.Pagination(pageIndex,pageSize);**

返回分页后的PageResult\<T>
 * linq分页扩展
    > **IQueryable<T> datas = new List<T>().AsQueryable();**
      **IQueryable<T> result = datas.Pagination(pageIndex,pageSize);**

返回结果PageResult\<T>
  * 数据源总条数
    > int SourceCount { get; }
  * 数据源总页数
    > int PageCount { get; }
  * 分页结果集
    > IQueryable\<T> Results {get; }
  
  * 参数
    > pageIndex默认为1

    > pageSize默认为50

    > @where 默认为空数组


**本人QQ群  .net core交流群 838066934**  
