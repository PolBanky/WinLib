// Этот лебел ставится справа указанного контрола и имеет текст большого размера (12 пт.)

using System.Windows.Forms;

namespace WinLib
{
    public class LabelR : Label
    {
        int def_wdt = 75;

        // КОНСТРУКТОР - устанавливается справа, ширина лебела - по умолчанию
        public LabelR(TxtBoxDbl a)
        {
            doIt(def_wdt);     // общие действия для всех конструкторов
            this.Left = a.Right + 3;
            this.Top = a.Bottom - this.Height;
            this.Text = a.name1;
        }   // end of - КОНСТРУКТОР

        // КОНСТРУКТОР - устанавливается справа, ширина лебела - по умолчанию
        public LabelR(Control a, string s)
        {
            doIt(def_wdt);     // общие действия для всех конструкторов
            this.Left = a.Right + 3;
            this.Top = a.Bottom - this.Height;            
            this.Text = s;
        }   // end of - КОНСТРУКТОР

        // КОНСТРУКТОР - устанавливается справа, ширина лебела задается
        public LabelR(Control a, string s, int label_wdt)
        {
            doIt(label_wdt);     // общие действия для всех конструкторов
            this.Left = a.Right + 3;
            this.Top = a.Bottom - this.Height;
            this.Text = s;
        }   // end of - КОНСТРУКТОР

        // КОНСТРУКТОР
        public LabelR(int x, int y, string s)
        {
            doIt(def_wdt);     // общие действия для всех конструкторов
            this.Left = x;
            this.Top = y;            
            this.Text = s;
        }   // end of - КОНСТРУКТОР

        // doIt(int wdt)
        void doIt(int wdt)     // общие действия для всех конструкторов
        {            
            this.AutoSize = false;
            this.Width = wdt;
            // this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
            this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }   // end of - doIt(int wdt)

    }   // end of - class LabelR : Label
}       // end of - namespace WinLib
