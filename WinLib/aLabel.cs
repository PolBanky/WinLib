using System;
using System.Windows.Forms;

namespace WinLib
{
    public class aLabel : Label
    {
        int widht = 140;
        int height = 25;

        // КОНСТРУКТОР - на всякий случай
        //public aLabel()
        //{ doIt(); }   // end of - КОНСТРУКТОР


        // КОНСТРУКТОР - ставится под объектом
        public aLabel(Control a)
        {
            doIt();
            this.Left = a.Left;
            this.Top = a.Bottom + aForm.gap;
        }   // end of - КОНСТРУКТОР


        // КОНСТРУКТОР - ставится под объектом или справа
        public aLabel(Control a, Place b, int wdht, int hght)
        {
            this.widht  = wdht;
            this.height = hght;
            doIt();
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
        }   // end of - КОНСТРУКТОР


        // КОНСТРУКТОР - по координатам
        public aLabel(int x, int y)
        {
            doIt();
            this.Left = x;
            this.Top = y;
        }   // end of - КОНСТРУКТОР


        // КОНСТРУКТОР - по координатам и размеры алебела
        public aLabel(int x, int y, int wdht, int hght)
        {
            widht = wdht;
            height = hght;
            doIt();
            this.Left = x;
            this.Top = y;            
        }   // end of - КОНСТРУКТОР


        void doIt()
        {
            this.Text = "";
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size( this.widht, this.height);
            if (height == 25)
            {
                this.Font =  new System.Drawing.Font("Microsoft Sans Serif", 12);
                this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            }
            else
                this.TextAlign = System.Drawing.ContentAlignment.TopLeft;
        }   // end of - doIt()


            // МЕГА-МЕТОД ВЫВОДА СТРОКИ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public void setText(params object[] list)
        {
            string txt = "";
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].GetType() == typeof(double))
                {
                    double val = (double)list[i];
                    val = r(val);
                    list[i] = val;
                }
                txt += list[i].ToString();
            }   // for
            this.Text = txt;
        }   // end of - setText(params object[] list)


        // МЕГА-МЕТОД ВЫВОДА СТРОКИ !!!  (перегрузка - строка передается по ссылке)
        public void setText(bool showIt, ref string txt, params object[] list)
        {
            txt = "";
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].GetType() == typeof(double))
                {
                    double val = (double)list[i];
                    val = r(val);
                    list[i] = val;
                }
                txt += list[i].ToString();
            }   // for
            if (showIt == true)
                this.Text = txt;
        }   // end of - setText(bool showIt, ref string txt, params object[] list)


        // МЕГА-МЕТОД ВЫВОДА СТРОКИ !!!  (перегрузка - строка передается по ссылке)
        static public void setText( ref string txt, params object[] list)
        {
            txt = "";
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].GetType() == typeof(double))
                {
                    double val = (double)list[i];
                    val = r(val);
                    list[i] = val;
                }
                txt += list[i].ToString();
            }   // for
        }   // end of - setText(bool showIt, ref string txt, params object[] list)
        

        // МЕГА-МЕТОД ВЫВОДА СТРОКИ !!! (перегрузка - если аргумент один и он - double)
        public void setText(double val)
        {
            this.Text = r(val).ToString();

            //aForm.whereDivider(a);
        }


        // function round
        static public double r(double val)
        {
            int num = 0;
            for (; ; )
            {
                if (val < 1) { num = 5; break; }
                if (val < 10) { num = 4; break; }
                if (val < 100) { num = 3; break; }
                if (val < 1000) { num = 2; break; }
                if (val < 10000) { num = 1; break; }
                if (val >= 10000) { num = 0; break; }
            }
            return Math.Round(val, num);
        }   // end of - r() - round

    }   // end of - class aLabel : System.Windows.Forms.Label
}       // end of - namespace WinLib
