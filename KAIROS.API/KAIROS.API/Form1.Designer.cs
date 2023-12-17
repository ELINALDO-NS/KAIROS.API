namespace KAIROS.API
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            InsereCadastros = new TabPage();
            btn_Iniciar = new Button();
            btn_Valida_Dados = new Button();
            btn_Lista_Horarios = new Button();
            textBox6 = new TextBox();
            label6 = new Label();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            btn_LocalExcel = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            InsereCadastros.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(InsereCadastros);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, -2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(530, 308);
            tabControl1.TabIndex = 0;
            // 
            // InsereCadastros
            // 
            InsereCadastros.Controls.Add(btn_Iniciar);
            InsereCadastros.Controls.Add(btn_Valida_Dados);
            InsereCadastros.Controls.Add(btn_Lista_Horarios);
            InsereCadastros.Controls.Add(textBox6);
            InsereCadastros.Controls.Add(label6);
            InsereCadastros.Controls.Add(textBox5);
            InsereCadastros.Controls.Add(label5);
            InsereCadastros.Controls.Add(textBox4);
            InsereCadastros.Controls.Add(label4);
            InsereCadastros.Controls.Add(textBox3);
            InsereCadastros.Controls.Add(label3);
            InsereCadastros.Controls.Add(textBox2);
            InsereCadastros.Controls.Add(label2);
            InsereCadastros.Controls.Add(btn_LocalExcel);
            InsereCadastros.Controls.Add(textBox1);
            InsereCadastros.Controls.Add(label1);
            InsereCadastros.Location = new Point(4, 24);
            InsereCadastros.Name = "InsereCadastros";
            InsereCadastros.Padding = new Padding(3);
            InsereCadastros.Size = new Size(522, 280);
            InsereCadastros.TabIndex = 0;
            InsereCadastros.Text = "Insere Cadastros";
            InsereCadastros.UseVisualStyleBackColor = true;
            // 
            // btn_Iniciar
            // 
            btn_Iniciar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn_Iniciar.Location = new Point(268, 177);
            btn_Iniciar.Name = "btn_Iniciar";
            btn_Iniciar.Size = new Size(144, 23);
            btn_Iniciar.TabIndex = 15;
            btn_Iniciar.Text = "Iniciar";
            btn_Iniciar.TextAlign = ContentAlignment.TopCenter;
            btn_Iniciar.UseVisualStyleBackColor = true;
            // 
            // btn_Valida_Dados
            // 
            btn_Valida_Dados.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn_Valida_Dados.Location = new Point(268, 131);
            btn_Valida_Dados.Name = "btn_Valida_Dados";
            btn_Valida_Dados.Size = new Size(144, 23);
            btn_Valida_Dados.TabIndex = 14;
            btn_Valida_Dados.Text = "Valida Dados";
            btn_Valida_Dados.TextAlign = ContentAlignment.TopCenter;
            btn_Valida_Dados.UseVisualStyleBackColor = true;
            // 
            // btn_Lista_Horarios
            // 
            btn_Lista_Horarios.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn_Lista_Horarios.Location = new Point(268, 93);
            btn_Lista_Horarios.Name = "btn_Lista_Horarios";
            btn_Lista_Horarios.Size = new Size(144, 23);
            btn_Lista_Horarios.TabIndex = 13;
            btn_Lista_Horarios.Text = "Lista Horarios";
            btn_Lista_Horarios.TextAlign = ContentAlignment.TopCenter;
            btn_Lista_Horarios.UseVisualStyleBackColor = true;
            btn_Lista_Horarios.Click += btn_Lista_Horarios_Click;
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            textBox6.Location = new Point(123, 177);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(130, 25);
            textBox6.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label6.Location = new Point(7, 185);
            label6.Name = "label6";
            label6.Size = new Size(111, 17);
            label6.TabIndex = 11;
            label6.Text = "CPF Responsavel";
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            textBox5.Location = new Point(62, 131);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(193, 25);
            textBox5.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label5.Location = new Point(7, 139);
            label5.Name = "label5";
            label5.Size = new Size(39, 17);
            label5.TabIndex = 9;
            label5.Text = "CNPJ";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            textBox4.Location = new Point(62, 93);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(193, 25);
            textBox4.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(7, 101);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 7;
            label4.Text = "Key";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            textBox3.Location = new Point(62, 55);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(193, 25);
            textBox3.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(7, 63);
            label3.Name = "label3";
            label3.Size = new Size(55, 17);
            label3.TabIndex = 5;
            label3.Text = "Usuario";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            textBox2.Location = new Point(315, 55);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(97, 25);
            textBox2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(268, 63);
            label2.Name = "label2";
            label2.Size = new Size(45, 17);
            label2.TabIndex = 3;
            label2.Text = "Senha";
            // 
            // btn_LocalExcel
            // 
            btn_LocalExcel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn_LocalExcel.Location = new Point(322, 10);
            btn_LocalExcel.Name = "btn_LocalExcel";
            btn_LocalExcel.Size = new Size(58, 23);
            btn_LocalExcel.TabIndex = 2;
            btn_LocalExcel.Text = "...";
            btn_LocalExcel.TextAlign = ContentAlignment.TopCenter;
            btn_LocalExcel.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            textBox1.Location = new Point(113, 10);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(193, 25);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.Location = new Point(7, 18);
            label1.Name = "label1";
            label1.Size = new Size(98, 17);
            label1.TabIndex = 0;
            label1.Text = "Caminho Excel";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(522, 280);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Insere Saldo BH";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 307);
            Controls.Add(tabControl1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "KAIROS.API";
            tabControl1.ResumeLayout(false);
            InsereCadastros.ResumeLayout(false);
            InsereCadastros.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage InsereCadastros;
        private TabPage tabPage2;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private Button btn_LocalExcel;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox4;
        private Label label4;
        private Button btn_Iniciar;
        private Button btn_Valida_Dados;
        private Button btn_Lista_Horarios;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox5;
        private Label label5;
    }
}
