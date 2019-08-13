using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.GUI
{
    class PlayAgainOrQuitMenuWindow :Window
    {
        public Button PlayAgain{ get; set; }
        public Button QuitButton { get; set; }

        public List<Button> PlayAgainButtonsList { get; private set; } = new List<Button>();

        public PlayAgainOrQuitMenuWindow(): base(0, 0, 120, 30, 'o')
        {
            PlayAgain = new Button(20, 12, 18, 5, "PLAY AGAIN");
            PlayAgain.SetActive();
            QuitButton = new Button(80, 12, 18, 5, "QUIT");

            PlayAgainButtonsList.Add(PlayAgain);
            PlayAgainButtonsList.Add(QuitButton);

        }



        public override void Render()
        {
            base.Render();
            PlayAgain.Render();
            QuitButton.Render();
        }

    }
}
