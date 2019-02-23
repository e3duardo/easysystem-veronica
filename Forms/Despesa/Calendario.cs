using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;

namespace Forms.Despesa
{
    public partial class CalendarioForm : Form
    {
        DateTime special;
        DateTime mes;
        public CalendarioForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Calendario_Load(object sender, EventArgs e)
        {
            special = new DateTime(2011, 3, 6);
            mes = DateTime.Now;
            Atualizar(mes);
        }

        public void Atualizar(DateTime mes)
        {
            //mes = DateTime.Now;

            this.LMes.Text = string.Format("{0:MMMM} de {0:yyyy}", mes);

            int[] array1 = new int[42];
            Color[] ForeColor = new Color[42];
            Color[] BackColor = new Color[42];

            DateTime firstday = new DateTime(mes.Year, mes.Month, 1);
            DateTime moreday = firstday.AddDays(-1);

            DateTime firstNextDay = firstday.AddMonths(1);
            DateTime moreNextDay = firstNextDay.AddDays(-1);

            DateTime minusday = firstday;

            for (int i = (int)firstday.DayOfWeek; i < 42; i++)
            {
                BackColor[i] = Color.White;
                ForeColor[i] = Color.Silver;

                moreday = moreday.AddDays(1);

                if (moreday.Month == firstday.Month)
                {
                    array1[i] = moreday.Day;
                    
                    //cor
                    Color cor = ColorDay(moreday);
                    BackColor[i] = cor;
                    
                    if (Color.White == cor)
                        ForeColor[i] = Color.Black;
                    else
                        ForeColor[i] = Color.White;
                    //end cor
                }
                else if (moreday.Month > firstday.Month)
                {
                    moreNextDay = moreNextDay.AddDays(1);
                    array1[i] = moreNextDay.Day;
                    ForeColor[i] = Color.Silver;
                }

            }

            for (int i = (int)firstday.DayOfWeek - 1; i >= 0; i--)
            {
                ForeColor[i] = Color.Silver;
                minusday = minusday.AddDays(-1);

                array1[i] = minusday.Day;
            }

            this.LDom1.Text = array1[0].ToString();
            this.LDom2.Text = array1[7].ToString();
            this.LDom3.Text = array1[14].ToString();
            this.LDom4.Text = array1[21].ToString();
            this.LDom5.Text = array1[28].ToString();
            this.LDom6.Text = array1[35].ToString();

            this.LSeg1.Text = array1[1].ToString();
            this.LSeg2.Text = array1[8].ToString();
            this.LSeg3.Text = array1[15].ToString();
            this.LSeg4.Text = array1[22].ToString();
            this.LSeg5.Text = array1[29].ToString();
            this.LSeg6.Text = array1[36].ToString();

            this.LTer1.Text = array1[2].ToString();
            this.LTer2.Text = array1[9].ToString();
            this.LTer3.Text = array1[16].ToString();
            this.LTer4.Text = array1[23].ToString();
            this.LTer5.Text = array1[30].ToString();
            this.LTer6.Text = array1[37].ToString();

            this.LQua1.Text = array1[3].ToString();
            this.LQua2.Text = array1[10].ToString();
            this.LQua3.Text = array1[17].ToString();
            this.LQua4.Text = array1[24].ToString();
            this.LQua5.Text = array1[31].ToString();
            this.LQua6.Text = array1[38].ToString();

            this.LQui1.Text = array1[4].ToString();
            this.LQui2.Text = array1[11].ToString();
            this.LQui3.Text = array1[18].ToString();
            this.LQui4.Text = array1[25].ToString();
            this.LQui5.Text = array1[32].ToString();
            this.LQui6.Text = array1[39].ToString();

            this.LSex1.Text = array1[5].ToString();
            this.LSex2.Text = array1[12].ToString();
            this.LSex3.Text = array1[19].ToString();
            this.LSex4.Text = array1[26].ToString();
            this.LSex5.Text = array1[33].ToString();
            this.LSex6.Text = array1[40].ToString();

            this.LSab1.Text = array1[6].ToString();
            this.LSab2.Text = array1[13].ToString();
            this.LSab3.Text = array1[20].ToString();
            this.LSab4.Text = array1[27].ToString();
            this.LSab5.Text = array1[34].ToString();
            this.LSab6.Text = array1[41].ToString();

            Colorir(ForeColor, BackColor);
        }

        public void Colorir(Color[] ForeColor, Color[] BackColor)
        {
            this.LDom1.ForeColor = ForeColor[0];
            this.LDom2.ForeColor = ForeColor[7];
            this.LDom3.ForeColor = ForeColor[14];
            this.LDom4.ForeColor = ForeColor[21];
            this.LDom5.ForeColor = ForeColor[28];
            this.LDom6.ForeColor = ForeColor[35];

            this.LSeg1.ForeColor = ForeColor[1];
            this.LSeg2.ForeColor = ForeColor[8];
            this.LSeg3.ForeColor = ForeColor[15];
            this.LSeg4.ForeColor = ForeColor[22];
            this.LSeg5.ForeColor = ForeColor[29];
            this.LSeg6.ForeColor = ForeColor[36];

            this.LTer1.ForeColor = ForeColor[2];
            this.LTer2.ForeColor = ForeColor[9];
            this.LTer3.ForeColor = ForeColor[16];
            this.LTer4.ForeColor = ForeColor[23];
            this.LTer5.ForeColor = ForeColor[30];
            this.LTer6.ForeColor = ForeColor[37];

            this.LQua1.ForeColor = ForeColor[3];
            this.LQua2.ForeColor = ForeColor[10];
            this.LQua3.ForeColor = ForeColor[17];
            this.LQua4.ForeColor = ForeColor[24];
            this.LQua5.ForeColor = ForeColor[31];
            this.LQua6.ForeColor = ForeColor[38];

            this.LQui1.ForeColor = ForeColor[4];
            this.LQui2.ForeColor = ForeColor[11];
            this.LQui3.ForeColor = ForeColor[18];
            this.LQui4.ForeColor = ForeColor[25];
            this.LQui5.ForeColor = ForeColor[32];
            this.LQui6.ForeColor = ForeColor[39];

            this.LSex1.ForeColor = ForeColor[5];
            this.LSex2.ForeColor = ForeColor[12];
            this.LSex3.ForeColor = ForeColor[19];
            this.LSex4.ForeColor = ForeColor[26];
            this.LSex5.ForeColor = ForeColor[33];
            this.LSex6.ForeColor = ForeColor[40];

            this.LSab1.ForeColor = ForeColor[6];
            this.LSab2.ForeColor = ForeColor[13];
            this.LSab3.ForeColor = ForeColor[20];
            this.LSab4.ForeColor = ForeColor[27];
            this.LSab5.ForeColor = ForeColor[34];
            this.LSab6.ForeColor = ForeColor[41];

            //
            this.LDom1.BackColor = BackColor[0];
            this.LDom2.BackColor = BackColor[7];
            this.LDom3.BackColor = BackColor[14];
            this.LDom4.BackColor = BackColor[21];
            this.LDom5.BackColor = BackColor[28];
            this.LDom6.BackColor = BackColor[35];

            this.LSeg1.BackColor = BackColor[1];
            this.LSeg2.BackColor = BackColor[8];
            this.LSeg3.BackColor = BackColor[15];
            this.LSeg4.BackColor = BackColor[22];
            this.LSeg5.BackColor = BackColor[29];
            this.LSeg6.BackColor = BackColor[36];

            this.LTer1.BackColor = BackColor[2];
            this.LTer2.BackColor = BackColor[9];
            this.LTer3.BackColor = BackColor[16];
            this.LTer4.BackColor = BackColor[23];
            this.LTer5.BackColor = BackColor[30];
            this.LTer6.BackColor = BackColor[37];

            this.LQua1.BackColor = BackColor[3];
            this.LQua2.BackColor = BackColor[10];
            this.LQua3.BackColor = BackColor[17];
            this.LQua4.BackColor = BackColor[24];
            this.LQua5.BackColor = BackColor[31];
            this.LQua6.BackColor = BackColor[38];

            this.LQui1.BackColor = BackColor[4];
            this.LQui2.BackColor = BackColor[11];
            this.LQui3.BackColor = BackColor[18];
            this.LQui4.BackColor = BackColor[25];
            this.LQui5.BackColor = BackColor[32];
            this.LQui6.BackColor = BackColor[39];

            this.LSex1.BackColor = BackColor[5];
            this.LSex2.BackColor = BackColor[12];
            this.LSex3.BackColor = BackColor[19];
            this.LSex4.BackColor = BackColor[26];
            this.LSex5.BackColor = BackColor[33];
            this.LSex6.BackColor = BackColor[40];

            this.LSab1.BackColor = BackColor[6];
            this.LSab2.BackColor = BackColor[13];
            this.LSab3.BackColor = BackColor[20];
            this.LSab4.BackColor = BackColor[27];
            this.LSab5.BackColor = BackColor[34];
            this.LSab6.BackColor = BackColor[41];
        }

        private void BPrev_Click(object sender, EventArgs e)
        {
            mes = mes.AddMonths(-1);
            Atualizar(mes);
        }

        private void BNext_Click(object sender, EventArgs e)
        {
            mes = mes.AddMonths(1);
            Atualizar(mes);
        }

        private Color ColorDay(DateTime Date)
        {
            List<Library.Despesa> despesas = Library.DespesaBD.FindAdvanced(new QItem("d.data", Date.ToString("dd/MM/yyyy")));

            Color cor = Color.Silver;

            if (despesas.Count > 0)
                cor = Color.DodgerBlue;

            return cor;
        }

    }
}
