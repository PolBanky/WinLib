// Этот лебел предназначен для установки на рисунки размещенные в пикчебоксе формы
// Объект класса надо добавлять не к форме а к пикчебоксу

using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WinLib
{
    public class lblOnPic : Label
    {
        //
        // КОНСТРУКТОР of - CLASS  lblthis:Label  !!! 
        //
        public lblOnPic(int fromLeft, int fromTop /*, int align*/ )
        {
            this.Left = fromLeft;  // 111
            this.Top = fromTop;    // 100
            this.Width = 28;
            this.Height = 13;
            this.AutoSize = false;                        
            this.Font = new System.Drawing.Font("Arial", 9);
            this.TextAlign = ContentAlignment.MiddleRight;
            //this.BackColor = Color.Yellow;
            this.BackColor = Color.White;
        }   // end of - КОНСТРУКТОР 

        // КОНСТРУКТОР перегруженный 
        public lblOnPic(int fromLeft, int fromTop, int wdt, int ht, int align )
        {
            this.Left = fromLeft;  // 111
            this.Top = fromTop;    // 100
            this.Width = wdt;
            this.Height = ht;
            this.AutoSize = false;
            this.Font = new System.Drawing.Font("Arial", 9);
            switch(align)
            {
                case 1:
                    this.TextAlign = ContentAlignment.MiddleLeft;
                    break;
                case 2:
                    this.TextAlign = ContentAlignment.MiddleRight;
                    break;
            }
            //this.BackColor = Color.Yellow;
            this.BackColor = Color.White;
        }   // end of - КОНСТРУКТОР 

    }   // end of - class lblOnPic : Label 
}       // end of - namespace WinLib 
