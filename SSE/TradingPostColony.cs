using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    [Serializable()]
    public class TradingPostColony:Colony {
        public TradingPostColony(Player owner):base(owner) {
            this.isColony = false;
        }
    }
}
