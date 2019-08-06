using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.GUI
{
    abstract class GuiObject
    {
        public int X { get; set; }
        public int Width { get; set; }
        public int Hight { get; set; }
        public int Y { get; set; }


        public GuiObject(int x, int y, int width, int hight)
        {
            X = x;
            Y = y;
            Width = width;
            Hight = hight;
        }

        abstract public void Render();
        
        
    }
}
