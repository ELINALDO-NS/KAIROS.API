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
            button1 = new Button();
            Btn_Excel_Desligamento = new Button();
            Txb_Caminho_Excel_Desligamento = new TextBox();
            label3 = new Label();
            tabPage3 = new TabPage();
            Lbl_StatusAlteraPessoa = new Label();
            groupBox1 = new GroupBox();
            RB_PIS = new RadioButton();
            RB_CPF = new RadioButton();
            RB_Matricula = new RadioButton();
            Btn_Iniciar_AlteraPessoa = new Button();
            label12 = new Label();
            Check_alt_Sexo = new CheckBox();
            Check_alt_Departamento = new CheckBox();
            Check_alt_Cargo = new CheckBox();
            Check_alt_Email = new CheckBox();
            Check_alt_Celular = new CheckBox();
            Check_alt_Horario = new CheckBox();
            Check_alt_Admissao = new CheckBox();
            Check_alt_Matricula = new CheckBox();
            Check_alt_RG = new CheckBox();
            Check_alt_CPF = new CheckBox();
            Check_alt_Nascimento = new CheckBox();
            Check_alt_Crachar = new CheckBox();
            Check_alt_PIS = new CheckBox();
            Check_alt_Nome = new CheckBox();
            btn_Importar = new Button();
            Txb_Alt_Pessoa_CNPJ = new TextBox();
            label10 = new Label();
            Txb_Alt_Pessoa_Key = new TextBox();
            label11 = new Label();
            Grid_Pessoa = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Matricula = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            PIS = new DataGridViewTextBoxColumn();
            Cracha = new DataGridViewTextBoxColumn();
            DataDeNascimento = new DataGridViewTextBoxColumn();
            DataDeAdmissao = new DataGridViewTextBoxColumn();
            RG = new DataGridViewTextBoxColumn();
            CPF = new DataGridViewTextBoxColumn();
            CELULAR = new DataGridViewTextBoxColumn();
            EMAIL = new DataGridViewTextBoxColumn();
            DEPARTAMENTO = new DataGridViewTextBoxColumn();
            HORARIO = new DataGridViewTextBoxColumn();
            CARGO = new DataGridViewTextBoxColumn();
            SEXO = new DataGridViewTextBoxColumn();
            Btn_AtualizaDados = new Button();
            Btn_CaminExcel_Alt_Pessoa = new Button();
            Txb_Camin_Excel_Altera_Pessoa = new TextBox();
            label9 = new Label();
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
            tabPage3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Grid_Pessoa).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(InsereCadastros);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(1, -2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1435, 407);
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
            InsereCadastros.Size = new Size(1427, 379);
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
            tabPage2.Size = new Size(1427, 379);
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
            tabPage1.Size = new Size(1427, 379);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Insere Desligamento";
            tabPage1.UseVisualStyleBackColor = true;
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
            // tabPage3
            // 
            tabPage3.Controls.Add(Lbl_StatusAlteraPessoa);
            tabPage3.Controls.Add(groupBox1);
            tabPage3.Controls.Add(Btn_Iniciar_AlteraPessoa);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(Check_alt_Sexo);
            tabPage3.Controls.Add(Check_alt_Departamento);
            tabPage3.Controls.Add(Check_alt_Cargo);
            tabPage3.Controls.Add(Check_alt_Email);
            tabPage3.Controls.Add(Check_alt_Celular);
            tabPage3.Controls.Add(Check_alt_Horario);
            tabPage3.Controls.Add(Check_alt_Admissao);
            tabPage3.Controls.Add(Check_alt_Matricula);
            tabPage3.Controls.Add(Check_alt_RG);
            tabPage3.Controls.Add(Check_alt_CPF);
            tabPage3.Controls.Add(Check_alt_Nascimento);
            tabPage3.Controls.Add(Check_alt_Crachar);
            tabPage3.Controls.Add(Check_alt_PIS);
            tabPage3.Controls.Add(Check_alt_Nome);
            tabPage3.Controls.Add(btn_Importar);
            tabPage3.Controls.Add(Txb_Alt_Pessoa_CNPJ);
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(Txb_Alt_Pessoa_Key);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(Grid_Pessoa);
            tabPage3.Controls.Add(Btn_AtualizaDados);
            tabPage3.Controls.Add(Btn_CaminExcel_Alt_Pessoa);
            tabPage3.Controls.Add(Txb_Camin_Excel_Altera_Pessoa);
            tabPage3.Controls.Add(label9);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1427, 379);
            tabPage3.TabIndex = 3;
            tabPage3.Text = "Altera Pessoa";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Lbl_StatusAlteraPessoa
            // 
            Lbl_StatusAlteraPessoa.AutoSize = true;
            Lbl_StatusAlteraPessoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Lbl_StatusAlteraPessoa.Location = new Point(434, 118);
            Lbl_StatusAlteraPessoa.Name = "Lbl_StatusAlteraPessoa";
            Lbl_StatusAlteraPessoa.Size = new Size(0, 17);
            Lbl_StatusAlteraPessoa.TabIndex = 40;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RB_PIS);
            groupBox1.Controls.Add(RB_CPF);
            groupBox1.Controls.Add(RB_Matricula);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(5, 92);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(260, 59);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "Campo Chave do Funcionario";
            // 
            // RB_PIS
            // 
            RB_PIS.AutoSize = true;
            RB_PIS.Location = new Point(205, 26);
            RB_PIS.Name = "RB_PIS";
            RB_PIS.Size = new Size(43, 19);
            RB_PIS.TabIndex = 41;
            RB_PIS.Text = "PIS";
            RB_PIS.UseVisualStyleBackColor = true;
            // 
            // RB_CPF
            // 
            RB_CPF.AutoSize = true;
            RB_CPF.Location = new Point(125, 26);
            RB_CPF.Name = "RB_CPF";
            RB_CPF.Size = new Size(45, 19);
            RB_CPF.TabIndex = 40;
            RB_CPF.Text = "CPF";
            RB_CPF.UseVisualStyleBackColor = true;
            // 
            // RB_Matricula
            // 
            RB_Matricula.AutoSize = true;
            RB_Matricula.Checked = true;
            RB_Matricula.Location = new Point(13, 26);
            RB_Matricula.Name = "RB_Matricula";
            RB_Matricula.Size = new Size(77, 19);
            RB_Matricula.TabIndex = 39;
            RB_Matricula.TabStop = true;
            RB_Matricula.Text = "Matricula";
            RB_Matricula.UseVisualStyleBackColor = true;
            // 
            // Btn_Iniciar_AlteraPessoa
            // 
            Btn_Iniciar_AlteraPessoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Iniciar_AlteraPessoa.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Iniciar_AlteraPessoa.Location = new Point(290, 110);
            Btn_Iniciar_AlteraPessoa.Name = "Btn_Iniciar_AlteraPessoa";
            Btn_Iniciar_AlteraPessoa.Size = new Size(122, 27);
            Btn_Iniciar_AlteraPessoa.TabIndex = 35;
            Btn_Iniciar_AlteraPessoa.Text = "Iniciar";
            Btn_Iniciar_AlteraPessoa.UseVisualStyleBackColor = true;
            Btn_Iniciar_AlteraPessoa.Click += Btn_Iniciar_AlteraPessoa_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(682, 3);
            label12.Name = "label12";
            label12.Size = new Size(243, 17);
            label12.TabIndex = 34;
            label12.Text = "Selecione os item que serão alterado !";
            // 
            // Check_alt_Sexo
            // 
            Check_alt_Sexo.AutoSize = true;
            Check_alt_Sexo.Location = new Point(1343, 154);
            Check_alt_Sexo.Name = "Check_alt_Sexo";
            Check_alt_Sexo.Size = new Size(15, 14);
            Check_alt_Sexo.TabIndex = 33;
            Check_alt_Sexo.UseVisualStyleBackColor = true;
            // 
            // Check_alt_Departamento
            // 
            Check_alt_Departamento.AutoSize = true;
            Check_alt_Departamento.Location = new Point(1083, 153);
            Check_alt_Departamento.Name = "Check_alt_Departamento";
            Check_alt_Departamento.Size = new Size(15, 14);
            Check_alt_Departamento.TabIndex = 32;
            Check_alt_Departamento.UseVisualStyleBackColor = true;
            // 
            // Check_alt_Cargo
            // 
            Check_alt_Cargo.AutoSize = true;
            Check_alt_Cargo.Location = new Point(1282, 156);
            Check_alt_Cargo.Name = "Check_alt_Cargo";
            Check_alt_Cargo.Size = new Size(15, 14);
            Check_alt_Cargo.TabIndex = 31;
            Check_alt_Cargo.UseVisualStyleBackColor = true;
            // 
            // Check_alt_Email
            // 
            Check_alt_Email.AutoSize = true;
            Check_alt_Email.Location = new Point(982, 155);
            Check_alt_Email.Name = "Check_alt_Email";
            Check_alt_Email.Size = new Size(15, 14);
            Check_alt_Email.TabIndex = 30;
            Check_alt_Email.UseVisualStyleBackColor = true;
            // 
            // Check_alt_Celular
            // 
            Check_alt_Celular.AutoSize = true;
            Check_alt_Celular.Location = new Point(882, 155);
            Check_alt_Celular.Name = "Check_alt_Celular";
            Check_alt_Celular.Size = new Size(15, 14);
            Check_alt_Celular.TabIndex = 29;
            Check_alt_Celular.UseVisualStyleBackColor = true;
            // 
            // Check_alt_Horario
            // 
            Check_alt_Horario.AutoSize = true;
            Check_alt_Horario.Location = new Point(1180, 157);
            Check_alt_Horario.Name = "Check_alt_Horario";
            Check_alt_Horario.Size = new Size(15, 14);
            Check_alt_Horario.TabIndex = 28;
            Check_alt_Horario.UseVisualStyleBackColor = true;
            // 
            // Check_alt_Admissao
            // 
            Check_alt_Admissao.AutoSize = true;
            Check_alt_Admissao.Location = new Point(583, 156);
            Check_alt_Admissao.Name = "Check_alt_Admissao";
            Check_alt_Admissao.Size = new Size(15, 14);
            Check_alt_Admissao.TabIndex = 27;
            Check_alt_Admissao.UseVisualStyleBackColor = true;
            // 
            // Check_alt_Matricula
            // 
            Check_alt_Matricula.AutoSize = true;
            Check_alt_Matricula.Location = new Point(81, 157);
            Check_alt_Matricula.Name = "Check_alt_Matricula";
            Check_alt_Matricula.Size = new Size(15, 14);
            Check_alt_Matricula.TabIndex = 26;
            Check_alt_Matricula.UseVisualStyleBackColor = true;
            // 
            // Check_alt_RG
            // 
            Check_alt_RG.AutoSize = true;
            Check_alt_RG.Location = new Point(682, 158);
            Check_alt_RG.Name = "Check_alt_RG";
            Check_alt_RG.Size = new Size(15, 14);
            Check_alt_RG.TabIndex = 25;
            Check_alt_RG.UseVisualStyleBackColor = true;
            // 
            // Check_alt_CPF
            // 
            Check_alt_CPF.AutoSize = true;
            Check_alt_CPF.Location = new Point(782, 157);
            Check_alt_CPF.Name = "Check_alt_CPF";
            Check_alt_CPF.Size = new Size(15, 14);
            Check_alt_CPF.TabIndex = 24;
            Check_alt_CPF.UseVisualStyleBackColor = true;
            // 
            // Check_alt_Nascimento
            // 
            Check_alt_Nascimento.AutoSize = true;
            Check_alt_Nascimento.Location = new Point(484, 158);
            Check_alt_Nascimento.Name = "Check_alt_Nascimento";
            Check_alt_Nascimento.Size = new Size(15, 14);
            Check_alt_Nascimento.TabIndex = 23;
            Check_alt_Nascimento.UseVisualStyleBackColor = true;
            // 
            // Check_alt_Crachar
            // 
            Check_alt_Crachar.AutoSize = true;
            Check_alt_Crachar.Location = new Point(381, 156);
            Check_alt_Crachar.Name = "Check_alt_Crachar";
            Check_alt_Crachar.Size = new Size(15, 14);
            Check_alt_Crachar.TabIndex = 22;
            Check_alt_Crachar.UseVisualStyleBackColor = true;
            // 
            // Check_alt_PIS
            // 
            Check_alt_PIS.AutoSize = true;
            Check_alt_PIS.Location = new Point(281, 157);
            Check_alt_PIS.Name = "Check_alt_PIS";
            Check_alt_PIS.Size = new Size(15, 14);
            Check_alt_PIS.TabIndex = 21;
            Check_alt_PIS.UseVisualStyleBackColor = true;
            // 
            // Check_alt_Nome
            // 
            Check_alt_Nome.AutoSize = true;
            Check_alt_Nome.Location = new Point(181, 157);
            Check_alt_Nome.Name = "Check_alt_Nome";
            Check_alt_Nome.Size = new Size(15, 14);
            Check_alt_Nome.TabIndex = 20;
            Check_alt_Nome.UseVisualStyleBackColor = true;
            // 
            // btn_Importar
            // 
            btn_Importar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Importar.ImageAlign = ContentAlignment.MiddleRight;
            btn_Importar.Location = new Point(538, 17);
            btn_Importar.Name = "btn_Importar";
            btn_Importar.Size = new Size(70, 25);
            btn_Importar.TabIndex = 19;
            btn_Importar.Text = "Importar";
            btn_Importar.UseVisualStyleBackColor = true;
            btn_Importar.Click += btn_Importar_Click;
            // 
            // Txb_Alt_Pessoa_CNPJ
            // 
            Txb_Alt_Pessoa_CNPJ.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Txb_Alt_Pessoa_CNPJ.Location = new Point(60, 17);
            Txb_Alt_Pessoa_CNPJ.Name = "Txb_Alt_Pessoa_CNPJ";
            Txb_Alt_Pessoa_CNPJ.Size = new Size(193, 25);
            Txb_Alt_Pessoa_CNPJ.TabIndex = 18;
            Txb_Alt_Pessoa_CNPJ.Text = " 33.794.132/0003-53 \t";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label10.Location = new Point(5, 25);
            label10.Name = "label10";
            label10.Size = new Size(39, 17);
            label10.TabIndex = 17;
            label10.Text = "CNPJ";
            // 
            // Txb_Alt_Pessoa_Key
            // 
            Txb_Alt_Pessoa_Key.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Txb_Alt_Pessoa_Key.Location = new Point(326, 17);
            Txb_Alt_Pessoa_Key.Name = "Txb_Alt_Pessoa_Key";
            Txb_Alt_Pessoa_Key.Size = new Size(193, 25);
            Txb_Alt_Pessoa_Key.TabIndex = 16;
            Txb_Alt_Pessoa_Key.Text = "64d11909-3a4b-4e2b-9742-04d9c85abea4";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(271, 25);
            label11.Name = "label11";
            label11.Size = new Size(44, 15);
            label11.TabIndex = 15;
            label11.Text = "CHAVE";
            // 
            // Grid_Pessoa
            // 
            Grid_Pessoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_Pessoa.Columns.AddRange(new DataGridViewColumn[] { Id, Matricula, Nome, PIS, Cracha, DataDeNascimento, DataDeAdmissao, RG, CPF, CELULAR, EMAIL, DEPARTAMENTO, HORARIO, CARGO, SEXO });
            Grid_Pessoa.Location = new Point(0, 151);
            Grid_Pessoa.Name = "Grid_Pessoa";
            Grid_Pessoa.RowHeadersVisible = false;
            Grid_Pessoa.Size = new Size(1360, 225);
            Grid_Pessoa.TabIndex = 10;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Visible = false;
            // 
            // Matricula
            // 
            Matricula.HeaderText = "Matricula";
            Matricula.Name = "Matricula";
            // 
            // Nome
            // 
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            // 
            // PIS
            // 
            PIS.HeaderText = "PIS";
            PIS.Name = "PIS";
            // 
            // Cracha
            // 
            Cracha.HeaderText = "Cracha";
            Cracha.Name = "Cracha";
            // 
            // DataDeNascimento
            // 
            DataDeNascimento.HeaderText = "DATA DE NASCIMENTO";
            DataDeNascimento.Name = "DataDeNascimento";
            // 
            // DataDeAdmissao
            // 
            DataDeAdmissao.HeaderText = "DATA DE ADMISSÃO";
            DataDeAdmissao.Name = "DataDeAdmissao";
            // 
            // RG
            // 
            RG.HeaderText = "RG";
            RG.Name = "RG";
            // 
            // CPF
            // 
            CPF.HeaderText = "CPF";
            CPF.Name = "CPF";
            // 
            // CELULAR
            // 
            CELULAR.HeaderText = "CELULAR";
            CELULAR.Name = "CELULAR";
            // 
            // EMAIL
            // 
            EMAIL.HeaderText = "E-MAIL";
            EMAIL.Name = "EMAIL";
            // 
            // DEPARTAMENTO
            // 
            DEPARTAMENTO.HeaderText = "DEPARTAMENTO";
            DEPARTAMENTO.Name = "DEPARTAMENTO";
            // 
            // HORARIO
            // 
            HORARIO.HeaderText = "HORARIO";
            HORARIO.Name = "HORARIO";
            // 
            // CARGO
            // 
            CARGO.HeaderText = "CARGO";
            CARGO.Name = "CARGO";
            // 
            // SEXO
            // 
            SEXO.HeaderText = "SEXO";
            SEXO.Name = "SEXO";
            // 
            // Btn_AtualizaDados
            // 
            Btn_AtualizaDados.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_AtualizaDados.ImageAlign = ContentAlignment.MiddleRight;
            Btn_AtualizaDados.Location = new Point(498, 58);
            Btn_AtualizaDados.Name = "Btn_AtualizaDados";
            Btn_AtualizaDados.Size = new Size(122, 27);
            Btn_AtualizaDados.TabIndex = 9;
            Btn_AtualizaDados.Text = "Atualizar Lista";
            Btn_AtualizaDados.UseVisualStyleBackColor = true;
            Btn_AtualizaDados.Click += Btn_AtualizaDados_Click_1;
            // 
            // Btn_CaminExcel_Alt_Pessoa
            // 
            Btn_CaminExcel_Alt_Pessoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Btn_CaminExcel_Alt_Pessoa.Location = new Point(415, 62);
            Btn_CaminExcel_Alt_Pessoa.Name = "Btn_CaminExcel_Alt_Pessoa";
            Btn_CaminExcel_Alt_Pessoa.Size = new Size(58, 23);
            Btn_CaminExcel_Alt_Pessoa.TabIndex = 8;
            Btn_CaminExcel_Alt_Pessoa.Text = "...";
            Btn_CaminExcel_Alt_Pessoa.TextAlign = ContentAlignment.TopCenter;
            Btn_CaminExcel_Alt_Pessoa.UseVisualStyleBackColor = true;
            Btn_CaminExcel_Alt_Pessoa.Click += Btn_CaminExcel_Alt_Pessoa_Click;
            // 
            // Txb_Camin_Excel_Altera_Pessoa
            // 
            Txb_Camin_Excel_Altera_Pessoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Txb_Camin_Excel_Altera_Pessoa.Location = new Point(111, 60);
            Txb_Camin_Excel_Altera_Pessoa.Name = "Txb_Camin_Excel_Altera_Pessoa";
            Txb_Camin_Excel_Altera_Pessoa.ReadOnly = true;
            Txb_Camin_Excel_Altera_Pessoa.Size = new Size(287, 25);
            Txb_Camin_Excel_Altera_Pessoa.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label9.Location = new Point(5, 67);
            label9.Name = "label9";
            label9.Size = new Size(98, 17);
            label9.TabIndex = 6;
            label9.Text = "Caminho Excel";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 407);
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
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Grid_Pessoa).EndInit();
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
        private TabPage tabPage3;
        private Button Btn_AtualizaDados;
        private Button Btn_CaminExcel_Alt_Pessoa;
        private TextBox Txb_Camin_Excel_Altera_Pessoa;
        private Label label9;
        private DataGridView Grid_Pessoa;
        private Button btn_Importar;
        private TextBox Txb_Alt_Pessoa_CNPJ;
        private Label label10;
        private TextBox Txb_Alt_Pessoa_Key;
        private Label label11;
        private CheckBox Check_alt_Nascimento;
        private CheckBox Check_alt_Crachar;
        private CheckBox Check_alt_PIS;
        private CheckBox Check_alt_Nome;
        private CheckBox Check_alt_RG;
        private CheckBox Check_alt_CPF;
        private CheckBox Check_alt_Matricula;
        private CheckBox Check_alt_Admissao;
        private CheckBox Check_alt_Departamento;
        private CheckBox Check_alt_Cargo;
        private CheckBox Check_alt_Email;
        private CheckBox Check_alt_Celular;
        private CheckBox Check_alt_Horario;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Matricula;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn PIS;
        private DataGridViewTextBoxColumn Cracha;
        private DataGridViewTextBoxColumn DataDeNascimento;
        private DataGridViewTextBoxColumn DataDeAdmissao;
        private DataGridViewTextBoxColumn RG;
        private DataGridViewTextBoxColumn CPF;
        private DataGridViewTextBoxColumn CELULAR;
        private DataGridViewTextBoxColumn EMAIL;
        private DataGridViewTextBoxColumn DEPARTAMENTO;
        private DataGridViewTextBoxColumn HORARIO;
        private DataGridViewTextBoxColumn CARGO;
        private DataGridViewTextBoxColumn SEXO;
        private CheckBox Check_alt_Sexo;
        private Label label12;
        private Button Btn_Iniciar_AlteraPessoa;
        private GroupBox groupBox1;
        private RadioButton RB_PIS;
        private RadioButton RB_CPF;
        private RadioButton RB_Matricula;
        private Label Lbl_StatusAlteraPessoa;
    }
}
