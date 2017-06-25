using System;
using System.Windows.Forms;

namespace WinLib
{
    public class ListBoxSteelChoice : ListBox
    {
        #region DATA

        public LabelDataOfSteel labelDataOfSteel; // Ссылка на лебел в котором отображаются данные выбранной стали   
        public LabelAboutSteel LAS;               // Ссылка на лебел в котором отображаются обозначения марок сталей 
        public SteelData st;                      // Ссылка на экземпляр класса SteelData ( данные сталей ) в WinLib 
        // public double actual_Stress_Max = 0.0;    // Допускаемое напряжение при выбранном типе и виде нагрузки, МПа 
        public stress1 actual_Stress_Max = 0.0;    // Допускаемое напряжение при выбранном типе и виде нагрузки, МПа  
        int steelsListLength;                     // определение длины массива структур 
        public event EventHandler SteelChanged;   // EVENT 

        #endregion DATA

        //  КОНСТРУКТОР !!!!
        public ListBoxSteelChoice(Control a, int wdtWinForm) // установить ниже контрола, wdtWinForm - ширина винформы 
        {
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            this.Left = a.Left;
            this.Top = a.Bottom + aForm.gap;
            this.Size = new System.Drawing.Size(180, 84);

            st = new SteelData();
            steelsListLength = st.steels.GetLength(0);  // определение длины массива структур 
            int i = 0;                                  // подсчет циклов         
            while (i < steelsListLength)                // инициализация listBox1 
            { this.Items.Add(st.steels[i++].steelName); }
            this.SelectedIndex = 0;                     // выделяем первую строку в listBox1 

            this.SelectedIndexChanged += new System.EventHandler(listBox1_SelectedIndexChanged);

            labelDataOfSteel = new LabelDataOfSteel(this, 300);
            set_actual_Stress_Max();
            show_Data_Of_Steel();

            int wdtLAS = wdtWinForm - (this.Width + labelDataOfSteel.Width + 4 * aForm.gap + 6);
            LAS = new LabelAboutSteel(labelDataOfSteel, wdtLAS);

        }   // end of - ListBoxSteelChoice(Control a) 


            // Обработчик события
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            set_actual_Stress_Max();
            show_Data_Of_Steel();
            if (SteelChanged != null)
                SteelChanged(this, new EventArgs());  // Генерируется событие SteelChanged !!!!!!!!!!
        }     // завершение listBox1_SelectedIndexChanged()


            // set_actual_Stress_Max()
        public void set_actual_Stress_Max()
        {
            switch (aForm.typeload)   // TypeLoad { Stretch, Bend, Twist, Cut }; 
            {
                case TypeLoad.Stretch:  // растяжение 
                    actual_Stress_Max = st.steels[SelectedIndex].static_Stretch_Stress_Max;
                    break;

                case TypeLoad.Bend:     // изгиб 
                    actual_Stress_Max = st.steels[SelectedIndex].static_Bend_Stress_Max;
                    break;

                case TypeLoad.Twist:    // кручение 
                    actual_Stress_Max = st.steels[SelectedIndex].static_Twist_Stress_Max;
                    break;

                case TypeLoad.Cut:      // срез 
                    actual_Stress_Max = st.steels[SelectedIndex].static_Cut_Stress_Max;
                    break;

                case TypeLoad.Crush:      // смятие 
                    actual_Stress_Max = st.steels[SelectedIndex].static_Crush_Stress_Max;
                    break;
            }   // switch 
        }       // end of - set_actual_Stress_Max() 


            //show_Data_Of_Steel()
        public void show_Data_Of_Steel()
        {
            labelDataOfSteel.Text = "Марка стали - " + st.steels[SelectedIndex].steelName
+ "\nВременное сопротивление = " + Convert.ToString(st.steels[SelectedIndex].ultimate_Strength) + "  МПа"
+ "\nПредел текучести = " + Convert.ToString(st.steels[SelectedIndex].yield_Strength) + "  МПа"
+ "\n" + aForm.Tip[(int)aForm.typeload] + " допустимое напряжение = \n"
//+ Convert.ToString(actual_Stress_Max) + "  МПа"
+ actual_Stress_Max.MPa + actual_Stress_Max.wtDim
                //+ "\n" + Tip[(int)choisePanel] + Vid[(int)loadVid]
                /*+ "\nдопустимое напряжение  -  " + Convert.ToString(actual_Stress_Max) + "  МПа"*/;
        }   // завершение show_Data_Of_Steel()

    }   // end of - class ListBoxSteelChoice : ListBox
}       // end of - namespace WinLib