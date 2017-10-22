using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTKM_1
{
    class Route
    {
        public int demandId;
        public int demandPathId;
        public List<int> usedLinks = new List<int>();
    }
}
