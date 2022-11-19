using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Udger.Parser.Input
{
    public class Header
    {
        [NamePosition(1, Name = "Sec-Ch-Ua")]    
        public string SecChUa { get; set; }

        [NamePosition(2, Name = "Sec-Ch-Ua-Full-Version-List")]
        public string SecChUaFullVersionList { get; set; }

        [NamePosition(3, Name = "Sec-Ch-Ua-Mobile")]
        public string SecChUaMobile { get; set; }

        [NamePosition(4, Name = "Sec-Ch-Ua-Full-Version")]
        public string SecChUaFullVersion { get; set; }

        [NamePosition(5, Name = "Sec-Ch-Ua-Platform")]
        public string SecChUaPlatform { get; set; }

        [NamePosition(6, Name = "Sec-Ch-Ua-Platform-Version")]
        public string SecChUaPlatformVersion { get; set; }
        
        [NamePosition(7, Name = "Sec-Ch-Ua-Model")]
        public string SecChUaModel { get; set; }

        [NamePosition(8, Name = "User-Agent")]
        public string Ua { get; set; }

        public string cacheCode()
        {
            return $"{SecChUa} + {SecChUaFullVersionList} + {SecChUaMobile} + {SecChUaFullVersion} + {SecChUaPlatform} +  {SecChUaPlatformVersion} + {SecChUaModel}+ {Ua}";
        }
    }
}