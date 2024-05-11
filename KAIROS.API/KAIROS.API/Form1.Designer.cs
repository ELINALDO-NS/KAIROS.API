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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            InsereCadastros = new TabPage();
            SpinPessoa = new PictureBox();
            SpinCargos = new PictureBox();
            SpinEstrutura = new PictureBox();
            SpinHorarios = new PictureBox();
            SpinValidaDados = new PictureBox();
            CheckPessoa = new PictureBox();
            CheckCargos = new PictureBox();
            CheckEstruturas = new PictureBox();
            CheckHorarios = new PictureBox();
            CheckValidaDados = new PictureBox();
            Lbl_StatusPessoa = new Label();
            Lbl_Pessoas = new Label();
            Lbl_Cargos = new Label();
            Lbl_Estruturas = new Label();
            Lbl_Horarios = new Label();
            Lbl_ValidaDados = new Label();
            btn_Iniciar = new Button();
            btn_Valida_Dados = new Button();
            btn_Lista_Horarios = new Button();
            Txb_CPFResponsavel = new TextBox();
            label6 = new Label();
            Txb_CNPJ = new TextBox();
            label5 = new Label();
            txb_Key = new TextBox();
            label4 = new Label();
            btn_LocalExcel = new Button();
            Txb_Excel = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            button2 = new Button();
            Btn_IsenreSaldo_Iniciar = new Button();
            txb_InsereSaldo_CaminhoExcel = new TextBox();
            label2 = new Label();
            btn_InsereSaldo_Usuario = new TextBox();
            label7 = new Label();
            btn_InsereSaldo_Senha = new TextBox();
            label8 = new Label();
            tabPage1 = new TabPage();
            Btn_Excel_Desligamento = new Button();
            Txb_Caminho_Excel_Desligamento = new TextBox();
            label3 = new Label();
            button1 = new Button();
            tabControl1.SuspendLayout();
            InsereCadastros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpinPessoa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpinCargos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpinEstrutura).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpinHorarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpinValidaDados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CheckPessoa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CheckCargos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CheckEstruturas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CheckHorarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CheckValidaDados).BeginInit();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(InsereCadastros);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(1, -2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(618, 407);
            tabControl1.TabIndex = 0;
            // 
            // InsereCadastros
            // 
            InsereCadastros.Controls.Add(SpinPessoa);
            InsereCadastros.Controls.Add(SpinCargos);
            InsereCadastros.Controls.Add(SpinEstrutura);
            InsereCadastros.Controls.Add(SpinHorarios);
            InsereCadastros.Controls.Add(SpinValidaDados);
            InsereCadastros.Controls.Add(CheckPessoa);
            InsereCadastros.Controls.Add(CheckCargos);
            InsereCadastros.Controls.Add(CheckEstruturas);
            InsereCadastros.Controls.Add(CheckHorarios);
            InsereCadastros.Controls.Add(CheckValidaDados);
            InsereCadastros.Controls.Add(Lbl_StatusPessoa);
            InsereCadastros.Controls.Add(Lbl_Pessoas);
            InsereCadastros.Controls.Add(Lbl_Cargos);
            InsereCadastros.Controls.Add(Lbl_Estruturas);
            InsereCadastros.Controls.Add(Lbl_Horarios);
            InsereCadastros.Controls.Add(Lbl_ValidaDados);
            InsereCadastros.Controls.Add(btn_Iniciar);
            InsereCadastros.Controls.Add(btn_Valida_Dados);
            InsereCadastros.Controls.Add(btn_Lista_Horarios);
            InsereCadastros.Controls.Add(Txb_CPFResponsavel);
            InsereCadastros.Controls.Add(label6);
            InsereCadastros.Controls.Add(Txb_CNPJ);
            InsereCadastros.Controls.Add(label5);
            InsereCadastros.Controls.Add(txb_Key);
            InsereCadastros.Controls.Add(label4);
            InsereCadastros.Controls.Add(btn_LocalExcel);
            InsereCadastros.Controls.Add(Txb_Excel);
            InsereCadastros.Controls.Add(label1);
            InsereCadastros.Location = new Point(4, 24);
            InsereCadastros.Name = "InsereCadastros";
            InsereCadastros.Padding = new Padding(3);
            InsereCadastros.Size = new Size(610, 379);
            InsereCadastros.TabIndex = 0;
            InsereCadastros.Text = "Insere Cadastros";
            InsereCadastros.UseVisualStyleBackColor = true;
            // 
            // SpinPessoa
            // 
            SpinPessoa.Image = (Image)resources.GetObject("SpinPessoa.Image");
            SpinPessoa.Location = new Point(522, 193);
            SpinPessoa.Name = "SpinPessoa";
            SpinPessoa.Size = new Size(30, 20);
            SpinPessoa.SizeMode = PictureBoxSizeMode.StretchImage;
            SpinPessoa.TabIndex = 31;
            SpinPessoa.TabStop = false;
            SpinPessoa.Visible = false;
            // 
            // SpinCargos
            // 
            SpinCargos.Image = (Image)resources.GetObject("SpinCargos.Image");
            SpinCargos.Location = new Point(324, 193);
            SpinCargos.Name = "SpinCargos";
            SpinCargos.Size = new Size(30, 20);
            SpinCargos.SizeMode = PictureBoxSizeMode.StretchImage;
            SpinCargos.TabIndex = 30;
            SpinCargos.TabStop = false;
            SpinCargos.Visible = false;
            // 
            // SpinEstrutura
            // 
            SpinEstrutura.Image = (Image)resources.GetObject("SpinEstrutura.Image");
            SpinEstrutura.Location = new Point(235, 193);
            SpinEstrutura.Name = "SpinEstrutura";
            SpinEstrutura.Size = new Size(30, 20);
            SpinEstrutura.SizeMode = PictureBoxSizeMode.StretchImage;
            SpinEstrutura.TabIndex = 29;
            SpinEstrutura.TabStop = false;
            SpinEstrutura.Visible = false;
            // 
            // SpinHorarios
            // 
            SpinHorarios.Image = (Image)resources.GetObject("SpinHorarios.Image");
            SpinHorarios.Location = new Point(424, 193);
            SpinHorarios.Name = "SpinHorarios";
            SpinHorarios.Size = new Size(30, 20);
            SpinHorarios.SizeMode = PictureBoxSizeMode.StretchImage;
            SpinHorarios.TabIndex = 28;
            SpinHorarios.TabStop = false;
            SpinHorarios.Visible = false;
            // 
            // SpinValidaDados
            // 
            SpinValidaDados.Image = (Image)resources.GetObject("SpinValidaDados.Image");
            SpinValidaDados.Location = new Point(123, 193);
            SpinValidaDados.Name = "SpinValidaDados";
            SpinValidaDados.Size = new Size(30, 20);
            SpinValidaDados.SizeMode = PictureBoxSizeMode.StretchImage;
            SpinValidaDados.TabIndex = 27;
            SpinValidaDados.TabStop = false;
            SpinValidaDados.Visible = false;
            // 
            // CheckPessoa
            // 
            CheckPessoa.Image = (Image)resources.GetObject("CheckPessoa.Image");
            CheckPessoa.Location = new Point(522, 192);
            CheckPessoa.Name = "CheckPessoa";
            CheckPessoa.Size = new Size(30, 20);
            CheckPessoa.SizeMode = PictureBoxSizeMode.StretchImage;
            CheckPessoa.TabIndex = 26;
            CheckPessoa.TabStop = false;
            CheckPessoa.Visible = false;
            // 
            // CheckCargos
            // 
            CheckCargos.Image = (Image)resources.GetObject("CheckCargos.Image");
            CheckCargos.Location = new Point(324, 193);
            CheckCargos.Name = "CheckCargos";
            CheckCargos.Size = new Size(30, 20);
            CheckCargos.SizeMode = PictureBoxSizeMode.StretchImage;
            CheckCargos.TabIndex = 25;
            CheckCargos.TabStop = false;
            CheckCargos.Visible = false;
            // 
            // CheckEstruturas
            // 
            CheckEstruturas.Image = (Image)resources.GetObject("CheckEstruturas.Image");
            CheckEstruturas.Location = new Point(235, 193);
            CheckEstruturas.Name = "CheckEstruturas";
            CheckEstruturas.Size = new Size(30, 20);
            CheckEstruturas.SizeMode = PictureBoxSizeMode.StretchImage;
            CheckEstruturas.TabIndex = 24;
            CheckEstruturas.TabStop = false;
            CheckEstruturas.Visible = false;
            // 
            // CheckHorarios
            // 
            CheckHorarios.Image = (Image)resources.GetObject("CheckHorarios.Image");
            CheckHorarios.Location = new Point(424, 193);
            CheckHorarios.Name = "CheckHorarios";
            CheckHorarios.Size = new Size(30, 20);
            CheckHorarios.SizeMode = PictureBoxSizeMode.StretchImage;
            CheckHorarios.TabIndex = 23;
            CheckHorarios.TabStop = false;
            CheckHorarios.Visible = false;
            // 
            // CheckValidaDados
            // 
            CheckValidaDados.Image = (Image)resources.GetObject("CheckValidaDados.Image");
            CheckValidaDados.Location = new Point(123, 193);
            CheckValidaDados.Name = "CheckValidaDados";
            CheckValidaDados.Size = new Size(30, 20);
            CheckValidaDados.SizeMode = PictureBoxSizeMode.StretchImage;
            CheckValidaDados.TabIndex = 22;
            CheckValidaDados.TabStop = false;
            CheckValidaDados.Visible = false;
            // 
            // Lbl_StatusPessoa
            // 
            Lbl_StatusPessoa.AutoSize = true;
            Lbl_StatusPessoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Lbl_StatusPessoa.Location = new Point(522, 196);
            Lbl_StatusPessoa.Name = "Lbl_StatusPessoa";
            Lbl_StatusPessoa.Size = new Size(0, 17);
            Lbl_StatusPessoa.TabIndex = 21;
            // 
            // Lbl_Pessoas
            // 
            Lbl_Pessoas.AutoSize = true;
            Lbl_Pessoas.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Lbl_Pessoas.Location = new Point(460, 196);
            Lbl_Pessoas.Name = "Lbl_Pessoas";
            Lbl_Pessoas.Size = new Size(56, 17);
            Lbl_Pessoas.TabIndex = 20;
            Lbl_Pessoas.Text = "Pessoas";
            Lbl_Pessoas.Visible = false;
            // 
            // Lbl_Cargos
            // 
            Lbl_Cargos.AutoSize = true;
            Lbl_Cargos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Lbl_Cargos.Location = new Point(271, 196);
            Lbl_Cargos.Name = "Lbl_Cargos";
            Lbl_Cargos.Size = new Size(50, 17);
            Lbl_Cargos.TabIndex = 19;
            Lbl_Cargos.Text = "Cargos";
            Lbl_Cargos.Visible = false;
            // 
            // Lbl_Estruturas
            // 
            Lbl_Estruturas.AutoSize = true;
            Lbl_Estruturas.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Lbl_Estruturas.Location = new Point(162, 196);
            Lbl_Estruturas.Name = "Lbl_Estruturas";
            Lbl_Estruturas.Size = new Size(70, 17);
            Lbl_Estruturas.TabIndex = 18;
            Lbl_Estruturas.Text = "Estruturas";
            Lbl_Estruturas.Visible = false;
            // 
            // Lbl_Horarios
            // 
            Lbl_Horarios.AutoSize = true;
            Lbl_Horarios.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Lbl_Horarios.Location = new Point(360, 196);
            Lbl_Horarios.Name = "Lbl_Horarios";
            Lbl_Horarios.Size = new Size(61, 17);
            Lbl_Horarios.TabIndex = 17;
            Lbl_Horarios.Text = "Horarios";
            Lbl_Horarios.Visible = false;
            // 
            // Lbl_ValidaDados
            // 
            Lbl_ValidaDados.AutoSize = true;
            Lbl_ValidaDados.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Lbl_ValidaDados.Location = new Point(7, 196);
            Lbl_ValidaDados.Name = "Lbl_ValidaDados";
            Lbl_ValidaDados.Size = new Size(113, 17);
            Lbl_ValidaDados.TabIndex = 16;
            Lbl_ValidaDados.Text = "Validando Dados";
            Lbl_ValidaDados.Visible = false;
            // 
            // btn_Iniciar
            // 
            btn_Iniciar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn_Iniciar.Location = new Point(268, 143);
            btn_Iniciar.Name = "btn_Iniciar";
            btn_Iniciar.Size = new Size(199, 26);
            btn_Iniciar.TabIndex = 15;
            btn_Iniciar.Text = "Iniciar";
            btn_Iniciar.TextAlign = ContentAlignment.TopCenter;
            btn_Iniciar.UseVisualStyleBackColor = true;
            btn_Iniciar.Click += btn_Iniciar_Click;
            // 
            // btn_Valida_Dados
            // 
            btn_Valida_Dados.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn_Valida_Dados.Location = new Point(268, 97);
            btn_Valida_Dados.Name = "btn_Valida_Dados";
            btn_Valida_Dados.Size = new Size(199, 26);
            btn_Valida_Dados.TabIndex = 14;
            btn_Valida_Dados.Text = "Valida Dados";
            btn_Valida_Dados.TextAlign = ContentAlignment.TopCenter;
            btn_Valida_Dados.UseVisualStyleBackColor = true;
            btn_Valida_Dados.Click += btn_Valida_Dados_Click;
            // 
            // btn_Lista_Horarios
            // 
            btn_Lista_Horarios.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn_Lista_Horarios.Location = new Point(268, 59);
            btn_Lista_Horarios.Name = "btn_Lista_Horarios";
            btn_Lista_Horarios.Size = new Size(199, 26);
            btn_Lista_Horarios.TabIndex = 13;
            btn_Lista_Horarios.Text = "Lista Horarios";
            btn_Lista_Horarios.TextAlign = ContentAlignment.TopCenter;
            btn_Lista_Horarios.UseVisualStyleBackColor = true;
            btn_Lista_Horarios.Click += btn_Lista_Horarios_Click;
            // 
            // Txb_CPFResponsavel
            // 
            Txb_CPFResponsavel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Txb_CPFResponsavel.Location = new Point(123, 143);
            Txb_CPFResponsavel.Name = "Txb_CPFResponsavel";
            Txb_CPFResponsavel.Size = new Size(130, 25);
            Txb_CPFResponsavel.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label6.Location = new Point(7, 151);
            label6.Name = "label6";
            label6.Size = new Size(111, 17);
            label6.TabIndex = 11;
            label6.Text = "CPF Responsavel";
            // 
            // Txb_CNPJ
            // 
            Txb_CNPJ.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Txb_CNPJ.Location = new Point(62, 97);
            Txb_CNPJ.Name = "Txb_CNPJ";
            Txb_CNPJ.Size = new Size(193, 25);
            Txb_CNPJ.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label5.Location = new Point(7, 105);
            label5.Name = "label5";
            label5.Size = new Size(39, 17);
            label5.TabIndex = 9;
            label5.Text = "CNPJ";
            // 
            // txb_Key
            // 
            txb_Key.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            txb_Key.Location = new Point(62, 59);
            txb_Key.Name = "txb_Key";
            txb_Key.Size = new Size(193, 25);
            txb_Key.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(7, 67);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 7;
            label4.Text = "Key";
            // 
            // btn_LocalExcel
            // 
            btn_LocalExcel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn_LocalExcel.Location = new Point(417, 13);
            btn_LocalExcel.Name = "btn_LocalExcel";
            btn_LocalExcel.Size = new Size(58, 23);
            btn_LocalExcel.TabIndex = 2;
            btn_LocalExcel.Text = "...";
            btn_LocalExcel.TextAlign = ContentAlignment.TopCenter;
            btn_LocalExcel.UseVisualStyleBackColor = true;
            btn_LocalExcel.Click += btn_LocalExcel_Click;
            // 
            // Txb_Excel
            // 
            Txb_Excel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Txb_Excel.Location = new Point(113, 11);
            Txb_Excel.Name = "Txb_Excel";
            Txb_Excel.ReadOnly = true;
            Txb_Excel.Size = new Size(287, 25);
            Txb_Excel.TabIndex = 1;
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
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(Btn_IsenreSaldo_Iniciar);
            tabPage2.Controls.Add(txb_InsereSaldo_CaminhoExcel);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(btn_InsereSaldo_Usuario);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(btn_InsereSaldo_Senha);
            tabPage2.Controls.Add(label8);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(610, 379);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Insere Saldo BH";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button2.Location = new Point(419, 12);
            button2.Name = "button2";
            button2.Size = new Size(58, 23);
            button2.TabIndex = 5;
            button2.Text = "...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Btn_IsenreSaldo_Iniciar
            // 
            Btn_IsenreSaldo_Iniciar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Btn_IsenreSaldo_Iniciar.Location = new Point(102, 109);
            Btn_IsenreSaldo_Iniciar.Name = "Btn_IsenreSaldo_Iniciar";
            Btn_IsenreSaldo_Iniciar.Size = new Size(152, 27);
            Btn_IsenreSaldo_Iniciar.TabIndex = 23;
            Btn_IsenreSaldo_Iniciar.Text = "Iniciar";
            Btn_IsenreSaldo_Iniciar.UseVisualStyleBackColor = true;
            Btn_IsenreSaldo_Iniciar.Click += button1_Click;
            // 
            // txb_InsereSaldo_CaminhoExcel
            // 
            txb_InsereSaldo_CaminhoExcel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            txb_InsereSaldo_CaminhoExcel.Location = new Point(115, 10);
            txb_InsereSaldo_CaminhoExcel.Name = "txb_InsereSaldo_CaminhoExcel";
            txb_InsereSaldo_CaminhoExcel.ReadOnly = true;
            txb_InsereSaldo_CaminhoExcel.Size = new Size(287, 25);
            txb_InsereSaldo_CaminhoExcel.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(9, 17);
            label2.Name = "label2";
            label2.Size = new Size(98, 17);
            label2.TabIndex = 3;
            label2.Text = "Caminho Excel";
            // 
            // btn_InsereSaldo_Usuario
            // 
            btn_InsereSaldo_Usuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn_InsereSaldo_Usuario.Location = new Point(61, 51);
            btn_InsereSaldo_Usuario.Name = "btn_InsereSaldo_Usuario";
            btn_InsereSaldo_Usuario.Size = new Size(193, 25);
            btn_InsereSaldo_Usuario.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label7.Location = new Point(6, 59);
            label7.Name = "label7";
            label7.Size = new Size(55, 17);
            label7.TabIndex = 21;
            label7.Text = "Usuario";
            // 
            // btn_InsereSaldo_Senha
            // 
            btn_InsereSaldo_Senha.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn_InsereSaldo_Senha.Location = new Point(314, 51);
            btn_InsereSaldo_Senha.Name = "btn_InsereSaldo_Senha";
            btn_InsereSaldo_Senha.Size = new Size(97, 25);
            btn_InsereSaldo_Senha.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label8.Location = new Point(267, 59);
            label8.Name = "label8";
            label8.Size = new Size(45, 17);
            label8.TabIndex = 19;
            label8.Text = "Senha";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(Btn_Excel_Desligamento);
            tabPage1.Controls.Add(Txb_Caminho_Excel_Desligamento);
            tabPage1.Controls.Add(label3);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(610, 379);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Insere Desligamento";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // Btn_Excel_Desligamento
            // 
            Btn_Excel_Desligamento.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Btn_Excel_Desligamento.Location = new Point(417, 14);
            Btn_Excel_Desligamento.Name = "Btn_Excel_Desligamento";
            Btn_Excel_Desligamento.Size = new Size(58, 23);
            Btn_Excel_Desligamento.TabIndex = 5;
            Btn_Excel_Desligamento.Text = "...";
            Btn_Excel_Desligamento.TextAlign = ContentAlignment.TopCenter;
            Btn_Excel_Desligamento.UseVisualStyleBackColor = true;
            Btn_Excel_Desligamento.Click += Btn_Excel_Desligamento_Click;
            // 
            // Txb_Caminho_Excel_Desligamento
            // 
            Txb_Caminho_Excel_Desligamento.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Txb_Caminho_Excel_Desligamento.Location = new Point(113, 12);
            Txb_Caminho_Excel_Desligamento.Name = "Txb_Caminho_Excel_Desligamento";
            Txb_Caminho_Excel_Desligamento.ReadOnly = true;
            Txb_Caminho_Excel_Desligamento.Size = new Size(287, 25);
            Txb_Caminho_Excel_Desligamento.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(7, 19);
            label3.Name = "label3";
            label3.Size = new Size(98, 17);
            label3.TabIndex = 3;
            label3.Text = "Caminho Excel";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(200, 68);
            button1.Name = "button1";
            button1.Size = new Size(117, 32);
            button1.TabIndex = 6;
            button1.Text = "Iniciar";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 407);
            Controls.Add(tabControl1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "KAIROS.API";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            InsereCadastros.ResumeLayout(false);
            InsereCadastros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpinPessoa).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpinCargos).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpinEstrutura).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpinHorarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpinValidaDados).EndInit();
            ((System.ComponentModel.ISupportInitialize)CheckPessoa).EndInit();
            ((System.ComponentModel.ISupportInitialize)CheckCargos).EndInit();
            ((System.ComponentModel.ISupportInitialize)CheckEstruturas).EndInit();
            ((System.ComponentModel.ISupportInitialize)CheckHorarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)CheckValidaDados).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage InsereCadastros;
        private TabPage tabPage2;
        private Button btn_LocalExcel;
        private TextBox Txb_Excel;
        private Label label1;
        private TextBox txb_Key;
        private Label label4;
        private Button btn_Iniciar;
        private Button btn_Valida_Dados;
        private Button btn_Lista_Horarios;
        private TextBox Txb_CPFResponsavel;
        private Label label6;
        private TextBox Txb_CNPJ;
        private Label label5;
        private Button Btn_IsenreSaldo_Iniciar;
        private TextBox btn_InsereSaldo_Usuario;
        private Label label7;
        private TextBox btn_InsereSaldo_Senha;
        private Label label8;
        private PictureBox CheckValidaDados;
        private Label Lbl_StatusPessoa;
        private Label Lbl_Pessoas;
        private Label Lbl_Cargos;
        private Label Lbl_Estruturas;
        private Label Lbl_Horarios;
        private Label Lbl_ValidaDados;
        private PictureBox CheckPessoa;
        private PictureBox CheckCargos;
        private PictureBox CheckEstruturas;
        private PictureBox CheckHorarios;
        private PictureBox SpinCargos;
        private PictureBox SpinEstrutura;
        private PictureBox SpinHorarios;
        public PictureBox SpinValidaDados;
        private PictureBox SpinPessoa;
        private Button button2;
        private TextBox txb_InsereSaldo_CaminhoExcel;
        private Label label2;
        private TabPage tabPage1;
        private Button Btn_Excel_Desligamento;
        private TextBox Txb_Caminho_Excel_Desligamento;
        private Label label3;
        private Button button1;
    }
}
