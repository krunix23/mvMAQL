using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mv.MAQL;
using System.Threading;

namespace mvMAQLUnitTest
{
    public static class IntegrationTestsSynchronization
    {
        public static readonly object LockObject = new object();
    }

    [TestClass]
    public class UnitTest1
    {
        const string knownMAC = "00:0C:8D:00:0C:F1";
        const string knownSerial = "MS000241";
        const string knownType = "mvBlueGEMINI";

        private ConfigHandling cfg_ = null;
        private mvSQLDataHandlingBase sqldata_ = null;

        [TestInitialize]
        public void test_Init()
        {
            Monitor.Enter(IntegrationTestsSynchronization.LockObject);
            try
            {
                cfg_ = new ConfigHandling();
                sqldata_ = new mvOSQLDataHandling(cfg_.DatabaseName(), cfg_.ConnectionString());
            }
            catch(Exception ex)
            {
                Assert.Fail(string.Format("An exception has been thrown: {0}", ex.Message));
            }
        }

        [TestCleanup]
        public void test_Cleanup()
        {
            Monitor.Exit(IntegrationTestsSynchronization.LockObject);
            sqldata_.Dispose();
            sqldata_ = null;
            cfg_ = null;
            GC.Collect();
        }

        [TestMethod]
        public void test_ConfigHandlingPublicMethods()
        {
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
            string[] CameraTypes = cfg_.GetAllTypes();
            Assert.IsNotNull(CameraTypes.Length, "No camera types have been found in config.xml");

            foreach( string type in CameraTypes )
            {
                Assert.IsFalse(string.IsNullOrEmpty(cfg_.GetDefaultMAC(type)), string.Format("Can't get default MAC for {0}", type));
            }
        }

        [TestMethod]
        public void test_MAQLHandlingFindMAC()
        {
            Assert.IsTrue(!string.IsNullOrEmpty(sqldata_.FindMAC(knownType, knownMAC)), string.Format("MAC {0} could not be found in database", knownMAC));

            Random rand = new Random();
            int RandomValue = rand.Next(0xffff);
            Int64 RandomMAC = mvSQLDataHandlingBase.MACStringToInt64(knownMAC) - RandomValue;
            Assert.IsTrue(string.IsNullOrEmpty(sqldata_.FindMAC(knownType, mvSQLDataHandlingBase.MACInt64ToString(RandomMAC))), string.Format("Random MAC {0} found in database", knownMAC));
        }

        [TestMethod]
        public void test_MAQLHandlingInsertMAC()
        {
            Assert.IsFalse(sqldata_.InsertMAC(knownType, knownMAC));
        }

        [TestMethod]
        public void test_MAQLHandlingInsertLicenseFile()
        {
            // insert a null file
            Assert.IsFalse(sqldata_.InsertLicenseFile(knownType, knownMAC, null));

            // insert a license file which doesn't exist
            string NotExistingFile = @"C:\blabla_license.dat";
            Assert.IsFalse(sqldata_.InsertLicenseFile(knownType, knownMAC, NotExistingFile));

            // insert a license to a MAC which doesn't exist
            string PseudoLicenseFile = "config.xml";
            Random rand = new Random();
            int RandomValue = rand.Next(0xffff);
            Int64 RandomMAC = mvSQLDataHandlingBase.MACStringToInt64(knownMAC) - RandomValue;
            Assert.IsFalse(sqldata_.InsertLicenseFile(knownType, mvSQLDataHandlingBase.MACInt64ToString(RandomMAC), PseudoLicenseFile));

            // insert license where MAC and CameraType mismatch
            string[] CameraTypes = cfg_.GetAllTypes();
            foreach (string type in CameraTypes)
            {
                if (type != knownType)
                {
                    Assert.IsFalse(sqldata_.InsertLicenseFile(type, knownMAC, PseudoLicenseFile));
                }
            }
        }

        [TestMethod]
        public void test_MAQLHandlingFindUnusedMAC()
        {
            string[] CameraTypes = cfg_.GetAllTypes();
            foreach (string type in CameraTypes)
            {
                Assert.IsFalse(string.IsNullOrEmpty(sqldata_.FindUnusedMAC(type)));
            }
        }

        [TestMethod]
        public void test_MAQLHandlingDisposeSerialnumber()
        {
            Assert.IsFalse(sqldata_.DisposeSerialnumber(null));
            Assert.IsFalse(sqldata_.DisposeSerialnumber(""));
            Assert.IsFalse(sqldata_.DisposeSerialnumber("RESERVED"));
            Assert.IsFalse(sqldata_.DisposeSerialnumber("deadaffe"));
        }
    }
}