using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMusCringleW
{
    public class ViewModelLocator
    {
        private XMusCringleLib.Main _main;
        public XMusCringleLib.Main Main
        {
            get
            {
                if (_main == null) _main = new XMusCringleLib.Main();
                return _main;
            }
        }
    }
}
