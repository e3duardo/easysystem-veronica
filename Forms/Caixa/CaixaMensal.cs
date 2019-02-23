using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Library;
using Library.Classes;

namespace Forms.Caixa
{

    public partial class CaixaMensal : Form
    {
        public CaixaMensal()
        {
            InitializeComponent();
        }

        private void CaixaMensal_Load(object sender, EventArgs e)
        {
            //preenchendo e selecionando ano
            comboBoxAno.Items.Add(2011);
            for (uint i = 0; i < (DateTime.Now.Year - 2011); i++)
            {
                comboBoxAno.Items.Add(new DateTime(2011, 01, 01).AddYears(1).Year);
            }
            comboBoxAno.SelectedItem = DateTime.Now.Year;

            //selecionando mes
            comboBoxMes.SelectedIndex = DateTime.Now.Month;

            RefreshForm();
        }

        public void RefreshForm()
        {
            //tranalhando com chart
            try
            {
                chart1.Series[0].Points.Clear();
                dataGridView1.Rows.Clear();

                if (comboBoxMes.SelectedIndex != -1)
                {
                    int ano = int.Parse(comboBoxAno.SelectedItem.ToString());
                    int mes = comboBoxMes.SelectedIndex;

                    List<Library.Caixa> caixa = CaixaBD.FindAdvanced(
                                        new QItem("dataMaior", new DateTime(ano, mes, 31).ToString("yyyy-MM-dd"))
                                      , new QItem("dataMenor", new DateTime(ano, mes, 1).ToString("yyyy-MM-dd")));

                    for (int j = 0; j < caixa.Count; j++)//até 31
                    {
                        chart1.Series[0].Points.AddXY(caixa[j].Data.Value.Day, double.Parse(caixa[j].Saldo.ToString()));

                        dataGridView1.Rows.Add(caixa[j].Data.Value.Day, caixa[j].Saldo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void comboBoxAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshForm();
        }
    }
}
