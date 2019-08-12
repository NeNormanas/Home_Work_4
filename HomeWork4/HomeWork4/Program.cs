using HomeWork4.GUI;
using HomeWork4.GUI_Controller;
using HomeWork4.Game_Controller;
using System;

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool playAgain = false;
            
            do
            {
                Player.PlayerId = 1; // tam kad po kiekvienos rotacijos numeruoti nuo pirmojo zaidejo.

                // GUI KONTROLERIS 

                GuiController guiController = new GuiController();
                guiController.StartGuiController();

                if (guiController.closeAllProgram == true)
                {
                    continue;
                }
                // PRASIDEDA GAME COROLLERIS 

                GameCotroller _GameCotroller = new GameCotroller(guiController.QuantityOfPlayers, guiController.DiceAmount);
                _GameCotroller.StartGame();

                Console.Clear();

                Console.WriteLine("Do you wantto Play again? " + " PRESS ENTER!");

                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.Enter:
                        playAgain = true;
                        break;
                }
                

            } while (playAgain != false);

            Console.Clear();
            Console.WriteLine("TKANK YOU FOR PLAYING THIS GAME!! SEE YOU!");


        }
    }
}
