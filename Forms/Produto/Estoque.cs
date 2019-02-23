﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Converter;

namespace Forms.Produto
{
    public partial class Estoque : Form
    {
        public Estoque()
        {
            InitializeComponent();
        }

        private void Estoque_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.RefreshGrid();
                this.ColorGrid();

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        private void aumentarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.produtoDGV.SelectedRows.Count == 1)
            {
                long idProdutoTMP = (long)this.produtoDGV.SelectedRows[0].Cells[0].Value;

                Library.Produto produto = Library.ProdutoBD.FindById(idProdutoTMP);

                produto.Estoque += this.aumentarTB.Text.ConvertToDouble();

                Library.ProdutoBD.Update(produto);
            }
            this.RefreshGrid();
            this.ColorGrid();
            Forms.OpenForm.RefreshProdutos();

            this.Cursor = Cursors.Default;
        }

        private void reduzirButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.produtoDGV.SelectedRows.Count == 1)
            {
                long idProdutoTMP = (long)this.produtoDGV.SelectedRows[0].Cells[0].Value;

                Library.Produto produto = Library.ProdutoBD.FindById(idProdutoTMP);

                produto.Estoque -= this.reduzirTB.Text.ConvertToDouble();

                Library.ProdutoBD.Update(produto);
            }
            this.RefreshGrid();
            this.ColorGrid();
            Forms.OpenForm.RefreshProdutos();

            this.Cursor = Cursors.Default;
        }

        private void RefreshGrid()
        {
            List<Library.Produto> produtos = Library.ProdutoBD.FindAdvanced();

            this.produtoDGV.Rows.Clear();
            foreach (Library.Produto pd in produtos)
            {
                int i = this.produtoDGV.Rows.Add(pd.Id, pd.Nome, pd.Estoque, pd.PrecoVenda, pd.PrecoVendaAVista);

                double estoque = pd.Estoque;
                double estoqueRisco = pd.EstoqueRisco;

                if (estoque <= 0)
                {
                    this.produtoDGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(234, 203, 181);
                    this.produtoDGV.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(223, 175, 141);
                }
                else if (estoque > 0 && estoque <= estoqueRisco)
                {
                    this.produtoDGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(234, 224, 181);
                    this.produtoDGV.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(223, 207, 141);
                }
                else
                {
                    this.produtoDGV.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(211, 227, 174);
                    this.produtoDGV.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 214, 136);
                }
            }
        }
        private void ColorGrid()
        {
            //for (int i = 0; i < this.produtoDGV.RowCount; i++)
            //{
                

                /* 
                 * verde 211, 227, 174
                 * verde selecionado 191, 214, 136
                 * 
                 * vermelho 234, 203, 181
                 * vermelho selecionado 223, 175, 141
                 * 
                 * amarelo 234, 224, 181
                 * amarelo selecionado 223, 207, 141
                 */
            //}
        }

        private void produtoDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //achando idProduto selecionado na grid
            long idProduto = 0;
            for (int i = 0; i < this.produtoDGV.SelectedRows.Count; i++)
            {
                idProduto = (long)this.produtoDGV.SelectedRows[i].Cells[0].Value;
            }

            Forms.OpenForm.OpenProdutoId(idProduto);
        }

        private void Estoque_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

        private void Estoque_KeyDown(object sender, KeyEventArgs e)
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
