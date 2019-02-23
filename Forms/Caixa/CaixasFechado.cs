using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Library.Converter;
using Library.Classes;

namespace Forms.Caixa
{

    public partial class CaixaFechado : Form
    {
        private delegate void InvokeDelegate(int index);

        //private Library.Windows.Forms.Print print;

        private Forms.Venda.VendaDetail vd = null;



        public CaixaFechado()
        {
            InitializeComponent();
        }

        private void CaixaFechado_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Refreshs();

            this.Cursor = Cursors.Default;
        }


        private void dataCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.AtualizarGrid();

            this.Cursor = Cursors.Default;
        }

        private void imprimirButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Library.Caixa caixa = (Library.Caixa)this.dataCB.SelectedItem;
            //atualizando caixa atual com valores do banco de dados;
            caixa = Library.CaixaBD.FindById(caixa.Id);

            Library.Classes.Print.PrintCaixa(caixa);

            this.Cursor = Cursors.Default;
        }



        private void CaixaFechado_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }


        private void Refreshs()
        {
            //this.dataCB.Items.Clear();
            this.dataCB.DisplayMember = "data";
            this.dataCB.ValueMember = "id";
            this.dataCB.DataSource = Library.CaixaBD.FindAdvanced(new QItem("c.status", "Fechado"), new QItem("ORDER BY", "c.data"));
            //this.dataCB.Items.AddRange(Library.CaixaFechadoBD.FindAdvanced());
            //this.dataCB.SelectedIndex = this.dataCB.Items.Count - 1;
            this.dataCB.SelectedIndex = -1;
            transacoesDGV.Rows.Clear();

            this.AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            try
            {
                if (this.dataCB.SelectedIndex != -1)
                {
                    Library.Caixa caixa = (Library.Caixa)this.dataCB.SelectedItem;
                    //atualizando caixa atual com valores do banco de dados;
                    caixa = Library.CaixaBD.FindById(caixa.Id);
                    List<Library.CaixaTransacao> transacoes = Library.CaixaTransacaoBD.FindAdvanced(new QItem("ct.idCaixa", caixa.Id));

                    this.transacoesDGV.Rows.Clear();
                    foreach (Library.CaixaTransacao ct in transacoes)
                    {
                        if (ct.Despesa != null)
                            this.transacoesDGV.Rows.Add(ct.Id, Library.Classes.StringFunctions.CortarString(ct.Despesa.Descricao, 110).Replace(char.ConvertFromUtf32(13) + char.ConvertFromUtf32(10), " "), ct.Tipo, ct.Valor, ct.Hora);
                        else if (ct.Venda != null)
                        {
                            if (ct.VendaParcela == null)
                                this.transacoesDGV.Rows.Add(ct.Id, ct.Venda.Cliente.Nome, ct.Tipo, ct.Valor, ct.Hora);
                            else
                                this.transacoesDGV.Rows.Add(ct.Id, ct.VendaParcela.Venda.Cliente.Nome, ct.Tipo, ct.Valor, ct.Hora);
                        }
                        else
                            this.transacoesDGV.Rows.Add(ct.Id, "Indisponível", ct.Tipo, ct.Valor, ct.Hora);
                    }
                    this.saldoTextBox.Text = caixa.Saldo.ConvertToMoneyString();

                    this.statusLabel.Text = string.Format("CaixaFechado {0}", caixa.Status);
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        private void CaixaFechado_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
