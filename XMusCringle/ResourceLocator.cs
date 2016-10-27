using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMusCringle
{
    public static class ResourceLocator
    {
        private static XMusCringleLib.Main _main;
        public static XMusCringleLib.Main Main
        {
            get
            {
                if (_main == null) _main = new XMusCringleLib.Main();
                return _main;
            }
        }
    }
}
