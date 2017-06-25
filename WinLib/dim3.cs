
namespace WinLib
{
    public struct dim3
    {
        // Поле
        double mm_cub;
        public string wtDim;

        // Конструктор 
        public dim3(double val_mm_cub)
        {
            wtDim = " mm^3";
            mm_cub = val_mm_cub;
        }   // dim3(double val_mm_cub) 


        // Возвращение строкового представления dim3 
        public override string ToString()
        {
            return ConLib.Lib.r(Cm_Cub).ToString() + wtDim;    //return base.ToString() + ", Diameter = " + mm; 
        }   // end of override string ToString()


        #region Properties

        public double Mm_Cub
        {
            get { wtDim = " mm^3";
                return mm_cub; }
            set { mm_cub = value; }
        }   // Mm_Cub 


        public double Cm_Cub
        {
            get { wtDim = " cm^3";
                return mm_cub / 1000.0; }
            set { mm_cub = value * 1000.0; }
        }   // Cm_Cub 

        #endregion Properties


        #region Operators


        #endregion Operators
        

        #region Conversion

        // user-defined conversion from Fraction to double 
        public static implicit operator double(dim3 d)
        {
            return d.Mm_Cub;
        }   // conversion from dim3 to double 

        // user-defined conversion from double to Dim1 
        public static implicit operator dim3(double d)
        {
            return new dim3(d);
        }   // conversion from double to dim3 

        #endregion Conversion

    }   // struct dim1     
}       // namespace WinLib
