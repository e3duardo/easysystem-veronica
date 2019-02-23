using System.Collections.Generic;
using System.Text;
using System;
using Library.Converter;
using System.Windows.Forms;
using Bematech.MiniImpressoras;
using Bematech.Texto;

namespace Library.Classes
{
    public class Print
    {

        static public void PrintCondicional(Library.Condicional condicional)
        {

            Library.Configuracoes config = Library.ConfiguracoesBD.FindById(1);
            if (config.Impressora == "bematech")
                PrintBematechCondicional(condicional, config);
            else
                PrintOutrasCondicional(condicional, config);
        }

        static public void PrintVenda(Library.Venda venda)
        {
            Library.Configuracoes config = Library.ConfiguracoesBD.FindById(1);
            if (config.Impressora == "bematech")
                PrintBematechVenda(venda, config);
            else
                PrintOutrasVenda(venda, config);
        }

        static public void PrintCaixa(Library.Caixa caixa)
        {
            Library.Configuracoes config = Library.ConfiguracoesBD.FindById(1);
            if (config.Impressora == "bematech")
                PrintBematechCaixa(caixa, config);
            else
                PrintOutrasCaixa(caixa, config);
        }

        static public void PrintParcela(Library.VendaParcela parcela)
        {
            Library.Configuracoes config = Library.ConfiguracoesBD.FindById(1);
            if (config.Impressora == "bematech")
                PrintBematechParcela(parcela, config);
            else
                PrintOutrasParcela(parcela, config);
        }


        //impressora bematech:::
        static public void PrintBematechCondicional(Library.Condicional condicional, Library.Configuracoes config)
        {
            try
            {
                //variaveis
                string tot = condicional.Valor.ConvertToMoneyString();
                decimal produtostotal = 0;
                int i = 0;
                List<Library.CondicionalProduto> condicionalProdutos = Library.CondicionalProdutoBD.FindAdvanced(new Library.Classes.QItem("v.id", condicional.Id));


                //funcao
                ImpressoraNaoFiscal inf = new ImpressoraNaoFiscal();
                inf.Modelo = Bematech.ModeloImpressoraNaoFiscal.MP20MI;
                inf.NomePorta = config.ImpressoraPorta;

                bool status = inf.LerStatus().OffLine;
                while (status)
                {
                    if (MessageBox.Show("Impressora OffLine! Deseja tentar novamente?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        status = inf.LerStatus().OffLine;
                    else
                        return;
                }

                TextoFormatado linha1 = new TextoFormatado("JEANE MODAS" + "\r\n", TextoFormatado.TamanhoCaracter.Elite, TextoFormatado.FormatoCaracter.Expandido, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linha2 = new TextoFormatado("Av. Nilo Peçanha, 688" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linha3 = new TextoFormatado("(22) 3852-6784 / 9873-2552" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linha4 = new TextoFormatado("Condicional" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Negrito, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linha5 = new TextoFormatado("N.: " + condicional.Id + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);
                TextoFormatado linha6 = new TextoFormatado(DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToShortTimeString() + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);
                TextoFormatado linhaTotal1 = new TextoFormatado("TOTAl: " + tot + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Direita);
                TextoFormatado linhaPagamento1 = new TextoFormatado("Volte Sempre!" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linhaCliente1 = new TextoFormatado(condicional.Cliente.Nome + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);
                TextoFormatado linhaCliente5 = new TextoFormatado("ASSINATURA" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linhaLinha = new TextoFormatado("------------------------------------------------" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Direita);
                TextoFormatado linhaBranca = new TextoFormatado("" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);


                inf.Imprimir(linha1);
                inf.Imprimir(linha2);
                inf.Imprimir(linha3);
                inf.Imprimir(linha4);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linha5);
                inf.Imprimir(linha6);
                inf.Imprimir(linhaLinha);

                foreach (Library.CondicionalProduto vp in condicionalProdutos)
                {
                    string quantidade = vp.Quantidade.ToString();
                    string nome = vp.Produto.Nome;
                    string preco = vp.PrecoTotal.Value.ConvertToMoneyString();

                    string texto = "  " + quantidade.PadRight(5 - quantidade.Length, ' ');
                    texto += nome.PadRight(47 - quantidade.Length - nome.Length - preco.Length, ' ');
                    texto += preco + "\r\n";

                    inf.Imprimir(texto);

                    produtostotal += vp.PrecoTotal.Value;
                    i++;
                }

                inf.Imprimir(linhaBranca);

                inf.Imprimir(linhaTotal1);
                inf.Imprimir(linhaLinha);
                inf.Imprimir(linhaPagamento1);

                inf.Imprimir(linhaBranca);

                inf.Imprimir(linhaCliente1);

                if (condicional.Cliente.Cpf != "")
                {
                    TextoFormatado linhaCliente2 = new TextoFormatado("CPF: " + condicional.Cliente.Cpf + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);
                    inf.Imprimir(linhaBranca);
                }
                if (condicional.Cliente.Endereco != "")
                {
                    TextoFormatado linhaCliente3 = new TextoFormatado(condicional.Cliente.Endereco + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);
                    inf.Imprimir(linhaBranca);
                }
                if (condicional.Cliente.Cidade != "")
                {
                    TextoFormatado linhaCliente4 = new TextoFormatado(condicional.Cliente.Cidade + "-" + condicional.Cliente.Estado + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);
                    inf.Imprimir(linhaBranca);
                }
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaLinha);
                inf.Imprimir(linhaCliente5);

                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        static public void PrintBematechVenda(Library.Venda venda, Library.Configuracoes config)
        {
            try
            {
                ImpressoraNaoFiscal inf = new ImpressoraNaoFiscal();
                inf.Modelo = Bematech.ModeloImpressoraNaoFiscal.MP20MI;
                inf.NomePorta = config.ImpressoraPorta;

                bool status = inf.LerStatus().OffLine;
                while (status)
                {
                    if (MessageBox.Show("Impressora OffLine! Deseja tentar novamente?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        status = inf.LerStatus().OffLine;
                    else
                        return;
                }

                TextoFormatado linha1 = new TextoFormatado("JEANE MODAS" + "\r\n", TextoFormatado.TamanhoCaracter.Elite, TextoFormatado.FormatoCaracter.Expandido, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linha2 = new TextoFormatado("Av. Nilo Peçanha, 688" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linha3 = new TextoFormatado("(22) 3852-6784 / 9873-2552" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linha4 = new TextoFormatado("Venda" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Negrito, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linha5 = new TextoFormatado("N.: " + venda.Id + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);
                TextoFormatado linha6 = new TextoFormatado(DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToShortTimeString() + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);
                TextoFormatado linhaLinha = new TextoFormatado("------------------------------------------------" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Direita);
                TextoFormatado linhaBranca = new TextoFormatado("" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);


                List<Library.VendaProduto> vendaProdutos = Library.VendaProdutoBD.FindAdvanced(new Library.Classes.QItem("v.id", venda.Id));
                decimal produtostotal = 0;

                inf.Imprimir(linha1);
                inf.Imprimir(linha2);
                inf.Imprimir(linha3);
                inf.Imprimir(linha4);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linha5);
                inf.Imprimir(linha6);
                inf.Imprimir(linhaLinha);

                foreach (Library.VendaProduto vp in vendaProdutos)
                {
                    string quantidade = vp.Quantidade.ToString();
                    string nome = vp.Produto.Nome;
                    string preco = vp.PrecoTotal.Value.ConvertToMoneyString();

                    string texto = "  " + quantidade.PadRight(5 - quantidade.Length, ' ');
                    texto += nome.PadRight(47 - quantidade.Length - nome.Length - preco.Length, ' ');
                    texto += preco + "\r\n";

                    inf.Imprimir(texto);

                    produtostotal += vp.PrecoTotal.Value;
                }

                inf.Imprimir(linhaBranca);

                string tot = venda.Valor.ConvertToMoneyString();

                if (venda.FormaPagamento == "avista")
                {
                    string tota = produtostotal.ConvertToMoneyString();
                    TextoFormatado linhaTotal1 = new TextoFormatado("TOTAl: " + tota + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Direita);
                    TextoFormatado linhaTotal2 = new TextoFormatado("TOTAl FINAL: " + tot + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Direita);


                    TextoFormatado linhaPagamento1 = new TextoFormatado("Pagamento a vista" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);
                    TextoFormatado linhaPagamento2 = new TextoFormatado("Volte Sempre!" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);


                    inf.Imprimir(linhaTotal1);
                    inf.Imprimir(linhaTotal2);
                    inf.Imprimir(linhaLinha);
                    inf.Imprimir(linhaPagamento1);
                    inf.Imprimir(linhaPagamento2);
                }
                else if (venda.FormaPagamento == "aprazo")
                {
                    string entrada = venda.Entrada.ConvertToMoneyString();
                    TextoFormatado linhaTotal1 = new TextoFormatado("TOTAl: " + tot + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Direita);
                    TextoFormatado linhaEntrada = new TextoFormatado("Entrada: " + entrada + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Direita);

                    TextoFormatado linhaPagamento1 = new TextoFormatado("Pagamento a prazo" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);
                    TextoFormatado linhaPagamento2 = new TextoFormatado("Volte Sempre!" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);


                    inf.Imprimir(linhaTotal1);
                    inf.Imprimir(linhaLinha);
                    inf.Imprimir(linhaEntrada);

                    decimal j = 1;
                    foreach (Library.VendaParcela vp in Library.VendaParcelaBD.FindAdvanced(new QItem("v.id", venda.Id)))
                    {
                        string preco = vp.Valor.Value.ConvertToMoneyString();
                        TextoFormatado linhaParcela1 = new TextoFormatado("Parcela " + j + " " + vp.Vencimento.Value.ToString("dd/MM/yyyy") + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);
                        TextoFormatado linhaParcela2 = new TextoFormatado(preco + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Direita);

                        inf.Imprimir(linhaParcela1);
                        inf.Imprimir(linhaParcela2);
                        j++;
                    }

                    inf.Imprimir(linhaLinha);
                    inf.Imprimir(linhaPagamento1);
                    inf.Imprimir(linhaPagamento2);
                }
                else if (venda.FormaPagamento == "cheque")
                {
                    TextoFormatado linhaTotal1 = new TextoFormatado("TOTAl: " + tot + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Direita);

                    TextoFormatado linhaPagamento1 = new TextoFormatado("Pagamento em cheque" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);
                    TextoFormatado linhaPagamento2 = new TextoFormatado("Volte Sempre!" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);

                    inf.Imprimir(linhaTotal1);
                    inf.Imprimir(linhaLinha);
                    inf.Imprimir(linhaPagamento1);
                    inf.Imprimir(linhaPagamento2);
                }
                else if (venda.FormaPagamento == "cartao")
                {
                    TextoFormatado linhaTotal1 = new TextoFormatado("TOTAl: " + tot + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Direita);

                    TextoFormatado linhaPagamento1 = new TextoFormatado("Pagamento em cartão" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);
                    TextoFormatado linhaPagamento2 = new TextoFormatado("Volte Sempre!" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);

                    inf.Imprimir(linhaTotal1);
                    inf.Imprimir(linhaLinha);
                    inf.Imprimir(linhaPagamento1);
                    inf.Imprimir(linhaPagamento2);
                }
                else
                {
                    TextoFormatado linhaTotal1 = new TextoFormatado("TOTAl: " + tot + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Direita);
                    TextoFormatado linhaPagamento1 = new TextoFormatado("Volte Sempre!" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);

                    inf.Imprimir(linhaTotal1);
                    inf.Imprimir(linhaLinha);
                    inf.Imprimir(linhaPagamento1);
                }

                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        static public void PrintBematechCaixa(Library.Caixa caixa, Library.Configuracoes config)
        {
            try
            {
                ImpressoraNaoFiscal inf = new ImpressoraNaoFiscal();
                inf.Modelo = Bematech.ModeloImpressoraNaoFiscal.MP20MI;
                inf.NomePorta = config.ImpressoraPorta;

                bool status = inf.LerStatus().OffLine;
                while (status)
                {
                    if (MessageBox.Show("Impressora OffLine! Deseja tentar novamente?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        status = inf.LerStatus().OffLine;
                    else
                        return;
                }

                TextoFormatado linhaLinha = new TextoFormatado("------------------------------------------------" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Direita);
                TextoFormatado linhaBranca = new TextoFormatado("" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);


                decimal vendaavista = 0;
                decimal vendaaprazo = 0;
                decimal despesas = 0;
                decimal outrasOperacoes = 0;

                List<Library.CaixaTransacao> transacoes = Library.CaixaTransacaoBD.FindAdvanced(new QItem("ct.idCaixa", caixa.Id));

                foreach (Library.CaixaTransacao ct in transacoes)
                {
                    if (ct.Despesa != null)
                        despesas += ct.Valor;
                    else if (ct.Venda != null)
                    {
                        if (ct.VendaParcela == null)
                            vendaavista += ct.Valor;
                        else
                            vendaaprazo += ct.Valor;
                    }
                    else
                        outrasOperacoes += ct.Valor;
                }


                TextoFormatado linha1 = new TextoFormatado("CAIXA " + caixa.Data.Value.ToShortDateString() + "\r\n", TextoFormatado.TamanhoCaracter.Elite, TextoFormatado.FormatoCaracter.Expandido, TextoFormatado.TipoAlinhamento.Esquerda);
                inf.Imprimir(linha1);
                inf.Imprimir(linhaBranca);

                if (vendaavista > 0)
                {
                    TextoFormatado linha2 = new TextoFormatado("Vendas a vista: " + vendaavista.ConvertToMoneyString() + "\r\n", TextoFormatado.TamanhoCaracter.Elite, TextoFormatado.FormatoCaracter.Expandido, TextoFormatado.TipoAlinhamento.Direita);
                    inf.Imprimir(linhaBranca);
                }
                if (vendaaprazo > 0)
                {
                    TextoFormatado linha2 = new TextoFormatado("Vendas a prazo: " + vendaaprazo.ConvertToMoneyString() + "\r\n", TextoFormatado.TamanhoCaracter.Elite, TextoFormatado.FormatoCaracter.Expandido, TextoFormatado.TipoAlinhamento.Direita);
                    inf.Imprimir(linhaBranca);
                }
                if (despesas > 0)
                {
                    TextoFormatado linha2 = new TextoFormatado("Despesas: " + despesas.ConvertToMoneyString() + "\r\n", TextoFormatado.TamanhoCaracter.Elite, TextoFormatado.FormatoCaracter.Expandido, TextoFormatado.TipoAlinhamento.Direita);
                    inf.Imprimir(linhaBranca);
                }
                if (outrasOperacoes > 0)
                {
                    TextoFormatado linha2 = new TextoFormatado("Outras operacoes: " + outrasOperacoes.ConvertToMoneyString() + "\r\n", TextoFormatado.TamanhoCaracter.Elite, TextoFormatado.FormatoCaracter.Expandido, TextoFormatado.TipoAlinhamento.Direita);
                    inf.Imprimir(linhaBranca);
                }

                TextoFormatado linha3 = new TextoFormatado("TOTAL: " + caixa.Saldo.ConvertToMoneyString() + "\r\n", TextoFormatado.TamanhoCaracter.Elite, TextoFormatado.FormatoCaracter.Expandido, TextoFormatado.TipoAlinhamento.Direita);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linha3);

                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        static public void PrintBematechParcela(Library.VendaParcela parcela, Library.Configuracoes config)
        {
            try
            {
                ImpressoraNaoFiscal inf = new ImpressoraNaoFiscal();
                inf.Modelo = Bematech.ModeloImpressoraNaoFiscal.MP20MI;
                inf.NomePorta = config.ImpressoraPorta;

                bool status = inf.LerStatus().OffLine;
                while (status)
                {
                    if (MessageBox.Show("Impressora OffLine! Deseja tentar novamente?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        status = inf.LerStatus().OffLine;
                    else
                        return;
                }

                TextoFormatado linha1 = new TextoFormatado("JEANE MODAS" + "\r\n", TextoFormatado.TamanhoCaracter.Elite, TextoFormatado.FormatoCaracter.Expandido, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linha2 = new TextoFormatado("Av. Nilo Peçanha, 688" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linha3 = new TextoFormatado("(22) 3852-6784 / 9873-2552" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linha4 = new TextoFormatado("Parcela de Venda" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Negrito, TextoFormatado.TipoAlinhamento.Centralizado);
                TextoFormatado linha5 = new TextoFormatado("N. da Venda: " + parcela.Venda.Id + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);
                TextoFormatado linha6 = new TextoFormatado(DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToShortTimeString() + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);


                TextoFormatado linha7 = new TextoFormatado("Valor da Parcela: " + parcela.Valor + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);
                TextoFormatado linha8 = new TextoFormatado("Valor pago: " + parcela.ValorPago + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);
                TextoFormatado linhaLinha = new TextoFormatado("------------------------------------------------" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Direita);
                TextoFormatado linhaBranca = new TextoFormatado("" + "\r\n", TextoFormatado.TamanhoCaracter.Normal, TextoFormatado.FormatoCaracter.Normal, TextoFormatado.TipoAlinhamento.Esquerda);


                List<Library.VendaProduto> vendaProdutos = Library.VendaProdutoBD.FindAdvanced(new Library.Classes.QItem("v.id", parcela.Id));

                inf.Imprimir(linha1);
                inf.Imprimir(linha2);
                inf.Imprimir(linha3);
                inf.Imprimir(linha4);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linha5);
                inf.Imprimir(linha6);
                inf.Imprimir(linhaLinha);
                inf.Imprimir(linha7);
                if (parcela.Valor != parcela.ValorPago)
                    inf.Imprimir(linha8);


                //escape
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
                inf.Imprimir(linhaBranca);
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }



        #region outras impressoras
        //outras impressoras:::

        static public void PrintOutrasCondicional(Library.Condicional condicional, Library.Configuracoes config)
        {
            try
            {
                MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

                MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

                _Reporter.Output = config.ImpressoraPorta;

                _Reporter.StartJob();

                _Reporter.PrintText(01, 14, _EpsonCodes.ExpandedOn + "JEANE MODAS" + _EpsonCodes.ExpandedOff);
                _Reporter.PrintText(02, 06, _EpsonCodes.ItalicOn + "Av. Nilo Peçanha, 688" + _EpsonCodes.ItalicOff);
                _Reporter.PrintText(03, 10, "(22) 3852-6784 / 9873-2552");
                _Reporter.PrintText(04, 16, _EpsonCodes.CondensedOn + _EpsonCodes.ExpandedOn + _Reporter.CleanText("Condicional") + _EpsonCodes.ExpandedOff + _EpsonCodes.CondensedOff);

                _Reporter.PrintText(05, 01, "");
                _Reporter.PrintText(06, 02, _Reporter.CleanText("N.: " + condicional.Id));
                _Reporter.PrintText(07, 01, DateTime.Now.ToShortDateString());
                _Reporter.PrintText(07, 43, DateTime.Now.ToShortTimeString());

                _Reporter.PrintText(08, 01, "-----------------------------------------------");

                List<Library.CondicionalProduto> condicionalProdutos = Library.CondicionalProdutoBD.FindAdvanced(new Library.Classes.QItem("o.id", condicional.Id));

                int i = 0;
                foreach (Library.CondicionalProduto op in condicionalProdutos)
                {
                    _Reporter.PrintText(9 + i, 02, op.Quantidade.ToString());
                    _Reporter.PrintText(9 + i, 08, _Reporter.CleanText(op.Produto.Nome));
                    string preco = op.PrecoTotal.Value.ConvertToMoneyString();
                    _Reporter.PrintText(9 + i, 47 - preco.Length, preco);
                    i++;
                }

                string tota = condicional.Valor.ConvertToMoneyString();

                _Reporter.PrintText(10 + i, 25, "TOTAl: ");
                _Reporter.PrintText(10 + i, 47 - tota.Length, tota);

                _Reporter.EndJob();
                _Reporter.PrintJob();

                PrintCliente(condicional.Cliente, config);

                Library.Classes.Print.PrintSpace(config);


            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        static public void PrintOutrasVenda(Library.Venda venda, Library.Configuracoes config)
        {
            try
            {
                MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

                MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

                _Reporter.Output = config.ImpressoraPorta;

                _Reporter.StartJob();

                _Reporter.PrintText(01, 14, _EpsonCodes.ExpandedOn + "JEANE MODAS" + _EpsonCodes.ExpandedOff);
                _Reporter.PrintText(02, 06, _EpsonCodes.ItalicOn + "Av. Nilo Peçanha, 688" + _EpsonCodes.ItalicOff);
                _Reporter.PrintText(03, 12, "(22) 3852-6784 / 9873-2552");
                _Reporter.PrintText(04, 19, _EpsonCodes.CondensedOn + _EpsonCodes.ExpandedOn + _Reporter.CleanText("Venda") + _EpsonCodes.ExpandedOff + _EpsonCodes.CondensedOff);

                _Reporter.PrintText(05, 01, "");
                _Reporter.PrintText(06, 02, _Reporter.CleanText("N.: " + venda.Id));
                _Reporter.PrintText(07, 02, DateTime.Now.ToString("dd/MM/yyyy"));
                _Reporter.PrintText(07, 42, DateTime.Now.ToShortTimeString());

                _Reporter.PrintText(08, 01, "-----------------------------------------------");

                List<Library.VendaProduto> vendaProdutos = Library.VendaProdutoBD.FindAdvanced(new Library.Classes.QItem("v.id", venda.Id));

                decimal produtostotal = 0;
                int i = 0;
                foreach (Library.VendaProduto vp in vendaProdutos)
                {
                    _Reporter.PrintText(9 + i, 02, vp.Quantidade.ToString());
                    _Reporter.PrintText(9 + i, 08, _Reporter.CleanText(vp.Produto.Nome));

                    string preco = vp.PrecoTotal.Value.ConvertToMoneyString();

                    _Reporter.PrintText(9 + i, 47 - preco.Length, preco);
                    produtostotal += vp.PrecoTotal.Value;
                    i++;
                }

                if (venda.FormaPagamento == "avista")
                {
                    string tota = produtostotal.ConvertToMoneyString();
                    string tdea = venda.Valor.ConvertToMoneyString();

                    _Reporter.PrintText(10 + i, 25, "TOTAl: ");
                    _Reporter.PrintText(10 + i, 47 - tota.Length, tota);

                    _Reporter.PrintText(11 + i, 19, "TOTAl FINAL: ");
                    _Reporter.PrintText(11 + i, 47 - tdea.Length, tdea);

                    _Reporter.PrintText(12 + i, 01, "");
                }
                else if (venda.FormaPagamento == "aprazo")
                {
                    string tot = venda.Valor.ConvertToMoneyString();
                    _Reporter.PrintText(10 + i, 25, "TOTAl: ");
                    _Reporter.PrintText(10 + i, 47 - tot.Length, tot);

                    _Reporter.PrintText(11 + i, 01, "");
                    _Reporter.PrintText(12 + i, 01, "-----------------------------------------------");

                    _Reporter.PrintText(13 + i, 02, "Entrada");
                    string entrada = venda.Entrada.ConvertToMoneyString();
                    _Reporter.PrintText(13 + i, 47 - entrada.Length, entrada);

                    decimal j = 1;
                    foreach (Library.VendaParcela vp in Library.VendaParcelaBD.FindAdvanced(new QItem("v.id", venda.Id)))
                    {
                        _Reporter.PrintText(14 + i, 02, "Parcela " + j + " " + vp.Vencimento.Value.ToString("dd/MM/yyyy"));

                        string preco = vp.Valor.Value.ConvertToMoneyString();
                        _Reporter.PrintText(14 + i, 47 - preco.Length, preco);
                        i++;
                        j++;
                    }

                    _Reporter.PrintText(15 + i, 01, "-----------------------------------------------");
                }
                else
                {
                    string tot = venda.Valor.ConvertToMoneyString();
                    _Reporter.PrintText(10 + i, 25, "TOTAl: ");
                    _Reporter.PrintText(10 + i, 47 - tot.Length, tot);

                    _Reporter.PrintText(11 + i, 01, "");
                }



                _Reporter.EndJob();

                _Reporter.PrintJob();


                if (venda.FormaPagamento == "avista")
                {
                    Library.Classes.Print.PrintPagamentoAVista(config);
                }
                else if (venda.FormaPagamento == "aprazo")
                {
                    Library.Classes.Print.PrintPagamentoAPrazo(config);
                    PrintCliente(venda.Cliente, config);
                }
                else if (venda.FormaPagamento == "cartao")
                {
                    Library.Classes.Print.PrintPagamentoCartao(config);
                }
                else if (venda.FormaPagamento == "cheque")
                {
                    Library.Classes.Print.PrintPagamentoCheque(config);
                }
                Library.Classes.Print.PrintSpace(config);


            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        static public void PrintOutrasCaixa(Library.Caixa caixa, Library.Configuracoes config)
        {
            try
            {
                decimal vendaavista = 0;
                decimal vendaaprazo = 0;
                decimal despesas = 0;
                decimal outrasOperacoes = 0;

                List<Library.CaixaTransacao> transacoes = Library.CaixaTransacaoBD.FindAdvanced(new QItem("ct.idCaixa", caixa.Id));

                foreach (Library.CaixaTransacao ct in transacoes)
                {
                    if (ct.Despesa != null)
                        despesas += ct.Valor;
                    else if (ct.Venda != null)
                    {
                        if (ct.VendaParcela == null)
                            vendaavista += ct.Valor;
                        else
                            vendaaprazo += ct.Valor;
                    }
                    else
                        outrasOperacoes += ct.Valor;
                }


                MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

                MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

                _Reporter.Output = config.ImpressoraPorta;

                _Reporter.StartJob();


                int i = 1;
                _Reporter.PrintText(i, 01, _Reporter.CleanText("CAIXA " + caixa.Data.Value.ToShortDateString()));
                i++;
                _Reporter.PrintText(i, 01, " ");
                i++;
                if (vendaavista > 0)
                {
                    _Reporter.PrintText(i, 01, _Reporter.CleanText("Vendas a vista: "));
                    string valor1 = vendaavista.ConvertToMoneyString();
                    _Reporter.PrintText(i, 47 - valor1.Length, valor1);
                    i++;
                }
                if (vendaaprazo > 0)
                {
                    _Reporter.PrintText(i, 01, _Reporter.CleanText("Vendas a prazo: "));
                    string valor1 = vendaaprazo.ConvertToMoneyString();
                    _Reporter.PrintText(i, 47 - valor1.Length, valor1);
                    i++;
                }
                if (despesas > 0)
                {
                    _Reporter.PrintText(i, 01, _Reporter.CleanText("Despesas: "));
                    string valor1 = despesas.ConvertToMoneyString();
                    _Reporter.PrintText(i, 47 - valor1.Length, valor1);
                    i++;
                }
                if (outrasOperacoes > 0)
                {
                    _Reporter.PrintText(i, 01, _Reporter.CleanText("Outras operacoes: "));
                    string valor1 = outrasOperacoes.ConvertToMoneyString();
                    _Reporter.PrintText(i, 47 - valor1.Length, valor1);
                    i++;
                }
                _Reporter.PrintText(i, 01, " ");
                i++;
                _Reporter.PrintText(i, 01, _Reporter.CleanText("TOTAL: "));
                string valor = caixa.Saldo.ConvertToMoneyString();
                _Reporter.PrintText(i, 47 - valor.Length, valor);
                i++;


                _Reporter.EndJob();

                Console.WriteLine(_Reporter.PreviewJob());
                //_Reporter.PrintJob();

                //PrintSpace();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        static public void PrintOutrasParcela(Library.VendaParcela parcela, Library.Configuracoes config)
        {
            try
            {
                MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

                MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

                _Reporter.Output = config.ImpressoraPorta;

                _Reporter.StartJob();

                _Reporter.PrintText(01, 14, _EpsonCodes.ExpandedOn + "JEANE MODAS" + _EpsonCodes.ExpandedOff);
                _Reporter.PrintText(02, 06, _EpsonCodes.ItalicOn + "Av. Nilo Peçanha, 688" + _EpsonCodes.ItalicOff);
                _Reporter.PrintText(03, 12, "(22) 3852-6784 / 9873-2552");
                _Reporter.PrintText(04, 19, _EpsonCodes.CondensedOn + _EpsonCodes.ExpandedOn + _Reporter.CleanText("Parcela de Venda") + _EpsonCodes.ExpandedOff + _EpsonCodes.CondensedOff);

                _Reporter.PrintText(05, 01, "");
                _Reporter.PrintText(06, 02, _Reporter.CleanText("N. da Venda: " + parcela.Id));
                _Reporter.PrintText(07, 02, DateTime.Now.ToString("dd/MM/yyyy"));
                _Reporter.PrintText(07, 42, DateTime.Now.ToShortTimeString());

                _Reporter.PrintText(08, 01, "-----------------------------------------------");

                _Reporter.PrintText(09, 02, _Reporter.CleanText("Valor da Parcela: " + parcela.Valor));

                if (parcela.Valor != parcela.ValorPago)
                    _Reporter.PrintText(10, 02, _Reporter.CleanText("Valor pago: " + parcela.ValorPago));

                _Reporter.EndJob();

                _Reporter.PrintJob();

                Library.Classes.Print.PrintSpace(config);


            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }



        //compartilhadas:::
        static public void PrintSpace(Library.Configuracoes config)
        {
            MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

            MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

            _Reporter.Output = config.ImpressoraPorta;

            _Reporter.StartJob();

            _Reporter.PrintText(01, 01, "");
            _Reporter.PrintText(02, 01, "");
            _Reporter.PrintText(03, 01, "");
            _Reporter.PrintText(04, 01, "");
            _Reporter.PrintText(05, 01, "");
            _Reporter.PrintText(06, 01, "");
            _Reporter.PrintText(07, 01, "");

            _Reporter.EndJob();

            _Reporter.PrintJob();
        }

        static public void PrintCliente(Library.Cliente cliente, Library.Configuracoes config)
        {
            MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

            MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

            _Reporter.Output = config.ImpressoraPorta;

            _Reporter.StartJob();

            _Reporter.PrintText(01, 01, "");

            int i = 2;

            _Reporter.PrintText(i, 02, _Reporter.CleanText(cliente.Nome));
            i++;

            if (cliente.Cpf != "")
            {
                _Reporter.PrintText(i, 02, "CPF: " + _Reporter.CleanText(cliente.Cpf));
                i++;
            }
            if (cliente.Endereco != "")
            {
                _Reporter.PrintText(i, 02, _Reporter.CleanText(cliente.Endereco));
                i++;
            }
            if (cliente.Cidade != "")
            {
                _Reporter.PrintText(i, 02, _Reporter.CleanText(cliente.Cidade));
                _Reporter.PrintText(i, cliente.Cidade.Length, _Reporter.CleanText("-" + cliente.Estado));
                i++;
            }
            _Reporter.PrintText(i, 01, "");
            i++;
            _Reporter.PrintText(i, 01, "");
            i++;
            _Reporter.PrintText(i, 01, "-----------------------------------------------");
            i++;
            _Reporter.PrintText(i, 19, "ASSINATURA");
            i++;
            _Reporter.PrintText(i, 01, "");

            _Reporter.EndJob();

            _Reporter.PrintJob();
        }

        static public void PrintPagamentoAVista(Library.Configuracoes config)
        {
            MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

            MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

            _Reporter.Output = config.ImpressoraPorta;

            _Reporter.StartJob();

            _Reporter.PrintText(01, 02, _Reporter.CleanText("Pagamento a vista"));
            _Reporter.PrintText(02, 02, "Volte Sempre!");

            _Reporter.EndJob();

            _Reporter.PrintJob();
        }
        static public void PrintPagamentoAPrazo(Library.Configuracoes config)
        {
            MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

            MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

            _Reporter.Output = config.ImpressoraPorta;

            _Reporter.StartJob();

            _Reporter.PrintText(01, 02, _Reporter.CleanText("Pagamento a prazo"));
            _Reporter.PrintText(02, 02, "Volte Sempre!");

            _Reporter.EndJob();

            _Reporter.PrintJob();
        }
        static public void PrintPagamentoCheque(Library.Configuracoes config)
        {
            MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

            MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

            _Reporter.Output = config.ImpressoraPorta;

            _Reporter.StartJob();

            _Reporter.PrintText(01, 02, _Reporter.CleanText("Pagamento em cheque"));
            _Reporter.PrintText(02, 02, "Volte Sempre!");

            _Reporter.EndJob();

            _Reporter.PrintJob();
        }
        static public void PrintPagamentoCartao(Library.Configuracoes config)
        {
            MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

            MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

            _Reporter.Output = config.ImpressoraPorta;

            _Reporter.StartJob();

            _Reporter.PrintText(01, 02, _Reporter.CleanText("Pagamento em cartão"));
            _Reporter.PrintText(02, 02, "Volte Sempre!");

            _Reporter.EndJob();

            _Reporter.PrintJob();
        }
        #endregion
    }
}
