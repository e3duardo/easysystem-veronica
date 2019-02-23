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


namespace Forms.Condicional
{
    public partial class Condicional : Form
    {
        /******************************************************/
        string foCondicionalImprimirMsg = "Deseja imprimir esta Condicional?";
        string foCondicionalImprimirMsgTitle = "Imprimir";

        string foCondicionalValidateFuncionario = "Por favor informe o funcionário.";
        string foCondicionalValidateCliente = "Por favor informe o cliente!";
        /******************************************************/

        private Library.Condicional condicional;

        //private Library.Windows.Forms.Print print;

        //private Reports.nota_condicional notao;

        public Condicional()
        {
            InitializeComponent();
        }



        // //////FUNÇÕES DE EVENTOS
        private void Condicional_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.RefreshForm();
            this.Cursor = Cursors.Default;
        }


        private void funcionarioButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Forms.OpenForm.OpenFuncionario();

            this.Cursor = Cursors.Default;
        }

        private void produtoButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Forms.OpenForm.OpenProduto();

            this.Cursor = Cursors.Default;
        }

        private void clienteButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Forms.OpenForm.OpenClienteFisica();

            this.Cursor = Cursors.Default;
        }


        private void idClienteTB_KeyUp(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            long tmpIdCliente = 0;
            long.TryParse(this.idClienteTB.Text, out tmpIdCliente);

            Library.Cliente cliente = Library.ClienteBD.FindById(tmpIdCliente);

            if (cliente != null)
            {
                int i = 0;
                foreach (Library.Cliente c in this.idClienteCB.Items)
                {
                    if (c.Id == cliente.Id)
                    {
                        this.idClienteCB.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }
            else
                this.idClienteCB.SelectedIndex = -1;

            this.Cursor = Cursors.Default;
        }

        private void idClienteCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.idClienteCB.SelectedIndex != -1)
            {

                Library.Cliente cliente = (Library.Cliente)this.idClienteCB.SelectedItem;

                if (cliente != null)
                    this.idClienteTB.Text = string.Format("{0}", cliente.Id);
                else
                    this.idClienteTB.Text = "";
            }

            this.Cursor = Cursors.Default;
        }

        private void idClienteTB_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            long tmpIdCliente = 0;
            long.TryParse(this.idClienteTB.Text, out tmpIdCliente);

            Library.Cliente cliente = Library.ClienteBD.FindById(tmpIdCliente);

            if (cliente == null)
            {
                this.idClienteTB.Text = "";
                this.idClienteCB.SelectedIndex = -1;
            }
            this.Cursor = Cursors.Default;
        }


        private void salvarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (ValidateForm())
                {

                    this.condicional = this.ReturnCondicionalFromForm();
                    Library.CondicionalBD.Save(this.condicional);


                    foreach (Library.CondicionalProduto a in ReturnCondicionalProdutoFromForm(long.Parse(this.codigoTB.Text)))
                    {
                        Library.CondicionalProdutoBD.Save(a);

                        Library.Produto produtoTMP = a.Produto;
                        produtoTMP.Estoque -= (double)a.Quantidade;
                        //produtoTMP.Vendido += (double)a.Quantidade;
                        Library.ProdutoBD.Update(produtoTMP);
                    }

                    if (MessageBox.Show(this.foCondicionalImprimirMsg, this.foCondicionalImprimirMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Library.Classes.Print.PrintCondicional(this.condicional);
                    }

                    this.produtos1.Clear();
                    this.RefreshForm();
                    this.RefreshChilds();

                    Forms.OpenForm.RefreshCondicionais();
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            this.Cursor = Cursors.Default;
        }

        private void limparButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            ShowValues();

            this.Cursor = Cursors.Default;
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            this.dataTB.Text = DateTime.Now.ToString();
        }


        private void Condicional_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F8:
                    this.funcionarioCB.Focus();
                    break;
                /* case Keys.F9:
                     this.produtoNomeCB.Focus();
                     break;
                 case Keys.F10:
                     this.produtoQuantidadeTB.Focus();
                     break;
                 case Keys.F11:
                     this.produtoAdicionarButton.Focus();
                     break;*/
                case Keys.F12:
                    this.idClienteCB.Focus();
                    break;
            }
        }

        private void Condicional_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }



        // //////FUNÇÕES DO FORMULÁRIO
        private void RefreshForm()
        {
            try
            {
                FillCliente();
                FillFuncionario();
                //FillProduto();

                ShowValues();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }
        private void RefreshChilds()
        {
            Forms.OpenForm.RefreshProdutos();
        }
        public override void Refresh()
        {
            this.valorTotalTextBox.Text = this.produtos1.ValorProdutos.ConvertToMoneyString();
            this.valorTotal2TextBox.Text = this.produtos1.ValorProdutosAVista.ConvertToMoneyString();
            //base.Refresh();
        }

        public void FillCliente()
        {
            //this.idClienteCB.Items.Clear();
            this.idClienteCB.DisplayMember = "nome";
            this.idClienteCB.ValueMember = "id";
            this.idClienteCB.DataSource = Library.ClienteBD.FindAdvanced(new QItem("ORDER BY", "c.nome"));
            //this.idClienteCB.Items.AddRange(Library.ClienteBD.FindAdvanced());
        }
        public void FillFuncionario()
        {
            //this.funcionarioCB.Items.Clear();
            this.funcionarioCB.DisplayMember = "nome";
            this.funcionarioCB.ValueMember = "id";
            this.funcionarioCB.DataSource = Library.FuncionarioBD.FindAdvanced(new QItem("ORDER BY", "f.nome"));
            //this.funcionarioCB.Items.AddRange(Library.FuncionarioBD.FindAdvanced());
        }
        public void FillProduto()
        {
            produtos1.FillProduto();
        }

        private void ShowValues()
        {
            this.codigoTB.Text = string.Format("{0}", Library.CondicionalBD.GetNextId());
            this.funcionarioCB.SelectedIndex = -1;
            this.dataTB.Text = string.Format("{0}", DateTime.Now);

            /*this.produtoCodigoSistemaTB.Text = "";
            this.produtoCodigoBarraTB.Text = "";
            this.produtoNomeCB.SelectedIndex = -1;*/

            this.idClienteTB.Text = "";
            this.idClienteCB.SelectedIndex = -1;

            this.valorTotalTextBox.Text = "";
        }


        private Library.Condicional ReturnCondicionalFromForm()
        {
            this.condicional = new Library.Condicional();

            this.condicional.Id = long.Parse(this.codigoTB.Text);

            Library.Cliente cliente = (Library.Cliente)this.idClienteCB.SelectedItem;
            if (cliente.Id == long.Parse(this.idClienteTB.Text))
            {
                this.condicional.Cliente = Library.ClienteBD.FindById(long.Parse(this.idClienteTB.Text));
            }
            else
            {
                this.condicional.Cliente = null;
            }

            this.condicional.Funcionario = (Library.Funcionario)this.funcionarioCB.SelectedItem;

            this.condicional.Data = DateTime.Parse(this.dataTB.Text);
            this.condicional.Valor = this.valorTotalTextBox.Text.ConvertToDecimal();

            return condicional;
        }
        private List<Library.CondicionalProduto> ReturnCondicionalProdutoFromForm(long idCondicionalAtual)
        {
            try
            {
                List<Library.CondicionalProduto> condicionalProdutoArray = new List<Library.CondicionalProduto>();

                foreach (Library.Classes.QItemProduto p in this.produtos1.produtos)
                {
                    Library.CondicionalProduto CondicionalProduto = new Library.CondicionalProduto();
                    CondicionalProduto.Condicional = Library.CondicionalBD.FindById(idCondicionalAtual);
                    CondicionalProduto.Produto = p.Produto;
                    CondicionalProduto.Quantidade = p.Quantidade;
                    CondicionalProduto.Preco = p.PrecoTotal;
                    CondicionalProduto.PrecoTotal = p.PrecoTotal;

                    condicionalProdutoArray.Add(CondicionalProduto);
                }
                return condicionalProdutoArray;

            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            return null;
        }




        // //////FUNÇÕES DE VALIDAÇÕS
        private void funcionarioCB_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateFuncionario();
        }
        private void idClienteTB_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateIdCliente();
        }
        private void idClienteCB_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateIdCliente();
        }

        private bool ValidateFuncionario()
        {
            if (this.funcionarioCB.SelectedIndex == -1)
            {
                this.errorProvider.SetError(this.funcionarioButton, this.foCondicionalValidateFuncionario);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.funcionarioButton, "");
            }
            return true;
        }
        private bool ValidateIdCliente()
        {
            long tmpIdCliente = 0;
            long.TryParse(this.idClienteTB.Text, out tmpIdCliente);

            if (tmpIdCliente == 0 & this.idClienteCB.SelectedIndex == -1)
            {
                this.errorProvider.SetError(this.clienteButton, this.foCondicionalValidateCliente);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.clienteButton, "");
            }
            return true;
        }

        private bool ValidateForm()
        {
            bool bValidIdCliente = this.ValidateIdCliente();
            bool bValidFuncionario = this.ValidateFuncionario();
            bool bValidProdutos = this.produtos1.Validar();

            if (bValidIdCliente & bValidFuncionario & bValidProdutos)
            {
                salvarButton.BackColor = System.Drawing.SystemColors.Control;
                salvarButton.UseVisualStyleBackColor = true;
                return true;
            }
            salvarButton.BackColor = Color.FromArgb(222, 143, 141);
            return false;
        }
    }
}
