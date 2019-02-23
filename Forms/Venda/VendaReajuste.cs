using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Library.Converter;
using Library.Classes;


namespace Forms.Venda
{
    public partial class VendaReajuste : Form
    {
        private Library.Venda venda;

        private Forms.FormaPagamento formaPagamento;

        public Library.Condicional condicional { set; get; }



        public VendaReajuste()
        {
            InitializeComponent();
        }


        // //////FUNÇÕES DE EVENTOS
        private void Venda_Load(object sender, EventArgs e)
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
                {
                    this.idClienteTB.Text = string.Format("{0}", cliente.Id);
                }
                else
                {
                    this.idClienteTB.Text = "";
                }



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

        private void idClienteTB_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                long t = 0;
                long.TryParse(this.idClienteTB.Text, out t);
                Library.Cliente cliente = Library.ClienteBD.FindById(t);

                if (cliente != null)
                {
                    PerformLimiteCliente(cliente);
                }
                else
                {

                    textBoxLimiteVendaAPrazo.Text = "";
                    textBoxStatusVendaAPrazo.Text = "";

                    textBoxStatusVendaAPrazo.BackColor = DefaultBackColor;
                    textBoxLimiteVendaAPrazo.BackColor = DefaultBackColor;
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
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
                    if (ValidadePrecoVenda())
                    {
                        //instanciando nova forma de pagamento e definindo seu valor
                        formaPagamento = new Forms.FormaPagamento();

                        Library.Cliente cliente = (Library.Cliente)this.idClienteCB.SelectedItem;
                        if (cliente.AptoVendaAPrazo == 1)
                            formaPagamento.aptoAPrazo = true;
                        else
                            formaPagamento.aptoAPrazo = false;
                        formaPagamento.diaPagamento = cliente.VencimentoVendaAPrazo;

                        formaPagamento.ValorTotal = this.valorTotalTextBox.Text.ConvertToDecimal();
                        formaPagamento.ValorTotalAVista = this.produtos1.ValorProdutosAVista;
                        //mostrando texto na toolbar
                        this.toolbarStatusTSSL.Text = this.fvVendaToolbarAbrindoFormaPagamento;
                        //abrindo forma de pagamento
                        formaPagamento.ShowDialog(this);
                        //se confirnada forma de pagamento
                        if (formaPagamento.DialogResult == DialogResult.OK)
                        {
                            //mostrando texto na toolbar
                            this.toolbarStatusTSSL.Text = this.fvVendaToolbarSalvandoVenda;
                            //salvando venda
                            this.venda = this.ReturnVendaFromForm();
                            this.venda.Pago = 0;
                            this.venda.FormaPagamento = "";
                            this.venda.Entrada = formaPagamento.Entrada;
                            Library.VendaBD.Save(this.venda);

                            //mostrando texto na toolbar
                            this.toolbarStatusTSSL.Text = this.fvVendaToolbarSalvandoProdutos;
                            //salvando produtos
                            foreach (Library.VendaProduto a in ReturnVendaProdutoFromForm(long.Parse(this.codigoTB.Text)))
                            {
                                Library.VendaProdutoBD.Save(a);

                                Library.Produto produtoTMP = a.Produto;
                                produtoTMP.Estoque -= (double)a.Quantidade;
                                produtoTMP.Vendido += (double)a.Quantidade;
                                Library.ProdutoBD.Update(produtoTMP);
                            }

                            //instanciando e definindo valores de uma transação
                            Library.CaixaTransacao caixaTransacao = new Library.CaixaTransacao();
                            caixaTransacao.Venda = this.venda;
                            caixaTransacao.Caixa = Library.CaixaBD.GetCaixaToday();
                            caixaTransacao.Hora = TimeSpan.Parse(this.venda.Data.GetValueOrDefault().ToShortTimeString());
                            caixaTransacao.Tipo = "Venda";
                            caixaTransacao.Valor = (decimal)this.venda.Valor;

                            //coletando a forma de pagamento
                            switch (formaPagamento.Forma)
                            {
                                case "avista":
                                    //atualisando venda
                                    this.venda.FormaPagamento = "avista";
                                    this.venda.Pago = 1;
                                    this.venda.Valor = formaPagamento.ValorTotalTextBox;
                                    Library.VendaBD.Update(this.venda);
                                    //salvando transacao

                                    caixaTransacao.Valor = this.venda.Valor;
                                    Library.CaixaTransacaoBD.Save(caixaTransacao);

                                    break;
                                case "aprazo":
                                    //atualisando venda
                                    this.venda.FormaPagamento = "aprazo";
                                    Library.VendaBD.Update(this.venda);

                                    //mostrando texto na toolbar
                                    this.toolbarStatusTSSL.Text = this.fvVendaToolbarSalvandoParcelas;
                                    //salvando parcelas
                                    foreach (Library.VendaParcela a in this.ReturnVendaParcela(formaPagamento.ParcelasDGV, long.Parse(this.codigoTB.Text)))
                                    {
                                        Library.VendaParcelaBD.Save(a);
                                    }

                                    //salvando transacao
                                    if (formaPagamento.Entrada != 0)
                                    {
                                        caixaTransacao.Valor = formaPagamento.Entrada;
                                        Library.CaixaTransacaoBD.Save(caixaTransacao);
                                    }
                                    break;
                                case "cartao":
                                    //atualisando venda
                                    this.venda.FormaPagamento = "cartao";
                                    //this.venda.Pago = 1;
                                    Library.VendaBD.Update(this.venda);


                                    Library.Cartao cartao = new Library.Cartao();
                                    //cartao.Servico = Library.ServicoBD.FindServicoById(idServicoAtual);
                                    cartao.Venda = this.venda;
                                    cartao.Data = this.venda.Data.GetValueOrDefault(DateTime.MinValue);
                                    cartao.Tipo = formaPagamento.CartaoTipo;
                                    cartao.Valor = this.venda.Valor - formaPagamento.Entrada;
                                    cartao.Parcelas = formaPagamento.Quantidade;
                                    Library.CartaoBD.Save(cartao);


                                    //salvando transacao
                                    if (formaPagamento.Entrada != 0)
                                    {
                                        caixaTransacao.Valor = formaPagamento.Entrada;
                                        Library.CaixaTransacaoBD.Save(caixaTransacao);
                                    }

                                    break;
                                case "cheque":
                                    //atualisando venda
                                    this.venda.FormaPagamento = "cheque";
                                    Library.VendaBD.Update(this.venda);

                                    //mostrando texto na toolbar
                                    this.toolbarStatusTSSL.Text = this.fvVendaToolbarSalvandoParcelas;
                                    //salvando parcelas
                                    foreach (Library.Cheque a in this.ReturnCheque(formaPagamento.ParcelasDGV, long.Parse(this.codigoTB.Text)))
                                    {
                                        Library.ChequeBD.Save(a);
                                    }

                                    //salvando transacao
                                    if (formaPagamento.Entrada != 0)
                                    {
                                        caixaTransacao.Valor = formaPagamento.Entrada;
                                        Library.CaixaTransacaoBD.Save(caixaTransacao);
                                    }
                                    break;
                            }
                            //*************************************
                            // COMISSÂO
                            //

                            if (this.venda.Funcionario.Comissao == 1)
                            {
                                Library.Comissao comissao = new Library.Comissao();
                                comissao.Funcionario = venda.Funcionario;
                                comissao.Venda = venda;
                                comissao.Tipo = "Venda";
                                comissao.Pago = 0;

                                decimal valor = 0;
                                decimal comissaoPadrao = venda.Funcionario.ComissaoVenda;
                                if (comissaoPadrao != 0)
                                {
                                    valor = (decimal)(venda.Valor * (comissaoPadrao / 100));
                                    comissao.Porcentagem = venda.Funcionario.ComissaoVenda;


                                    comissao.Valor = (decimal)valor;

                                    Library.ComissaoBD.Save(comissao);
                                }
                            }



                            //
                            // END COMISSÂO
                            //*************************************

                            //vai imprimir?
                            if (MessageBox.Show(this.fvVendaImprimirMsg, this.fvVendaImprimirMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                this.toolbarStatusTSSL.Text = "Imprimindo";
                                //print = new Library.Windows.Forms.Print(Library.Classes.Print.PrintVenda(this.venda), "Venda");
                                //print.ShowDialog(this);
                                //notav = new Reports.nota_venda();
                                //notav.Venda = this.venda;
                                //notav.ShowDialog(this);
                                Library.Classes.Print.PrintVenda(this.venda);
                            }


                            //limpando produtos
                            this.produtos1.Clear();
                            //limpando form
                            this.RefreshForm();
                            //atualizar forms externos
                            this.RefreshChilds();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {

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
            //this.dataTB.Text = DateTime.Now.ToString();
        }

        private void Venda_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            switch (e.KeyCode)
            {
                case Keys.F8:
                    this.funcionarioCB.Focus();
                    break;
                case Keys.F12:
                    this.idClienteCB.Focus();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }

            this.Cursor = Cursors.Default;
        }

        private void Venda_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }


        // //////FUNÇÕES DE VALIDAÇÕS
        private void funcionarioCB_Validating(object sender, CancelEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.ValidateFuncionario();
            this.Cursor = Cursors.Default;
        }

        private void idClienteTB_Validating(object sender, CancelEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.ValidateIdCliente();
            this.Cursor = Cursors.Default;
        }

        private void idClienteCB_Validating(object sender, CancelEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.ValidateIdCliente();
            this.Cursor = Cursors.Default;
        }

        /*************************************************/
        string fvVendaToolbarAbrindoFormaPagamento = "Abrindo Forma de Pagamento";
        string fvVendaToolbarSalvandoVenda = "Salvando Venda";
        string fvVendaToolbarSalvandoProdutos = "Salvando Produtos";
        string fvVendaToolbarSalvandoParcelas = "Salvando Parcelas";
        string fvVendaToolbarNovaVenda = "Nova venda código: {0}";

        string fvVendaImprimirMsg = "Deseja imprimir esta venda?";
        string fvVendaImprimirMsgTitle = "Imprimir";

        string fvVendaValidateFuncionario = "Por favor informe o funcionário!";
        string fvVendaValidateCliente = "Por favor informe o cliente!";
        /*************************************************/



        private void RefreshForm()
        {
            try
            {
                this.FillCliente();
                this.FillFuncionario();

                this.ShowValues();

                if (this.condicional != null)
                {
                    this.ShowCondicional(this.condicional);
                    this.Refresh();
                }

                this.toolbarStatusTSSL.Text = string.Format(this.fvVendaToolbarNovaVenda, this.codigoTB.Text);
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
        }

        private decimal PerformLimiteCliente(Library.Cliente cliente)
        {

            textBoxLimiteVendaAPrazo.Text = "0";

            decimal limite = cliente.LimiteVendaAPrazo;
            decimal dividas = Library.ClienteBD.GetParcelasAtrasadasValorById(cliente.Id);
            decimal novoLimite = limite - dividas - this.produtos1.ValorProdutos;

            if (cliente.AptoVendaAPrazo == 0)
            {
                textBoxStatusVendaAPrazo.Text = "Negada";
                textBoxStatusVendaAPrazo.BackColor = Color.FromArgb(250, 200, 187);
                textBoxLimiteVendaAPrazo.BackColor = Color.FromArgb(250, 200, 187);
                return 0;
            }
            else
            {
                if (novoLimite <= 0)
                {
                    textBoxStatusVendaAPrazo.Text = "Sem limite";
                    textBoxStatusVendaAPrazo.BackColor = Color.FromArgb(250, 200, 187);
                    textBoxLimiteVendaAPrazo.BackColor = Color.FromArgb(250, 200, 187);
                    return 0;
                }
                else
                {
                    textBoxLimiteVendaAPrazo.Text = novoLimite.ConvertToMoneyString();
                    textBoxStatusVendaAPrazo.Text = "Aprovado";
                    textBoxStatusVendaAPrazo.BackColor = Color.FromArgb(200, 240, 180);
                    textBoxLimiteVendaAPrazo.BackColor = Color.FromArgb(200, 240, 180);
                    return novoLimite;
                }
            }
        }

        public void FillCliente()
        {
            this.idClienteCB.DisplayMember = "nome";
            this.idClienteCB.ValueMember = "id";
            this.idClienteCB.DataSource = Library.ClienteBD.FindAdvanced(new QItem("ORDER BY", "c.nome"));
        }

        public void FillFuncionario()
        {
            this.funcionarioCB.DisplayMember = "nome";
            this.funcionarioCB.ValueMember = "id";
            this.funcionarioCB.DataSource = Library.FuncionarioBD.FindAdvanced(new QItem("ORDER BY", "f.nome"));
        }

        public void FillProduto()
        {
            produtos1.FillProduto();
        }

        private void ShowValues()
        {
            this.codigoTB.Text = string.Format("{0}", Library.VendaBD.GetNextId());
            this.funcionarioCB.SelectedIndex = -1;
            this.dataTB.Text = string.Format("{0}", DateTime.Now);

            this.idClienteTB.Text = "";
            this.idClienteCB.SelectedIndex = -1;


            this.valorTotalTextBox.Text = "";
        }

        private Library.Venda ReturnVendaFromForm()
        {
            this.venda = new Library.Venda();

            this.venda.Id = long.Parse(this.codigoTB.Text);

            Library.Cliente clientetmp = (Library.Cliente)this.idClienteCB.SelectedItem;
            if (clientetmp.Id == long.Parse(this.idClienteTB.Text))
            {
                this.venda.Cliente = clientetmp;
            }
            else
            {
                this.venda.Cliente = null;
            }

            this.venda.Funcionario = (Library.Funcionario)this.funcionarioCB.SelectedItem;

            this.venda.Data = DateTime.Parse(this.dataTB.Text);
            this.venda.Valor = this.valorTotalTextBox.Text.ConvertToDecimal();

            return venda;
        }

        private List<Library.VendaProduto> ReturnVendaProdutoFromForm(long idVendaAtual)
        {
            try
            {
                List<Library.VendaProduto> vendaProdutoArray = new List<Library.VendaProduto>();

                foreach (Library.Classes.QItemProduto p in this.produtos1.produtos)
                {
                    Library.VendaProduto VendaProduto = new Library.VendaProduto();
                    VendaProduto.Venda = Library.VendaBD.FindById(idVendaAtual);
                    VendaProduto.Produto = p.Produto;
                    VendaProduto.Quantidade = p.Quantidade;
                    VendaProduto.Preco = p.PrecoTotal;
                    VendaProduto.PrecoTotal = p.PrecoTotal;

                    vendaProdutoArray.Add(VendaProduto);
                }
                return vendaProdutoArray;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            return null;
        }

        private Library.VendaParcela[] ReturnVendaParcela(DataGridView dataGrid, long idVendaAtual)
        {
            try
            {
                int vendaParcelaCount = dataGrid.Rows.Count;

                Library.VendaParcela[] vendaParcelaArray = new Library.VendaParcela[vendaParcelaCount];

                for (int i = 0; i < vendaParcelaCount; i++)
                {
                    vendaParcelaArray[i] = new Library.VendaParcela();
                    vendaParcelaArray[i].Venda = Library.VendaBD.FindById(idVendaAtual);
                    vendaParcelaArray[i].Vencimento = DateTime.Parse(dataGrid.Rows[i].Cells[1].Value.ToString());
                    vendaParcelaArray[i].Pagamento = DateTime.MinValue;
                    vendaParcelaArray[i].Pago = 0;
                    vendaParcelaArray[i].Valor = (decimal)dataGrid.Rows[i].Cells[0].Value;
                    vendaParcelaArray[i].ValorPago = 0;
                }
                return vendaParcelaArray;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            return null;
        }

        private Library.Cheque[] ReturnCheque(DataGridView dataGrid, long idVendaAtual)
        {
            try
            {
                int chequeCount = dataGrid.Rows.Count;

                Library.Cheque[] chequeArray = new Library.Cheque[chequeCount];

                for (int i = 0; i < chequeCount; i++)
                {
                    chequeArray[i] = new Library.Cheque();
                    chequeArray[i].Venda = Library.VendaBD.FindById(idVendaAtual);
                    chequeArray[i].Data = DateTime.Parse(dataGrid.Rows[i].Cells[2].Value.ToString());
                    chequeArray[i].Numero = dataGrid.Rows[i].Cells[0].Value.ToString();
                    chequeArray[i].Valor = (decimal)dataGrid.Rows[i].Cells[1].Value;
                }
                return chequeArray;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            return null;
        }

        private Library.Cartao[] ReturnCartao(DataGridView dataGrid, long idVendaAtual)
        {
            try
            {
                int cartaoCount = dataGrid.Rows.Count;

                Library.Cartao[] cartaoArray = new Library.Cartao[cartaoCount];

                for (int i = 0; i < cartaoCount; i++)
                {
                    cartaoArray[i] = new Library.Cartao();
                    cartaoArray[i].Venda = Library.VendaBD.FindById(idVendaAtual);
                    cartaoArray[i].Data = DateTime.Parse(dataGrid.Rows[i].Cells[1].Value.ToString());
                    cartaoArray[i].Tipo = "Crédito";
                    cartaoArray[i].Valor = (decimal)dataGrid.Rows[i].Cells[0].Value;
                }
                return cartaoArray;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            return null;
        }

        public void ShowCondicional(Library.Condicional condicional)
        {
            List<Library.CondicionalProduto> CondicionalProdutos = Library.CondicionalProdutoBD.FindAdvanced(new QItem("o.id", condicional.Id));

            List<Library.Classes.QItemProduto> QItems = new List<Library.Classes.QItemProduto>();

            foreach (Library.CondicionalProduto a in CondicionalProdutos)
            {
                Library.Classes.QItemProduto QItem = new Library.Classes.QItemProduto(a.Produto, (int)a.Quantidade, (decimal)a.Preco, (decimal)a.PrecoTotal);
                QItems.Add(QItem);
            }

            produtos1.produtos = QItems;

            int fi = 0;
            foreach (Library.Funcionario f in funcionarioCB.Items)
            {
                if (f.Id == condicional.Funcionario.Id)
                {
                    funcionarioCB.SelectedIndex = fi;
                    break;
                }
                fi++;
            }

            int ci = 0;
            foreach (Library.Cliente c in idClienteCB.Items)
            {
                if (c.Id == condicional.Cliente.Id)
                {
                    idClienteCB.SelectedIndex = ci;
                    break;
                }
                ci++;
            }
        }

        private bool ValidateFuncionario()
        {
            if (this.funcionarioCB.SelectedIndex == -1)
            {
                this.errorProvider.SetError(this.funcionarioButton, this.fvVendaValidateFuncionario);
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
                this.errorProvider.SetError(this.clienteButton, this.fvVendaValidateCliente);
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


        private bool ValidadePrecoVenda()
        {
            foreach (Library.Classes.QItemProduto qp in this.produtos1.produtos)
            {
                if (qp.PrecoTotal == 0)
                {
                    if (MessageBox.Show("Esta venda tem um produto com valor total de R$ 0,00, deseja salva-la assim mesmo?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        return true;
                    else
                        return false;
                }
            }

            if (this.valorTotalTextBox.Text.ConvertToDecimal() <= 0)
            {
                if (MessageBox.Show("Esta venda tem um valor total de R$ 0,00, deseja salva-la assim mesmo?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            return true;
        }
    }
}
