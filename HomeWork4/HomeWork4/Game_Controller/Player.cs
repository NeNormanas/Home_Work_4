using HomeWork4.GUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.Game_Controller
{
    class Player : GuiObject
    {
        public static int PlayerId  = 1;
        public string Name { get;  set; } = "Player";
        private int diceNumber;
        public int TotalPoints { get; set; } = 0;
       
        public List<int> DiceNumbers { get; } = new List<int>();

        public Player() : base (10, 10, 10, 5)
        {
           
            Name = "Player " + PlayerId.ToString();
            PlayerId++;
            
        }


        public void RollaDice(int quantityOfDicees)
        {
            for (int i = 0; i < quantityOfDicees; i++)
            {
                Random rnd = new Random();
                diceNumber = rnd.Next(1, 6);

                DiceNumbers.Add(diceNumber);

                TotalPoints += diceNumber;
            }
        }

        public override void Render()
        {
            Console.WriteLine($"{Name}, earned {TotalPoints} points.");
        }

        public void RenderDiceNumbers()
        {
            for (int i = 0; i < DiceNumbers.Count; i++)
            {
                Console.SetCursorPosition(5, 20 + i + 2);
                Console.Write(DiceNumbers[i] + "+ ");
            }
        }
    }
}
