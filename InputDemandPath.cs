using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTKM_1
{
    class InputDemandPath
    {
        public int demandId;
        public List<int> linksIDs;

        public InputDemandPath()
        {
            linksIDs = new List<int>();
        }
    }
}
