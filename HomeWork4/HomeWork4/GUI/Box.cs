using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.GUI
{
    class Box : GuiObject, IRenderable
    {
        public bool isActive { get; set; } = false;

        private Frame _activeBox;
        private Frame _notActiveBox;

        private TextLine _boxText; 

        public Box(int x, int y, int width, int hight, string boxText): base(x,y,width,hight)
        {
            _activeBox = new Frame(x, y, width, hight, '@');
            _notActiveBox = new Frame(x, y, width, hight, '+');

            _boxText = new TextLine(x + 1, y + 1 + ((hight - 2) / 2), width - 2, boxText);


        }


        public void SetActive()
        {
            isActive = true;
        }


        public void Disable()
        {
            isActive = false;
        }

        public override void Render()
        {
            if (isActive)
            {
                _activeBox.Render();
            }
            else
            {
                _notActiveBox.Render();
            }
            _boxText.Render();
        }
    }
}
