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

        [NamePosition(2, Name = "SecChUaFullVersionList")]
        public string SecChUaFullVersionList { get; set; }

        [NamePosition(3, Name = "SecChUaMobile")]
        public string SecChUaMobile { get; set; }

        [NamePosition(4, Name = "SecChUaFullVersion")]
        public string SecChUaFullVersion { get; set; }

        [NamePosition(5, Name = "SecChUaPlatform")]
        public string SecChUaPlatform { get; set; }

        [NamePosition(6, Name = "SecChUaPlatformVersion")]
        public string SecChUaPlatformVersion { get; set; }
        
        [NamePosition(7, Name = "SecChUaModel")]
        public string SecChUaModel { get; set; }

        [NamePosition(8, Name = "ua")]
        public string Ua { get; set; }
    }
}
