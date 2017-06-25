//  #define __A__

using System;
using System.Windows.Forms;

namespace WinLib
{
        // TxtBoxDbl : TextBox 
    public class TxtBoxDbl : TextBox
    {
        #region DATA

        public string name1;
        public string name2;
        public double val = 0.0;                // значение, введенное в этот экземпляр текстбокса 
        public static int TBoxesWdt = 100;      // Значение ширины текстбокса по умолчанию
        public static char divide_true = ' ', divide_false = ' ';   // значения одни на все экземпляры 
        public Control showErr = null;          // Ссылка на контрол для вывода сообщений об ошибках 
        public event EventHandler TxtChanged;   // EVENT !!!   
        const int WM_PASTE = 0x0302;
        static int thisTabIndex = 1;

        public LabelR1 lbl; // не используется пока что 

        #endregion DATA


        #region СВОЙСТВА

        // Свойство - если val==0 выдается сообщение об этом в окно ошибки 
        public double Val
        {
            get
            {
                checkZero();
                return val;
            }   // get
        }       // Val


        public bool Val_bool
        {
            get
            {
                return checkZero(); // return bool
            }   // get
        }       // Val_bool

        #endregion СВОЙСТВА


        protected override void WndProc(ref Message m)  // Запрет вставки из буфера обмена
        {
            //Запрещаем обрабатывать WM_PASTE
            if (m.Msg == WM_PASTE)
            {
                MessageBox.Show("Хрена а не вставка", "Access denied",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            base.WndProc(ref m);
        }   // end of - WndProc(ref Message m)

        #region  КОНСТРУКТОРЫ !!!

        // КОНСТРУКТОР - на всякий случай
        public TxtBoxDbl()
        {   
            if (divide_true == ' ') divider();
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Width = TBoxesWdt;  // ширина окна
            this.TabIndex = thisTabIndex++;

            this.MouseClick += new MouseEventHandler(TxtBoxDbl_MouseClick);
            this.KeyDown += new KeyEventHandler(txtBoxDbl_KeyDown);
            this.KeyPress += new KeyPressEventHandler(TxtBoxDbl_KeyPress);
            this.TextChanged += new EventHandler(TxtBoxDbl_TextChanged);    // Обработчик события this.TextChanged
            this.VisibleChanged += new EventHandler(TxtBoxDbl_VisibleChanged);
#if __A__
            MessageBox.Show(" Inside TxtBoxDbl() ");
#endif      
        }   // end of - КОНСТРУКТОР


        // КОНСТРУКТОР - установить текстбокс ниже указанного контрола на aForm.gap 
        // Первым исполняется this() - т.е. конструктор TxtBoxDbl() 
        public TxtBoxDbl(Control a) : this()    
        {
#if __A__
            MessageBox.Show(" Inside TxtBoxDbl(Control a) ");
#endif
            this.Left = a.Left;
            this.Top = a.Bottom + aForm.gap;
        }   // end of - конструктор TxtBoxDbl(Control a)
        

        // КОНСТРУКТОР - установить тбокс снизу или справа
        public TxtBoxDbl(Control a, Place b) : this()
        {
#if __A__
            MessageBox.Show(" Inside TxtBoxDbl(Control a, Place b) ");
#endif
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
        }       // end of - конструктор TxtBoxDbl(Control a, Place b)


        // КОНСТРУКТОР - установить тбокс снизу или справа и задать величину зазора
        public TxtBoxDbl(Control a, Place b, int localGap) : this()
        {
#if __A__
            MessageBox.Show(" Inside TxtBoxDbl(Control a, Place b, int localGap) ");
#endif
            switch (b)
            {
                case Place.bottom:
                    this.Left = a.Left;
                    this.Top = a.Bottom + localGap;
                    break;
                case Place.right:
                    this.Top = a.Top;
                    this.Left = a.Right + localGap;
                    break;
                default:
                    break;
            }   // switch
        }  // end of - конструктор TxtBoxDbl(Control a, Place b)

                
        // КОНСТРУКТОР - установить тбокс по координатам
        public TxtBoxDbl(int x, int y) : this()
        {
            this.Left = x;
            this.Top = y;
        }   //  end of - конструктор TxtBoxDbl(int x, int y)

        #endregion  КОНСТРУКТОРЫ !!!


        //  ну ви панимаете..
        static void divider()
        {
            string a;
            a = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (a[0] == ',')
            { divide_true = ','; divide_false = '.'; }
            else
            { divide_true = '.'; divide_false = ','; }
        }	// end of - divider()
        

        //  УСТАРЕВШИЙ МЕТОД
        // Конвертировать Text данного объекта в число double, которое дано по ССЫЛКЕ (out)
        public void strToDbl(out double b)
        {
            if (this.Text.Length == 0) b = 0;
            else
            {
                try { b = Convert.ToDouble(this.Text); }
                catch
                {
                    MessageBox.Show("Недопустимый ввод", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Text = "";
                    b = 0;
                }   // завершение try...catch
            }       // завершение if...else
            // Курсор в конец текста
            this.Select(this.Text.Length, 0);
        }   // завершение strToDbl()


        // метод вызывается обработчиком TxtBoxDbl_TextChanged() события this.TextChanged
        // Конвертировать Text данного объекта в число double TxtBoxDbl.val (переменная этого экземпляра текстбокса)
        void strToDbl()
        {
            if (this.Text.Length == 0) val = 0.0;
            else
            {
                try { val = Convert.ToDouble(this.Text); }
                catch
                {
                    MessageBox.Show("Недопустимый ввод", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Text = "";
                    val = 0.0;
                }   // end of - try...catch
            }       // end of -  if...else
        }           // end of - strToDbl()


        // setText(double a)   Программная запись текста в текстбокс !!!
        public void setText(double a)   
        {
            double c = (double)aForm.whereDivider(a);   // показатель степени для 10.0 
            double d = Math.Pow(10.0, c);               // = 1...10000     
            double b = a * d;                           // = a * 1...10000 
            /// TODO
            b = Math.Floor(b); // округление всегда в меньшую сторону Т.Е. МОЖЕТ СТАТЬ НУЛЕМ !!!! 
            b = b / d;
            this.Text = b.ToString();
            this.Focus();
            this.Select(this.Text.Length, 0);
            //return a;
        }   // end of - setText(double a)


        // bool checkZero()
        public bool checkZero()
        {   
            if (val == 0.0)
            {
                if (showErr != null)  // showErr - Ссылка на контрол для вывода сообщений об ошибках 
                {
                    showErr.BackColor = System.Drawing.Color.LightPink;
                    showErr.Text = "Data can't = 0\nin cell \"" + name1 + "\"";
                    Focus();
                    return false;
                }   // end of - if (showErr != null)
                else
                    MessageBox.Show("Programmer's Error !!!\nRef \"showErr\" == null");
            }       // end of - if (val == 0.0)
            return true;
        }   // end of - bool checkZero()
        

        #region ОБРАБОТЧИКИ СОБЫТИЙ !!!

        // TxtBoxDbl_VisibleChanged
        void TxtBoxDbl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false) this.Text = "";
        }

        // ОБРАБОТЧИК СОБЫТИЯ - this.TextChanged
        // TxtBoxDbl_TextChanged - пребразуем введенный в TxtBoxDbl текст - в число
        void TxtBoxDbl_TextChanged(object sender, EventArgs e)
        {
            strToDbl();
            if (TxtChanged != null)
                TxtChanged(this, new EventArgs());  // Генерируется событие TxtChanged !!!!!!!!!!
        }   // end of - TxtBoxDbl_TextChanged


        // txtBoxDbl_MouseClick
        void TxtBoxDbl_MouseClick(object sender, MouseEventArgs e)
        {
            this.Select(this.Text.Length, 0);
        }   // end of - txtBoxDbl_MouseClick


        // txtBoxDbl_KeyDown - отключить управляющие и перемещения клавиши
        void txtBoxDbl_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Home) || (e.KeyCode == Keys.End) || (e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Down))
                e.Handled = true;
        }   // end of -  txtBoxDbl_KeyDown


        // txtBoxDbl_KeyPress -  принимать если цифра или BackSpace
        void TxtBoxDbl_KeyPress(object sender, KeyPressEventArgs e)
        {
            // если неправильный десятичный разделитель - ставим правильный вместо неправильного
            if (e.KeyChar == divide_false)
                e.KeyChar = divide_true;
            // если правильный десятичный разделитель
            if (e.KeyChar == divide_true)
            { // нельзя больше 1 разделителя
                if (this.Text.IndexOf(divide_true) != -1)
                {
                    e.Handled = true;
                    return;
                }
                // десятичный разделитель не может быть первым символом - добавляем ноль впереди
                if (this.Text.Length == 0)// e.KeyChar = '0';
                {
                    e.Handled = true;
                    this.Text = "0" + divide_true;
                    this.Select(this.Text.Length, 0);
                }
                return;
            } // завершение if (e.KeyChar == divide_true)
            // если BackSpace
            if (e.KeyChar == 8)
            {  //MessageBox.Show(this.Text + "__" + this.Text.Length + "__" + this.Text[0]);
                int a = this.Text.Length;
                if (a > 0)
                {
                    if (this.Text[a - 1] == divide_true)
                    {
                        if (this.Text[0] == '0')
                            this.Text = "";
                    }   // end of - if (this.Text[a - 1] == divide_true)
                }       // end of - if (a > 0)
                return;
            }           //  end of - if (e.KeyChar == 8)
            // если цифра
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                if ((this.Text.Length == 0) && (e.KeyChar == '0'))
                {   // если первый ноль - сразу добавляем десятичный разделитель 
                    e.Handled = true;
                    this.Text = "0" + divide_true;
                    this.Select(this.Text.Length, 0);
                }
                return;
            }   // завершение if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            // если все другие символы  //MessageBox.Show("Цифирку надо!");
            e.Handled = true;
        }   // end of - TxtBoxDbl_KeyPress

        #endregion ОБРАБОТЧИКИ СОБЫТИЙ !!!

    }       // end of - TxtBoxDbl : TextBox
}           // end of - namespace WinLib
