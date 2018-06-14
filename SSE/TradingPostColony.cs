using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class TradingPostColony:Colony {
        public TradingPostColony(Player owner):base(owner) {
            this.type = "tradepost";
        }
    }
}
