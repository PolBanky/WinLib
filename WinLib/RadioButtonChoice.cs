using System;
using System.Windows.Forms;

namespace WinLib
{
    // GroupBoxChoice : GroupBox
    public class RadioButtonChoice : RadioButton
    {

        //  КОНСТРУКТОР !!!
        public RadioButtonChoice(Control a, string b, bool c)
        {
            //doIt();
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9);
            this.AutoSize = true;
            this.Checked = c;
            this.Text = b;
            if (a == null)
            {
                this.Left = aForm.gap;
                this.Top = 20;
            }
            else
            {
                this.Left = a.Left;
                this.Top = a.Bottom;
            }
            this.TabStop = false;   // Эта инструкция должна быть последней !!!!
        }   // end of - GroupBoxChoice(Control a, string b)


        //// doIt()
        //void doIt()
        //{
            
        //}   // end of - doIt()


    }   // end of - class RadioButtonChoice : RadioButton

}   // end of - namespace WinLib