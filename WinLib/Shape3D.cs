// по мотивам - Дейтел - C# в подлиннике (стр.172)

using System;
using System.Windows.Forms;


namespace WinLib
{
                            // class Shape3D
    public class Shape3D
    {
        protected const double Pi = Math.PI;        // = 3,1415926535897932384626433832795
        protected const double PiDiv4 = Pi / 4;     // = 0,78539816339744830961566084581988
        protected const double PiDiv16 = Pi / 16;   // = 0,19634954084936207740391521145497
        protected const double PiDiv32 = Pi / 32;   // = 0,098174770424681038701957605727484
        protected const double dFactor = Pi / 180;  // = 0,01745329251994329576923690768489

        public dim1 length;            // длина 3D тела  

        //public virtual dim2 Area { get {return 0.0} set ;}

        public virtual dim2 Area    { get { return 0.0; } }
        public virtual dim3 Axial_W { get { return 0.0; } }
        public virtual dim3 Polar_W { get { return 0.0; } }

        /*** РАСЧЕТЫ - МЕТОДЫ ***/
        //public virtual dim2 Area()
        //{ return 0; }
        //
        //public virtual dim3 Axial_W( )
        //{ return 0.0; }        
        ////
        //public virtual dim3 Polar_W( )
        //{ return 0.0; }
        //
        // Возвращение строкового представления Shape3D
        public override string ToString()
        { return "Shape3D"; }   // end of override ToString()

    }   // end of - class Point
}       // end of - namespace Stress_Calc
