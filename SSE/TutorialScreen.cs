using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSE {
    public class TutorialScreen : MenuState {
        public Button back;

        public TutorialScreen(int width, int height): base(width,height){
            back = new Button();
            this.buttons = new Button[1] { back };
            //TODO custom image and button positioning
        }
    }
}
