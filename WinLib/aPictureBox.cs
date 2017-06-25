using System;
using System.Windows.Forms;

namespace WinLib
{
    public partial class aPictureBox : PictureBox
    {
        #region  КОНСТРУКТОРЫ !!!
        public aPictureBox()
        {
            this.Top  = aForm.gap;         // т.е. коорд Y == 5
            this.Left = aForm.gap;         // т.е. коорд X == 5
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Height = 385;
            this.Width  = 385;
            this.Image  = Properties.Resources.Tutorial;
            this.TabStop = false;
            this.MouseClick += new MouseEventHandler(aPictureBox_MouseClick);   // определение обработчика события
        }   // end of - public aPictureBox()
        
        #endregion  КОНСТРУКТОРЫ !!!

        #region EVENT HANDLERS !!!
        void aPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion EVENT HANDLERS !!!
    }
}
