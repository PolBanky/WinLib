// Этот лебел ставится справа или снизу указанного контрола и имеет текст большого размера (12 пт.)

using System.Windows.Forms;

namespace WinLib
{
    public class sLabel : Label
    {
        // КОНСТРУКТОР - на всякий случай
        public sLabel(string s)
        {
            doIt();     // общие действия для всех конструкторов
            this.Text = s;
        }   // end of - КОНСТРУКТОР


        // КОНСТРУКТОР - устанавливается справа или снизу
        public sLabel(Control a, Place b, string s)
        {
            doIt();     // общие действия для всех конструкторов
            switch (b)
            {
                case Place.bottom:
                    this.Left = a.Left;
                    this.Top = a.Bottom + aForm.gap;
                    break;
                case Place.right:
                    this.Top = a.Top;
                    this.Left = a.Right + aForm.gap;
                    break;
                default:
                    break;
            }   // switch
            this.Text = s;
        }   // end of - КОНСТРУКТОР


        // КОНСТРУКТОР
        public sLabel(int x, int y, string s)
        {
            doIt();     // общие действия для всех конструкторов
            this.Left = x;
            this.Top = y;            
            this.Text = s;
        }   // end of - КОНСТРУКТОР

        void doIt()     // общие действия для всех конструкторов
        {            
            this.AutoSize = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
            this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }   // end of - doIt()

    }   // end of - class sLabel : Label
}       // end of - namespace WinLib
