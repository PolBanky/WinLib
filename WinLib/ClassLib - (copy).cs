using System;
using System.Windows.Forms;
using WinLib;

namespace ConLib
{
    public class Lib
    {
        public const double Pi = Math.PI;       // = 3,1415926535897932384626433832795
        public const double PiPow2 = Pi * Pi;   // = 9,8696044010893586188344909998762
        public const double PiDiv4 = Pi / 4;    // = 0,78539816339744830961566084581988
        public const double PiDiv16 = Pi / 16;  // = 0,19634954084936207740391521145497
        public const double PiDiv32 = Pi / 32;  // = 0,098174770424681038701957605727484
        public const double dFactor = Pi / 180; // = 0,01745329251994329576923690768489
        // Угол A должен быть в радианах. Умножьте A на Math.PI/180 для преобразования градусов в радианы  
        static char divide_true = ' ', divide_false = ' ';
        

        static double degToRad(double angleInDegree)
        {
            return angleInDegree * dFactor; // Вернуть к-во радиан в этом к-ве градусов 
        }   // end of - toDeg(double angleInRad) 


        // функциональный аналог текстбокса с лебелом - return double 
        static public double Promt(string a)
        {
            string str;
            double d;
            bool result;

            if (divide_true == ' ') divider();
            Console.Write( a );
            do
            {
                str = Console.ReadLine();   // читать строку ! 
                str = str.Replace(divide_false, divide_true);                
                result = Double.TryParse(str, out d);
                if (!result)
                { Console.WriteLine("Input Error! Try Again!");
                    str = "";
                    d = 0.0;
                }
            } while (!result);
            return d;
        }   // end of - Promt(string a) 
        


        // функциональный аналог текстбокса с лебелом - out double dbl 
        static public void Promt(string a, out double dbl)
        {
            string str;
            double d;
            bool result;

            if (divide_true == ' ') divider();
            Console.Write(a);
            do
            {
                str = Console.ReadLine();   // читать строку ! 
                str = str.Replace(divide_false, divide_true);
                result = Double.TryParse(str, out d);
                if (!result)
                {
                    Console.WriteLine("Input Error! Try Again!");
                    str = "";
                    d = 0.0;
                }
            } while (!result);
            dbl = d;
        }   // end of - Promt(string a) 


        // функциональный аналог текстбокса с лебелом - out double dbl 
        static public void Promt(string a, out dim1 dim)
        {
            string str;
            double d;
            bool result;

            if (divide_true == ' ') divider();
            Console.Write(a);
            do
            {
                str = Console.ReadLine();   // читать строку ! 
                str = str.Replace(divide_false, divide_true);
                result = Double.TryParse(str, out d);
                if (!result)
                {
                    Console.WriteLine("Input Error! Try Again!");
                    str = "";
                    d = 0.0;
                }
            } while (!result);
            dim = new dim1(d);
        }   // end of - Promt(string a) 


        // функциональный аналог текстбокса с лебелом - out int i 
        static public void Promt(string a, out int i)
        {
            string str;
            int i1;
            bool result;

            Console.Write(a);
            do
            {
                str = Console.ReadLine();   // читать строку ! 
                result = Int32.TryParse(str, out i1);
                if (!result)
                {
                    Console.WriteLine("Input Error! Try Again!");
                    str = "";
                    i = 0;
                }
            } while (!result);
            i = i1;
        }   // end of - Promt(string a) 


        // функциональный аналог текстбокса с лебелом - out char c 
        static public void Promt(string a, out char c)
        {
            string str;
            char ch;
            bool result;

            Console.Write(a);
            do
            {
                str = Console.ReadLine();   // читать строку ! 
                result = Char.TryParse(str, out ch);
                if (!result)
                {
                    Console.WriteLine("Input Error! Try Again!");
                    str = "";
                    ch = ' ';
                }
            } while (!result);
            c = ch;
        }   // end of - Promt(string a) 



        // МЕГА-МЕТОД ВЫВОДА СТРОКИ !!! - аналог адвансед лебела 
        static public void s(params object[] list)
        {   // метод в таком виде для разработки его использования в форме 
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
            Console.WriteLine( txt);
        }   // end of - s(params object[] list) 



        // функция round 
        static public double r(double val)
        {
            int num = 0;
            for (;;)
            {
                if (val < 1) { num = 5; break; }
                if (val < 10) { num = 4; break; }
                if (val < 100) { num = 3; break; }
                if (val < 1000) { num = 2; break; }
                if (val < 10000) { num = 1; break; }
                if (val >= 10000) { num = 0; break; }
            }
            //Math.Round(val, num);
            return Math.Round(val, num);
        }   // end of - r(double val) - round 

         

        // Вычисление косинуса угла (аргумент в градусах) 
        public static double Cos(double grad)
        { return Math.Cos(degToRad(grad)); }
        

        // Вычисление синуса угла (аргумент в градусах) 
        public static double Sin(double grad)
        { return Math.Sin(degToRad(grad)); }

//*******************************************************************
        #region Area

        public static double AreaCircle(double d_ex)
        {
            return Math.Pow(d_ex, 2) * PiDiv4;
        }  // end of - AreaCircle()


        public static dim2 AreaCircle(dim1 d_ex)
        {
            // 
            return Math.Pow(d_ex, 2) * PiDiv4;
        }  // end of - AreaCircle()


        public static dim2 AreaRing(dim1 d_ex, dim1 d_in)
        {
            // 
            return (Math.Pow(d_ex, 2) * PiDiv4 - Math.Pow(d_in, 2) * PiDiv4);
        }  // end of - AreaCircle()


        public static double AreaRectangle(double b_ex, double h_ex)
        {
            return b_ex * h_ex;
        }  // end of - AreaRectangle()
        

        public static dim2 AreaRectangle(dim1 b_ex, dim1 h_ex)
        {
            return b_ex * h_ex;
        }  // end of - AreaRectangle()
        
        #endregion Area
//*******************************************************************

        #region - Anythings
        // на всякий случай
        static public double r(double val, int num)
        {            
            return Math.Round(val, num);
        }   // end of - r(double val, int num) - round
        


        static public void initialize(int wdt, int hgt)
        {
            // MessageBox.Show("Just for proba");
            int wdBuf = Console.BufferWidth;
            int htBuf = Console.BufferHeight;
            int wdWnd = Console.WindowWidth;
            int htWnd = Console.WindowHeight;
            int wdWndMax = Console.LargestWindowWidth;
            int htWndMax = Console.LargestWindowHeight;

            if((wdt > wdWndMax)||(hgt > htWndMax))
            {
                MessageBox.Show(" Window is too big. Now use Width = 105 and Height = 50 ");
                wdt = 105;
                hgt = 50;            
            }
            
            Console.Title = " -- MY GREAT 3-D PROGRAMM (v 1.0) -- ";

            if(wdBuf >= wdt)
            {
                Console.SetWindowSize(wdt, hgt);  // Размер окна консоли
                Console.SetBufferSize(wdt, hgt);  // Размер буфера экрана
            }
            else
            {
                Console.SetBufferSize(wdt, hgt);  // Размер буфера экрана
                Console.SetWindowSize(wdt, hgt);  // Размер окна консоли
            }
            //Console.SetBufferSize(105, Console.BufferHeight);  // Размер буфера экрана
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            //s("Width Buff = ", wdBuf, ";  Heigth Buff = ", htBuf);
            //s("\nWidth Wind = ", wdWnd, ";  Heigth Wind = ", htWnd);
            //s("\n\nWidth Buff = ", Console.BufferWidth, ";  Heigth Buff = ", Console.BufferHeight);
            //s("\nWidth Wind = ", Console.WindowWidth, ";  Heigth Wind = ", Console.WindowHeight);
            s("\nHello! It's Program with classes !    Now is " + DateTime.Now + "\n");
        }   // end of initialize()



        //  ну ви панимаете..
        static void divider()
        {
            string a;
            a = System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (a[0] == ',')
            { divide_true = ','; divide_false = '.'; }
            else
            { divide_true = '.'; divide_false = ','; }
        }	// end of - divider()



        // Continue()
        static public void Continue()
        {
            Console.Write("\n   Press any key for continue \n\n");
            Console.ReadKey(true);
        }   // end of - Continue()


        // Continue()
        static public void Continue(string txt)
        {
            Console.Write("\n" + txt);
            Console.Write("   Press any key for continue \n\n");
            Console.ReadKey(true);
        }   // end of - Continue()


        // Exit()
        static public void Exit()
        {
            Console.Write("\n   Bye-bye!   Press any key for exit");
            Console.ReadKey(true);
        }   // end of - Exit()

        #endregion
    }   // end of - class ConLib 
}       // end of - namespace ConLib 
