using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples
{
    public class AppSettings
    {
        public AppSettingsSection1 Section1 { get; set; }
        public AppSettingsSection2 Section2 { get; set; }
    }

    public class AppSettingsSection1
    {
        public string SettingA { get; set; }
        public string SettingB { get; set; }
    }

    public class AppSettingsSection2
    {
        public string SettingC { get; set; }
    }
}
