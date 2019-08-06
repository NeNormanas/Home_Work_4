using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.GUI
{
    class PlayerSelectionWindow : Window
    {

        public bool isActive { get; set; } = false;
        private TextBlock _title;

        public Box P2{ get; set; }
        public Box P3{ get; set; }
        public Box P4{ get; set; }
        public Box P5{ get; set; }
        public Box P6{ get; set; }
        public Box P7{ get; set; }

        public List<Box> ListOfBoxes { get; private set; } = new List<Box>();


        public PlayerSelectionWindow() : base(0, 0, 120, 30, 'o')
        {
            _title = new TextBlock(10, 5, 100, new List<string> { "PLEASE SELECT HOW MANY PLAYER WILL PLAY" });

            P2 = new Box(30, 13, 20, 5, "P2");
            P2.SetActive();
            P3 = new Box(50, 13, 20, 5, "P3");
            P4 = new Box(70, 13, 20, 5, "P4");
            P5 = new Box(30, 18, 20, 5, "P5");
            P6 = new Box(50, 18, 20, 5, "P6");
            P7 = new Box(70, 18, 20, 5, "P7");

            ListOfBoxes.Add(P2);
            ListOfBoxes.Add(P3);
            ListOfBoxes.Add(P4);
            ListOfBoxes.Add(P5);
            ListOfBoxes.Add(P6);
            ListOfBoxes.Add(P7);

        }

        public override void Render()
        {
            base.Render();
            _title.Render();

            for (int i = 0; i < ListOfBoxes.Count; i++)
            {
                ListOfBoxes[i].Render();

            }


        }


        

    }
}
