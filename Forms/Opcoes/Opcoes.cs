using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forms.Opcoes
{
    public partial class Opcoes : Form
    {
        Library.Configuracoes config;
        public Opcoes()
        {
            InitializeComponent();
        }

        private void Opcoes_Load(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            config.Empresa = textBoxEmpresa.Text;
            config.Telefone = textBoxTelefone.Text;
            config.Endereco = textBoxEndereco.Text;

            if (radioButtonBematech.Checked == true)

                config.Impressora = "bematech";
            else
                config.Impressora = "outras";

            config.ImpressoraCabecalho = richTextBoxCabecalho.Text;
            
            Library.ConfiguracoesBD.Update(config);
            Atualizar();
        }
        public void Atualizar()
        {
            config = Library.ConfiguracoesBD.FindById(1);

            textBoxEmpresa.Text = config.Empresa;
            textBoxTelefone.Text = config.Telefone;
            textBoxEndereco.Text = config.Endereco;

            switch (config.Impressora)
            {
                case "bematech":
                    radioButtonBematech.Checked = true;
                    break;
                default:
                    radioButtonOutras.Checked = true;
                    break;
            }
            richTextBoxCabecalho.Text = config.ImpressoraCabecalho;
        }
    }
}
