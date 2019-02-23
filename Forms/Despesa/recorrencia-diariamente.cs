using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Converter;

namespace Forms.Despesa
{
    public partial class recorrencia_diariamente : UserControl
    {
        public int dia
        {
            get
            {
                int valor = 0;
                if (radioButton1.Checked)
                    valor = textBox1.Text.ConvertToInt();
                return valor;
            }
            set
            {
                textBox1.Text = value.ToString();
            }
        }


        public recorrencia_diariamente()
        {
            InitializeComponent();
        }

        private void recorrencia_diariamente_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            radioButton1.Select();
        }
    }
}
