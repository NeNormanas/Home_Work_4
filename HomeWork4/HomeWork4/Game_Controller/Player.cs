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
        public int TotalDicesPoints { get; set; } = 0;
        public Dice kauliukas { get; set; } = null;
        public List<Dice> kauliukuSarasa { get; set; } = new List<Dice>();
       
        public List<int> DiceNumbers { get; } = new List<int>();

        public Player(int numberOfDice) : base (10, 10, 10, 5)
        {
            Name = "Player " + PlayerId.ToString();

            PlayerId++;

        }

        public void RollaDice(int numOfDice)
        {
            for (int i = 0; i < numOfDice; i++)
            {
                kauliukas = new Dice();
                kauliukas.Id = i + 1;
                kauliukuSarasa.Add(kauliukas);
                TotalDicesPoints += kauliukas.Number;
            }
        }

        public void ResetData()
        {
            kauliukuSarasa = new List<Dice>();
            TotalDicesPoints = 0;
        }
        

        public override void Render()
        {
            Console.Write($"{Name}, TOTAL POINTS : {TotalDicesPoints} ");
        }

        public void RenderDiceNumbers()
        {
            for (int i = 0; i < kauliukuSarasa.Count; i++)
            {
                kauliukuSarasa[i].Render();
            }

        }
    }
}
