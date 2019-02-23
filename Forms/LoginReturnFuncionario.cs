using System;
using System.Windows.Forms;

namespace Forms
{
    public partial class LoginReturnFuncionario : Library.Windows.Forms.Form1
    {
        public Library.Funcionario Funcionario { get; set; }
        public LoginReturnFuncionario()
        {
            InitializeComponent();
        }

        private void Login2_Load(object sender, EventArgs e)
        {
            this.loginTB.Focus();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.logarButton.PerformClick();
            }
        }

        private void logarButton_Click(object sender, EventArgs e)
        {
            Library.Funcionario funcionario;

            string message = "";

            if (Library.FuncionarioBD.Logar(this.loginTB.Text, this.senhaTB.Text, out funcionario, out message))
            {
                this.Funcionario = funcionario;

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(message);
            }

        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
