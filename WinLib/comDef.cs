using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinLib
{

    public static class comDef    // commonDefinition
    {
        //#region common DATA
        public static int gap = 5;    // величина промежутка между контролами
        public static TypeLoad typeload = TypeLoad.Stretch;   // Тип нагрузки = растяжение
        public static string[] Tip = {"При растяжении ","При изгибе ","При кручении ","При срезе ","При смятии " };
        //#endregion common DATA

        // МЕГА-МЕТОД ФОРМАТИРОВАНИЯ СТРОКИ !!!  (перегрузка - строка передается СЮДА по ссылке)
        public static void setText(ref string txt, params object[] list)
        {
            txt = "";
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
        }   // end of - setText(bool showIt, ref string txt, params object[] list)


        // МЕГА-МЕТОД ФОРМАТИРОВАНИЯ СТРОКИ !!! (перегрузка - строка возвращается)
        public static string setText(params object[] list)
        {
            string txt = "";
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].GetType() == typeof(double))
                {
                    double val = (double)list[i];
                    val = r(val);
                    list[i] = val;
                }
                else
                {
                    if (list[i].GetType() == typeof(int))
                    {
                        int val = (int)list[i];
                        list[i] = val;
                    }
                }
                txt += list[i].ToString();
            }   // for
            return txt;
        }   // end of - setText(params object[] list)


        public static void a(params object[] listIn)
        {
            string str = setText(listIn);
            System.Windows.Forms.MessageBox.Show(str);
        }


        // function round
        public static double r(double val)  // вместо метода Math.Round
        {
            int num = whereDivider(val);
            return Math.Round(val, num);
        }   // end of - r() - round


        // int whereDivider(double val)
        public static int whereDivider(double val)
        {
            for (; ; )
            {
                if (val < 1) return 5;
                if (val < 10) return 4;
                if (val < 100) return 3;
                if (val < 1000) return 2;
                if (val < 10000) return 1;
                if (val >= 10000) return 0;
            }   // for (; ; )
        }   // end of - int whereDivider(double val)

        //// int whereDivider(double val)
        //public static int whereDivider(double val)
        //{
        //    int num = 0;
        //    for (; ; )
        //    {
        //        if (val < 1) { num = 5; break; }
        //        if (val < 10) { num = 4; break; }
        //        if (val < 100) { num = 3; break; }
        //        if (val < 1000) { num = 2; break; }
        //        if (val < 10000) { num = 1; break; }
        //        if (val >= 10000) { num = 0; break; }
        //    }   // for (; ; )
        //    return num;
        //}   // end of - int whereDivider(double val)

    }   // end of - class comDef
}       // end of - namespace WinLib
