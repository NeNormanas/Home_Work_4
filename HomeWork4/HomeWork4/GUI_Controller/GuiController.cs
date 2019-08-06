using HomeWork4.GUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.GUI_Controller
{
    class GuiController
    {
        private enum MainMenuButtons { PLAY, QUIT }
        private enum BoxesInPlayerSelection {
            P2, P3, P4,
            P5, P6, P7}

        public MenuWindow _MenuWindow { get; set; }
        public PlayerSelectionWindow _PlayerSelectionWindow { get; }
        public QuantityOfDiceWindow _QuantityOfDiceWindow { get; set; }

        public int quantityOfPlayers { get; private set; }
        private int number = 0;


        private int ActiveButtonNumberInMainMenu;
        private int ActiveBoxNumberInPlayerSelectionWindow;

        private TextLine NumOfDice;





        public GuiController()
        {
            _MenuWindow = new MenuWindow();
            _PlayerSelectionWindow = new PlayerSelectionWindow();
            _QuantityOfDiceWindow = new QuantityOfDiceWindow();
            

        }

        public void StartGuiController()
        {
            UsersActivityInMainMenu();
        }




        public void CheckActiveButton(List<Button> listOfButtons)
        {

            for (int i = 0; i < listOfButtons.Count; i++)
            {
                if (listOfButtons[i].isActive == true )
                {
                    ActiveButtonNumberInMainMenu = i;
                }
            }
            

        }

        public void CheckActiveBoxes(List<Box> listOfBoxes)
        {

            for (int i = 0; i < listOfBoxes.Count; i++)
            {
                if (listOfBoxes[i].isActive == true)
                {
                    ActiveBoxNumberInPlayerSelectionWindow = i;
                }
            }


        }

        public void ActivateNextButton(int activatedButtonNr)
        {
            switch (activatedButtonNr)
            {
                case (int)MainMenuButtons.PLAY:
                    _MenuWindow.PlayButton.Disable();
                    _MenuWindow.QuitButton.SetActive();
                    break;
                case (int)MainMenuButtons.QUIT:
                    _MenuWindow.QuitButton.Disable();
                    _MenuWindow.PlayButton.SetActive();
                    break;
                default:
                    break;
            }
        }

       


        public void UsersActivityInMainMenu()
        {
            
            bool needToRender = true;

            do
            {
                Console.Clear();

                while (Console.KeyAvailable)
                {
                   

                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            needToRender = false;
                            break;
                        case ConsoleKey.RightArrow:
                            CheckActiveButton(_MenuWindow.MenuWindowButtons);
                            ActivateNextButton(ActiveButtonNumberInMainMenu);
                            break;
                        case ConsoleKey.LeftArrow:
                            CheckActiveButton(_MenuWindow.MenuWindowButtons);
                            ActivateNextButton(ActiveButtonNumberInMainMenu);
                            break;
                        case ConsoleKey.Enter:

                            CheckActiveButton(_MenuWindow.MenuWindowButtons);

                            if (ActiveButtonNumberInMainMenu == (int)MainMenuButtons.QUIT)
                            {
                                needToRender = false;
                            }
                            else
                            {
                                UsersActivityInPlayerSelectionMenu();
                            }
                           
                            break;
                    }
                    

                }

                _MenuWindow.Render();


                System.Threading.Thread.Sleep(250);

            } while (needToRender);
        }

        public void UsersActivityInPlayerSelectionMenu()
        {

            bool needToRender = true;

            do
            {
                Console.Clear();
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            needToRender = false;
                            break;
                        case ConsoleKey.RightArrow:
                            CheckActiveBoxes(_PlayerSelectionWindow.ListOfBoxes);
                            if (ActiveBoxNumberInPlayerSelectionWindow < _PlayerSelectionWindow.ListOfBoxes.Count-1)
                            {
                                _PlayerSelectionWindow.ListOfBoxes[ActiveBoxNumberInPlayerSelectionWindow].Disable();
                                _PlayerSelectionWindow.ListOfBoxes[ActiveBoxNumberInPlayerSelectionWindow + 1].SetActive();
                            }

                            break;
                        case ConsoleKey.LeftArrow:
                            CheckActiveBoxes(_PlayerSelectionWindow.ListOfBoxes);
                            if (ActiveBoxNumberInPlayerSelectionWindow > 0)
                            {
                                _PlayerSelectionWindow.ListOfBoxes[ActiveBoxNumberInPlayerSelectionWindow].Disable();
                                _PlayerSelectionWindow.ListOfBoxes[ActiveBoxNumberInPlayerSelectionWindow - 1].SetActive();
                            }
                            
                            break;

                        case ConsoleKey.UpArrow:

                            CheckActiveBoxes(_PlayerSelectionWindow.ListOfBoxes);

                            if (ActiveBoxNumberInPlayerSelectionWindow >= 3 && ActiveBoxNumberInPlayerSelectionWindow <= 5)
                            {
                                _PlayerSelectionWindow.ListOfBoxes[ActiveBoxNumberInPlayerSelectionWindow].Disable();
                                _PlayerSelectionWindow.ListOfBoxes[ActiveBoxNumberInPlayerSelectionWindow - 3].SetActive();
                            }
                            break;
                        case ConsoleKey.DownArrow:

                            CheckActiveBoxes(_PlayerSelectionWindow.ListOfBoxes);

                            if (ActiveBoxNumberInPlayerSelectionWindow >= 0 && ActiveBoxNumberInPlayerSelectionWindow <= 2)
                            {
                                _PlayerSelectionWindow.ListOfBoxes[ActiveBoxNumberInPlayerSelectionWindow].Disable();
                                _PlayerSelectionWindow.ListOfBoxes[ActiveBoxNumberInPlayerSelectionWindow + 3].SetActive();

                            }
                            break;
                        case ConsoleKey.Enter:
                            CheckActiveBoxes(_PlayerSelectionWindow.ListOfBoxes);
                            quantityOfPlayers = ActiveBoxNumberInPlayerSelectionWindow + 2;

                            UsersActivityInQuantityOfDiceMenu();


                            break;
                    }
                }

                _PlayerSelectionWindow.Render();

                System.Threading.Thread.Sleep(250);

            } while (needToRender);
        }

        public void UsersActivityInQuantityOfDiceMenu()
        {
            
            bool needToRender = true;

            do
            {
                Console.Clear();

                while (Console.KeyAvailable)
                {
                    

                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            needToRender = false;
                            break;
                        case ConsoleKey.Subtract:
                            if (number > 0)
                            {
                                number--;
                            }
                            
                            NumOfDice = new TextLine(10, 25, 100, number.ToString());
                            
                            break;
                        case ConsoleKey.Add:
                            number++;
                            NumOfDice = new TextLine(10, 25, 100, number.ToString());
                            break;
                        case ConsoleKey.Enter:

                            break;
                            
                    }


                }
                
                _QuantityOfDiceWindow.Render();
                if (NumOfDice != null)
                {
                    NumOfDice.Render();
                }
                


                System.Threading.Thread.Sleep(250);

            } while (needToRender);
        }




    }
}
