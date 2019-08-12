using HomeWork4.GUI;
using HomeWork4.GUI_Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork4.Game_Controller
{
    class GameCotroller
    {
        // KINTAMIEJI IR PROPERTIES


        private int _quantityOfDice;
        private int _quantityOfPlayers;
        private int _roundNumber = 1;

        public List<Player> AllPlayers { get; set; } = new List<Player>();
        public List<Player> NextRoundPlayers { get; set; } = new List<Player>();
        public List<Player> SecondRoundPlayersList { get; set; } = new List<Player>();

        public List<int> AllPlayersRezults { get; set; } = new List<int>();
        public List<int> IndexOfPlayersWithSameRezults { get; set; } = new List<int>();


        public Button _startButton { get; private set; }
        private GameWindow _GameWindow { get; set; }


        // KOSTRUKTORIUS 


        public GameCotroller(int playersCount, int diceCount)
        {
            _GameWindow = new GameWindow();
            _quantityOfPlayers = playersCount;
            _quantityOfDice = diceCount;

            
            _startButton = new Button(50, 10, 25, 5, "PRESS ENTER TO PLAY");
            _startButton.SetActive();
            

        }

        // FUNKCIJOS

        public void StartGame()
        {
            
            Console.Clear();
            _GameWindow.Render();
            _startButton.Render();

            ConsoleKeyInfo pressedChar = Console.ReadKey(true);

            switch (pressedChar.Key)
            {
                case ConsoleKey.Enter:

                    NextRoundPlayers = MainRoundStart(_quantityOfPlayers); // grazina sarasa zaideju, kurie ismete toki pati max rezultata


                    while (NextRoundPlayers.Count > 1) // Suksis tol kol bus daugiau nei 1 zaidejas surinkes tiek pat tasku
                    {

                        Console.Clear();
                        _GameWindow.Render();

                        NextRoundStart(NextRoundPlayers.Count, NextRoundPlayers); // universalumas...

                        ++_roundNumber;
                        Console.SetCursorPosition(2, 2);
                        Console.WriteLine("Round Played: " + _roundNumber);
                    }


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(2, 2);
                    Console.WriteLine("Round Played : " + _roundNumber);
                    Console.SetCursorPosition(5, 18);
                    Console.WriteLine("The WINNER is:   " + NextRoundPlayers[0].Name.ToUpper());

                    System.Threading.Thread.Sleep(6000);
                    Console.ResetColor();

                    break;
            }

        }

        public void NextRoundStart(int quantityOfPlayers, List<Player> NextRoundPlayers)
        {
            Console.Clear();

            _GameWindow.Render();

            Console.SetCursorPosition(0, 0);

            PlayerStatus(quantityOfPlayers, _quantityOfDice, NextRoundPlayers);

            AllPlayersRezults = AllPlayersTotalRezultsToList(NextRoundPlayers); // sudedamos reiksmes VISOS

            IndexOfPlayersWithSameRezults = ALLPlayersRezultsWithTheSameValue(AllPlayersRezults);

            SecondRoundPlayersList = GetSecondRoundPlayersList(IndexOfPlayersWithSameRezults, NextRoundPlayers);

            this.NextRoundPlayers = SecondRoundPlayersList;

        }

        public List<Player> MainRoundStart(int quantityOfPlayers)
        {
            Console.Clear();

            _GameWindow.Render();

            AllPlayers = AddAllPLayersToList(quantityOfPlayers);

            Console.SetCursorPosition(0, 0);

            PlayerStatus(quantityOfPlayers, _quantityOfDice, AllPlayers);



            AllPlayersRezults = AllPlayersTotalRezultsToList(AllPlayers); // sudedamos reiksmes VISOS

            IndexOfPlayersWithSameRezults = ALLPlayersRezultsWithTheSameValue(AllPlayersRezults);

            SecondRoundPlayersList = GetSecondRoundPlayersList(IndexOfPlayersWithSameRezults, AllPlayers);

            return SecondRoundPlayersList;
            ///////////


        }

        private List<Player> GetSecondRoundPlayersList(List<int> IndexOfPlayersWithSameRezults, List<Player> AllPlayers)
        {
            List<Player> nextRoundPlayers = new List<Player>();

            for (int i = 0; i < IndexOfPlayersWithSameRezults.Count; i++)
            {
                nextRoundPlayers.Add(AllPlayers[IndexOfPlayersWithSameRezults[i]]);

            }

            return nextRoundPlayers;





        }

        private List<int> ALLPlayersRezultsWithTheSameValue(List<int> allPlayersRezults)
        {
            int maxValue = allPlayersRezults.Max();

            List<int> IndexOfPlayersWithSameRezults = new List<int>();

            for (int i = 0; i < allPlayersRezults.Count; i++)
            {
                if (maxValue == allPlayersRezults[i])
                {
                    IndexOfPlayersWithSameRezults.Add(i);
                }
            }

            return IndexOfPlayersWithSameRezults;

        }

        private List<Player> AddAllPLayersToList(int numOfPlayers)
        {
            List<Player> Players = new List<Player>();

            for (int i = 0; i < numOfPlayers; i++)
            {
                Player player = new Player();
                Players.Add(player);
            }

            return Players;


        }

        public void PlayerStatus(int quantityOfPlayers, int quantityOfDice, List<Player> playersList)
        {
            for (int i = 0; i < quantityOfPlayers; i++)
            {
                playersList[i].RollaDice(quantityOfDice);

                Console.SetCursorPosition(5, 5 + i + 3);

                Console.Write("{0} has these Dices rolled:  ", playersList[i].Name);

                for (int j = 0; j < playersList[i].DiceNumbers.Count; j++)
                {
                    if (j != playersList[i].DiceNumbers.Count - 1)
                    {
                        Console.Write(playersList[i].DiceNumbers[j] + " + ");
                    }
                    else
                    {
                        Console.Write(playersList[i].DiceNumbers[j]);
                    }
                }


                Console.WriteLine(" Result: " + playersList[i].TotalPoints);

                Console.WriteLine();
                System.Threading.Thread.Sleep(500);

            }
        }

        private List<int> AllPlayersTotalRezultsToList(List<Player> Players)
        {
            List<int> PlayersRezultsList = new List<int>();

            for (int i = 0; i < Players.Count; i++)
            {


                PlayersRezultsList.Add(Players[i].TotalPoints);



            }
            return PlayersRezultsList;

        }



    }
}
