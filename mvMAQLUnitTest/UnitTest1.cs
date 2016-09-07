using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mv.MAQL;
using System.Threading;
using System.IO;

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
            catch (Exception ex)
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
        public void test_01ConfigHandlingPublicMethods()
        {
            Assert.IsFalse(string.IsNullOrEmpty(cfg_.ConnectionString()));
            Assert.IsFalse(string.IsNullOrEmpty(cfg_.DatabaseName()));
            Assert.IsFalse(string.IsNullOrEmpty(cfg_.DatabaseProvider()));
            Assert.IsFalse(string.IsNullOrEmpty(cfg_.LicenseStoreDir()));
        }

        [TestMethod]
        public void test_02ConfigHandlingValidCameraTypes()
        {
            // we check defined camera types in config.xml against a hardcoded list
            // if changes occur in config.xml, this test needs adaptions
            string[] ValidCameraTypes = { "mvBlueGEMINI", "BlfCam_Profinet", "BlfCam_TCP" };
            int NumValidCameraTypes = ValidCameraTypes.Length;

            string[] CameraTypes = cfg_.GetAllTypes();
            int NumCameraTypes = CameraTypes.Length;

            Assert.AreEqual(NumCameraTypes, NumValidCameraTypes);

            foreach (string type in CameraTypes)
            {
                bool found = false;
                foreach (string validtype in ValidCameraTypes)
                {
                    if (type == validtype)
                    {
                        found = true;
                        break;
                    }
                }
                Assert.IsTrue(found, string.Format("CameraType {0} was not found in list of valid camera types", type));
            }
        }

        [TestMethod]
        public void test_03ConfigHandlingDefaultMACEachType()
        {
            string[] CameraTypes = cfg_.GetAllTypes();
            Assert.IsNotNull(CameraTypes.Length, "No camera types have been found in config.xml");

            foreach (string type in CameraTypes)
            {
                Assert.IsFalse(string.IsNullOrEmpty(cfg_.GetDefaultMAC(type)), string.Format("Can't get default MAC for {0}", type));
            }
        }

        [TestMethod]
        public void test_04MAQLHandlingFindMAC()
        {
            Assert.IsTrue(!string.IsNullOrEmpty(sqldata_.FindMAC(knownType, knownMAC)), string.Format("MAC {0} could not be found in database", knownMAC));

            Random rand = new Random();
            int RandomValue = rand.Next(0xffff);
            Int64 RandomMAC = mvSQLDataHandlingBase.MACStringToInt64(knownMAC) - RandomValue;
            Assert.IsTrue(string.IsNullOrEmpty(sqldata_.FindMAC(knownType, mvSQLDataHandlingBase.MACInt64ToString(RandomMAC))), string.Format("Random MAC {0} found in database", knownMAC));
        }

        [TestMethod]
        public void test_05MAQLHandlingInsertMAC()
        {
            Assert.IsFalse(sqldata_.InsertMAC(knownType, knownMAC));
        }

        [TestMethod]
        public void test_06MAQLHandlingInsertLicenseFile()
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
        public void test_07MAQLHandlingFindUnusedMAC()
        {
            string[] CameraTypes = cfg_.GetAllTypes();
            foreach (string type in CameraTypes)
            {
                Assert.IsFalse(string.IsNullOrEmpty(sqldata_.FindUnusedMAC(type)));
            }
        }

        [TestMethod]
        public void test_08MAQLHandlingDisposeSerialnumber()
        {
            Assert.IsFalse(sqldata_.DisposeSerialnumber(null));
            Assert.IsFalse(sqldata_.DisposeSerialnumber(""));
            Assert.IsFalse(sqldata_.DisposeSerialnumber("RESERVED"));
            Assert.IsFalse(sqldata_.DisposeSerialnumber("deadaffe"));
        }

        [TestMethod]
        public void test_09MAQLHandlingStaticMethods()
        {
            Int64 tmp = mvSQLDataHandlingBase.MACStringToInt64(knownMAC);
            int result = knownMAC.CompareTo(mvSQLDataHandlingBase.MACInt64ToString(tmp));
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void test_10MAQLHandlingFindMACBySerial()
        {
            Assert.AreEqual(sqldata_.FindMACBySerial(knownType, knownSerial), knownMAC, "Can't find {0} MAC for serial={1}", knownType, knownSerial);
        }

        [TestMethod]
        public void test_10MAQLHandlingUpdateMACWithSerial()
        {
            Assert.IsFalse(sqldata_.UpdateMACWithSerial(knownType, knownMAC, knownSerial), "Expected, that {0} is assgined to {1} for {2}, but is not.");
        }

        [TestMethod]
        public void test_11MAQLHandlingAssignSerialToMACAndDispose()
        {
            string[] CameryTypes = cfg_.GetAllTypes();
            Random rand = new Random();

            foreach (string type in CameryTypes)
            {
                int RandomValue = rand.Next(0xfff);
                Assert.AreNotEqual(0, RandomValue, "Generated random serialnumber is zero");

                string randSerial = string.Format("SES{0:D5}", RandomValue);
                string freeMAC = sqldata_.FindUnusedMAC(type);
                Assert.IsFalse(string.IsNullOrEmpty(freeMAC), "Can't find unused MAC for {0}", type);

                Assert.IsTrue(sqldata_.UpdateMACWithSerial(type, freeMAC, randSerial), "Assign serial to MAC returned failure");
                Console.WriteLine("Assigned serial={0} to MAC={1} for {2}", randSerial, freeMAC, type);
                Assert.IsTrue(sqldata_.DisposeSerialnumber(randSerial));
                Console.WriteLine("Disposed serial={0} from MAC={1} for {2}", randSerial, freeMAC, type);
            }
        }

        [TestMethod]
        public void test_12MAQLHandlingRetrieveLicenseFile()
        {
            byte[] license = sqldata_.RetrieveLicenseFile(knownType, knownMAC);
            Assert.IsNotNull(license.Length);
            string sLicense = System.Text.Encoding.Default.GetString(license);
            Console.WriteLine(sLicense);
        }

        [TestMethod]
        public void test_13MAQLHandlingLoadLicensesFromFolder()
        {
            byte[] license = sqldata_.RetrieveLicenseFile(knownType, knownMAC);
            Assert.IsNotNull(license.Length);
            string sLicense = System.Text.Encoding.Default.GetString(license);
            Console.WriteLine(sLicense);

            Directory.CreateDirectory(knownType);
            Random rand = new Random();
            Int64 randMACInt = rand.Next(0xffff) + 0x001893000000;
            string randMACStr = mvSQLDataHandlingBase.MACInt64ToString(randMACInt);
            string outFile = string.Format(@"{0}\license_{1:x12}.dat", knownType, randMACInt);
            File.WriteAllBytes(outFile, license);

            string resultMAC = sqldata_.LoadLicensesFromFolder(knownType, knownType);
            Assert.AreEqual(randMACStr, resultMAC);
            File.Delete(outFile);

            byte[] license2 = sqldata_.RetrieveLicenseFile(knownType, randMACStr);
            Assert.IsNotNull(license.Length);

            for (int i = 0; i < license.Length; ++i )
            {
                Assert.AreEqual(license[i], license2[i]);
            }
            
            Assert.IsTrue(sqldata_.DisposeLicense(knownType, randMACStr));
        }

        [TestMethod]
        public void test_14MAQLHandlingUpdateDateTime()
        {
            Assert.IsTrue(sqldata_.UpdateDateTime(knownType, knownMAC, knownSerial));
            Assert.IsTrue(sqldata_.UpdateDateTime(knownType, knownMAC));
        }
    }
}
