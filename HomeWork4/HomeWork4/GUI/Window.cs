using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.GUI
{
    class Window : GuiObject
    {
        private Frame _border;

        public Window( int x,  int y, int width, int hight, char symbol) : base(x,  y, width, hight)
        {
            _border = new Frame(x,  y, width, hight, symbol);

        }

        public override void Render()
        {
            _border.Render();
        }
    }
}
