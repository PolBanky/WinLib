using System.Diagnostics;


namespace WinLib
{
    public struct dim1
    {
        // Поле 
        double mm;  // В миллиметрах 
        public string wtDim;

        // Конструктор 
        public dim1(double val_mm)
        {
            wtDim = " mm";
            mm = val_mm;
        }   // dim1(double val_mm) 


        // Возвращение строкового представления dim1 
        public override string ToString( )
        {   
            return ConLib.Lib.r(Cm).ToString() + wtDim; //return base.ToString() + ", Diameter = " + mm;
        }   // end of override string ToString()


        #region Properties

        public double Mm
        {
            get { wtDim = " mm"; 
                return mm; }
            set { mm = value; }
        }   // Mm 


        public double Cm
        {
            get { wtDim = " cm"; 
                return mm / 10.0; }
            set { mm = value * 10.0; }
        }   // Cm 


        public double M
        {
            get { wtDim = " M"; 
                return mm / 1000.0; }
            set { mm = value * 1000.0; }
        }   // M 

        #endregion Properties

        #region Operators
        // operator *(dim1 d1, dim1 d2) 
        public static dim2 operator *(dim1 d1, dim1 d2)
        {
            dim2 d3 = new dim2();
            d3.Mm_Sq = d1.Mm * d2.Mm;
            return d3;
        }   // operator *(dim1 d1, dim1 d2) 


        // operator *(Dim1 d1, double dbl) 
        public static dim1 operator *(dim1 d1, double dbl)
        {
            dim1 d3 = new dim1();
            d3.Mm = d1.Mm * dbl;
            return d3;
        }   // operator *(dim1 d1, double dbl) 


        // operator *(Dim1 d1, double dbl) 
        public static dim1 operator *(double dbl, dim1 d1)
        {
            dim1 d3 = new dim1();
            d3.Mm = d1.Mm * dbl;
            return d3;
        }   // operator *(dim1 d1, double dbl) 


        // operator +(dim1 l1, force1 f1) 
        public static moment1 operator *(dim1 l1, force1 f1)
        {
            moment1 m1 = new moment1();
            m1.NxMm = l1.Mm * f1.N;
            return m1;
        }   // operator *(dim1 l1, force1 f1) 


        // operator +(dim1 l1, force1 f1) 
        public static moment1 operator *(force1 f1, dim1 l1)
        {
            moment1 m1 = new moment1();
            m1.NxMm = l1.Mm * f1.N;
            return m1;
        }   // operator *(dim1 l1, force1 f1) 
        
        #endregion Operators

        #region Conversion
        // user-defined conversion from Fraction to double 
        public static implicit operator double(dim1 d)
        {
            // Debug.WriteLine(string.Format("Now dim1 d = double {0}", d.Mm), "operator double(dim1 d)");
            // Debug.WriteLine(string.Format("Now dim1 {0} = double {1}", d.Mm), "operator double(dim1 d)");
            return d.Mm;
        }   // conversion from dim1 to double 

        // user-defined conversion from double to dim1 
        public static implicit operator dim1(double d)
        {
            // Debug.WriteLine(string.Format("Now double d = dim1({0})", d), "operator dim1(double d)");
            return new dim1(d);
        }   // conversion from double to dim1 
        #endregion Conversion
        
    }   // struct dim1     
}       // namespace WinLib
