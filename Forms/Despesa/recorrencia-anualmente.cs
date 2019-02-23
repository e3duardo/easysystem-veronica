using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forms.Despesa
{
    public partial class recorrencia_anualmente : UserControl
    {
        public DateTime data;

        public recorrencia_anualmente()
        {
            InitializeComponent();
        }

        private void recorrencia_anualmente_Load(object sender, EventArgs e)
        {
            radioButton1.Text = string.Format("{0:dd}° dia de {0:MMMM}", data);
            label2.Text = string.Format("de {0:MMMM}", data);
        }
    }
}
