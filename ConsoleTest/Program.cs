/*
  UdgerParser - Test - Local parser lib 
 
  author     The Udger.com Team (info@udger.com)
  copyright  Copyright (c) Udger s.r.o.
 
  license    GNU Lesser General Public License
  link       http://udger.com/products/local_parser
*/


using System;
using System.Collections.Generic;
using System.IO;
using Udger.Parser;


namespace ConsoleTest
{
    class Program
    {

        static void Main(string[] args)
        {
            TestByJson jsonTest;

            jsonTest = new TestByJson(@"C:\udger\test_ua.json");
            var retJson = jsonTest.doTest();

            foreach (var line in retJson)
            {
                Console.WriteLine(line);
            }
            
            Console.ReadLine();


            Udger.Parser.UserAgent a;
            Udger.Parser.IPAddress i;

            // Create a new UdgerParser object
            UdgerParser parser = new UdgerParser();
            // or Create and set LRU Cache capacity
            //UdgerParser parser = new UdgerParser(5000);

            // Set data dir (in this directory is stored data file: udgerdb_v4.dat)
            // Test data file is available on:  https://github.com/udger/test-data/tree/master/data_v4
            // Full data file can be downloaded manually from http://data.udger.com/, but we recommend use udger-updater
            parser.SetDataDir(@"C:\udger");
            // or set data dir and DB filename
            //parser.SetDataDir(@"C:\udger", "udgerdb_v4-noip.dat ");

            // Set user agent and /or IP address
            parser.ua = @"Mozilla/5.0 (compatible; SeznamBot/3.2; +http://fulltext.sblog.cz/)";
            parser.ip = "77.75.74.35";

            // Parse
            parser.setHeader(@"Sec-Ch-Ua: ""Chromium"";v=""104"", "" Not A;Brand"";v=""99"", ""Google Chrome"";v=""104""
Sec-Ch-Ua-Mobile: ?0
Sec-Ch-Ua-Full-Version: ""104.0.5112.102""
Sec-Ch-Ua-Arch: ""x86""
Sec-Ch-Ua-Platform: ""Windows""
Sec-Ch-Ua-Platform-Version: ""14.0.0""
Sec-Ch-Ua-Model: """"
Sec-Ch-Ua-Bitness: ""64""
Sec-Ch-Ua-Full-Version-List: ""Chromium"";v=""104.0.5112.102"", "" Not A;Brand"";v=""99.0.0.0"", ""Google Chrome"";v=""104.0.5112.102""
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36");

            parser.parse();

            parser.setHeader(@"Sec-Ch-Ua: ""Chromium"";v=""104"", "" Not A;Brand"";v=""99"", ""Google Chrome"";v=""104""
Sec-Ch-Ua-Mobile: ?0
Sec-Ch-Ua-Platform: ""Windows""
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36");
            parser.parse();

            parser.header.SecChUaFullVersionList = @"""Chromium"";v=""104.0.5112.102"", "" Not A;Brand"";v=""99.0.0.0"", ""Google Chrome"";v=""104.0.5112.102""";
            parser.header.SecChUaMobile = @"?0";
            parser.header.SecChUaPlatform = @"""Windows""";
            parser.header.SecChUaPlatformVersion = @"""14.0.0""";

            parser.parse();

            parser.header.SecChUaFullVersionList = @"""Chromium"";v=""104.0.5112.102"", "" Not A;Brand"";v=""99.0.0.0"", ""Google Chrome"";v=""104.0.5112.102""";
            parser.header.SecChUaMobile = @"?0";
            parser.header.SecChUaPlatform = @"""Windows""";
            parser.header.SecChUaPlatformVersion = @"""14.0.0""";

            parser.parse();

            parser.header.SecChUa = @"""Chromium"";v=""104"", "" Not A; Brand"";v=""99"", ""Google Chrome"";v=""104""";
            parser.header.SecChUaMobile = @"?0";
            parser.header.SecChUaFullVersion = @"""97.0.4692.71""";

            parser.parse();

            parser.header.SecChUa = @"""Chromium"";v=""104"", "" Not A; Brand"";v=""99"", ""Google Chrome"";v=""104""";
            parser.header.SecChUaMobile = @"?1";
            parser.header.SecChUaFullVersion = @"""104.0.5112.97""";
            parser.ua = @"Mozilla/5.0 (Linux; Android 11; CPH2001) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Mobile Safari/537.36";
            parser.header.SecChUaFullVersionList = @"""Chromium"";v=""104.0.5112.102"", "" Not A;Brand"";v=""99.0.0.0"", ""Google Chrome"";v=""104.0.5112.102""";
            parser.header.SecChUaModel = @"""CPH2001""";
            parser.header.SecChUaPlatform = @"""Android""";
            parser.header.SecChUaPlatformVersion = @"""11.0.0""";

            parser.parse();

            // Get information 
            a = parser.userAgent;
            i = parser.ipAddress;

            // Set user agent and /or IP address
            parser.ua = @"Mozilla/5.0 (Linux; U; Android 4.0.4; sk-sk; Luna TAB474 Build/LunaTAB474) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Safari/534.30";
            parser.parse();
            a = parser.userAgent;


            parser.ip = "2a02:598:111::9";
            parser.parse();
            i = parser.ipAddress;

        }


    }
}
