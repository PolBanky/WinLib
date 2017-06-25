// LabelDataOfSteel

using System;
using System.Windows.Forms;

namespace WinLib
{
    public class LabelDataOfSteel : Label
    {
        //  КОНСТРУКТОР !!!!
        public LabelDataOfSteel(Control a, int wdt)  // wdt - задание ширины ЭТОГО контрола 
        {
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Left = a.Right + aForm.gap;
            this.Top = a.Top;
            //this.Width = wdt;
            //this.Height = a.Height;
            this.Size = new System.Drawing.Size(wdt, a.Height);

        }   // end of - public LabelDataOfSteel(Control a) //  КОНСТРУКТОР !!!!

    }   // end of - class LabelDataOfSteelChoice : Label
}       // end of - namespace WinLib