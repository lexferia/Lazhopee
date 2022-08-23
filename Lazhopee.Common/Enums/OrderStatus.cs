using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazhopee.Common.Enums
{
    public enum OrderStatus
    {
        Pending = 1,
        ToShip = 2,
        ToReceive = 4,
        Compeleted = 8,
        Cancel = 16    
    }
}
