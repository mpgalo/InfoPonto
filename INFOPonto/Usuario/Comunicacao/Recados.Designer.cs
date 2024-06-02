namespace INFOPonto.Usuario.Comunicacao
{
    partial class Recados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recados));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEnviarRecado = new System.Windows.Forms.Button();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConteudoRecado = new System.Windows.Forms.TextBox();
            this.lstArquivos = new System.Windows.Forms.ListBox();
            this.btnArquivo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAssunto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAnexos = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.recadosNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bsRecados = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRecadosNaoLidos = new System.Windows.Forms.ToolStripLabel();
            this.grdRecados = new System.Windows.Forms.DataGridView();
            this.Anexo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UsuarioRemetente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recadosNavigator)).BeginInit();
            this.recadosNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRecados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecados)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(513, 359);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.btnCancelar);
            this.tabPage1.Controls.Add(this.btnEnviarRecado);
            this.tabPage1.Controls.Add(this.btnSelecionar);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtConteudoRecado);
            this.tabPage1.Controls.Add(this.lstArquivos);
            this.tabPage1.Controls.Add(this.btnArquivo);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtAssunto);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(505, 333);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Enviar Recado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(274, 294);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviarRecado
            // 
            this.btnEnviarRecado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarRecado.Location = new System.Drawing.Point(379, 294);
            this.btnEnviarRecado.Name = "btnEnviarRecado";
            this.btnEnviarRecado.Size = new System.Drawing.Size(99, 23);
            this.btnEnviarRecado.TabIndex = 5;
            this.btnEnviarRecado.Text = "Enviar Recado";
            this.btnEnviarRecado.UseVisualStyleBackColor = true;
            this.btnEnviarRecado.Click += new System.EventHandler(this.btnEnviarRecado_Click);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionar.Location = new System.Drawing.Point(103, 15);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(75, 23);
            this.btnSelecionar.TabIndex = 1;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Recado :";
            // 
            // txtConteudoRecado
            // 
            this.txtConteudoRecado.Location = new System.Drawing.Point(103, 116);
            this.txtConteudoRecado.MaxLength = 3000;
            this.txtConteudoRecado.Multiline = true;
            this.txtConteudoRecado.Name = "txtConteudoRecado";
            this.txtConteudoRecado.Size = new System.Drawing.Size(376, 172);
            this.txtConteudoRecado.TabIndex = 4;
            // 
            // lstArquivos
            // 
            this.lstArquivos.Enabled = false;
            this.lstArquivos.FormattingEnabled = true;
            this.lstArquivos.Location = new System.Drawing.Point(103, 70);
            this.lstArquivos.Name = "lstArquivos";
            this.lstArquivos.Size = new System.Drawing.Size(303, 43);
            this.lstArquivos.TabIndex = 16;
            // 
            // btnArquivo
            // 
            this.btnArquivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArquivo.Location = new System.Drawing.Point(412, 70);
            this.btnArquivo.Name = "btnArquivo";
            this.btnArquivo.Size = new System.Drawing.Size(67, 23);
            this.btnArquivo.TabIndex = 3;
            this.btnArquivo.Text = "Arquivo...";
            this.btnArquivo.UseVisualStyleBackColor = true;
            this.btnArquivo.Click += new System.EventHandler(this.btnArquivo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Anexar Arquivo :";
            // 
            // txtAssunto
            // 
            this.txtAssunto.Location = new System.Drawing.Point(103, 44);
            this.txtAssunto.MaxLength = 250;
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.Size = new System.Drawing.Size(376, 20);
            this.txtAssunto.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Assunto :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Destinatário(s) :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAnexos);
            this.tabPage2.Controls.Add(this.txtDescricao);
            this.tabPage2.Controls.Add(this.recadosNavigator);
            this.tabPage2.Controls.Add(this.grdRecados);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(505, 333);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Seus Recados";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAnexos
            // 
            this.btnAnexos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnexos.Location = new System.Drawing.Point(3, 306);
            this.btnAnexos.Name = "btnAnexos";
            this.btnAnexos.Size = new System.Drawing.Size(75, 23);
            this.btnAnexos.TabIndex = 4;
            this.btnAnexos.Text = "Anexos";
            this.btnAnexos.UseVisualStyleBackColor = true;
            this.btnAnexos.Click += new System.EventHandler(this.btnAnexos_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(0, 158);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricao.Size = new System.Drawing.Size(502, 142);
            this.txtDescricao.TabIndex = 2;
            // 
            // recadosNavigator
            // 
            this.recadosNavigator.AddNewItem = null;
            this.recadosNavigator.BindingSource = this.bsRecados;
            this.recadosNavigator.CountItem = this.bindingNavigatorCountItem;
            this.recadosNavigator.CountItemFormat = "de {0}";
            this.recadosNavigator.DeleteItem = null;
            this.recadosNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.lblRecadosNaoLidos});
            this.recadosNavigator.Location = new System.Drawing.Point(3, 3);
            this.recadosNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.recadosNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.recadosNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.recadosNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.recadosNavigator.Name = "recadosNavigator";
            this.recadosNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.recadosNavigator.Size = new System.Drawing.Size(499, 25);
            this.recadosNavigator.TabIndex = 1;
            this.recadosNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Último recado recebido";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Próximo recado";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(20, 22);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posição Atual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Recando Anterior";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Primeiro recado recebido";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lblRecadosNaoLidos
            // 
            this.lblRecadosNaoLidos.Name = "lblRecadosNaoLidos";
            this.lblRecadosNaoLidos.Size = new System.Drawing.Size(72, 22);
            this.lblRecadosNaoLidos.Text = "{0} não lidos.";
            // 
            // grdRecados
            // 
            this.grdRecados.AllowUserToAddRows = false;
            this.grdRecados.AllowUserToDeleteRows = false;
            this.grdRecados.AutoGenerateColumns = false;
            this.grdRecados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRecados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Anexo,
            this.UsuarioRemetente,
            this.Assunto,
            this.Data});
            this.grdRecados.DataSource = this.bsRecados;
            this.grdRecados.Location = new System.Drawing.Point(0, 31);
            this.grdRecados.Name = "grdRecados";
            this.grdRecados.ReadOnly = true;
            this.grdRecados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRecados.Size = new System.Drawing.Size(502, 121);
            this.grdRecados.TabIndex = 0;
            this.grdRecados.VirtualMode = true;
            this.grdRecados.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdRecados_CellFormatting);
            this.grdRecados.SelectionChanged += new System.EventHandler(this.grdRecados_SelectionChanged);
            // 
            // Anexo
            // 
            this.Anexo.DataPropertyName = "HasAnexo";
            this.Anexo.HeaderText = "Anexo";
            this.Anexo.Name = "Anexo";
            this.Anexo.ReadOnly = true;
            this.Anexo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Anexo.Width = 40;
            // 
            // UsuarioRemetente
            // 
            this.UsuarioRemetente.DataPropertyName = "NomeRemetente";
            this.UsuarioRemetente.HeaderText = "Remetente";
            this.UsuarioRemetente.Name = "UsuarioRemetente";
            this.UsuarioRemetente.ReadOnly = true;
            // 
            // Assunto
            // 
            this.Assunto.DataPropertyName = "Assunto";
            this.Assunto.HeaderText = "Assunto";
            this.Assunto.Name = "Assunto";
            this.Assunto.ReadOnly = true;
            this.Assunto.Width = 190;
            // 
            // Data
            // 
            this.Data.DataPropertyName = "DataRecado";
            this.Data.HeaderText = "Data/Hora";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Recados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 359);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Recados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Recados";
            this.Load += new System.EventHandler(this.Recados_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recadosNavigator)).EndInit();
            this.recadosNavigator.ResumeLayout(false);
            this.recadosNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRecados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstArquivos;
        private System.Windows.Forms.Button btnArquivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAssunto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConteudoRecado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEnviarRecado;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView grdRecados;
        private System.Windows.Forms.BindingSource bsRecados;
        private System.Windows.Forms.BindingNavigator recadosNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Anexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRemetente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.Button btnAnexos;
        private System.Windows.Forms.ToolStripLabel lblRecadosNaoLidos;
    }
}