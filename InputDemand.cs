using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTKM_1
{
    class InputDemand
    {
        public int id;
        public int startNode;
        public int endNode;
        public int volume;
        public int numberOfDemandPaths;
        public List<InputDemandPath> demandPaths;

        public InputDemand()
        {
            demandPaths = new List<InputDemandPath>();
        }

    }
}
