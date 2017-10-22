using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTKM_1
{
    class InputData
    {
        public int numberOfLinks;
        public int numberOfDemands;
        public List<InputLink> links;
        public List<InputDemand> demands;

        public InputData()
        {
        links = new List<InputLink>();
        demands = new List<InputDemand>();
        }
    }
}
