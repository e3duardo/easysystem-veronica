namespace Forms.Despesa
{
    /// <summary>
    /// despesa
    /// </summary>
    partial class DespesaOLD
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DespesaOLD));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataDTP = new Library.Windows.Forms.DateTextBox();
            this.descricaoTB = new System.Windows.Forms.TextBox();
            this.codigoTB = new System.Windows.Forms.TextBox();
            this.valorTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.novoButton = new System.Windows.Forms.Button();
            this.salvarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTextBox1 = new Library.Windows.Forms.DateTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // dataDTP
            // 
            this.dataDTP.Location = new System.Drawing.Point(8, 40);
            this.dataDTP.Margin = new System.Windows.Forms.Padding(3, 3, 19, 3);
            this.dataDTP.MaxLength = 10;
            this.dataDTP.Name = "dataDTP";
            this.dataDTP.Size = new System.Drawing.Size(88, 20);
            this.dataDTP.TabIndex = 3;
            this.dataDTP.Text = "01/01/0001";
            this.dataDTP.Value = new System.DateTime(((long)(0)));
            this.dataDTP.Validating += new System.ComponentModel.CancelEventHandler(this.dataDTP_Validating);
            // 
            // descricaoTB
            // 
            this.descricaoTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.descricaoTB.Location = new System.Drawing.Point(136, 32);
            this.descricaoTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 3);
            this.descricaoTB.Multiline = true;
            this.descricaoTB.Name = "descricaoTB";
            this.descricaoTB.Size = new System.Drawing.Size(512, 68);
            this.descricaoTB.TabIndex = 7;
            // 
            // codigoTB
            // 
            this.codigoTB.Location = new System.Drawing.Point(16, 32);
            this.codigoTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 3);
            this.codigoTB.Name = "codigoTB";
            this.codigoTB.ReadOnly = true;
            this.codigoTB.Size = new System.Drawing.Size(88, 20);
            this.codigoTB.TabIndex = 1;
            // 
            // valorTB
            // 
            this.valorTB.Location = new System.Drawing.Point(16, 80);
            this.valorTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 3);
            this.valorTB.Name = "valorTB";
            this.valorTB.Size = new System.Drawing.Size(88, 20);
            this.valorTB.TabIndex = 5;
            this.valorTB.Leave += new System.EventHandler(this.valorTB_Leave);
            this.valorTB.Validating += new System.ComponentModel.CancelEventHandler(this.valorTB_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Código";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descrição";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Valor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Início";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.novoButton);
            this.panel1.Controls.Add(this.salvarButton);
            this.panel1.Controls.Add(this.cancelarButton);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 88);
            this.panel1.TabIndex = 8;
            // 
            // novoButton
            // 
            this.novoButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.novoButton.Image = ((System.Drawing.Image)(resources.GetObject("novoButton.Image")));
            this.novoButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.novoButton.Location = new System.Drawing.Point(234, 16);
            this.novoButton.Margin = new System.Windows.Forms.Padding(0);
            this.novoButton.Name = "novoButton";
            this.novoButton.Size = new System.Drawing.Size(60, 60);
            this.novoButton.TabIndex = 0;
            this.novoButton.Text = "&Novo";
            this.novoButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.novoButton.UseVisualStyleBackColor = true;
            this.novoButton.Click += new System.EventHandler(this.novoButton_Click);
            // 
            // salvarButton
            // 
            this.salvarButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.salvarButton.Image = ((System.Drawing.Image)(resources.GetObject("salvarButton.Image")));
            this.salvarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.salvarButton.Location = new System.Drawing.Point(302, 16);
            this.salvarButton.Margin = new System.Windows.Forms.Padding(0);
            this.salvarButton.Name = "salvarButton";
            this.salvarButton.Size = new System.Drawing.Size(60, 60);
            this.salvarButton.TabIndex = 1;
            this.salvarButton.Text = "&Salvar";
            this.salvarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.salvarButton.UseVisualStyleBackColor = true;
            this.salvarButton.Click += new System.EventHandler(this.salvarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cancelarButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelarButton.Image")));
            this.cancelarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancelarButton.Location = new System.Drawing.Point(370, 16);
            this.cancelarButton.Margin = new System.Windows.Forms.Padding(0);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(60, 60);
            this.cancelarButton.TabIndex = 2;
            this.cancelarButton.Text = "&Cancelar";
            this.cancelarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.codigoTB);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.descricaoTB);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.valorTB);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(664, 442);
            this.panel2.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dateTextBox1);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataDTP);
            this.groupBox1.Location = new System.Drawing.Point(16, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 319);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vencimento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(139, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Fim";
            // 
            // dateTextBox1
            // 
            this.dateTextBox1.Location = new System.Drawing.Point(139, 40);
            this.dateTextBox1.Margin = new System.Windows.Forms.Padding(3, 3, 19, 3);
            this.dateTextBox1.MaxLength = 10;
            this.dateTextBox1.Name = "dateTextBox1";
            this.dateTextBox1.Size = new System.Drawing.Size(88, 20);
            this.dateTextBox1.TabIndex = 7;
            this.dateTextBox1.Text = "01/01/0001";
            this.dateTextBox1.Value = new System.DateTime(((long)(0)));
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(6, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(620, 27);
            this.panel4.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(472, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Definir recorrência";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Sem repetição";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(14, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Recorrência: ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(6, 99);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(620, 214);
            this.panel3.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(0, 44);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(620, 170);
            this.panel5.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Diariamente",
            "Semanalmente",
            "Mensalmente",
            "Anualmente"});
            this.comboBox1.Location = new System.Drawing.Point(51, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ocorre:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(118, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // DespesaOLD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(663, 531);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(503, 271);
            this.Name = "DespesaOLD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Despesa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Despesa_FormClosed);
            this.Load += new System.EventHandler(this.Despesa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Despesa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button novoButton;
        private System.Windows.Forms.Button salvarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.TextBox descricaoTB;
        private System.Windows.Forms.TextBox valorTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Library.Windows.Forms.DateTextBox dataDTP;
        private System.Windows.Forms.TextBox codigoTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private Library.Windows.Forms.DateTextBox dateTextBox1;
        private System.Windows.Forms.CheckBox checkBox1;

    }
}