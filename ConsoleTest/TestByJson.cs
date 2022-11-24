using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Udger.Parser;
using Udger.Parser.Input;

namespace ConsoleTest
{
    class TestByJson
    {

        //[JsonPropertyName("Wind")]
        private string filePath;
        public TestByJson(string _filePath)
        {
            filePath = _filePath;
        }

        public List<string> doTest()
        {
            Udger.Parser.UserAgent u,uToCompare;
            Udger.Parser.IPAddress i;
            List<string> listToRet = new List<string>();
           // Create a new UdgerParser object
           UdgerParser parser = new UdgerParser();


            // or Create and set LRU Cache capacity
            //UdgerParser parser = new UdgerParser(5000);

            // Set data dir (in this directory is stored data file: udgerdb_v4.dat)
            // Test data file is available on:  https://github.com/udger/test-data/tree/master/data_v4
            // Full data file can be downloaded manually from http://data.udger.com/, but we recommend use udger-updater
            parser.SetDataDir(@"C:\udger");


            //var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData.json");
            var jsonText = File.ReadAllText(filePath);

            try
            {
                Newtonsoft.Json.JsonSerializer json = new Newtonsoft.Json.JsonSerializer();

                json.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                json.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Replace;
                json.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
                json.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                StringReader sr = new StringReader(jsonText);

                Newtonsoft.Json.JsonTextReader reader = new JsonTextReader(sr);
                var result = json.Deserialize<List<JObject>>(reader);
                var ts  = result.Values("test");
                var ret = result.Values("ret").GetEnumerator() ;

                int count = 0;
                foreach (var test in ts)
                {
                    //var h = test.Select(t => new Header() { SecChUa = t.Value<string>("Sec-Ch-Ua") }).SingleOrDefault();
                    Header h = new Header() { SecChUa = test.Value<string>("Sec-Ch-Ua"),
                                                SecChUaFullVersion = test.Value<string>("Sec-Ch-Ua-Full-Version"),
                                                SecChUaFullVersionList = test.Value<string>("Sec-Ch-Ua-Full-Version-List"),
                                                SecChUaMobile = test.Value<string>("Sec-Ch-Ua-Mobile"),
                                                SecChUaModel = test.Value<string>("Sec-Ch-Ua-Model"),
                                                SecChUaPlatform = test.Value<string>("Sec-Ch-Ua-Platform"),
                                                SecChUaPlatformVersion = test.Value<string>("Sec-Ch-Ua-Platform-Version"),
                                                Ua = test.Value<string>("User-Agent")


                    };
                    parser.ua = test.Value<string>("User-Agent");


                    parser.header = h;
                    parser.parse();
                    
                    u =  parser.userAgent;
                    ret.MoveNext();
                    
                    var r = ret.Current;
                    uToCompare = new UserAgent()
                    {
                        CrawlerCategory = r.Value<string>("crawler_category"),
                        CrawlerCategoryCode = r.Value<string>("crawler_category_code"),
                        CrawlerLastSeen = null,
                        CrawlerRespectRobotstxt = r.Value<string>("crawler_respect_robotstxt"),
                        DeviceBrand = r.Value<string>("device_brand"),
                        DeviceBrandCode = r.Value<string>("device_brand_code"),
                        DeviceBrandHomepage = r.Value<string>("device_brand_homepage"),
                        DeviceBrandIcon = r.Value<string>("device_brand_icon"),
                        DeviceBrandIconBig = r.Value<string>("device_brand_icon_big"),
                        DeviceBrandInfoUrl = r.Value<string>("device_brand_info_url"),
                        DeviceClass = r.Value<string>("device_class"),
                        DeviceClassCode = r.Value<string>("device_class_code"),
                        DeviceClassIcon = r.Value<string>("device_class_icon"),
                        DeviceClassIconBig = r.Value<string>("device_class_icon_big"),
                        DeviceClassInfoUrl = r.Value<string>("device_class_info_url"),
                        DeviceMarketname = r.Value<string>("device_marketname"),
                        Os = r.Value<string>("os"),
                        OsCode = r.Value<string>("os_code"),
                        OsFamily = r.Value<string>("os_family"),
                        OsFamilyCode = r.Value<string>("os_family_code"),
                        OsFamilyVendor = r.Value<string>("os_family_vendor"),
                        OsFamilyVendorCode = r.Value<string>("os_family_vendor_code"),
                        OsFamilyVendorHomepage = r.Value<string>("os_family_vendor_homepage"),
                        OsHomepage = r.Value<string>("os_homepage"),
                        OsIcon = r.Value<string>("os_icon"),
                        OsIconBig = r.Value<string>("os_icon_big"),
                        OsInfoUrl = r.Value<string>("os_info_url"),
                        SecChUa = r.Value<string>("sec_ch_ua"),
                        SecChUaFullVersion = r.Value<string>("sec_ch_ua_full_version"),
                        SecChUaFullVersionList = r.Value<string>("sec_ch_ua_full_version_list"),
                        SecChUaMobile = r.Value<string>("sec_ch_ua_mobile"),
                        SecChUaModel = r.Value<string>("sec_ch_ua_model"),
                        SecChUaPlatform = r.Value<string>("sec_ch_ua_platform"),
                        SecChUaPlatformVersion = r.Value<string>("sec_ch_ua_platform_version"),
                        Ua = r.Value<string>("ua"),
                        UaClass = r.Value<string>("ua_class"),
                        UaClassCode = r.Value<string>("ua_class_code"),
                        UaEngine = r.Value<string>("ua_engine"),
                        UaFamily = r.Value<string>("ua_family"),
                        UaFamilyCode = r.Value<string>("ua_family_code"),
                        UaFamilyHompage = r.Value<string>("ua_family_homepage"),
                        UaFamilyIcon = r.Value<string>("ua_family_icon"),
                        UaFamilyIconBig = r.Value<string>("ua_family_icon_big"),
                        UaFamilyInfoUrl = r.Value<string>("ua_family_info_url"),
                        UaFamilyVendor = r.Value<string>("ua_family_vendor"),
                        UaFamilyVendorCode = r.Value<string>("ua_family_vendor_code"),
                        UaFamilyVendorHomepage = r.Value<string>("ua_family_vendor_homepage"),
                        UaString = r.Value<string>("ua_string"),
                        UaUptodateCurrentVersion = r.Value<string>("ua_uptodate_current_version"),
                        UaVersion = r.Value<string>("ua_version"),
                        UaVersionMajor = r.Value<string>("ua_version_major")
                    };

                    count++;

                    listToRet.Add($"{count}{System.Environment.NewLine}{u.Compare(uToCompare)}");

                }
                reader.Close();
                //return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listToRet;
        }
    }
}
