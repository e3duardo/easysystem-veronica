﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Library.Classes;

namespace Forms.Condicional
{
    public partial class CondicionalList : Form
    {
        private delegate void InvokeDelegate(int index);
        private string fvDeletarMsgSmall = "Desseja mesmo remover esta Condicional?";
        private string fvDeletarMsgLarger = "Excluindo esta Condicional, todos seus produtos serão removidos também.";
        private string fvDeletarMsgTitle = "Exclusão de Condicional";

        Forms.Condicional.CondicionalDetail sd = null;

        public CondicionalList()
        {
            InitializeComponent();
        }

        private void CondicionalList_Load(object sender, EventArgs e)
        {
            dataInicioDTP.Text = "";
            dataTerminoDTP.Text = "";
            pesquisarButton.PerformClick();
        }

        private void pesquisarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //
            resultadoDGV.Rows.Clear();

            QItem queryData1 = new QItem(null, null);
            QItem queryData2 = new QItem(null, null);

            QItem queryCodigo = new QItem(null, null);
            QItem queryClienteNome = new QItem(null, null);

            //dataEntrega
            if (this.dataInicioDTP.Text != "")
                queryData1 = new QItem("dataMenor", this.dataInicioDTP.Value.ToString("yyyy-MM-dd"));
            else
                queryData1 = new QItem(null, null);

            if (this.dataTerminoDTP.Text != "")
                queryData2 = new QItem("dataMaior", this.dataTerminoDTP.Value.ToString("yyyy-MM-dd"));
            else
                queryData2 = new QItem(null, null);

            //codigo
            if (this.codigoTB.Text != "")
                queryCodigo = new QItem("o.id", this.codigoTB.Text);
            else
                queryCodigo = new QItem(null, null);

            //cliente
            if (this.clienteNomeTB.Text != "")
                queryClienteNome = new QItem("c.nome LIKE %%", this.clienteNomeTB.Text);
            else
                queryClienteNome = new QItem(null, null);

                        
            List<Library.Condicional> condicionals = Library.CondicionalBD.FindAdvanced(queryData1, queryData2, queryCodigo, queryClienteNome);

            if (condicionals != null)
            {
                foreach (Library.Condicional o in condicionals)
                {
                    resultadoDGV.Rows.Add(o.Id, o.Cliente.Nome, o.Data);
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void resultadoDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowSelected = resultadoDGV.SelectedRows[0];

            Library.Condicional Condicional = Library.CondicionalBD.FindById((long)rowSelected.Cells[0].Value);

            if (Condicional != null)
            {
                sd = new Forms.Condicional.CondicionalDetail();
                sd.Condicional = Condicional;

                sd.ShowDialog(this);

                this.pesquisarButton.PerformClick();
            }
        }

        private void CondicionalList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }
        

        private void resultadoDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (e.RowIndex != -1)
                {
                    if (this.resultadoDGV.Columns[e.ColumnIndex].Name == "sellColumn")
                        this.resultadoDGV.BeginInvoke(new InvokeDelegate(SellRow), new object[] { e.RowIndex });
                    if (this.resultadoDGV.Columns[e.ColumnIndex].Name == "deleteColumn")
                        this.resultadoDGV.BeginInvoke(new InvokeDelegate(DeleteRow), new object[] { e.RowIndex });
                    if (this.resultadoDGV.Columns[e.ColumnIndex].Name == "printColumn")
                        this.resultadoDGV.BeginInvoke(new InvokeDelegate(PrintRow), new object[] { e.RowIndex });
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

            this.Cursor = Cursors.Default;
        }

        private void SellRow(int index)
        {
            try
            {
                Library.Condicional condicional = Library.CondicionalBD.FindById((long)this.resultadoDGV.Rows[index].Cells[0].Value);
                //this.resultadoDGV.Rows.RemoveAt(index);
                Forms.Venda.Venda venda = new Forms.Venda.Venda();
                venda.condicional = condicional;
                venda.Show();
                venda.Disposed += delegate { venda.Dispose(); };
                
                List<Library.CondicionalProduto> CondicionalProdutos = Library.CondicionalProdutoBD.FindAdvanced(new QItem("o.id", condicional.Id));

                foreach (Library.CondicionalProduto a in CondicionalProdutos)
                {
                    Library.Produto produtoTMP = a.Produto;
                    produtoTMP.Estoque += (double)a.Quantidade;
                    Library.ProdutoBD.Update(produtoTMP);
                }

                Library.CondicionalBD.Delete(condicional);

                Forms.OpenForm.RefreshCondicionais();
                Forms.OpenForm.RefreshProdutos();

                this.pesquisarButton.PerformClick();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        private void PrintRow(int index)
        {
            try
            {
                Library.Classes.Print.PrintCondicional(Library.CondicionalBD.FindById((long)this.resultadoDGV.Rows[index].Cells[0].Value));

            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        private void DeleteRow(int index)
        {
            try
            {

                //this.RefreshPreco();
                if (Library.Windows.Forms.MessageBox.Show(this.fvDeletarMsgTitle, this.fvDeletarMsgSmall, this.fvDeletarMsgLarger, "Sim", "Não", global::Resources.Properties.Resources.dialog_warning) == DialogResult.OK)
                {
                    Library.Condicional condicional = Library.CondicionalBD.FindById((long)this.resultadoDGV.Rows[index].Cells[0].Value);

                    List<Library.CondicionalProduto> CondicionalProdutos = Library.CondicionalProdutoBD.FindAdvanced(new QItem("o.id", condicional.Id));

                    foreach (Library.CondicionalProduto a in CondicionalProdutos)
                    {
                        Library.Produto produtoTMP = a.Produto;
                        produtoTMP.Estoque += (double)a.Quantidade;
                        Library.ProdutoBD.Update(produtoTMP);
                    }

                    Library.CondicionalBD.Delete(condicional);
                    this.resultadoDGV.Rows.RemoveAt(index);
                    //this.DialogResult = DialogResult.Ignore;

                    Forms.OpenForm.RefreshCondicionais();
                    Forms.OpenForm.RefreshProdutos();

                    this.pesquisarButton.PerformClick();
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        private void CondicionalList_KeyDown(object sender, KeyEventArgs e)
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
