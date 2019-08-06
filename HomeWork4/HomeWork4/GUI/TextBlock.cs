using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.GUI
{
    class TextBlock : GuiObject
    {

        private List<TextLine> TextsBlock = new List<TextLine>();

        public TextBlock(int x, int y, int width, List<string> textLines ) : base(x, y, width, 0)
        {
            for (int i = 0; i < textLines.Count; i++)
            {
                TextsBlock.Add(new TextLine(x, y + i, width, textLines[i]));

            }

        }

        public override void Render()
        {
            for (int i = 0; i < TextsBlock.Count; i++)
            {
                TextsBlock[i].Render();
            }
        }
    }
}
