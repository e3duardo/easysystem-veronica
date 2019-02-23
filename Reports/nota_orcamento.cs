using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Library.Converter;

namespace Reports
{
    public partial class nota_condicional : Form
    {
        public Library.Condicional Condicional { get; set; }

        public nota_condicional()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.condicionalProduto1TableAdapter.FillByIdCondicional(this.sistemaBDDataSet.CondicionalProduto1, this.Condicional.Id);

            Microsoft.Reporting.WinForms.ReportParameter rp0 = new Microsoft.Reporting.WinForms.ReportParameter("cliente", this.Condicional.Cliente.Nome);
            Microsoft.Reporting.WinForms.ReportParameter rp1 = new Microsoft.Reporting.WinForms.ReportParameter("endereco", this.Condicional.Cliente.Endereco);
            Microsoft.Reporting.WinForms.ReportParameter rp2 = new Microsoft.Reporting.WinForms.ReportParameter("bairro", this.Condicional.Cliente.Bairro);
            Microsoft.Reporting.WinForms.ReportParameter rp3 = new Microsoft.Reporting.WinForms.ReportParameter("cidade", this.Condicional.Cliente.Cidade);
            Microsoft.Reporting.WinForms.ReportParameter rp4 = new Microsoft.Reporting.WinForms.ReportParameter("estado", this.Condicional.Cliente.Estado);
            Microsoft.Reporting.WinForms.ReportParameter rp5 = new Microsoft.Reporting.WinForms.ReportParameter("cnpjcpf", this.Condicional.Cliente.Cpf);
            Microsoft.Reporting.WinForms.ReportParameter rp6 = new Microsoft.Reporting.WinForms.ReportParameter("inscricaoestadual", this.Condicional.Cliente.InscricaoEstadual);
            Microsoft.Reporting.WinForms.ReportParameter rp7 = new Microsoft.Reporting.WinForms.ReportParameter("idCondicional", this.Condicional.Id.ToString());
            Microsoft.Reporting.WinForms.ReportParameter rp8 = new Microsoft.Reporting.WinForms.ReportParameter("data", this.Condicional.Data.Value.ToString("dd/MM/yyyy"));
            Microsoft.Reporting.WinForms.ReportParameter rp9 = new Microsoft.Reporting.WinForms.ReportParameter("valorTotal", this.Condicional.Valor.ConvertToMoneyString());

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp0, rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9 });

            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            this.reportViewer1.RefreshReport();
        }

        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DataSet1", this.condicionalProduto1BindingSource));
            //this.reportViewer1.RefreshReport();
        }
    }
}
