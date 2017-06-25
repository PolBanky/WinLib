using System;
using System.Windows.Forms;

namespace WinLib
{
    // GroupBoxChoice : GroupBox
    public class GroupBoxChoice : GroupBox
    {

        //  КОНСТРУКТОР !!!
        public GroupBoxChoice(Control a, int w, int h, string b)
        {
            //doIt();
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11);
            this.TabStop = false;
            this.Width = w;
            this.Height = h;
            this.Left = a.Left;
            this.Top = a.Bottom + aForm.gap;
            this.Text = b;
        }   // end of - GroupBoxChoice(Control a, string b)
        

        // doIt()
        //void doIt()
        //{
            
        //}   // end of - doIt()


    }   // end of - class GroupBoxChoice : GroupBox

}   // end of - namespace WinLib