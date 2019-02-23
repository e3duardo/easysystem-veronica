using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;
using Library.Converter;

namespace Forms.Cliente
{
    public partial class Gerenciamento : Form
    {
        public Gerenciamento()
        {
            InitializeComponent();
        }

        private void c_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //
            resultadoDGV.Rows.Clear();

            QItem queryCodigo = new QItem(null, null);
            QItem queryClienteNome = new QItem(null, null);

            //codigo
            if (this.codigoTB.Text != "")
                queryCodigo = new QItem("v.id", this.codigoTB.Text);
            else
                queryCodigo = new QItem(null, null);

            //cliente
            if (this.clienteNomeTB.Text != "")
                queryClienteNome = new QItem("c.nome LIKE %%", this.clienteNomeTB.Text);
            else
                queryClienteNome = new QItem(null, null);

            List<Library.Cliente> clientes = Library.ClienteBD.FindAdvanced(queryCodigo, queryClienteNome);

            if (clientes != null)
            {
                foreach (Library.Cliente c in clientes)
                {
                    resultadoDGV.Rows.Add(c.Id, c.Nome);
                }
            }

            //
            this.Cursor = Cursors.Default;
        }

        private void resultadoDGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            List<Library.Venda> vendas = Library.VendaBD.FindAdvanced(new QItem("c.id", resultadoDGV[0, e.RowIndex].Value));

            vendasDGV.Rows.Clear();
            foreach (Library.Venda v in vendas)
            {
                vendasDGV.Rows.Add(v.Id, v.FormaPagamento, v.Valor.ConvertToMoneyString(), v.Data.Value.ToShortDateString());
            }
        }

        private void Gerenciamento_Load(object sender, EventArgs e)
        {

        }

        private void vendasDGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            List<Library.VendaParcela> parcelas = Library.VendaParcelaBD.FindAdvanced(new QItem("v.id", vendasDGV[0, e.RowIndex].Value));

            parcelasDGV.Rows.Clear();
            int i = 0;
            int np = 1;
            foreach (Library.VendaParcela vp in parcelas)
            {
                if (vp.Pago == 1)
                {
                    this.parcelasDGV.Rows.Add(vp.Id, np, vp.Venda.Id, vp.Vencimento.Value.ToString("dd/MM/yyyy"), vp.Pagamento.Value.ToString("dd/MM/yyyy"), vp.Valor.Value.ConvertToMoneyString(), vp.Pago, "PAGO");

                    this.parcelasDGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(178, 178, 178);
                    this.parcelasDGV.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(178, 178, 178);
                }
                else
                {
                    if (vp.Vencimento < DateTime.Today)
                    {
                        this.parcelasDGV.Rows.Add(vp.Id, np, vp.Venda.Id, vp.Vencimento.Value.ToString("dd/MM/yyyy"), vp.Pagamento.Value.ToString("dd/MM/yyyy"), vp.Valor.Value.ConvertToMoneyString(), vp.Pago, "Atrasada");

                        this.parcelasDGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(234, 203, 181);
                        this.parcelasDGV.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(223, 175, 141);
                    }
                    else
                    {
                        this.parcelasDGV.Rows.Add(vp.Id, np, vp.Venda.Id, vp.Vencimento.Value.ToString("dd/MM/yyyy"), vp.Pagamento.Value.ToString("dd/MM/yyyy"), vp.Valor.Value.ConvertToMoneyString(), vp.Pago, "");

                        this.parcelasDGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(211, 227, 174);
                        this.parcelasDGV.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 214, 136);
                    }
                }
                i++;
                np++;
            }


            //foreach (Library.VendaParcela vp in parcelas)
            //{
            //    parcelasDGV.Rows.Add(vp.Id, vp.Valor.Value.ConvertToMoneyString(), vp.Vencimento.Value.ToShortDateString(), vp.Pagamento.Value.ToShortDateString());
            //}
        }

        private void resultadoDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Forms.Cliente.GerenciamentoPopUp Ger = new Forms.Cliente.GerenciamentoPopUp();
            Ger.Cliente = Library.ClienteBD.FindById((long)resultadoDGV[0, e.RowIndex].Value);
            Ger.ShowDialog(this);
        }

        private void resultadoDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                Forms.Cliente.GerenciamentoPopUp parcelas = new Forms.Cliente.GerenciamentoPopUp();
                parcelas.Cliente = Library.ClienteBD.FindById((long)resultadoDGV[0,e.RowIndex].Value);
                parcelas.ShowDialog(this);
            }
        }
    }
}
