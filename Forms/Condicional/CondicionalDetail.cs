﻿using System;
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
    public partial class CondicionalDetail : Form
    {
        string fvDeletarMsgSmall = "Desseja mesmo remover esta Condicional?";
        string fvDeletarMsgLarger = "Excluindo esta Condicional, todos seus produtos serão removidos também.";
        string fvDeletarMsgTitle = "Exclusão de Condicional";

        //private Library.Windows.Forms.Print print;
        //Reports.nota_condicional notao;

        public Library.Condicional Condicional { get; set; }
        
        /*************************************************/

        public CondicionalDetail()
        {
            InitializeComponent();
        }


        private void CondicionalDetail_Load(object sender, EventArgs e)
        {
            this.ShowValues();
            this.ShowProdutos();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.DialogResult = DialogResult.OK;

            this.Cursor = Cursors.Default;
        }

        private void imprimirButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Library.Classes.Print.PrintCondicional(this.Condicional);

            this.Cursor = Cursors.Default;
        }

        private void deletarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (Library.Windows.Forms.MessageBox.Show(this.fvDeletarMsgTitle, this.fvDeletarMsgSmall, this.fvDeletarMsgLarger, "Sim", "Não", global::Resources.Properties.Resources.dialog_warning) == DialogResult.OK)
            {
                List<Library.CondicionalProduto> CondicionalProdutos = Library.CondicionalProdutoBD.FindAdvanced(new QItem("o.id", this.Condicional.Id));

                foreach (Library.CondicionalProduto a in CondicionalProdutos)
                {
                    Library.Produto produtoTMP = a.Produto;
                    produtoTMP.Estoque += (double)a.Quantidade;
                    Library.ProdutoBD.Update(produtoTMP);
                }

                Library.CondicionalBD.Delete(this.Condicional);

                this.DialogResult = DialogResult.Ignore;
            }

            Forms.OpenForm.RefreshCondicionais();
            Forms.OpenForm.RefreshProdutos();

            this.Cursor = Cursors.Default;
        }

        private void venderButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Forms.Venda.Venda venda = new Forms.Venda.Venda();
            venda.condicional = this.Condicional;
            venda.Show();
            venda.Disposed += delegate { venda.Dispose(); };

            List<Library.CondicionalProduto> CondicionalProdutos = Library.CondicionalProdutoBD.FindAdvanced(new QItem("o.id", this.Condicional.Id));
            
            foreach (Library.CondicionalProduto a in CondicionalProdutos)
            {
                Library.Produto produtoTMP = a.Produto;
                produtoTMP.Estoque += (double)a.Quantidade;
                Library.ProdutoBD.Update(produtoTMP);
            }

            Library.CondicionalBD.Delete(this.Condicional);

            Forms.OpenForm.RefreshCondicionais();
            Forms.OpenForm.RefreshProdutos();

            this.Cursor = Cursors.Default;
        }

        private void ShowValues()
        {
            this.codigoTB.Text = this.Condicional.Id.ToString();
            this.dataTB.Text = this.Condicional.Data.ToString();
            this.clienteTB.Text = this.Condicional.Cliente.Nome.ToString();
            this.vendedorTB.Text = this.Condicional.Funcionario.Nome.ToString();
            this.valorTotalTB.Text = this.Condicional.Valor.ConvertToMoneyString();
        }

        private void ShowProdutos()
        {
            List<Library.CondicionalProduto> CondicionalProdutos = Library.CondicionalProdutoBD.FindAdvanced(new QItem("o.id",this.Condicional.Id));

            this.CondicionalProdutoDGV.Rows.Clear();
            
            foreach (Library.CondicionalProduto a in CondicionalProdutos)
            {
                if (a != null & a.Produto != null)
                {                    
                    this.CondicionalProdutoDGV.Rows.Add(a.Produto.Id, a.Produto.Nome, a.Quantidade, a.Preco, a.PrecoTotal);
                }
            }
        }

        private void CondicionalDetail_KeyDown(object sender, KeyEventArgs e)
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
