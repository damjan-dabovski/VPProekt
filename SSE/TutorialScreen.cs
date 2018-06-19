using System;
using System.Collections.Generic;
using System.Drawing;
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
            this.background = Properties.Resources.tutorial;
            this.buttons[0].Text = "Back"; 
            buttons[0].Location = new Point(25,height-83);
            buttons[0].Size = new Size(158, 58);
            buttons[0].BackgroundImage = Properties.Resources.mainmenubutton;
            buttons[0].BackgroundImageLayout = ImageLayout.Zoom;
            buttons[0].BackColor = Color.Transparent;
            buttons[0].FlatAppearance.BorderSize = 0;
            buttons[0].FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttons[0].FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttons[0].FlatStyle = FlatStyle.Flat;
        }
    }
}
