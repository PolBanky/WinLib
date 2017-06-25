namespace WinLib
{
    public struct dim2
    {
        // Поле
        double mm_sq;   // В миллиметрах квадратных 
        public string wtDim;

        // Конструктор 
        public dim2(double val_mm_sq)
        {
            wtDim = " mm^2";
            mm_sq = val_mm_sq;
        }   // dim2(double val_mm_sq) 


        // Возвращение строкового представления dim2 
        public override string ToString()
        {   
            return ConLib.Lib.r(Cm_Sq).ToString() + wtDim;    //return base.ToString() + ", Diameter = " + mm; 
        }   // end of override string ToString()


        #region Properties

        public double Mm_Sq
        {
            get { wtDim = " mm^2";
                return mm_sq; }
            set { mm_sq = value; }
        }   // Mm_Sq 


        public double Cm_Sq
        {
            get { wtDim = " cm^2";
                return mm_sq / 100.0; }
            set { mm_sq = value * 100.0; }
        }   // Cm_Sq 

        #endregion Properties

        #region Operators

        // operator /(dim2 d2, force1 f1) 
        public static stress1 operator /(dim2 d2, force1 f1)
        {
            stress1 str = new stress1();
            str.N_MmSq = f1.N / d2.Mm_Sq;
            return str;
        }   // operator /(dim2 d2,  force1 f1) 


        //public static stress1 operator /(dim2 d2, force1 f1)
        //{
        //    stress1 str = new stress1();
        //    str.N_MmSq = f1.N / d2.Mm_Sq;
        //    return str;
        //}   // operator /(dim2 d2,  force1 f1) 


        // operator -(dim2 d1, dim2 d2) 
        public static dim2 operator -(dim2 d1, dim2 d2)
        {
            dim2 d3 = new dim2();
            d3.Mm_Sq = d1.Mm_Sq - d2.Mm_Sq;
            return d3;
        }   // operator -(dim2 d1, dim2 d2) 

        #endregion Operators

        #region Conversion

        // user-defined conversion from Fraction to double 
        public static implicit operator double(dim2 d)
        {
            return d.Mm_Sq;
        }   // conversion from dim2 to double 

        // user-defined conversion from double to Dim1 
        public static implicit operator dim2(double d)
        {
            return new dim2(d);
        }   // conversion from double to dim2 

        #endregion Conversion

    }   // struct dim2 
}       // namespace WinLib
