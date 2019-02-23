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
    public partial class recorrencia_semanalmente : UserControl
    {
        public int dia
        {
            get
            {
                return textBox1.Text.ConvertToInt();
            }
            set
            {
                textBox1.Text = value.ToString();
            }
        }

        public string dias
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value.ToString();
            }
        }

        public recorrencia_semanalmente()
        {
            InitializeComponent();
        }

        private void recorrencia_semanalmente_Load(object sender, EventArgs e)
        {

        }
    }
}
