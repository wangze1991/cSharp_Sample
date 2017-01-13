using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

namespace UtilsTest
{
    [TestClass]
    public class ConvTest
    {

        
        [TestMethod]

        public void TestConvInt() {

            DBNull value1 = DBNull.Value;
            Assert.IsNull(Conv.ToNullableInt(value1));
            string value2 = "ab1";
            Assert.AreEqual(Conv.ToInt(value2), 0);
            string value3 = "12";
            Assert.AreEqual(Conv.ToInt(value3), 12);
            Assert.AreEqual(Conv.ToInt(12), 12);
        }

        [TestMethod]
        public void TestGuid() {
            Guid guid = Guid.NewGuid();
            Assert.IsNull(Conv.ToNullableGuid("abc"));
            Assert.AreNotEqual<Guid?>(Conv.ToNullableGuid(guid.ToString()),Guid.Empty);

            Assert.AreEqual(Conv.ToNullableGuid(guid),guid);
        }
    }
}
