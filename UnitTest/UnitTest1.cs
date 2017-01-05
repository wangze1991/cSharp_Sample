using System;
using Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var annoy = new { age = 1, name = "wangze" };
            object obj = new {age="1",name="www" };
            var result = obj.Cast(annoy);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestLog()
        {
            LogWrapper.Info("测试一下");
        }
        [TestMethod]
        public void TestDebugLog()
        {
            LogWrapper.Debug("测试一下");
        }
    }
}
