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
    public partial class recorrencia_mensalmente : UserControl
    {
        public DateTime data;

        public recorrencia_mensalmente()
        {
            InitializeComponent();
        }

        private void recorrencia_mensalmente_Load(object sender, EventArgs e)
        {
            radioButton1.Text = string.Format("{0:dd}° dia do mês", data);
        }
    }
}
