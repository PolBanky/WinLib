// LabelWhatMeansAboutSteel

using System;
using System.Windows.Forms;

namespace WinLib
{
    public class LabelAboutSteel : Label
    {
        //  КОНСТРУКТОР !!!!
        public LabelAboutSteel(Control a, int wdt)
        {
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Left = a.Right + 5;
            this.Top = a.Top;
            this.Width = wdt;
            this.Height = a.Height;
            this.Text = "Н - нормализация, У - улучшение, Ц - цементация\nТВЧ - закалка с нагревом ТВЧ\nВ - закалка с охлажденим в воде\nМ - закалка с охлаждением в масле\nЧисло после М,В,Н - твердость по HRC";

        }   // end of - public LabelDataOfSteel(Control a) //  КОНСТРУКТОР !!!!

    }   // end of - class LabelWhatMeansAboutSteel : Label
}       // end of - namespace WinLib