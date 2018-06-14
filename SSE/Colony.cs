using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class Colony {
        public Player owner;
        public String type { get; set; }

        public Colony(Player owner) {
            this.owner = owner;
            this.type = "colony";
        }
    }
}
