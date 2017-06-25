using System;

namespace WinLib
{
    public class Trig
    {
        public const double Pi = Math.PI;          // = 3,1415926535897932384626433832795   
        public const double PiPow2 =  Pi * Pi;     // = 9,8696044010893586188344909998762   
        public const double PiDiv4 =  Pi / 4.0;    // = 0,78539816339744830961566084581988  
        public const double PiDiv16 = Pi / 16.0;   // = 0,19634954084936207740391521145497  
        public const double PiDiv32 = Pi / 32.0;   // = 0,098174770424681038701957605727484 
        public const double dFactor = Pi / 180.0;  // = 0,01745329251994329576923690768489  
            // Km == coefficient of measure
        public static double[] Km = { 1.0, 0.1 }; // коэффициент единиц измерения: если 1 - mm & N, если 0.1 - cm & Kg 
        public static string[] m1 = { " mm", " cm" };       // measure ^1 
        public static string[] m2 = { " mm^2", " cm^2" };   // measure ^2 
        public static string[] m3 = { " mm^3", " cm^3" };   // measure ^3 
        public static string[] NKg = { "F, N", "F, kg" };   // Newton - Kilogram 
        public static int I = 1;                            // Индекс массивов которые выше = см 

        // public static dim1 d_ex = 0.0;        // Диаметр наружный 



        // Вычисление косинуса угла (аргумент в градусах) 
        public static double Cos(double grad)
        { 
            return Math.Cos(grad * dFactor);
        }    // end of - Cos

        // Вычисление синуса угла (аргумент в градусах) 
        public static double Sin(double grad)
        {
            return Math.Sin(grad * dFactor);
        }    // end of - Sin

        // function alfa - для расчета полярного момента сопротивления прямоугольника 
        static public double alfa(double val)
        {
            double a = 0.0;
            for (;;) {
                if (val == 1.00) { a = 0.208; break; }
                if (val <= 1.20) { a = 0.219; break; }
                if (val <= 1.25) { a = 0.221; break; }
                if (val <= 1.50) { a = 0.231; break; }
                if (val <= 1.75) { a = 0.239; break; }
                if (val <= 2.00) { a = 0.246; break; }
                if (val <= 2.50) { a = 0.258; break; }
                if (val <= 3.00) { a = 0.267; break; }
                if (val <= 4.00) { a = 0.282; break; }
                if (val <= 5.00) { a = 0.291; break; }
                if (val <= 6.00) { a = 0.299; break; }
                if (val <= 8.00) { a = 0.307; break; }
                if (val <= 10.00){ a = 0.312; break; }
                if (val >  10.00){ a = 0.333; break; }
            }   // end of - for
            return a;
        }   // end of - alfa() 


        #region Area
        
        public static double AreaCircle(double d_ex)
        {
            return Math.Pow(d_ex, 2.0) * PiDiv4;    //  Pi * d_ex^2 / 4 
        }  // end of - AreaCircle() 


        public static dim2 AreaCircle(dim1 d_ex)
        {
            return Math.Pow(d_ex, 2.0) * PiDiv4;
        }  // end of - AreaCircle() 


        // public static dim2 CircArea { get { return Math.Pow(d_ex, 2.0) * PiDiv4; } } 


        public static double AreaCircleRing(double d_ex, double d_in)
        {
            return (Math.Pow(d_ex, 2.0) * PiDiv4) - (Math.Pow(d_in, 2.0) * PiDiv4);
        }  // end of - AreaCircleRing() 


        public static dim2 AreaCircleRing(dim1 d_ex, dim1 d_in)
        {
            //return (Math.Pow(d_ex, 2) * PiDiv4) - (Math.Pow(d_in, 2) * PiDiv4); 
            dim2 s1 = AreaCircle(d_ex);
            dim2 s2 = AreaCircle(d_in);
            return (s1 - s2);
        }  // end of - AreaCircleRing() 

        public static double AreaRectangle(double b_ex, double h_ex)
        {
            return b_ex * h_ex;
        }  // end of - AreaRectangle() 


        public static dim2 AreaRectangle(dim1 b_ex, dim1 h_ex)
        {
            return b_ex * h_ex;
        }  // end of - AreaRectangle() 


        public static double AreaRectangleRing(double b_ex, double h_ex, double b_in, double h_in)
        {
            return (b_ex * h_ex) - (b_in * h_in);
        }  // end of - AreaRectangle() 


        public static dim2 AreaRectangleRing(dim1 b_ex, dim1 h_ex, dim1 b_in, dim1 h_in)
        {
            dim2 s1 = AreaRectangle(b_ex, h_ex);
            dim2 s2 = AreaRectangle(b_in, h_in);
            return s1 - s2;
        }  // end of - AreaRectangle() 

        #endregion Area


        #region AxialW

        public static double AxialWCircle(double d_ex)
        {
            // Число двойной точности с плавающей запятой, задающее степень. 
            return Math.Pow(d_ex, 3.0) * PiDiv32;
        }  // end of - AxialWCircle()


        public static dim3 AxialWCircle(dim1 d_ex)
        {
            return Math.Pow(d_ex, 3.0) * PiDiv32;
            //return d_ex * d_ex * d_ex * PiDiv32;
        }  // end of - AxialWCircle()


        public static double AxialWCircleRing(double d_ex, double d_in)
        {
            return Math.Pow(d_ex, 3.0) * PiDiv32 * (1.0 - Math.Pow((d_in / d_ex), 4.0));
        }  // end of - AxialWCircleRing()


        public static dim3 AxialWCircleRing(dim1 d_ex, dim1 d_in)
        {
            return Math.Pow(d_ex, 3.0) * PiDiv32 * (1.0 - Math.Pow((d_in / d_ex), 4.0));
        }  // end of - AxialWCircleRing()


        public static double AxialWRectangle(double b_ex, double h_ex)
        {   // Анурьев стр.58 
            return b_ex * Math.Pow(h_ex, 2.0) / 6.0;
        }  // end of - AxialWRectangle()


        public static dim3 AxialWRectangle(dim1 b_ex, dim1 h_ex)
        {
            return b_ex * Math.Pow(h_ex, 2.0) / 6.0;
        }  // end of - AxialWRectangle()


        public static double AxialWRectangleRing(double b_ex, double h_ex, double b_in, double h_in)
        {
            return ((b_ex * Math.Pow(h_ex, 3.0)) - (b_in * Math.Pow(h_in, 3.0))) / (6.0 * h_ex);
        }  // end of - AxialWRectangle()

        #endregion  AxialW


        #region PolarW

        public static double PolarWCircle(double d_ex)
        {
            return Math.Pow(d_ex, 3.0) * PiDiv16;
        }   // end of - PolarWCircle()


        public static dim3 PolarWCircle(dim1 d_ex)
        {
            return Math.Pow(d_ex, 3.0) * PiDiv16;
        }   // end of - PolarWCircle()


        public static double PolarWCircleRing(double d_ex, double d_in)
        {
            double a = d_in / d_ex;
            return Math.Pow(d_ex, 3.0) * PiDiv16 * (1.0 - Math.Pow(a, 4.0));
        }   // end of - PolarWCircleRing()


        public static dim3 PolarWCircleRing(dim1 d_ex, dim1 d_in)
        {
            double a = d_in / d_ex;
            return Math.Pow(d_ex, 3.0) * PiDiv16 * (1.0 - Math.Pow(a, 4.0));
        }   // end of - PolarWCircleRing()


        public static double PolarWRectangle(double b_ex, double h_ex)
        {
            return alfa(h_ex / b_ex) * h_ex * Math.Pow(b_ex, 2.0);
        }   // end of - PolarWRectangle()

        
        // no data !!!
        public static double PolarWRectangleRing(double b_ex, double h_ex, double b_in, double h_in)
        { return 0.0; }   // no data

        #endregion PolarW

    }   // end of - class Trig 
}       // end of - namespace WinLib 