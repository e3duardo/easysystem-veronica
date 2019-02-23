namespace Forms.Caixa
{
    partial class CaixaFechado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaixaFechado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saldoLabel = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imprimirButton = new System.Windows.Forms.Button();
            this.dataCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCaixaFechado = new System.Windows.Forms.Panel();
            this.transacoesDGV = new System.Windows.Forms.DataGridView();
            this.tcodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.saldoTextBox = new Library.Windows.Forms.MoneyTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelCaixaFechado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transacoesDGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saldoLabel
            // 
            this.saldoLabel.AutoSize = true;
            this.saldoLabel.Location = new System.Drawing.Point(9, 36);
            this.saldoLabel.Name = "saldoLabel";
            this.saldoLabel.Size = new System.Drawing.Size(37, 13);
            this.saldoLabel.TabIndex = 1;
            this.saldoLabel.Text = "Saldo:";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.panel5);
            this.panel.Controls.Add(this.panel1);
            this.panel.Controls.Add(this.panelCaixaFechado);
            this.panel.Controls.Add(this.panel2);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(861, 610);
            this.panel.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Location = new System.Drawing.Point(661, 203);
            this.panel5.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 407);
            this.panel5.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.imprimirButton);
            this.panel1.Controls.Add(this.dataCB);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 98);
            this.panel1.TabIndex = 0;
            // 
            // imprimirButton
            // 
            this.imprimirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imprimirButton.Image = ((System.Drawing.Image)(resources.GetObject("imprimirButton.Image")));
            this.imprimirButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.imprimirButton.Location = new System.Drawing.Point(782, 14);
            this.imprimirButton.Name = "imprimirButton";
            this.imprimirButton.Size = new System.Drawing.Size(70, 70);
            this.imprimirButton.TabIndex = 2;
            this.imprimirButton.Text = "Imprimir";
            this.imprimirButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.imprimirButton.UseVisualStyleBackColor = true;
            this.imprimirButton.Click += new System.EventHandler(this.imprimirButton_Click);
            // 
            // dataCB
            // 
            this.dataCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataCB.FormattingEnabled = true;
            this.dataCB.Location = new System.Drawing.Point(17, 52);
            this.dataCB.Name = "dataCB";
            this.dataCB.Size = new System.Drawing.Size(152, 24);
            this.dataCB.TabIndex = 1;
            this.dataCB.SelectedIndexChanged += new System.EventHandler(this.dataCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Movimentos fechados:";
            // 
            // panelCaixaFechado
            // 
            this.panelCaixaFechado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCaixaFechado.BackColor = System.Drawing.SystemColors.Control;
            this.panelCaixaFechado.Controls.Add(this.transacoesDGV);
            this.panelCaixaFechado.Controls.Add(this.label7);
            this.panelCaixaFechado.Location = new System.Drawing.Point(0, 99);
            this.panelCaixaFechado.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panelCaixaFechado.Name = "panelCaixaFechado";
            this.panelCaixaFechado.Size = new System.Drawing.Size(660, 511);
            this.panelCaixaFechado.TabIndex = 1;
            // 
            // transacoesDGV
            // 
            this.transacoesDGV.AllowUserToAddRows = false;
            this.transacoesDGV.AllowUserToDeleteRows = false;
            this.transacoesDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.transacoesDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.transacoesDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.transacoesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transacoesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tcodigo,
            this.tcliente,
            this.ttipo,
            this.valor,
            this.thora});
            this.transacoesDGV.Location = new System.Drawing.Point(3, 39);
            this.transacoesDGV.MultiSelect = false;
            this.transacoesDGV.Name = "transacoesDGV";
            this.transacoesDGV.ReadOnly = true;
            this.transacoesDGV.RowHeadersVisible = false;
            this.transacoesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.transacoesDGV.Size = new System.Drawing.Size(654, 469);
            this.transacoesDGV.TabIndex = 1;
            // 
            // tcodigo
            // 
            this.tcodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tcodigo.HeaderText = "Código";
            this.tcodigo.Name = "tcodigo";
            this.tcodigo.ReadOnly = true;
            this.tcodigo.Visible = false;
            // 
            // tcliente
            // 
            this.tcliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tcliente.HeaderText = "Cliente";
            this.tcliente.Name = "tcliente";
            this.tcliente.ReadOnly = true;
            // 
            // ttipo
            // 
            this.ttipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ttipo.HeaderText = "Tipo";
            this.ttipo.Name = "ttipo";
            this.ttipo.ReadOnly = true;
            this.ttipo.Width = 51;
            // 
            // valor
            // 
            this.valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.valor.DefaultCellStyle = dataGridViewCellStyle1;
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            this.valor.Width = 54;
            // 
            // thora
            // 
            this.thora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.thora.DefaultCellStyle = dataGridViewCellStyle2;
            this.thora.HeaderText = "Hora";
            this.thora.Name = "thora";
            this.thora.ReadOnly = true;
            this.thora.Width = 53;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Controle de transações";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.saldoLabel);
            this.panel2.Controls.Add(this.statusLabel);
            this.panel2.Controls.Add(this.saldoTextBox);
            this.panel2.Location = new System.Drawing.Point(661, 99);
            this.panel2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 103);
            this.panel2.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(3, 14);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(148, 18);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Caixa (Fechado):";
            // 
            // saldoTextBox
            // 
            this.saldoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saldoTextBox.Location = new System.Drawing.Point(9, 54);
            this.saldoTextBox.Name = "saldoTextBox";
            this.saldoTextBox.ReadOnly = true;
            this.saldoTextBox.Size = new System.Drawing.Size(182, 29);
            this.saldoTextBox.TabIndex = 2;
            this.saldoTextBox.Text = "R$ 0,00";
            this.saldoTextBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 610);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(861, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // CaixaFechado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(861, 632);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(510, 452);
            this.Name = "CaixaFechado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caixas Fechado";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CaixaFechado_FormClosed);
            this.Load += new System.EventHandler(this.CaixaFechado_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CaixaFechado_KeyDown);
            this.panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelCaixaFechado.ResumeLayout(false);
            this.panelCaixaFechado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transacoesDGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private Library.Windows.Forms.MoneyTextBox saldoTextBox;
        private System.Windows.Forms.DataGridView transacoesDGV;
        private System.Windows.Forms.Panel panelCaixaFechado;
        private System.Windows.Forms.ComboBox dataCB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button imprimirButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label saldoLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn thora;
    }
}