// Этот лебел ставится снизу указанного контрола и имеет одну или две строчки

using System.Windows.Forms;

namespace WinLib
{
    public class LabelT : Label
    {
        // КОНСТРУКТОР
        public LabelT(string s)
        {            
            this.Text = s;
            doIt();
        }

        // КОНСТРУКТОР - устанавливается снизу
        public LabelT(Control a, string s)
        {            
            this.Text = s;            
            doIt();
            this.Left = a.Left;
            this.Top = a.Bottom + 5;            
        }   // end of - КОНСТРУКТОР

        // КОНСТРУКТОР
        public LabelT(int x, int y, string s)
        {            
            this.Text = s;
            doIt();
            this.Left = x;
            this.Top = y;            
        }   // end of - КОНСТРУКТОР

        void doIt()
        {
            this.Width = 140;
            int index = this.Text.IndexOf('\n', 0);
            if (index != -1)
                this.Height = 28;
            else
                this.Height = 16;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9);
            this.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
        }
    }   // end of - class LabelT : Label
}       // end of - namespace WinLib
