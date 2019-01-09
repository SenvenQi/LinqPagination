using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LinqPagination;

namespace FunctionExtentionTest
{
    [TestClass]
    public class FuncExtentionTest
    {
        public class TestStudent
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public class TestStudentTo
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        [TestMethod]
        public void DoTest()
        {
            var testStudent = new TestStudent();
            Assert.AreEqual(testStudent, testStudent.Do(x => x.Name = "Test"));
            Assert.IsTrue(testStudent.Name.Equals("Test"));
        }
        [TestMethod]
        public void EachDoTest()
        {
            var testStudent = CreateTestList().ToList();
            Assert.AreEqual(testStudent, testStudent.EachDo(x => x.Name = "Test"));
        }
        public void EachToTest()
        {
            var testStudent = CreateTestList();
            var testToData = testStudent.EachTo(x => new TestStudentTo { Name = x.Name, Age = x.Age });
            Type t = testToData.GetType().GenericTypeArguments[0];
            Assert.IsTrue(t == typeof(TestStudentTo));
        }

        public IEnumerable<TestStudent> CreateTestList()
        {
            var testStudent = new List<TestStudent>();
            100.ForByCount(x => testStudent.Add(
                new TestStudent
                {
                    Name = "Test" + x
                }
            ));
            return testStudent;
        }
    }
}
