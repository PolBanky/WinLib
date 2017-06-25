
namespace WinLib
{
    public struct stress1
    {
        double a; // Напряжение в МПа = N/mm^2 
        public string wtDim;
                
        // Конструктор 
        public stress1(double f)
        {
            wtDim = " MPa";
            a = f;
        }   // stress1 


        // Возвращение строкового представления stress1 
        public override string ToString()
        {
            return ConLib.Lib.r(Kg_CmSq).ToString() + wtDim;    // return base.ToString() + ", Diameter = " + mm; 
        }   // end of override string ToString()
        

        #region Properties

        public double N_MmSq    // MPa = N/mm^2 
        {
            get
            {   wtDim = " MPa (N/mm^2)";
                return a; }
            set { a = value; }
        }   // N_MmSq 


        public double MPa    // MPa = N/mm^2 
        {
            get
            {   wtDim = " MPa";
                return a;
            }
            set { a = value; }
        }   // MPa 
         

        public double Kg_CmSq   // Kg/cm^2 * 10.0 = MPa 
        {
            get
            {   wtDim = " Kg/cm^2"; 
                return a * 10.0; }
            set { a = value / 10.0; }
        }   // Kg_CmSq 

        #endregion Properties


        #region Operators

        #endregion Operators


        #region Conversion

        // user-defined conversion from Fraction to double 
        public static implicit operator double(stress1 s)
        {
            return s.N_MmSq;
        }   // conversion from dim1 to double 


        // user-defined conversion from double to dim1 
        public static implicit operator stress1(double s)
        {
            return new stress1(s);
        }   // conversion from double to dim1 

        #endregion Conversion

    }   // class stress 
}       // namespace ConLib 
