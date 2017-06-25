using System;
using System.Windows.Forms;

namespace WinLib    // WinLib !!!!!
{

    #region common DATA in namespace WinLib

        // Создаем тип данных Place, задающий расположение контрола (справа или снизу)
        // - относительно контрола принятого за базу
    public enum Place { right, bottom }   // определение типа данных - вне классов
        // Создаем тип данных TypeLoad - тип нагрузки
        //(0)Stretch - растяжение//(1)Bend - изгиб//(2)Twist - кручение//(3)Cut - срез//(4)Crush - смятие
    public enum TypeLoad { Stretch, Bend, Twist, Cut, Crush };
        // Профиль детали
    public enum Profile { Circle, CircleRing, Rectangle, RectangleRing };
        // Для опытов
    delegate void Proba(int a);
        // ***

    #endregion common DATA in namespace WinLib


        //  !!!!!!!!!!!!!!!!!!!!!!!!!!!  aForm : Form  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
    public partial class aForm : Form
    {

        #region  DATA in class aForm !!!
            //***
        protected ToolTip Tip1, Tip2;  // protected
        protected HelpProvider hlP1;
        protected string hlpFile = null;
        public static int gap = 5;    // величина промежутка между контролами
        //public static double _981 = 10.0;
        public static Profile profile = Profile.Circle;       // создание объекта - profile (типа - Profile)
        public static TypeLoad typeload = TypeLoad.Stretch;   // Тип нагрузки = растяжение
        public static string[] Tip = { "При растяжении ", "При изгибе ", "При кручении ", "При срезе ", "При смятии " };
            //***
        #endregion  DATA in class aForm !!!
            

            #region  КОНСТРУКТОР !!!
        public aForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += new FormClosingEventHandler(Form_CalcStress_FormClosing); // Обработчик для события закрытия
        }   // end of aForm()
            #endregion  КОНСТРУКТОР !!!


            // МЕГА-МЕТОД ФОРМАТИРОВАНИЯ СТРОКИ !!!  (перегрузка - строка передается СЮДА по ссылке)
        public static void setText(ref string txt, params object[] list)
        {
            txt = "";   // переданную ссылку обнуляем на всякий..

            txt = setText(list);    // вызов этого-же метода !! (но перегруженного..)
        }   // end of - setText(ref string txt, params object[] list)


            // МЕГА-МЕТОД ФОРМАТИРОВАНИЯ СТРОКИ !!! (перегрузка - строка возвращается)
            // теперь и для double и для int !!!
        public static string setText(params object[] list)
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
                else
                {
                    if (list[i].GetType() == typeof(int))
                    {
                        int val = (int)list[i];
                        list[i] = val;
                    }
                }
                txt += list[i].ToString();
            }   // for
            return txt;
        }   // end of - setText(params object[] list)


            // Функция вывода инфо месседж бокса
        public static void msg(params object[] listIn)
        {
            string str = setText(listIn);
            System.Windows.Forms.MessageBox.Show(str);
        }   // end of - msg(params object[] listIn)


            // function round
        public static double r(double val)  // вместо метода Math.Round
        {
            int num = whereDivider(val);
            return Math.Round(val, num);
        }   // end of - r() - round


            // int whereDivider(double val)
        public static int whereDivider(double val)
        {
            for (; ; )
            {
                if (val < 1) return 5;
                if (val < 10) return 4;
                if (val < 100) return 3;
                if (val < 1000) return 2;
                if (val < 10000) return 1;
                if (val >= 10000) return 0;
            }   // for (; ; )
        }   // end of - int whereDivider(double val)
        

        #region EVENT HANDLERS !!!

            // Form_CalcStress_FormClosing
        private void Form_CalcStress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Чета не понял - ВЫХОДИМ ???", "Хрена-се...",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)   // MessageBoxButtons.YesNo
            {
                e.Cancel = false;   // продолжение закрытия программы 
            }
            else
                e.Cancel = true;    // отмена закрытия программы 
        }   // end of Form_CalcStress_FormClosing

        #endregion EVENT HANDLERS !!!

    }       // end of class aForm : Form
}           // end of namespace WinLib
