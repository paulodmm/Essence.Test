namespace Essence.Test.FormUI
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbxListaAmigos = new System.Windows.Forms.ListBox();
            this.btnExibirProximos = new System.Windows.Forms.Button();
            this.btnAtualiarLista = new System.Windows.Forms.Button();
            this.lbxAmigosProximos = new System.Windows.Forms.ListBox();
            this.AmigosProximos = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCadastrar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtLongitude);
            this.groupBox1.Controls.Add(this.txtLatitude);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 137);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastrar Novo Amigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nome";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(88, 19);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(318, 20);
            this.txtNome.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Latitude";
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(88, 46);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(144, 20);
            this.txtLatitude.TabIndex = 3;
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(88, 73);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(144, 20);
            this.txtLongitude.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Longitude";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(12, 99);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 6;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AmigosProximos);
            this.groupBox2.Controls.Add(this.lbxAmigosProximos);
            this.groupBox2.Controls.Add(this.btnAtualiarLista);
            this.groupBox2.Controls.Add(this.btnExibirProximos);
            this.groupBox2.Controls.Add(this.lbxListaAmigos);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 298);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de Amigos";
            // 
            // lbxListaAmigos
            // 
            this.lbxListaAmigos.FormattingEnabled = true;
            this.lbxListaAmigos.Location = new System.Drawing.Point(6, 19);
            this.lbxListaAmigos.Name = "lbxListaAmigos";
            this.lbxListaAmigos.Size = new System.Drawing.Size(400, 134);
            this.lbxListaAmigos.TabIndex = 1;
            // 
            // btnExibirProximos
            // 
            this.btnExibirProximos.Location = new System.Drawing.Point(7, 160);
            this.btnExibirProximos.Name = "btnExibirProximos";
            this.btnExibirProximos.Size = new System.Drawing.Size(136, 23);
            this.btnExibirProximos.TabIndex = 2;
            this.btnExibirProximos.Text = "Exibir Proximos";
            this.btnExibirProximos.UseVisualStyleBackColor = true;
            this.btnExibirProximos.Click += new System.EventHandler(this.btnExibirProximos_Click);
            // 
            // btnAtualiarLista
            // 
            this.btnAtualiarLista.Location = new System.Drawing.Point(150, 160);
            this.btnAtualiarLista.Name = "btnAtualiarLista";
            this.btnAtualiarLista.Size = new System.Drawing.Size(129, 23);
            this.btnAtualiarLista.TabIndex = 3;
            this.btnAtualiarLista.Text = "Atualizar Lista";
            this.btnAtualiarLista.UseVisualStyleBackColor = true;
            this.btnAtualiarLista.Click += new System.EventHandler(this.btnAtualiarLista_Click);
            // 
            // lbxAmigosProximos
            // 
            this.lbxAmigosProximos.FormattingEnabled = true;
            this.lbxAmigosProximos.Location = new System.Drawing.Point(7, 216);
            this.lbxAmigosProximos.Name = "lbxAmigosProximos";
            this.lbxAmigosProximos.Size = new System.Drawing.Size(399, 69);
            this.lbxAmigosProximos.TabIndex = 4;
            // 
            // AmigosProximos
            // 
            this.AmigosProximos.AutoSize = true;
            this.AmigosProximos.Location = new System.Drawing.Point(7, 197);
            this.AmigosProximos.Name = "AmigosProximos";
            this.AmigosProximos.Size = new System.Drawing.Size(86, 13);
            this.AmigosProximos.TabIndex = 5;
            this.AmigosProximos.Text = "Amigos Proximos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 465);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExibirProximos;
        private System.Windows.Forms.ListBox lbxListaAmigos;
        private System.Windows.Forms.Button btnAtualiarLista;
        private System.Windows.Forms.Label AmigosProximos;
        private System.Windows.Forms.ListBox lbxAmigosProximos;
    }
}

