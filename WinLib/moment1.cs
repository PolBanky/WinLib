
namespace WinLib
{
    public struct moment1
    {
        double nxmm;   // В Ньютонах * Миллиметр !!! т.к. ввод как правило в мм 
        public string wtDim;
                
        // Конструктор 
        public moment1(double m)    // В Ньютонах * Метр !!!
        {
            wtDim = " N*mm";
            nxmm = m;
        }   // moment1() 


        // Возвращение строкового представления stress1 
        public override string ToString()
        {
            return ConLib.Lib.r(KgxCm).ToString() + wtDim;    //return base.ToString() + ", Diameter = " + mm; 
        }   // end of override string ToString()


        #region Properties
        
        public double NxM
        {
            get { wtDim = " N*M"; 
                  return nxmm / 1000.0; }
            set { nxmm = value * 1000.0; }
        }   // M_Nm 

        public double NxMm
        {
            get { wtDim = " N*mm"; 
                  return nxmm; }
            set { nxmm = value; }
        }   // M_Nm 
        

        public double KgxCm
        {
            get { wtDim = " Kg*Cm";
                  return nxmm / 100.0; }   // 1 NM = 10 kg*cm 
            set { nxmm = value * 100.0; }
        }   // N 

        #endregion Properties


        #region Operators

        // operator /(dim3 d3, moment1 m1) 
        public static stress1 operator /(dim3 w, moment1 m)
        {
            stress1 str = new stress1();
            str.Kg_CmSq = m.KgxCm / w.Cm_Cub;
            //s.N_MmSq = m1.Nxmm / d3.Mm_Cub;
            return str;
        }   // operator /(dim2 d2,  force1 f1) 

        #endregion Operators


        #region Conversion

        // user-defined conversion from force1 to double 
        public static implicit operator double(moment1 m)
        {
            return m.NxMm;
        }   // conversion from force1 to double 


        // user-defined conversion from double to force1 
        public static implicit operator moment1(double m)
        {
            return new moment1(m);
        }   // conversion from double to dim1 

        #endregion Conversion

    }   // struct force1 
}       // namespace ConLib 