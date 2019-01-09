using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LinqPagination;

namespace FunctionExtentionTest
{
    [TestClass]
    public class PagingTest
    {
        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public IList<Student> MakeData()
        {
            IList<Student> students = new List<Student>();
            for (int i = 0; i < 100; i++)
            {
                students.Add(new Student
                {
                    Name = "test" + i,
                    Age = i
                });
            }
            return students;
        }
        [TestMethod]
        public void PagingFilterTest1()
        {
            var data = MakeData().AsQueryable().Pagination(1).ToList();
            Assert.IsTrue(data.Count == 50);
        }
        [TestMethod]
        public void PagingFilterTest2()
        {
            var data = MakeData().AsQueryable().Pagination(3).ToList();
            Assert.IsTrue(data.Count == 0);
        }
        [TestMethod]
        public void PagingFilterTest3()
        {
            var data = MakeData().AsQueryable().Pagination(3,10).ToList();
            Assert.IsTrue(data.Count == 10);
        }
        [TestMethod]
        public void PagingFilterTest4()
        {
            IList<Student> students = new List<Student>();
            var data = students.AsQueryable().Pagination(3).ToList();
            Assert.IsTrue(data.Count == 0);
        }
        [TestMethod]
        public void PagingFilterTest5()
        {
            var data = MakeData().AsQueryable().Pagination(x=>x.Name=="test0").ToList();
            Assert.IsTrue(data.Count == 1);
        }
        [TestMethod]
        public void PagingResult1()
        {
            var data = MakeData().AsQueryable().PaginationToResult(3);
            Assert.IsTrue(data.Results.ToList().Count == 0);
        }
        [TestMethod]
        public void PagingResult2()
        {
            var data = MakeData().AsQueryable().PaginationToResult(x=>x.Name=="test0");
            Assert.IsTrue(data.Results.ToList().Count == 1);
        }
    }
}
