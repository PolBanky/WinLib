// Этот лебел ставится справа указанного контрола и имеет текст большого размера (12 пт.)

using System.Windows.Forms;

namespace WinLib
{
    public class LabelR1 : Label
    {
        int def_wdt = 100;

        // КОНСТРУКТОР - устанавливается справа, ширина лебела - по умолчанию
        public LabelR1(TxtBoxDbl a)
        {
            doIt(def_wdt);     // общие действия для всех конструкторов, т.е. можно перенести..., но типа для совместимости...
            this.Left = a.Right + 3;
            this.Top = a.Bottom - this.Height;
            this.Text = a.name1;
        }   // end of - КОНСТРУКТОР

        // doIt(int wdt)
        void doIt(int wdt)     // общие действия для всех конструкторов
        {            
            this.AutoSize = false;
            this.Width = wdt;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
            this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.MouseClick += new MouseEventHandler(LabelR1_MouseClick);
        }      // end of - doIt(int wdt)

        void LabelR1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Click");
        }   // end of - LabelR1_MouseClick()

    }   // end of - class LabelR1 : Label
}       // end of - namespace WinLib
