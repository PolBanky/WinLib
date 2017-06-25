using System;
using System.Windows.Forms;


namespace WinLib
{
    public class Rod : Shape3D
    {
        public dim1 d_ex;

        // конструктор с аргументами - dim1 
        public Rod(dim1 d_exVal, dim1 lengthVal)
        {
            d_ex = d_exVal;
            length = lengthVal;
        }
        
        // конструктор с аргументом - dim1 
        public Rod(dim1 d_exVal)
        {
            d_ex = d_exVal;
            length = 1000.0;
        }


        public override dim2 Area    { get { return Math.Pow(d_ex, 2) * PiDiv4; } }
        public override dim3 Axial_W { get { return Math.Pow(d_ex, 3) * PiDiv32; } }
        public override dim3 Polar_W { get { return Math.Pow(d_ex, 3) * PiDiv16; } }

        /*** РАСЧЕТЫ - МЕТОДЫ ***/

        // Расчет площади исходного профиля Rod
        //public override dim2 Area()
        //{ return Math.Pow(d_ex, 2) * PiDiv4; }

        // Расчет площади по заданным значениям
        //protected dim2 Area(dim1 dia)
        //{ return Math.Pow(dia, 2) * PiDiv4; }

        //// Расчет осевого момента сопротивления исходного профиля Rod
        //public override dim3 Axial_W()
        //{ return Math.Pow(d_ex, 3) * PiDiv32; }

        //// Расчет полярного момента сопротивления исходного профиля Rod
        //public override dim3 Polar_W()
        //{ return Math.Pow(d_ex, 3) * PiDiv16; }


        // Возвращение строкового представления Rod
        public override string ToString()
        {
            return " Rod d_ex = " + d_ex;            
        }   // end of override string ToString()

    }   // end of - class Circle
}       // end of - namespace Stress_Calc