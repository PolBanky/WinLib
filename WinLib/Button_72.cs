// 72 - это размер кнопки 72 х 72

using System.Windows.Forms;

namespace WinLib
{
    public class Button_72 : Button
    {
        //public int val = 0;

        // КОНСТРУКТОР - установить батн по координатам
        public Button_72(int x, int y)
        {
            doIt();
            this.Left = x;
            this.Top = y;
        }   // end of - Button_72()


        // КОНСТРУКТОР - установить батн снизу или справа
        public Button_72(Control a, Place b)
        {
            doIt();
            switch (b)
            {
                case Place.bottom:
                    this.Left = a.Left;
                    this.Top = a.Bottom + 5;
                    break;
                case Place.right:
                    this.Top = a.Top;
                    this.Left = a.Right + 5;
                    break;
                default:
                    break;
            }   // switch
        }       // end of - Button_72()


        void doIt()
        {
            this.Size = new System.Drawing.Size(72, 72);
            this.UseVisualStyleBackColor = true;
            this.TabStop = false;
        }   // end of - doIt()

    }   // end of - Button_72 : Button
}       // end of - namespace WinLib
