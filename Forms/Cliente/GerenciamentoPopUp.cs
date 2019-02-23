using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Converter;
using Library.Classes;

namespace Forms.Cliente
{
    public partial class GerenciamentoPopUp : Form
    {
        public Library.Cliente Cliente { get; set; }

        public GerenciamentoPopUp()
        {
            InitializeComponent();
        }

        private void GerenciamentoPopUp_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("Parcelas de {0}",Cliente.Nome);


            List<Library.VendaParcela> parcelas = Library.VendaParcelaBD.FindAdvanced(new QItem("c.id", Cliente.Id));

            this.parcelasDGV.Rows.Clear();
            int i = 0;
            foreach (Library.VendaParcela vp in parcelas)
            {
                string pagamento = "";


                if(!vp.Pagamento.Value.Equals(DateTime.MinValue))
                    pagamento = vp.Pagamento.Value.ToString("dd/MM/yyyy");

                if (vp.Pago == 1)
                {
                    if (vp.Vencimento < vp.Pagamento.Value)
                    {
                        this.parcelasDGV.Rows.Add(vp.Id, vp.Venda.Id, vp.Vencimento.Value.ToString("dd/MM/yyyy"), pagamento, vp.Valor.Value.ConvertToMoneyString(), vp.Pago, "PAGO (Atrasada)");

                        this.parcelasDGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(234, 203, 181);
                        this.parcelasDGV.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(223, 175, 141);
                    }
                    else
                    {
                        this.parcelasDGV.Rows.Add(vp.Id, vp.Venda.Id, vp.Vencimento.Value.ToString("dd/MM/yyyy"), pagamento, vp.Valor.Value.ConvertToMoneyString(), vp.Pago, "PAGO");

                        this.parcelasDGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(178, 178, 178);
                        this.parcelasDGV.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(178, 178, 178);
                    }
                }
                else
                {
                    if (vp.Vencimento < DateTime.Today)
                    {
                        this.parcelasDGV.Rows.Add(vp.Id, vp.Venda.Id, vp.Vencimento.Value.ToString("dd/MM/yyyy"), pagamento, vp.Valor.Value.ConvertToMoneyString(), vp.Pago, "Atrasada");

                        this.parcelasDGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(234, 203, 181);
                        this.parcelasDGV.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(223, 175, 141);
                    }
                    else
                    {
                        this.parcelasDGV.Rows.Add(vp.Id, vp.Venda.Id, vp.Vencimento.Value.ToString("dd/MM/yyyy"), pagamento, vp.Valor.Value.ConvertToMoneyString(), vp.Pago, "");

                        this.parcelasDGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(211, 227, 174);
                        this.parcelasDGV.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 214, 136);
                    }
                }
                i++;
            }
        }
    }
}
