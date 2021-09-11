using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Domain.Entities
{
    public class Selling : Transaction
    {
        public Selling()
        {
            Side = "Sell";
        }

        
        
    }
}
