using HomeWork4.Game_Controller;
using HomeWork4.GUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.GUI_Controller
{
    enum MainAndPlayAgainMenuButtons { PLAY, QUIT }
    enum BoxesInPlayerSelection { P2, P3, P4, P5, P6, P7 }

    class GuiController
    {
        //KINTAMIEJI IR PROPERTIES

        public MenuWindow _MenuWindow { get; set; }
        public PlayerSelectionWindow _PlayerSelectionWindow { get; set; }
        public QuantityOfDiceWindow _QuantityOfDiceWindow { get; set; }
        public GameWindow _GameWindow { get; set; }
        public GameCotroller _GameCotroller { get; set; }
        public PlayAgainOrQuitMenuWindow _playAgainOrQuitMenuWindow { get; set; }

        public int QuantityOfPlayers { get; set; }
        public int DiceAmount { get; set; }


        private int _activeButtonNumberInMainMenu;
        private int _activeBoxNumberInPlayerSelectionWindow;
       
        public bool playAgain { get; set; }

        public TextLine NumOfDice { get; set; }
        public bool closeGUI { get; set; } = false;
        public bool closeAllProgram { get; set; } = false;

        //KONSTRUKTORIUS

        public GuiController()
        {
        }

        //FUNKCJIJOS 

        public void StartGuiController()
        {
            while (closeGUI != true)
            {
                _MenuWindow = new MenuWindow(); // sukuriu MeniuWindow Objekta.

                UsersActivityInMainMenu(); // Aktyvuoju pagrindini MENU;
                if (closeGUI == true) { break; }
                else
                {
                    _PlayerSelectionWindow = new PlayerSelectionWindow();
                    UsersActivityInPlayerSelectionMenu();
                    if (closeGUI == true) { break; }

                    _QuantityOfDiceWindow = new QuantityOfDiceWindow();
                    UsersActivityInQuantityOfDiceMenu();
                }
                closeGUI = true;
            }
            Console.ResetColor();
        }

        public void CheckActiveButton(List<Button> listOfButtons)
        {
            for (int i = 0; i < listOfButtons.Count; i++)
            {
                if (listOfButtons[i].isActive == true)
                {
                    _activeButtonNumberInMainMenu = i;
                    _activeBoxNumberInPlayerSelectionWindow = i;
                }
            }
        }

        public void CheckActiveBoxes(List<Box> listOfBoxes)
        {

            for (int i = 0; i < listOfBoxes.Count; i++)
            {
                if (listOfBoxes[i].isActive == true)
                {
                    _activeBoxNumberInPlayerSelectionWindow = i;
                }
            }
        }

        public void ActivateNextButtonInMainMenu(int activatedButtonNr)
        {
            switch (activatedButtonNr)
            {
                case (int)MainAndPlayAgainMenuButtons.PLAY:
                    _MenuWindow.PlayButton.Disable();
                    _MenuWindow.QuitButton.SetActive();
                    break;
                case (int)MainAndPlayAgainMenuButtons.QUIT:
                    _MenuWindow.QuitButton.Disable();
                    _MenuWindow.PlayButton.SetActive();
                    break;
                default:
                    break;
            }
        }

        public void ActivateNextButtonInPlayAgainMenu(int activatedButtonNr)
        {
            switch (activatedButtonNr)
            {
                case (int)MainAndPlayAgainMenuButtons.PLAY:
                    _playAgainOrQuitMenuWindow.PlayAgain.Disable();
                    _playAgainOrQuitMenuWindow.QuitButton.SetActive();
                    
                    break;
                case (int)MainAndPlayAgainMenuButtons.QUIT:
                    _playAgainOrQuitMenuWindow.QuitButton.Disable();
                    _playAgainOrQuitMenuWindow.PlayAgain.SetActive();
                    break;
                default:
                    break;
            }

        }

        public void UsersActivityInMainMenu()
        {
            bool closeWindow = false;
            while (closeWindow != true)
            {
                _MenuWindow.Render(); // nupiesiu pradini meniu

                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.Escape:
                        closeWindow = true; // isjungiu Menu Window
                        closeGUI = true;
                        closeAllProgram = true;
                        break;

                    case ConsoleKey.RightArrow:
                        CheckActiveButton(_MenuWindow.MenuWindowButtons); // Patikrinu kuris siuo metu mygtukas yra aktyvus 
                        ActivateNextButtonInMainMenu(_activeButtonNumberInMainMenu); // Aktyvuoju sekanti mygtuka, kadangi yra tik 2 mygtukai
                        break;

                    case ConsoleKey.LeftArrow:
                        CheckActiveButton(_MenuWindow.MenuWindowButtons); // Patikrinu kuris siuo metu mygtukas yra aktyvus 
                        ActivateNextButtonInMainMenu(_activeButtonNumberInMainMenu); // Aktyvuoju sekanti mygtuka, kadangi yra tik 2 mygtukai
                        break;

                    case ConsoleKey.Enter:
                        CheckActiveButton(_MenuWindow.MenuWindowButtons);
                        if (_activeButtonNumberInMainMenu == (int)MainAndPlayAgainMenuButtons.QUIT)
                        {
                            closeGUI = true;
                            closeAllProgram = true;
                        }
                        
                        closeWindow = true;
                        break;
                }

            }
        }

        public void UsersActivityInPlayerSelectionMenu()
        {
            bool closeWindow = false;

            while (closeWindow != true)
            {
                _PlayerSelectionWindow.Render();

                ConsoleKeyInfo pressedChar = Console.ReadKey(true);

                switch (pressedChar.Key)
                {
                    case ConsoleKey.Escape:
                        closeWindow = true; // isjungiu Si langa
                        closeGUI = true;
                        closeAllProgram = true;
                        break;

                    case ConsoleKey.RightArrow:

                        CheckActiveBoxes(_PlayerSelectionWindow.ListOfBoxes);
                        if (_activeBoxNumberInPlayerSelectionWindow < _PlayerSelectionWindow.ListOfBoxes.Count - 1)
                        {
                            _PlayerSelectionWindow.ListOfBoxes[_activeBoxNumberInPlayerSelectionWindow].Disable();
                            _PlayerSelectionWindow.ListOfBoxes[_activeBoxNumberInPlayerSelectionWindow + 1].SetActive();
                        }

                        break;
                    case ConsoleKey.LeftArrow:

                        CheckActiveBoxes(_PlayerSelectionWindow.ListOfBoxes);
                        if (_activeBoxNumberInPlayerSelectionWindow > 0)
                        {
                            _PlayerSelectionWindow.ListOfBoxes[_activeBoxNumberInPlayerSelectionWindow].Disable();
                            _PlayerSelectionWindow.ListOfBoxes[_activeBoxNumberInPlayerSelectionWindow - 1].SetActive();
                        }

                        break;

                    case ConsoleKey.UpArrow:

                        CheckActiveBoxes(_PlayerSelectionWindow.ListOfBoxes);

                        if (_activeBoxNumberInPlayerSelectionWindow >= 3 && _activeBoxNumberInPlayerSelectionWindow <= 5)
                        {
                            _PlayerSelectionWindow.ListOfBoxes[_activeBoxNumberInPlayerSelectionWindow].Disable();
                            _PlayerSelectionWindow.ListOfBoxes[_activeBoxNumberInPlayerSelectionWindow - 3].SetActive();
                        }

                        break;
                    case ConsoleKey.DownArrow:

                        CheckActiveBoxes(_PlayerSelectionWindow.ListOfBoxes);

                        if (_activeBoxNumberInPlayerSelectionWindow >= 0 && _activeBoxNumberInPlayerSelectionWindow <= 2)
                        {
                            _PlayerSelectionWindow.ListOfBoxes[_activeBoxNumberInPlayerSelectionWindow].Disable();
                            _PlayerSelectionWindow.ListOfBoxes[_activeBoxNumberInPlayerSelectionWindow + 3].SetActive();

                        }

                        break;
                    case ConsoleKey.Enter:

                        CheckActiveBoxes(_PlayerSelectionWindow.ListOfBoxes);
                        QuantityOfPlayers = _activeBoxNumberInPlayerSelectionWindow + 2;

                        closeWindow = true;
                        break;
                }
            }



        }

        public void UsersActivityInQuantityOfDiceMenu()
        {
            bool closeWindow = false;
            DiceAmount = 0;
            NumOfDice = new TextLine(10, 25, 100, DiceAmount.ToString());

            while (closeWindow != true)
            {
                _QuantityOfDiceWindow.Render();

                if (NumOfDice != null)
                {
                    NumOfDice.Render();
                }

                ConsoleKeyInfo pressedChar = Console.ReadKey(true);

                switch (pressedChar.Key)
                {
                    case ConsoleKey.Escape:
                        closeWindow = true;
                        closeAllProgram = true;
                        break;

                    case ConsoleKey.Subtract:

                        if (DiceAmount > 0)
                        {
                            DiceAmount--;
                        }

                        NumOfDice = new TextLine(10, 25, 100, DiceAmount.ToString());
                        break;

                    case ConsoleKey.Add:

                        DiceAmount++;
                        NumOfDice = new TextLine(10, 25, 100, DiceAmount.ToString());
                        break;

                    case ConsoleKey.Enter:
                        closeWindow = true;
                        break;
                }

            }

        }

        public void UsersActivityInPlayAgainMenu()
        {
            _playAgainOrQuitMenuWindow = new PlayAgainOrQuitMenuWindow();

            bool closeWindow = false;

            while (closeWindow != true)
            {
                _playAgainOrQuitMenuWindow.Render(); 

                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.Escape:
                        closeWindow = true; // isjungiu Menu Window
                        closeGUI = true;
                        closeAllProgram = true;
                        break;

                    case ConsoleKey.RightArrow:
                        CheckActiveButton(_playAgainOrQuitMenuWindow.PlayAgainButtonsList); // Patikrinu kuris siuo metu mygtukas yra aktyvus 
                        ActivateNextButtonInPlayAgainMenu(_activeBoxNumberInPlayerSelectionWindow); // Aktyvuoju sekanti mygtuka, kadangi yra tik 2 mygtukai
                        break;

                    case ConsoleKey.LeftArrow:
                        CheckActiveButton(_playAgainOrQuitMenuWindow.PlayAgainButtonsList); // Patikrinu kuris siuo metu mygtukas yra aktyvus 
                        ActivateNextButtonInPlayAgainMenu(_activeBoxNumberInPlayerSelectionWindow); // Aktyvuoju sekanti mygtuka, kadangi yra tik 2 mygtukai
                        break;

                    case ConsoleKey.Enter:
                        CheckActiveButton(_playAgainOrQuitMenuWindow.PlayAgainButtonsList);
                        playAgain = true;
                        if (_activeBoxNumberInPlayerSelectionWindow == (int)MainAndPlayAgainMenuButtons.QUIT)
                        {
                            closeGUI = true;
                            closeAllProgram = true;
                            playAgain = false;
                        }
                        closeWindow = true;
                        break;
                }



            }

        }

    }
}
