using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.Game_Controller
{
    class Dice
    {
        public int Id { get; set; } = 0;
        public int Number { get; set; }

        public Dice()
        {
            Random rnd = new Random();
            Number = rnd.Next(1, 6);
           
        }

        public  void Render()
        {
            Console.Write($"({Id}-dice) Points: {Number} ");
        }
    }
}
