namespace Forms.Produto
{
    partial class Estoque
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Estoque));
            this.aumentarButton = new System.Windows.Forms.Button();
            this.aumentarTB = new System.Windows.Forms.TextBox();
            this.reduzirButton = new System.Windows.Forms.Button();
            this.reduzirTB = new System.Windows.Forms.TextBox();
            this.produtoDGV = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.produtoL = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.idDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estoqueDGVTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoVenda2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.produtoDGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // aumentarButton
            // 
            this.aumentarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aumentarButton.Location = new System.Drawing.Point(120, 66);
            this.aumentarButton.Name = "aumentarButton";
            this.aumentarButton.Size = new System.Drawing.Size(61, 23);
            this.aumentarButton.TabIndex = 2;
            this.aumentarButton.Text = "Aumentar";
            this.aumentarButton.UseVisualStyleBackColor = true;
            this.aumentarButton.Click += new System.EventHandler(this.aumentarButton_Click);
            // 
            // aumentarTB
            // 
            this.aumentarTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.aumentarTB.Location = new System.Drawing.Point(6, 38);
            this.aumentarTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.aumentarTB.Name = "aumentarTB";
            this.aumentarTB.Size = new System.Drawing.Size(175, 20);
            this.aumentarTB.TabIndex = 1;
            // 
            // reduzirButton
            // 
            this.reduzirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reduzirButton.Location = new System.Drawing.Point(120, 64);
            this.reduzirButton.Name = "reduzirButton";
            this.reduzirButton.Size = new System.Drawing.Size(61, 23);
            this.reduzirButton.TabIndex = 2;
            this.reduzirButton.Text = "Reduzir";
            this.reduzirButton.UseVisualStyleBackColor = true;
            this.reduzirButton.Click += new System.EventHandler(this.reduzirButton_Click);
            // 
            // reduzirTB
            // 
            this.reduzirTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reduzirTB.Location = new System.Drawing.Point(6, 36);
            this.reduzirTB.Margin = new System.Windows.Forms.Padding(3, 3, 19, 5);
            this.reduzirTB.Name = "reduzirTB";
            this.reduzirTB.Size = new System.Drawing.Size(175, 20);
            this.reduzirTB.TabIndex = 1;
            // 
            // produtoDGV
            // 
            this.produtoDGV.AllowUserToAddRows = false;
            this.produtoDGV.AllowUserToDeleteRows = false;
            this.produtoDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.produtoDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.produtoDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.produtoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.produtoDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDGVTBC,
            this.nomeDGVTBC,
            this.estoqueDGVTBC,
            this.Column1,
            this.precoVenda2});
            this.produtoDGV.Location = new System.Drawing.Point(3, 38);
            this.produtoDGV.MultiSelect = false;
            this.produtoDGV.Name = "produtoDGV";
            this.produtoDGV.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.YellowGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.OliveDrab;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.produtoDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.produtoDGV.RowHeadersVisible = false;
            this.produtoDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.produtoDGV.Size = new System.Drawing.Size(638, 457);
            this.produtoDGV.TabIndex = 1;
            this.produtoDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.produtoDGV_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.produtoL);
            this.panel1.Controls.Add(this.produtoDGV);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 507);
            this.panel1.TabIndex = 0;
            // 
            // produtoL
            // 
            this.produtoL.AutoSize = true;
            this.produtoL.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtoL.Location = new System.Drawing.Point(12, 15);
            this.produtoL.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.produtoL.Name = "produtoL";
            this.produtoL.Size = new System.Drawing.Size(88, 18);
            this.produtoL.TabIndex = 0;
            this.produtoL.Text = "Produtos:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.aumentarButton);
            this.panel2.Controls.Add(this.aumentarTB);
            this.panel2.Location = new System.Drawing.Point(645, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aumentar estoque:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.reduzirButton);
            this.panel3.Controls.Add(this.reduzirTB);
            this.panel3.Location = new System.Drawing.Point(645, 101);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Reduzir estoque:";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Location = new System.Drawing.Point(645, 202);
            this.panel4.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 305);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(845, 507);
            this.panel5.TabIndex = 0;
            // 
            // idDGVTBC
            // 
            this.idDGVTBC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idDGVTBC.DataPropertyName = "id";
            this.idDGVTBC.HeaderText = "Cod.";
            this.idDGVTBC.Name = "idDGVTBC";
            this.idDGVTBC.ReadOnly = true;
            this.idDGVTBC.Width = 52;
            // 
            // nomeDGVTBC
            // 
            this.nomeDGVTBC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nomeDGVTBC.DataPropertyName = "nome";
            this.nomeDGVTBC.HeaderText = "Nome";
            this.nomeDGVTBC.Name = "nomeDGVTBC";
            this.nomeDGVTBC.ReadOnly = true;
            this.nomeDGVTBC.Width = 58;
            // 
            // estoqueDGVTBC
            // 
            this.estoqueDGVTBC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.estoqueDGVTBC.DataPropertyName = "estoque";
            this.estoqueDGVTBC.HeaderText = "Estoque";
            this.estoqueDGVTBC.Name = "estoqueDGVTBC";
            this.estoqueDGVTBC.ReadOnly = true;
            this.estoqueDGVTBC.Width = 69;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Preço";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // precoVenda2
            // 
            this.precoVenda2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.precoVenda2.DefaultCellStyle = dataGridViewCellStyle2;
            this.precoVenda2.HeaderText = "Preço (à vista)";
            this.precoVenda2.Name = "precoVenda2";
            this.precoVenda2.ReadOnly = true;
            this.precoVenda2.Width = 98;
            // 
            // Estoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(845, 507);
            this.Controls.Add(this.panel5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 235);
            this.Name = "Estoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de estoque";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Estoque_FormClosed);
            this.Load += new System.EventHandler(this.Estoque_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Estoque_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.produtoDGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button aumentarButton;
        private System.Windows.Forms.TextBox aumentarTB;
        private System.Windows.Forms.Button reduzirButton;
        private System.Windows.Forms.TextBox reduzirTB;
        //private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        //private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        //private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn4;
        //private System.Windows.Forms.DataGridViewTextBoxColumn estoqueDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridView produtoDGV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label produtoL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn estoqueDGVTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoVenda2;
    }
}