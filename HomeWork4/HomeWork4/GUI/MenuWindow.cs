using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.GUI
{
    class MenuWindow : Window
    {
        public Button PlayButton { get; }
        public Button QuitButton { get; }
        private TextBlock _title;

        public List<Button> MenuWindowButtons { get; private set; } = new List<Button>();

        public MenuWindow() : base(0, 0, 120, 30, 'o')
        {
            _title = new TextBlock(10, 5, 100, new List<string> { "WELCOME TO DICE GAME!", " ", "MAIN MENU"});

            PlayButton = new Button(20, 12, 18, 5, "PLAY");
            PlayButton.SetActive();
            QuitButton = new Button(80, 12, 18, 5, "QUIT");

            MenuWindowButtons.Add(PlayButton);
            MenuWindowButtons.Add(QuitButton);


        }

        public override void Render()
        {
            base.Render();
            PlayButton.Render();
            QuitButton.Render();
            _title.Render();

        }
    }
}
