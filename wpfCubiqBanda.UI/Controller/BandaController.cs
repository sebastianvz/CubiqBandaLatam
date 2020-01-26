using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfCubiqBanda.UI.Helper;

namespace wpfCubiqBanda.UI.Controller
{
    public class BandaController
    {
        public string APi()
        {
            return Utilities.DoRequest();
        }
    }
}
