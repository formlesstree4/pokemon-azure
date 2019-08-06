namespace MercuryClientTestProgram
{
    partial class FrmMain
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
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lvSearchResults = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.btnSearchReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbSearchGender = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudSearchHigh = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudSearchLow = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSearchPokemon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbUpload = new System.Windows.Forms.GroupBox();
            this.tcUpload = new System.Windows.Forms.TabControl();
            this.tpData = new System.Windows.Forms.TabPage();
            this.pbUpload = new System.Windows.Forms.PictureBox();
            this.btnUploadReset = new System.Windows.Forms.Button();
            this.cbUploadPokemon = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbUploadGender = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nudUploadLevel = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.tpRequirements = new System.Windows.Forms.TabPage();
            this.pbRequirements = new System.Windows.Forms.PictureBox();
            this.btnRequirementsReset = new System.Windows.Forms.Button();
            this.cbRequirementsPokemon = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbRequirementsGender = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nudRequirementsLow = new System.Windows.Forms.NumericUpDown();
            this.nudRequirementsHigh = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.msUploadOptions = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retrievePokémonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.cmsSearch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadAdditionalResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbLogin.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSearchHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSearchLow)).BeginInit();
            this.gbUpload.SuspendLayout();
            this.tcUpload.SuspendLayout();
            this.tpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUploadLevel)).BeginInit();
            this.tpRequirements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRequirements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRequirementsLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRequirementsHigh)).BeginInit();
            this.msUploadOptions.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.cmsSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.btnDisconnect);
            this.gbLogin.Controls.Add(this.btnConnect);
            this.gbLogin.Controls.Add(this.tbPassword);
            this.gbLogin.Controls.Add(this.label2);
            this.gbLogin.Controls.Add(this.tbUid);
            this.gbLogin.Controls.Add(this.label1);
            this.gbLogin.Location = new System.Drawing.Point(12, 12);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(371, 100);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Login Information";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(290, 71);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "&Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.BtnDisconnectClick);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(159, 71);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnectClick);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(159, 45);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(206, 20);
            this.tbPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // tbUid
            // 
            this.tbUid.Location = new System.Drawing.Point(159, 19);
            this.tbUid.Name = "tbUid";
            this.tbUid.ReadOnly = true;
            this.tbUid.Size = new System.Drawing.Size(206, 20);
            this.tbUid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unique Identification Number:";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.groupBox6);
            this.gbSearch.Controls.Add(this.groupBox5);
            this.gbSearch.Enabled = false;
            this.gbSearch.Location = new System.Drawing.Point(389, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(293, 334);
            this.gbSearch.TabIndex = 1;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "&Searching";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lvSearchResults);
            this.groupBox6.Location = new System.Drawing.Point(6, 180);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(275, 148);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Search Results";
            // 
            // lvSearchResults
            // 
            this.lvSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chLevel,
            this.chGender});
            this.lvSearchResults.ContextMenuStrip = this.cmsSearch;
            this.lvSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSearchResults.Location = new System.Drawing.Point(3, 16);
            this.lvSearchResults.Name = "lvSearchResults";
            this.lvSearchResults.Size = new System.Drawing.Size(269, 129);
            this.lvSearchResults.TabIndex = 0;
            this.lvSearchResults.UseCompatibleStateImageBehavior = false;
            this.lvSearchResults.View = System.Windows.Forms.View.Details;
            this.lvSearchResults.DoubleClick += new System.EventHandler(this.LvSearchResultsDoubleClick);
            // 
            // chName
            // 
            this.chName.Text = "Pokémon";
            this.chName.Width = 145;
            // 
            // chLevel
            // 
            this.chLevel.Text = "Level";
            // 
            // chGender
            // 
            this.chGender.Text = "Gender";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pbSearch);
            this.groupBox5.Controls.Add(this.btnSearchReset);
            this.groupBox5.Controls.Add(this.btnSearch);
            this.groupBox5.Controls.Add(this.cbSearchGender);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.nudSearchHigh);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.nudSearchLow);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.cbSearchPokemon);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(6, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(281, 155);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Search Parameters";
            // 
            // pbSearch
            // 
            this.pbSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSearch.Location = new System.Drawing.Point(3, 84);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(64, 64);
            this.pbSearch.TabIndex = 8;
            this.pbSearch.TabStop = false;
            // 
            // btnSearchReset
            // 
            this.btnSearchReset.Location = new System.Drawing.Point(200, 125);
            this.btnSearchReset.Name = "btnSearchReset";
            this.btnSearchReset.Size = new System.Drawing.Size(75, 23);
            this.btnSearchReset.TabIndex = 7;
            this.btnSearchReset.Text = "&Reset";
            this.btnSearchReset.UseVisualStyleBackColor = true;
            this.btnSearchReset.Click += new System.EventHandler(this.BtnSearchResetClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(102, 125);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
            // 
            // cbSearchGender
            // 
            this.cbSearchGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchGender.FormattingEnabled = true;
            this.cbSearchGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Any"});
            this.cbSearchGender.Location = new System.Drawing.Point(150, 98);
            this.cbSearchGender.Name = "cbSearchGender";
            this.cbSearchGender.Size = new System.Drawing.Size(125, 21);
            this.cbSearchGender.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Gender:";
            // 
            // nudSearchHigh
            // 
            this.nudSearchHigh.Location = new System.Drawing.Point(150, 72);
            this.nudSearchHigh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSearchHigh.Name = "nudSearchHigh";
            this.nudSearchHigh.Size = new System.Drawing.Size(125, 20);
            this.nudSearchHigh.TabIndex = 3;
            this.nudSearchHigh.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Max. Level:";
            // 
            // nudSearchLow
            // 
            this.nudSearchLow.Location = new System.Drawing.Point(150, 46);
            this.nudSearchLow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSearchLow.Name = "nudSearchLow";
            this.nudSearchLow.Size = new System.Drawing.Size(125, 20);
            this.nudSearchLow.TabIndex = 3;
            this.nudSearchLow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Min. Level:";
            // 
            // cbSearchPokemon
            // 
            this.cbSearchPokemon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSearchPokemon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSearchPokemon.FormattingEnabled = true;
            this.cbSearchPokemon.Location = new System.Drawing.Point(67, 19);
            this.cbSearchPokemon.Name = "cbSearchPokemon";
            this.cbSearchPokemon.Size = new System.Drawing.Size(208, 21);
            this.cbSearchPokemon.TabIndex = 1;
            this.cbSearchPokemon.SelectedIndexChanged += new System.EventHandler(this.CbSearchPokemonSelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Pokémon:";
            // 
            // gbUpload
            // 
            this.gbUpload.Controls.Add(this.tcUpload);
            this.gbUpload.Controls.Add(this.msUploadOptions);
            this.gbUpload.Enabled = false;
            this.gbUpload.Location = new System.Drawing.Point(12, 118);
            this.gbUpload.Name = "gbUpload";
            this.gbUpload.Size = new System.Drawing.Size(371, 228);
            this.gbUpload.TabIndex = 0;
            this.gbUpload.TabStop = false;
            this.gbUpload.Text = "Upload";
            // 
            // tcUpload
            // 
            this.tcUpload.Controls.Add(this.tpData);
            this.tcUpload.Controls.Add(this.tpRequirements);
            this.tcUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUpload.Location = new System.Drawing.Point(3, 40);
            this.tcUpload.Name = "tcUpload";
            this.tcUpload.SelectedIndex = 0;
            this.tcUpload.Size = new System.Drawing.Size(365, 185);
            this.tcUpload.TabIndex = 1;
            // 
            // tpData
            // 
            this.tpData.Controls.Add(this.pbUpload);
            this.tpData.Controls.Add(this.btnUploadReset);
            this.tpData.Controls.Add(this.cbUploadPokemon);
            this.tpData.Controls.Add(this.label7);
            this.tpData.Controls.Add(this.cbUploadGender);
            this.tpData.Controls.Add(this.label9);
            this.tpData.Controls.Add(this.nudUploadLevel);
            this.tpData.Controls.Add(this.label8);
            this.tpData.Location = new System.Drawing.Point(4, 22);
            this.tpData.Name = "tpData";
            this.tpData.Padding = new System.Windows.Forms.Padding(3);
            this.tpData.Size = new System.Drawing.Size(357, 159);
            this.tpData.TabIndex = 0;
            this.tpData.Text = "Pokémon Data";
            this.tpData.UseVisualStyleBackColor = true;
            // 
            // pbUpload
            // 
            this.pbUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbUpload.Location = new System.Drawing.Point(6, 89);
            this.pbUpload.Name = "pbUpload";
            this.pbUpload.Size = new System.Drawing.Size(64, 64);
            this.pbUpload.TabIndex = 9;
            this.pbUpload.TabStop = false;
            // 
            // btnUploadReset
            // 
            this.btnUploadReset.Location = new System.Drawing.Point(276, 86);
            this.btnUploadReset.Name = "btnUploadReset";
            this.btnUploadReset.Size = new System.Drawing.Size(75, 23);
            this.btnUploadReset.TabIndex = 6;
            this.btnUploadReset.Text = "&Reset";
            this.btnUploadReset.UseVisualStyleBackColor = true;
            this.btnUploadReset.Click += new System.EventHandler(this.BtnUploadResetClick);
            // 
            // cbUploadPokemon
            // 
            this.cbUploadPokemon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUploadPokemon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUploadPokemon.FormattingEnabled = true;
            this.cbUploadPokemon.Location = new System.Drawing.Point(67, 6);
            this.cbUploadPokemon.Name = "cbUploadPokemon";
            this.cbUploadPokemon.Size = new System.Drawing.Size(284, 21);
            this.cbUploadPokemon.TabIndex = 1;
            this.cbUploadPokemon.SelectedIndexChanged += new System.EventHandler(this.CbUploadPokemonSelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Pokémon:";
            // 
            // cbUploadGender
            // 
            this.cbUploadGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUploadGender.FormattingEnabled = true;
            this.cbUploadGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbUploadGender.Location = new System.Drawing.Point(106, 59);
            this.cbUploadGender.Name = "cbUploadGender";
            this.cbUploadGender.Size = new System.Drawing.Size(245, 21);
            this.cbUploadGender.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Gender:";
            // 
            // nudUploadLevel
            // 
            this.nudUploadLevel.Location = new System.Drawing.Point(106, 33);
            this.nudUploadLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUploadLevel.Name = "nudUploadLevel";
            this.nudUploadLevel.Size = new System.Drawing.Size(245, 20);
            this.nudUploadLevel.TabIndex = 3;
            this.nudUploadLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Level:";
            // 
            // tpRequirements
            // 
            this.tpRequirements.Controls.Add(this.pbRequirements);
            this.tpRequirements.Controls.Add(this.btnRequirementsReset);
            this.tpRequirements.Controls.Add(this.cbRequirementsPokemon);
            this.tpRequirements.Controls.Add(this.label10);
            this.tpRequirements.Controls.Add(this.cbRequirementsGender);
            this.tpRequirements.Controls.Add(this.label11);
            this.tpRequirements.Controls.Add(this.label13);
            this.tpRequirements.Controls.Add(this.nudRequirementsLow);
            this.tpRequirements.Controls.Add(this.nudRequirementsHigh);
            this.tpRequirements.Controls.Add(this.label12);
            this.tpRequirements.Location = new System.Drawing.Point(4, 22);
            this.tpRequirements.Name = "tpRequirements";
            this.tpRequirements.Padding = new System.Windows.Forms.Padding(3);
            this.tpRequirements.Size = new System.Drawing.Size(357, 159);
            this.tpRequirements.TabIndex = 1;
            this.tpRequirements.Text = "Pokémon Requirements";
            this.tpRequirements.UseVisualStyleBackColor = true;
            // 
            // pbRequirements
            // 
            this.pbRequirements.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRequirements.Location = new System.Drawing.Point(6, 89);
            this.pbRequirements.Name = "pbRequirements";
            this.pbRequirements.Size = new System.Drawing.Size(64, 64);
            this.pbRequirements.TabIndex = 9;
            this.pbRequirements.TabStop = false;
            // 
            // btnRequirementsReset
            // 
            this.btnRequirementsReset.Location = new System.Drawing.Point(276, 112);
            this.btnRequirementsReset.Name = "btnRequirementsReset";
            this.btnRequirementsReset.Size = new System.Drawing.Size(75, 23);
            this.btnRequirementsReset.TabIndex = 6;
            this.btnRequirementsReset.Text = "&Reset";
            this.btnRequirementsReset.UseVisualStyleBackColor = true;
            this.btnRequirementsReset.Click += new System.EventHandler(this.BtnRequirementsResetClick);
            // 
            // cbRequirementsPokemon
            // 
            this.cbRequirementsPokemon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbRequirementsPokemon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbRequirementsPokemon.FormattingEnabled = true;
            this.cbRequirementsPokemon.Location = new System.Drawing.Point(67, 6);
            this.cbRequirementsPokemon.Name = "cbRequirementsPokemon";
            this.cbRequirementsPokemon.Size = new System.Drawing.Size(284, 21);
            this.cbRequirementsPokemon.TabIndex = 1;
            this.cbRequirementsPokemon.SelectedIndexChanged += new System.EventHandler(this.CbRequirementsPokemonSelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Pokémon:";
            // 
            // cbRequirementsGender
            // 
            this.cbRequirementsGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRequirementsGender.FormattingEnabled = true;
            this.cbRequirementsGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Any"});
            this.cbRequirementsGender.Location = new System.Drawing.Point(150, 85);
            this.cbRequirementsGender.Name = "cbRequirementsGender";
            this.cbRequirementsGender.Size = new System.Drawing.Size(201, 21);
            this.cbRequirementsGender.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(64, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Minimum Level:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(99, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Gender:";
            // 
            // nudRequirementsLow
            // 
            this.nudRequirementsLow.Location = new System.Drawing.Point(150, 33);
            this.nudRequirementsLow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRequirementsLow.Name = "nudRequirementsLow";
            this.nudRequirementsLow.Size = new System.Drawing.Size(201, 20);
            this.nudRequirementsLow.TabIndex = 3;
            this.nudRequirementsLow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudRequirementsHigh
            // 
            this.nudRequirementsHigh.Location = new System.Drawing.Point(150, 59);
            this.nudRequirementsHigh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRequirementsHigh.Name = "nudRequirementsHigh";
            this.nudRequirementsHigh.Size = new System.Drawing.Size(201, 20);
            this.nudRequirementsHigh.TabIndex = 3;
            this.nudRequirementsHigh.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(61, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Maximum Level:";
            // 
            // msUploadOptions
            // 
            this.msUploadOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.msUploadOptions.Location = new System.Drawing.Point(3, 16);
            this.msUploadOptions.Name = "msUploadOptions";
            this.msUploadOptions.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.msUploadOptions.Size = new System.Drawing.Size(365, 24);
            this.msUploadOptions.TabIndex = 0;
            this.msUploadOptions.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshStatusToolStripMenuItem,
            this.retrievePokémonToolStripMenuItem,
            this.toolStripSeparator1,
            this.uploadToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // refreshStatusToolStripMenuItem
            // 
            this.refreshStatusToolStripMenuItem.Name = "refreshStatusToolStripMenuItem";
            this.refreshStatusToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.refreshStatusToolStripMenuItem.Text = "&Refresh Status";
            this.refreshStatusToolStripMenuItem.Click += new System.EventHandler(this.RefreshStatusToolStripMenuItemClick);
            // 
            // retrievePokémonToolStripMenuItem
            // 
            this.retrievePokémonToolStripMenuItem.Name = "retrievePokémonToolStripMenuItem";
            this.retrievePokémonToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.retrievePokémonToolStripMenuItem.Text = "R&etrieve Pokémon";
            this.retrievePokémonToolStripMenuItem.Click += new System.EventHandler(this.RetrievePokémonToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.uploadToolStripMenuItem.Text = "U&pload Pokémon";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.UploadToolStripMenuItemClick);
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.lbLog);
            this.gbLog.Location = new System.Drawing.Point(12, 352);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(670, 110);
            this.gbLog.TabIndex = 2;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Message Log";
            // 
            // lbLog
            // 
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(3, 16);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(664, 91);
            this.lbLog.TabIndex = 0;
            this.lbLog.DoubleClick += new System.EventHandler(this.LbLogDoubleClick);
            // 
            // cmsSearch
            // 
            this.cmsSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tradeToolStripMenuItem,
            this.loadAdditionalResultsToolStripMenuItem,
            this.toolStripSeparator2,
            this.clearListToolStripMenuItem});
            this.cmsSearch.Name = "cmsSearch";
            this.cmsSearch.Size = new System.Drawing.Size(199, 98);
            // 
            // loadAdditionalResultsToolStripMenuItem
            // 
            this.loadAdditionalResultsToolStripMenuItem.Name = "loadAdditionalResultsToolStripMenuItem";
            this.loadAdditionalResultsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.loadAdditionalResultsToolStripMenuItem.Text = "&Load Additional Results";
            this.loadAdditionalResultsToolStripMenuItem.Click += new System.EventHandler(this.LoadAdditionalResultsToolStripMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // clearListToolStripMenuItem
            // 
            this.clearListToolStripMenuItem.Name = "clearListToolStripMenuItem";
            this.clearListToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.clearListToolStripMenuItem.Text = "&Clear List";
            this.clearListToolStripMenuItem.Click += new System.EventHandler(this.ClearListToolStripMenuItemClick);
            // 
            // tradeToolStripMenuItem
            // 
            this.tradeToolStripMenuItem.Name = "tradeToolStripMenuItem";
            this.tradeToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.tradeToolStripMenuItem.Text = "&Trade";
            this.tradeToolStripMenuItem.Click += new System.EventHandler(this.TradeToolStripMenuItemClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 474);
            this.Controls.Add(this.gbLog);
            this.Controls.Add(this.gbUpload);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mercury Test Client";
            this.Load += new System.EventHandler(this.FrmMainLoad);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSearchHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSearchLow)).EndInit();
            this.gbUpload.ResumeLayout(false);
            this.gbUpload.PerformLayout();
            this.tcUpload.ResumeLayout(false);
            this.tpData.ResumeLayout(false);
            this.tpData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUploadLevel)).EndInit();
            this.tpRequirements.ResumeLayout(false);
            this.tpRequirements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRequirements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRequirementsLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRequirementsHigh)).EndInit();
            this.msUploadOptions.ResumeLayout(false);
            this.msUploadOptions.PerformLayout();
            this.gbLog.ResumeLayout(false);
            this.cmsSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.TextBox tbUid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.GroupBox gbUpload;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbSearchPokemon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudSearchHigh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudSearchLow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSearchGender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSearchReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListView lvSearchResults;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chLevel;
        private System.Windows.Forms.ColumnHeader chGender;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.MenuStrip msUploadOptions;
        private System.Windows.Forms.TabControl tcUpload;
        private System.Windows.Forms.TabPage tpData;
        private System.Windows.Forms.TabPage tpRequirements;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retrievePokémonToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbUploadPokemon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudUploadLevel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbUploadGender;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnUploadReset;
        private System.Windows.Forms.ComboBox cbRequirementsPokemon;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbRequirementsGender;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudRequirementsLow;
        private System.Windows.Forms.NumericUpDown nudRequirementsHigh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnRequirementsReset;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.PictureBox pbUpload;
        private System.Windows.Forms.PictureBox pbRequirements;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsSearch;
        private System.Windows.Forms.ToolStripMenuItem loadAdditionalResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem clearListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradeToolStripMenuItem;
    }
}