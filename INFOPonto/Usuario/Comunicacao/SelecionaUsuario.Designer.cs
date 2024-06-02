namespace INFOPonto.Usuario.Comunicacao
{
    partial class SelecionaUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelecionaUsuario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkSelecionarTodos = new System.Windows.Forms.LinkLabel();
            this.clUsuarios = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirmaSelecao = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lnkSelecionarTodos);
            this.panel1.Controls.Add(this.clUsuarios);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 140);
            this.panel1.TabIndex = 2;
            // 
            // lnkSelecionarTodos
            // 
            this.lnkSelecionarTodos.AutoSize = true;
            this.lnkSelecionarTodos.Location = new System.Drawing.Point(219, 4);
            this.lnkSelecionarTodos.Name = "lnkSelecionarTodos";
            this.lnkSelecionarTodos.Size = new System.Drawing.Size(90, 13);
            this.lnkSelecionarTodos.TabIndex = 4;
            this.lnkSelecionarTodos.TabStop = true;
            this.lnkSelecionarTodos.Text = "Selecionar Todos";
            this.lnkSelecionarTodos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelecionarTodos_LinkClicked);
            // 
            // clUsuarios
            // 
            this.clUsuarios.CheckOnClick = true;
            this.clUsuarios.FormattingEnabled = true;
            this.clUsuarios.Location = new System.Drawing.Point(7, 19);
            this.clUsuarios.Name = "clUsuarios";
            this.clUsuarios.Size = new System.Drawing.Size(302, 109);
            this.clUsuarios.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuários do Sistema";
            // 
            // btnConfirmaSelecao
            // 
            this.btnConfirmaSelecao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmaSelecao.Location = new System.Drawing.Point(194, 151);
            this.btnConfirmaSelecao.Name = "btnConfirmaSelecao";
            this.btnConfirmaSelecao.Size = new System.Drawing.Size(130, 23);
            this.btnConfirmaSelecao.TabIndex = 3;
            this.btnConfirmaSelecao.Text = "Confirmar Seleção";
            this.btnConfirmaSelecao.UseVisualStyleBackColor = true;
            this.btnConfirmaSelecao.Click += new System.EventHandler(this.btnConfirmaSelecao_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(105, 151);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // SelecionaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 179);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmaSelecao);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelecionaUsuario";
            this.Text = "Seleção de usuários";
            this.Load += new System.EventHandler(this.Seleciona_Usuario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox clUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirmaSelecao;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.LinkLabel lnkSelecionarTodos;
    }
}