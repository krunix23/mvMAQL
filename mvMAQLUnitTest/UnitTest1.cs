using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mv.MAQL;

namespace mvMAQLUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        const string knownMAC = "00:0C:8D:00:0C:F1";
        const string knownSerial = "MS000241";
        const string knownType = "mvBlueGEMINI";

        [TestMethod]
        public void test_ConfigHandlingConstructor()
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
                Assert.IsFalse(string.IsNullOrEmpty(cfg_.LicenseStoreDir()));
        }

        [TestMethod]
        public void test_ConfigHandlingValidCameraTypes()
        {
            // we check defined camera types in config.xml against a hardcoded list
            // if changes occur in config.xml, this test needs adaptions
            string[] ValidCameraTypes = { "mvBlueGEMINI", "BlfCam_Profinet", "BlfCam_TCP" };
            int NumValidCameraTypes = ValidCameraTypes.Length;

            ConfigHandling cfg_ = new ConfigHandling();

            string[] CameraTypes = cfg_.GetAllTypes();
            int NumCameraTypes = CameraTypes.Length;

            Assert.AreEqual(NumCameraTypes, NumValidCameraTypes);

            foreach( string type in CameraTypes )
            {
                bool found = false;
                foreach( string validtype in ValidCameraTypes)
                {
                    if( type == validtype)
                    {
                        found = true;
                        break;
                    }
                }
                Assert.IsTrue(found, string.Format("CameraType {0} was not found in list of valid camera types", type));
            }
        }

        [TestMethod]
        public void test_ConfigHandlingDefaultMACEachType()
        {
            ConfigHandling cfg_ = new ConfigHandling();

            string[] CameraTypes = cfg_.GetAllTypes();
            Assert.IsNotNull(CameraTypes.Length, "No camera types have been found in config.xml");

            foreach( string type in CameraTypes )
            {
                Assert.IsFalse(string.IsNullOrEmpty(cfg_.GetDefaultMAC(type)), string.Format("Can't get default MAC for {0}", type));
            }
        }

        [TestMethod]
        public void test_MAQLHandlingConstructor()
        {
            try
            {
                ConfigHandling cfg_ = new ConfigHandling();
                mvSQLDataHandlingBase sqldata_ = new mvOSQLDataHandling(cfg_.DatabaseName(), cfg_.ConnectionString());
            }
            catch( Exception ex )
            {
                Assert.Fail(string.Format("An exception has been thrown: {0}", ex.Message));
            }
        }

        [TestMethod]
        public void test_MAQLHandlingFindMAC()
        {
            ConfigHandling cfg_ = new ConfigHandling();
            mvSQLDataHandlingBase sqldata_ = new mvOSQLDataHandling(cfg_.DatabaseName(), cfg_.ConnectionString());

            Assert.IsTrue(!string.IsNullOrEmpty(sqldata_.FindMAC(knownType, knownMAC)), string.Format("MAC {0} could not be found in database", knownMAC));

            Random rand = new Random();
            int RandomValue = rand.Next(0xffff);
            Int64 RandomMAC = mvSQLDataHandlingBase.MACStringToInt64(knownMAC) - RandomValue;
            Assert.IsTrue(string.IsNullOrEmpty(sqldata_.FindMAC(knownType, mvSQLDataHandlingBase.MACInt64ToString(RandomMAC))), string.Format("Random MAC {0} found in database", knownMAC));
        }
    }
}