using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ScanApp.BaseModule
{
    public class ProcessInfo
    {
        public string ProcessName;
        public string ProcessPath;

        public ProcessInfo()
        {
            ProcessName = string.Empty;
            ProcessPath = string.Empty;
        }
    }
}
