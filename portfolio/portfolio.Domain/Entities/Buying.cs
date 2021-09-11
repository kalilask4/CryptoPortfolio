using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Domain.Entities
{
    class Buying:Transaction
    {
        public Buying()
        {
            Side = "Buy";
        }
    }
}
