using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4.GUI
{
    class QuantityOfDiceWindow : Window
    {
        private Box _boxMinus;
        private Box _boxPlus;
        private TextLine _text;
        public Button _startButton { get; private set; }
        private TextLine _title;
       


        
        
        public QuantityOfDiceWindow() : base (0, 0, 120, 30, 'o')
        {
            _title = new TextLine(10, 5, 100, "SELECT DICE QUANTITY");

            _boxMinus = new Box(40, 13, 20, 5, "PRESS  (-)");
            _boxPlus = new Box(61, 13, 20, 5, "PRESS  (+)");

            _text = new TextLine(10, 23, 100, "YOU HAVE THIS AMMOUNT OF DICE:");

            _startButton = new Button(100, 22, 15, 5, "START");
            _startButton.SetActive();
               
            

        }

        public override void Render()
        {
            base.Render();
            _title.Render();
            _boxMinus.Render();
            _boxPlus.Render();
            _text.Render();
            _startButton.Render();
        }

       

       

    }
}
