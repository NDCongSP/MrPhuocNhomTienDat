using DemoPhucThinh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPhucThinh
{
    public static class VariableGlobal
    {
        public static string PathFile = "";
        public static ModelTimeInterval TimeInterval { get; set; } = new ModelTimeInterval();
        public static List<LimitSettingsModel> LimitParametter { get; set; } = new List<LimitSettingsModel>();
        public static bool IsLogin { get; set; } = false;
    }
}
