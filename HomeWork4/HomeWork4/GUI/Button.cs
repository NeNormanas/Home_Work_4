using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.GUI
{
    class Button : GuiObject, IRenderable
    {
        public bool isActive { get; set; } = false;

        private Frame _activeButtonFrame;
        private Frame _notActiveButtonFrame;
        public TextLine _buttonText { get; }

        public Button(int x, int y, int width, int hight, string buttonText) : base(x, y, width, hight)
        {

            _activeButtonFrame = new Frame(x, y, width, hight, '@');
            _notActiveButtonFrame = new Frame(x, y, width, hight, '^');

            _buttonText = new TextLine (x + 1, y + 1 + ((hight - 2) / 2), width - 2,  buttonText);

        }


        public override void Render()
        {
            if (isActive)
            {
                _activeButtonFrame.Render();
            }
            else
            {
                _notActiveButtonFrame.Render();
            }
            _buttonText.Render();
        }

        public void SetActive()
        {
            isActive = true;
        }

        public void Disable()
        {
            isActive = false;
        }
    }
}
