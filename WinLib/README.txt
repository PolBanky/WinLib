dim1		(Cm).     ToString() + wtDim
dim2		(Cm_Sq).  ToString() + wtDim
dim3		(Cm_Cub). ToString() + wtDim
moment1		(KgxCm).  ToString() + wtDim
force1		(Kg).     ToString() + wtDim
stress1		(Kg_CmSq).ToString() + wtDim


switch (lbl_TBox_10.Text)
                    {
                        case "F, kg":
                            force.Kg = TBox_10.val; // сила в ньютонах ! - а ввод в текстбокс в килограммах !!! 
                            break;
                        case "F, N":
                            force.N = TBox_10.val; // сила в ньютонах ! - и ввод в текстбокс в ньютонах !!! 
                            break;
                    }   // end of - switch (lbl_TBox_10.Text) 