using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Udger.Parser.Input;

namespace ConsoleTest
{
    [Obsolete]
    class TestByJson
    {
        private string filePath;
        public TestByJson(string _filePath)
        {
            filePath = _filePath;
        }

        public bool doTest()
        {
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
                foreach (var test in result)
                {
                    var tst = test.SelectToken("test");
                    Header h = test.SelectToken("test").Select(t => new Header { SecChUa = t.SelectToken("Sec-Ch-Ua").Value<string>() }).Single();
                    foreach (var col in tst)
                    {
                         
                    }
                    
                }
                reader.Close();
                //return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
