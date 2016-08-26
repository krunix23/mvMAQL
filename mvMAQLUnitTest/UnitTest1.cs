using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mv.MAQL;

namespace mvMAQLUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void test_ConfigHandingConstructor()
        {
            try
            {
                ConfigHandling cfg_ = new ConfigHandling();
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("An exception has been thrown: {0}", ex.Message));
            }
        }

        [TestMethod]
        public void test_ConfigHandlingPublicMethods()
        {
                ConfigHandling cfg_ = new ConfigHandling();
                Assert.IsFalse(string.IsNullOrEmpty(cfg_.ConnectionString()));
                Assert.IsFalse(string.IsNullOrEmpty(cfg_.DatabaseName()));
                Assert.IsFalse(string.IsNullOrEmpty(cfg_.DatabaseProvider()));
        }
    }
}
