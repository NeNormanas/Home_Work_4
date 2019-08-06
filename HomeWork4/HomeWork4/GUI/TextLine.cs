using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.GUI
{
    class TextLine : GuiObject
    {

        public string Label { get; private set; }

        

        public TextLine(int x,  int y, int width, string data) : base(x, y, width, 0)
        {

            Label = data;
            
        }

       

        public override void Render()
        {

            Console.SetCursorPosition(X, Y);
            if (Width > Label.Length)
            {
                int offset = (Width - Label.Length) / 2;
                for (int i = 0; i < offset; i++)
                {
                    Console.Write(' ');
                }
            }

            Console.Write(Label);

        }

    }
}
