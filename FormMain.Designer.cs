namespace lorakon_manager
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.status = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progress = new System.Windows.Forms.ToolStripProgressBar();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.separatorMain = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditOpen = new System.Windows.Forms.ToolStripButton();
            this.lblPage = new System.Windows.Forms.ToolStripLabel();
            this.btnSpectrumOpenInGenie = new System.Windows.Forms.ToolStripButton();
            this.btnSpectrumDetails = new System.Windows.Forms.ToolStripButton();
            this.btnValidationAdd = new System.Windows.Forms.ToolStripButton();
            this.btnGeometryAdd = new System.Windows.Forms.ToolStripButton();
            this.btnValidationEdit = new System.Windows.Forms.ToolStripButton();
            this.btnGeometryEdit = new System.Windows.Forms.ToolStripButton();
            this.btnGeometryTrash = new System.Windows.Forms.ToolStripButton();
            this.btnValidationTrash = new System.Windows.Forms.ToolStripButton();
            this.btnSpectrumDelete = new System.Windows.Forms.ToolStripButton();
            this.tabs = new System.Windows.Forms.TabControl();
            this.pageMain = new System.Windows.Forms.TabPage();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnMainSearch = new System.Windows.Forms.Button();
            this.btnMainEdit = new System.Windows.Forms.Button();
            this.btnMainLog = new System.Windows.Forms.Button();
            this.btnMenuValidation = new System.Windows.Forms.Button();
            this.btnMenuGeometry = new System.Windows.Forms.Button();
            this.pageSearch = new System.Windows.Forms.TabPage();
            this.gridSearch = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcquisitionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Approved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ApprovedStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rejected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenSpectrum = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeleteSpectrum = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSearchTop = new System.Windows.Forms.Panel();
            this.tableSearch = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearchSampleType = new System.Windows.Forms.TextBox();
            this.cboxAccount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbRejected = new System.Windows.Forms.CheckBox();
            this.cbApproved = new System.Windows.Forms.CheckBox();
            this.pageEdit = new System.Windows.Forms.TabPage();
            this.gridEditFiles = new System.Windows.Forms.DataGridView();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSTYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSampleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSampleComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableEdit = new System.Windows.Forms.TableLayoutPanel();
            this.cboxEditSampleType = new System.Windows.Forms.ComboBox();
            this.cboxEditSampleComponent = new System.Windows.Forms.ComboBox();
            this.cboxEditAccountName = new System.Windows.Forms.ComboBox();
            this.btnEditSave = new System.Windows.Forms.Button();
            this.tbEditAccountID = new System.Windows.Forms.TextBox();
            this.tbEditLab = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pageLog = new System.Windows.Forms.TabPage();
            this.lbLogMessages = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtLogFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtLogTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cboxLogSeverity = new System.Windows.Forms.ComboBox();
            this.pageValidation = new System.Windows.Forms.TabPage();
            this.gridValidation = new System.Windows.Forms.DataGridView();
            this.menuValidationGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemNewValidationRule = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEditValidationRule = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeleteNuclide = new System.Windows.Forms.ToolStripMenuItem();
            this.pageGeometries = new System.Windows.Forms.TabPage();
            this.gridGeometries = new System.Windows.Forms.DataGridView();
            this.menuGeometryGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemNewGeometryRule = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEditGeometryRule = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeleteGeometry = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.tbSettingsUrl = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSettingsCancel = new System.Windows.Forms.Button();
            this.btnSettingsOk = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.status.SuspendLayout();
            this.menu.SuspendLayout();
            this.tools.SuspendLayout();
            this.tabs.SuspendLayout();
            this.pageMain.SuspendLayout();
            this.tableMain.SuspendLayout();
            this.pageSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).BeginInit();
            this.menuGrid.SuspendLayout();
            this.panelSearchTop.SuspendLayout();
            this.tableSearch.SuspendLayout();
            this.pageEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEditFiles)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableEdit.SuspendLayout();
            this.pageLog.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pageValidation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridValidation)).BeginInit();
            this.menuValidationGrid.SuspendLayout();
            this.pageGeometries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGeometries)).BeginInit();
            this.menuGeometryGrid.SuspendLayout();
            this.pageSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progress});
            this.status.Location = new System.Drawing.Point(0, 602);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.status.Size = new System.Drawing.Size(1039, 22);
            this.status.TabIndex = 0;
            this.status.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // progress
            // 
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(175, 16);
            this.progress.Visible = false;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1039, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpenFiles,
            this.menuItemSettings,
            this.toolStripSeparator2,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(31, 20);
            this.menuItemFile.Text = "&Fil";
            // 
            // menuItemOpenFiles
            // 
            this.menuItemOpenFiles.Image = global::lorakon_manager.Properties.Resources.open32;
            this.menuItemOpenFiles.Name = "menuItemOpenFiles";
            this.menuItemOpenFiles.Size = new System.Drawing.Size(169, 22);
            this.menuItemOpenFiles.Text = "&Åpne CNF spekter";
            this.menuItemOpenFiles.Click += new System.EventHandler(this.menuItemOpenFiles_Click);
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Size = new System.Drawing.Size(169, 22);
            this.menuItemSettings.Text = "Innstillinger";
            this.menuItemSettings.Click += new System.EventHandler(this.menuItemSettings_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Image = global::lorakon_manager.Properties.Resources.exit32;
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(169, 22);
            this.menuItemExit.Text = "&Avslutt";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // tools
            // 
            this.tools.AutoSize = false;
            this.tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBack,
            this.separatorMain,
            this.btnEditOpen,
            this.lblPage,
            this.btnSpectrumOpenInGenie,
            this.btnSpectrumDetails,
            this.btnValidationAdd,
            this.btnGeometryAdd,
            this.btnValidationEdit,
            this.btnGeometryEdit,
            this.btnGeometryTrash,
            this.btnValidationTrash,
            this.btnSpectrumDelete});
            this.tools.Location = new System.Drawing.Point(0, 24);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(1039, 40);
            this.tools.TabIndex = 2;
            this.tools.Text = "toolStrip1";
            // 
            // btnBack
            // 
            this.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBack.Image = global::lorakon_manager.Properties.Resources.back;
            this.btnBack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(36, 37);
            this.btnBack.Text = "Tilbake";
            this.btnBack.Click += new System.EventHandler(this.menuItemBack_Click);
            // 
            // separatorMain
            // 
            this.separatorMain.Name = "separatorMain";
            this.separatorMain.Size = new System.Drawing.Size(6, 40);
            // 
            // btnEditOpen
            // 
            this.btnEditOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditOpen.Image = global::lorakon_manager.Properties.Resources.open32;
            this.btnEditOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditOpen.Name = "btnEditOpen";
            this.btnEditOpen.Size = new System.Drawing.Size(36, 37);
            this.btnEditOpen.Text = "Åpne CNF spekter";
            this.btnEditOpen.ToolTipText = "Åpne CNF spekter";
            this.btnEditOpen.Click += new System.EventHandler(this.menuItemOpenFiles_Click);
            // 
            // lblPage
            // 
            this.lblPage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblPage.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(90, 37);
            this.lblPage.Text = "lblPage";
            // 
            // btnSpectrumOpenInGenie
            // 
            this.btnSpectrumOpenInGenie.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSpectrumOpenInGenie.Image = global::lorakon_manager.Properties.Resources.genie;
            this.btnSpectrumOpenInGenie.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSpectrumOpenInGenie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSpectrumOpenInGenie.Name = "btnSpectrumOpenInGenie";
            this.btnSpectrumOpenInGenie.Size = new System.Drawing.Size(36, 37);
            this.btnSpectrumOpenInGenie.Text = "toolStripButton1";
            this.btnSpectrumOpenInGenie.ToolTipText = "Åpne spektrum i Genie";
            this.btnSpectrumOpenInGenie.Click += new System.EventHandler(this.menuItemOpenSpectrum_Click);
            // 
            // btnSpectrumDetails
            // 
            this.btnSpectrumDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSpectrumDetails.Image = global::lorakon_manager.Properties.Resources.details_32;
            this.btnSpectrumDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSpectrumDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSpectrumDetails.Name = "btnSpectrumDetails";
            this.btnSpectrumDetails.Size = new System.Drawing.Size(36, 37);
            this.btnSpectrumDetails.Text = "toolStripButton1";
            this.btnSpectrumDetails.ToolTipText = "Vis spektrum detaljer";
            this.btnSpectrumDetails.Click += new System.EventHandler(this.menuItemShowDetails_Click);
            // 
            // btnValidationAdd
            // 
            this.btnValidationAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnValidationAdd.Image = global::lorakon_manager.Properties.Resources.new_32;
            this.btnValidationAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnValidationAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValidationAdd.Name = "btnValidationAdd";
            this.btnValidationAdd.Size = new System.Drawing.Size(36, 37);
            this.btnValidationAdd.Text = "Ny validerings regel";
            this.btnValidationAdd.Click += new System.EventHandler(this.menuItemNewValidationRule_Click);
            // 
            // btnGeometryAdd
            // 
            this.btnGeometryAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGeometryAdd.Image = global::lorakon_manager.Properties.Resources.new_32;
            this.btnGeometryAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGeometryAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGeometryAdd.Name = "btnGeometryAdd";
            this.btnGeometryAdd.Size = new System.Drawing.Size(36, 37);
            this.btnGeometryAdd.Text = "Ny geometri regel";
            this.btnGeometryAdd.Click += new System.EventHandler(this.menuItemNewGeometryRule_Click);
            // 
            // btnValidationEdit
            // 
            this.btnValidationEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnValidationEdit.Image = global::lorakon_manager.Properties.Resources.edit_32;
            this.btnValidationEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnValidationEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValidationEdit.Name = "btnValidationEdit";
            this.btnValidationEdit.Size = new System.Drawing.Size(36, 37);
            this.btnValidationEdit.Text = "Rediger valideringsregel";
            this.btnValidationEdit.Click += new System.EventHandler(this.menuItemEditValidationRule_Click);
            // 
            // btnGeometryEdit
            // 
            this.btnGeometryEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGeometryEdit.Image = global::lorakon_manager.Properties.Resources.edit_32;
            this.btnGeometryEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGeometryEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGeometryEdit.Name = "btnGeometryEdit";
            this.btnGeometryEdit.Size = new System.Drawing.Size(36, 37);
            this.btnGeometryEdit.Text = "Rediger geometri regel";
            this.btnGeometryEdit.Click += new System.EventHandler(this.menuItemEditGeometryRule_Click);
            // 
            // btnGeometryTrash
            // 
            this.btnGeometryTrash.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGeometryTrash.Image = global::lorakon_manager.Properties.Resources.trash_32;
            this.btnGeometryTrash.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGeometryTrash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGeometryTrash.Name = "btnGeometryTrash";
            this.btnGeometryTrash.Size = new System.Drawing.Size(36, 37);
            this.btnGeometryTrash.Text = "Slett geometri regel";
            this.btnGeometryTrash.ToolTipText = "Slett geometri regel";
            this.btnGeometryTrash.Click += new System.EventHandler(this.menuItemDeleteGeometry_Click);
            // 
            // btnValidationTrash
            // 
            this.btnValidationTrash.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnValidationTrash.Image = global::lorakon_manager.Properties.Resources.trash_32;
            this.btnValidationTrash.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnValidationTrash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValidationTrash.Name = "btnValidationTrash";
            this.btnValidationTrash.Size = new System.Drawing.Size(36, 37);
            this.btnValidationTrash.Text = "Slett valideringsregel";
            this.btnValidationTrash.ToolTipText = "Slett valideringsregel";
            this.btnValidationTrash.Click += new System.EventHandler(this.menuItemDeleteNuclide_Click);
            // 
            // btnSpectrumDelete
            // 
            this.btnSpectrumDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSpectrumDelete.Image = global::lorakon_manager.Properties.Resources.trash_32;
            this.btnSpectrumDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSpectrumDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSpectrumDelete.Name = "btnSpectrumDelete";
            this.btnSpectrumDelete.Size = new System.Drawing.Size(36, 37);
            this.btnSpectrumDelete.Text = "Slett spekter";
            this.btnSpectrumDelete.Click += new System.EventHandler(this.menuItemDeleteSpectrum_Click);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.pageMain);
            this.tabs.Controls.Add(this.pageSearch);
            this.tabs.Controls.Add(this.pageEdit);
            this.tabs.Controls.Add(this.pageLog);
            this.tabs.Controls.Add(this.pageValidation);
            this.tabs.Controls.Add(this.pageGeometries);
            this.tabs.Controls.Add(this.pageSettings);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 64);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1039, 538);
            this.tabs.TabIndex = 3;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // pageMain
            // 
            this.pageMain.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageMain.Controls.Add(this.tableMain);
            this.pageMain.Location = new System.Drawing.Point(4, 24);
            this.pageMain.Name = "pageMain";
            this.pageMain.Padding = new System.Windows.Forms.Padding(3);
            this.pageMain.Size = new System.Drawing.Size(1031, 510);
            this.pageMain.TabIndex = 0;
            this.pageMain.Text = "Meny";
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 3;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableMain.Controls.Add(this.btnMainSearch, 0, 0);
            this.tableMain.Controls.Add(this.btnMainEdit, 1, 0);
            this.tableMain.Controls.Add(this.btnMainLog, 2, 0);
            this.tableMain.Controls.Add(this.btnMenuValidation, 0, 1);
            this.tableMain.Controls.Add(this.btnMenuGeometry, 1, 1);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.Location = new System.Drawing.Point(3, 3);
            this.tableMain.Name = "tableMain";
            this.tableMain.Padding = new System.Windows.Forms.Padding(32);
            this.tableMain.RowCount = 2;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMain.Size = new System.Drawing.Size(1025, 504);
            this.tableMain.TabIndex = 0;
            // 
            // btnMainSearch
            // 
            this.btnMainSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMainSearch.FlatAppearance.BorderSize = 0;
            this.btnMainSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnMainSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnMainSearch.Image = global::lorakon_manager.Properties.Resources.doc_search_128;
            this.btnMainSearch.Location = new System.Drawing.Point(35, 35);
            this.btnMainSearch.Name = "btnMainSearch";
            this.btnMainSearch.Size = new System.Drawing.Size(314, 214);
            this.btnMainSearch.TabIndex = 0;
            this.btnMainSearch.Text = "Søk";
            this.btnMainSearch.UseVisualStyleBackColor = true;
            this.btnMainSearch.Click += new System.EventHandler(this.btnMainSearch_Click);
            // 
            // btnMainEdit
            // 
            this.btnMainEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMainEdit.FlatAppearance.BorderSize = 0;
            this.btnMainEdit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnMainEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainEdit.ForeColor = System.Drawing.Color.DimGray;
            this.btnMainEdit.Image = global::lorakon_manager.Properties.Resources.doc_edit_128;
            this.btnMainEdit.Location = new System.Drawing.Point(355, 35);
            this.btnMainEdit.Name = "btnMainEdit";
            this.btnMainEdit.Size = new System.Drawing.Size(314, 214);
            this.btnMainEdit.TabIndex = 1;
            this.btnMainEdit.Text = "Rediger";
            this.btnMainEdit.UseVisualStyleBackColor = true;
            this.btnMainEdit.Click += new System.EventHandler(this.btnMainEdit_Click);
            // 
            // btnMainLog
            // 
            this.btnMainLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMainLog.FlatAppearance.BorderSize = 0;
            this.btnMainLog.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnMainLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainLog.ForeColor = System.Drawing.Color.DimGray;
            this.btnMainLog.Image = global::lorakon_manager.Properties.Resources.doc_128;
            this.btnMainLog.Location = new System.Drawing.Point(675, 35);
            this.btnMainLog.Name = "btnMainLog";
            this.btnMainLog.Size = new System.Drawing.Size(315, 214);
            this.btnMainLog.TabIndex = 2;
            this.btnMainLog.Text = "Logg";
            this.btnMainLog.UseVisualStyleBackColor = true;
            this.btnMainLog.Click += new System.EventHandler(this.btnMainLog_Click);
            // 
            // btnMenuValidation
            // 
            this.btnMenuValidation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuValidation.FlatAppearance.BorderSize = 0;
            this.btnMenuValidation.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnMenuValidation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuValidation.ForeColor = System.Drawing.Color.DimGray;
            this.btnMenuValidation.Image = global::lorakon_manager.Properties.Resources.doc_settings_128;
            this.btnMenuValidation.Location = new System.Drawing.Point(35, 255);
            this.btnMenuValidation.Name = "btnMenuValidation";
            this.btnMenuValidation.Size = new System.Drawing.Size(314, 214);
            this.btnMenuValidation.TabIndex = 3;
            this.btnMenuValidation.Text = "Nuklider";
            this.btnMenuValidation.UseVisualStyleBackColor = true;
            this.btnMenuValidation.Click += new System.EventHandler(this.btnMenuValidation_Click);
            // 
            // btnMenuGeometry
            // 
            this.btnMenuGeometry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuGeometry.FlatAppearance.BorderSize = 0;
            this.btnMenuGeometry.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnMenuGeometry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuGeometry.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuGeometry.ForeColor = System.Drawing.Color.DimGray;
            this.btnMenuGeometry.Image = global::lorakon_manager.Properties.Resources.doc_star_128;
            this.btnMenuGeometry.Location = new System.Drawing.Point(355, 255);
            this.btnMenuGeometry.Name = "btnMenuGeometry";
            this.btnMenuGeometry.Size = new System.Drawing.Size(314, 214);
            this.btnMenuGeometry.TabIndex = 4;
            this.btnMenuGeometry.Text = "Geometrier";
            this.btnMenuGeometry.UseVisualStyleBackColor = true;
            this.btnMenuGeometry.Click += new System.EventHandler(this.btnMenuGeometry_Click);
            // 
            // pageSearch
            // 
            this.pageSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageSearch.Controls.Add(this.gridSearch);
            this.pageSearch.Controls.Add(this.panelSearchTop);
            this.pageSearch.Location = new System.Drawing.Point(4, 24);
            this.pageSearch.Name = "pageSearch";
            this.pageSearch.Padding = new System.Windows.Forms.Padding(3);
            this.pageSearch.Size = new System.Drawing.Size(1031, 510);
            this.pageSearch.TabIndex = 1;
            this.pageSearch.Text = "Søk";
            // 
            // gridSearch
            // 
            this.gridSearch.AllowUserToAddRows = false;
            this.gridSearch.AllowUserToDeleteRows = false;
            this.gridSearch.AllowUserToResizeRows = false;
            this.gridSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSearch.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gridSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.AccountName,
            this.Operator,
            this.colExID,
            this.ReferenceDate,
            this.AcquisitionDate,
            this.SampleType,
            this.SampleComponent,
            this.Approved,
            this.ApprovedStatus,
            this.Rejected});
            this.gridSearch.ContextMenuStrip = this.menuGrid;
            this.gridSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSearch.Location = new System.Drawing.Point(3, 88);
            this.gridSearch.MultiSelect = false;
            this.gridSearch.Name = "gridSearch";
            this.gridSearch.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gridSearch.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSearch.Size = new System.Drawing.Size(1025, 419);
            this.gridSearch.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // AccountName
            // 
            this.AccountName.HeaderText = "Konto";
            this.AccountName.Name = "AccountName";
            this.AccountName.ReadOnly = true;
            // 
            // Operator
            // 
            this.Operator.HeaderText = "Operatør";
            this.Operator.Name = "Operator";
            this.Operator.ReadOnly = true;
            // 
            // colExID
            // 
            this.colExID.HeaderText = "ExID";
            this.colExID.Name = "colExID";
            this.colExID.ReadOnly = true;
            // 
            // ReferenceDate
            // 
            this.ReferenceDate.HeaderText = "Ref. dato";
            this.ReferenceDate.Name = "ReferenceDate";
            this.ReferenceDate.ReadOnly = true;
            // 
            // AcquisitionDate
            // 
            this.AcquisitionDate.HeaderText = "Måledato";
            this.AcquisitionDate.Name = "AcquisitionDate";
            this.AcquisitionDate.ReadOnly = true;
            // 
            // SampleType
            // 
            this.SampleType.HeaderText = "Prøvetype";
            this.SampleType.Name = "SampleType";
            this.SampleType.ReadOnly = true;
            // 
            // SampleComponent
            // 
            this.SampleComponent.HeaderText = "Prøve komp.";
            this.SampleComponent.Name = "SampleComponent";
            this.SampleComponent.ReadOnly = true;
            // 
            // Approved
            // 
            this.Approved.HeaderText = "Godkjent";
            this.Approved.Name = "Approved";
            this.Approved.ReadOnly = true;
            this.Approved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Approved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ApprovedStatus
            // 
            this.ApprovedStatus.HeaderText = "Godkj. status";
            this.ApprovedStatus.Name = "ApprovedStatus";
            this.ApprovedStatus.ReadOnly = true;
            // 
            // Rejected
            // 
            this.Rejected.HeaderText = "Avvist";
            this.Rejected.Name = "Rejected";
            this.Rejected.ReadOnly = true;
            // 
            // menuGrid
            // 
            this.menuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemShowDetails,
            this.menuItemOpenSpectrum,
            this.menuItemDeleteSpectrum});
            this.menuGrid.Name = "menuGrid";
            this.menuGrid.Size = new System.Drawing.Size(195, 70);
            // 
            // menuItemShowDetails
            // 
            this.menuItemShowDetails.Name = "menuItemShowDetails";
            this.menuItemShowDetails.Size = new System.Drawing.Size(194, 22);
            this.menuItemShowDetails.Text = "Vis spektrum detaljer";
            this.menuItemShowDetails.Click += new System.EventHandler(this.menuItemShowDetails_Click);
            // 
            // menuItemOpenSpectrum
            // 
            this.menuItemOpenSpectrum.Name = "menuItemOpenSpectrum";
            this.menuItemOpenSpectrum.Size = new System.Drawing.Size(194, 22);
            this.menuItemOpenSpectrum.Text = "Åpne spektrum i Genie";
            this.menuItemOpenSpectrum.Click += new System.EventHandler(this.menuItemOpenSpectrum_Click);
            // 
            // menuItemDeleteSpectrum
            // 
            this.menuItemDeleteSpectrum.Name = "menuItemDeleteSpectrum";
            this.menuItemDeleteSpectrum.Size = new System.Drawing.Size(194, 22);
            this.menuItemDeleteSpectrum.Text = "Slett spekter";
            this.menuItemDeleteSpectrum.Click += new System.EventHandler(this.menuItemDeleteSpectrum_Click);
            // 
            // panelSearchTop
            // 
            this.panelSearchTop.Controls.Add(this.tableSearch);
            this.panelSearchTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearchTop.Location = new System.Drawing.Point(3, 3);
            this.panelSearchTop.Name = "panelSearchTop";
            this.panelSearchTop.Size = new System.Drawing.Size(1025, 85);
            this.panelSearchTop.TabIndex = 0;
            // 
            // tableSearch
            // 
            this.tableSearch.ColumnCount = 6;
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableSearch.Controls.Add(this.label1, 1, 0);
            this.tableSearch.Controls.Add(this.tbSearchSampleType, 1, 1);
            this.tableSearch.Controls.Add(this.cboxAccount, 0, 1);
            this.tableSearch.Controls.Add(this.label2, 0, 0);
            this.tableSearch.Controls.Add(this.dtFrom, 2, 1);
            this.tableSearch.Controls.Add(this.dtTo, 3, 1);
            this.tableSearch.Controls.Add(this.label3, 2, 0);
            this.tableSearch.Controls.Add(this.label4, 3, 0);
            this.tableSearch.Controls.Add(this.label5, 4, 0);
            this.tableSearch.Controls.Add(this.cbRejected, 5, 1);
            this.tableSearch.Controls.Add(this.cbApproved, 4, 1);
            this.tableSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableSearch.Location = new System.Drawing.Point(0, 0);
            this.tableSearch.Name = "tableSearch";
            this.tableSearch.RowCount = 3;
            this.tableSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableSearch.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableSearch.Size = new System.Drawing.Size(1025, 85);
            this.tableSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prøvetype";
            // 
            // tbSearchSampleType
            // 
            this.tbSearchSampleType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearchSampleType.Location = new System.Drawing.Point(173, 33);
            this.tbSearchSampleType.Name = "tbSearchSampleType";
            this.tbSearchSampleType.Size = new System.Drawing.Size(164, 21);
            this.tbSearchSampleType.TabIndex = 2;
            this.tbSearchSampleType.TextChanged += new System.EventHandler(this.tbSearchSampleType_TextChanged);
            // 
            // cboxAccount
            // 
            this.cboxAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxAccount.DropDownWidth = 400;
            this.cboxAccount.FormattingEnabled = true;
            this.cboxAccount.Location = new System.Drawing.Point(3, 33);
            this.cboxAccount.Name = "cboxAccount";
            this.cboxAccount.Size = new System.Drawing.Size(164, 23);
            this.cboxAccount.TabIndex = 3;
            this.cboxAccount.SelectedIndexChanged += new System.EventHandler(this.cboxAccount_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Konto";
            // 
            // dtFrom
            // 
            this.dtFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFrom.Location = new System.Drawing.Point(343, 33);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(164, 21);
            this.dtFrom.TabIndex = 5;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // dtTo
            // 
            this.dtTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTo.Location = new System.Drawing.Point(513, 33);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(164, 21);
            this.dtTo.TabIndex = 6;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dato fra";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(513, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dato til";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(683, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Status";
            // 
            // cbRejected
            // 
            this.cbRejected.AutoSize = true;
            this.cbRejected.Location = new System.Drawing.Point(853, 33);
            this.cbRejected.Name = "cbRejected";
            this.cbRejected.Size = new System.Drawing.Size(76, 19);
            this.cbRejected.TabIndex = 10;
            this.cbRejected.Text = "Forkastet";
            this.cbRejected.UseVisualStyleBackColor = true;
            this.cbRejected.CheckedChanged += new System.EventHandler(this.cbRejected_CheckedChanged);
            // 
            // cbApproved
            // 
            this.cbApproved.AutoSize = true;
            this.cbApproved.Checked = true;
            this.cbApproved.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbApproved.Location = new System.Drawing.Point(683, 33);
            this.cbApproved.Name = "cbApproved";
            this.cbApproved.Size = new System.Drawing.Size(75, 19);
            this.cbApproved.TabIndex = 12;
            this.cbApproved.Text = "Godkjent";
            this.cbApproved.UseVisualStyleBackColor = true;
            this.cbApproved.CheckedChanged += new System.EventHandler(this.cbApproved_CheckedChanged);
            // 
            // pageEdit
            // 
            this.pageEdit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageEdit.Controls.Add(this.gridEditFiles);
            this.pageEdit.Controls.Add(this.panel1);
            this.pageEdit.Location = new System.Drawing.Point(4, 24);
            this.pageEdit.Name = "pageEdit";
            this.pageEdit.Padding = new System.Windows.Forms.Padding(3);
            this.pageEdit.Size = new System.Drawing.Size(1031, 510);
            this.pageEdit.TabIndex = 2;
            this.pageEdit.Text = "Rediger";
            // 
            // gridEditFiles
            // 
            this.gridEditFiles.AllowUserToAddRows = false;
            this.gridEditFiles.AllowUserToDeleteRows = false;
            this.gridEditFiles.AllowUserToResizeRows = false;
            this.gridEditFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridEditFiles.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gridEditFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridEditFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEditFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFilename,
            this.colSTYPE,
            this.colLab,
            this.colAccountName,
            this.colAccountID,
            this.colSampleType,
            this.colSampleComponent});
            this.gridEditFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEditFiles.Location = new System.Drawing.Point(3, 3);
            this.gridEditFiles.Name = "gridEditFiles";
            this.gridEditFiles.ReadOnly = true;
            this.gridEditFiles.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gridEditFiles.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridEditFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEditFiles.Size = new System.Drawing.Size(1025, 384);
            this.gridEditFiles.TabIndex = 1;
            // 
            // colFilename
            // 
            this.colFilename.HeaderText = "Filnavn";
            this.colFilename.Name = "colFilename";
            this.colFilename.ReadOnly = true;
            // 
            // colSTYPE
            // 
            this.colSTYPE.HeaderText = "Type (STYPE)";
            this.colSTYPE.Name = "colSTYPE";
            this.colSTYPE.ReadOnly = true;
            // 
            // colLab
            // 
            this.colLab.HeaderText = "Lab (SSPRSTR1)";
            this.colLab.Name = "colLab";
            this.colLab.ReadOnly = true;
            // 
            // colAccountName
            // 
            this.colAccountName.HeaderText = "Konto";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            // 
            // colAccountID
            // 
            this.colAccountID.HeaderText = "Konto ID";
            this.colAccountID.Name = "colAccountID";
            this.colAccountID.ReadOnly = true;
            // 
            // colSampleType
            // 
            this.colSampleType.HeaderText = "Sample Type";
            this.colSampleType.Name = "colSampleType";
            this.colSampleType.ReadOnly = true;
            // 
            // colSampleComponent
            // 
            this.colSampleComponent.HeaderText = "Sample Component";
            this.colSampleComponent.Name = "colSampleComponent";
            this.colSampleComponent.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableEdit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 387);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 120);
            this.panel1.TabIndex = 0;
            // 
            // tableEdit
            // 
            this.tableEdit.ColumnCount = 4;
            this.tableEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableEdit.Controls.Add(this.cboxEditSampleType, 2, 1);
            this.tableEdit.Controls.Add(this.cboxEditSampleComponent, 3, 1);
            this.tableEdit.Controls.Add(this.cboxEditAccountName, 1, 1);
            this.tableEdit.Controls.Add(this.btnEditSave, 3, 3);
            this.tableEdit.Controls.Add(this.tbEditAccountID, 1, 2);
            this.tableEdit.Controls.Add(this.tbEditLab, 0, 1);
            this.tableEdit.Controls.Add(this.label8, 0, 0);
            this.tableEdit.Controls.Add(this.label9, 1, 0);
            this.tableEdit.Controls.Add(this.label10, 2, 0);
            this.tableEdit.Controls.Add(this.label11, 3, 0);
            this.tableEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableEdit.Location = new System.Drawing.Point(0, 0);
            this.tableEdit.Name = "tableEdit";
            this.tableEdit.RowCount = 4;
            this.tableEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableEdit.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableEdit.Size = new System.Drawing.Size(1025, 120);
            this.tableEdit.TabIndex = 0;
            // 
            // cboxEditSampleType
            // 
            this.cboxEditSampleType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboxEditSampleType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxEditSampleType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxEditSampleType.DropDownWidth = 520;
            this.cboxEditSampleType.FormattingEnabled = true;
            this.cboxEditSampleType.Location = new System.Drawing.Point(515, 31);
            this.cboxEditSampleType.Name = "cboxEditSampleType";
            this.cboxEditSampleType.Size = new System.Drawing.Size(250, 23);
            this.cboxEditSampleType.TabIndex = 1;
            this.cboxEditSampleType.SelectedIndexChanged += new System.EventHandler(this.cboxEditSampleType_SelectedIndexChanged);
            // 
            // cboxEditSampleComponent
            // 
            this.cboxEditSampleComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxEditSampleComponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxEditSampleComponent.FormattingEnabled = true;
            this.cboxEditSampleComponent.Location = new System.Drawing.Point(771, 31);
            this.cboxEditSampleComponent.Name = "cboxEditSampleComponent";
            this.cboxEditSampleComponent.Size = new System.Drawing.Size(251, 23);
            this.cboxEditSampleComponent.TabIndex = 3;
            // 
            // cboxEditAccountName
            // 
            this.cboxEditAccountName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxEditAccountName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxEditAccountName.DropDownWidth = 400;
            this.cboxEditAccountName.FormattingEnabled = true;
            this.cboxEditAccountName.Location = new System.Drawing.Point(259, 31);
            this.cboxEditAccountName.Name = "cboxEditAccountName";
            this.cboxEditAccountName.Size = new System.Drawing.Size(250, 23);
            this.cboxEditAccountName.TabIndex = 4;
            this.cboxEditAccountName.SelectedIndexChanged += new System.EventHandler(this.cboxEditAccountName_SelectedIndexChanged);
            // 
            // btnEditSave
            // 
            this.btnEditSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditSave.Location = new System.Drawing.Point(771, 87);
            this.btnEditSave.Name = "btnEditSave";
            this.btnEditSave.Size = new System.Drawing.Size(251, 30);
            this.btnEditSave.TabIndex = 0;
            this.btnEditSave.Text = "Save";
            this.btnEditSave.UseVisualStyleBackColor = true;
            this.btnEditSave.Click += new System.EventHandler(this.btnEditSave_Click);
            // 
            // tbEditAccountID
            // 
            this.tbEditAccountID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbEditAccountID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEditAccountID.Location = new System.Drawing.Point(259, 59);
            this.tbEditAccountID.Name = "tbEditAccountID";
            this.tbEditAccountID.ReadOnly = true;
            this.tbEditAccountID.Size = new System.Drawing.Size(250, 14);
            this.tbEditAccountID.TabIndex = 5;
            // 
            // tbEditLab
            // 
            this.tbEditLab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEditLab.Location = new System.Drawing.Point(3, 31);
            this.tbEditLab.Name = "tbEditLab";
            this.tbEditLab.Size = new System.Drawing.Size(250, 21);
            this.tbEditLab.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Lab";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(259, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Konto";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(515, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Prøvetype";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(771, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Part";
            // 
            // pageLog
            // 
            this.pageLog.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageLog.Controls.Add(this.lbLogMessages);
            this.pageLog.Controls.Add(this.tableLayoutPanel1);
            this.pageLog.Location = new System.Drawing.Point(4, 24);
            this.pageLog.Name = "pageLog";
            this.pageLog.Padding = new System.Windows.Forms.Padding(3);
            this.pageLog.Size = new System.Drawing.Size(1031, 510);
            this.pageLog.TabIndex = 3;
            this.pageLog.Text = "Logg";
            // 
            // lbLogMessages
            // 
            this.lbLogMessages.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbLogMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbLogMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLogMessages.FormattingEnabled = true;
            this.lbLogMessages.HorizontalScrollbar = true;
            this.lbLogMessages.ItemHeight = 15;
            this.lbLogMessages.Location = new System.Drawing.Point(3, 35);
            this.lbLogMessages.Name = "lbLogMessages";
            this.lbLogMessages.ScrollAlwaysVisible = true;
            this.lbLogMessages.Size = new System.Drawing.Size(1025, 472);
            this.lbLogMessages.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboxLogSeverity, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1025, 32);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtLogFrom);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 26);
            this.panel2.TabIndex = 3;
            // 
            // dtLogFrom
            // 
            this.dtLogFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtLogFrom.Location = new System.Drawing.Point(25, 0);
            this.dtLogFrom.Name = "dtLogFrom";
            this.dtLogFrom.Size = new System.Drawing.Size(310, 21);
            this.dtLogFrom.TabIndex = 1;
            this.dtLogFrom.ValueChanged += new System.EventHandler(this.dtLogFrom_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Fra";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtLogTo);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(344, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(335, 26);
            this.panel3.TabIndex = 5;
            // 
            // dtLogTo
            // 
            this.dtLogTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtLogTo.Location = new System.Drawing.Point(20, 0);
            this.dtLogTo.Name = "dtLogTo";
            this.dtLogTo.Size = new System.Drawing.Size(315, 21);
            this.dtLogTo.TabIndex = 2;
            this.dtLogTo.ValueChanged += new System.EventHandler(this.dtLogTo_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Til";
            // 
            // cboxLogSeverity
            // 
            this.cboxLogSeverity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxLogSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxLogSeverity.FormattingEnabled = true;
            this.cboxLogSeverity.Items.AddRange(new object[] {
            "",
            "Normal",
            "Warning",
            "Critical"});
            this.cboxLogSeverity.Location = new System.Drawing.Point(685, 3);
            this.cboxLogSeverity.Name = "cboxLogSeverity";
            this.cboxLogSeverity.Size = new System.Drawing.Size(337, 23);
            this.cboxLogSeverity.TabIndex = 6;
            this.cboxLogSeverity.SelectedIndexChanged += new System.EventHandler(this.cboxLogSeverity_SelectedIndexChanged);
            // 
            // pageValidation
            // 
            this.pageValidation.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageValidation.Controls.Add(this.gridValidation);
            this.pageValidation.Location = new System.Drawing.Point(4, 24);
            this.pageValidation.Name = "pageValidation";
            this.pageValidation.Padding = new System.Windows.Forms.Padding(3);
            this.pageValidation.Size = new System.Drawing.Size(1031, 510);
            this.pageValidation.TabIndex = 4;
            this.pageValidation.Text = "Nuklider";
            // 
            // gridValidation
            // 
            this.gridValidation.AllowUserToAddRows = false;
            this.gridValidation.AllowUserToDeleteRows = false;
            this.gridValidation.AllowUserToResizeRows = false;
            this.gridValidation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridValidation.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gridValidation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridValidation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridValidation.ContextMenuStrip = this.menuValidationGrid;
            this.gridValidation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridValidation.Location = new System.Drawing.Point(3, 3);
            this.gridValidation.MultiSelect = false;
            this.gridValidation.Name = "gridValidation";
            this.gridValidation.ReadOnly = true;
            this.gridValidation.RowHeadersVisible = false;
            this.gridValidation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridValidation.Size = new System.Drawing.Size(1025, 504);
            this.gridValidation.TabIndex = 0;
            // 
            // menuValidationGrid
            // 
            this.menuValidationGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewValidationRule,
            this.menuItemEditValidationRule,
            this.menuItemDeleteNuclide});
            this.menuValidationGrid.Name = "menuValidationGrid";
            this.menuValidationGrid.Size = new System.Drawing.Size(201, 70);
            // 
            // menuItemNewValidationRule
            // 
            this.menuItemNewValidationRule.Name = "menuItemNewValidationRule";
            this.menuItemNewValidationRule.Size = new System.Drawing.Size(200, 22);
            this.menuItemNewValidationRule.Text = "Ny valideringsregel";
            this.menuItemNewValidationRule.Click += new System.EventHandler(this.menuItemNewValidationRule_Click);
            // 
            // menuItemEditValidationRule
            // 
            this.menuItemEditValidationRule.Name = "menuItemEditValidationRule";
            this.menuItemEditValidationRule.Size = new System.Drawing.Size(200, 22);
            this.menuItemEditValidationRule.Text = "Rediger valideringsregel";
            this.menuItemEditValidationRule.Click += new System.EventHandler(this.menuItemEditValidationRule_Click);
            // 
            // menuItemDeleteNuclide
            // 
            this.menuItemDeleteNuclide.Name = "menuItemDeleteNuclide";
            this.menuItemDeleteNuclide.Size = new System.Drawing.Size(200, 22);
            this.menuItemDeleteNuclide.Text = "Slett valideringsregel";
            this.menuItemDeleteNuclide.Click += new System.EventHandler(this.menuItemDeleteNuclide_Click);
            // 
            // pageGeometries
            // 
            this.pageGeometries.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageGeometries.Controls.Add(this.gridGeometries);
            this.pageGeometries.Location = new System.Drawing.Point(4, 24);
            this.pageGeometries.Name = "pageGeometries";
            this.pageGeometries.Padding = new System.Windows.Forms.Padding(3);
            this.pageGeometries.Size = new System.Drawing.Size(1031, 510);
            this.pageGeometries.TabIndex = 5;
            this.pageGeometries.Text = "Geometrier";
            // 
            // gridGeometries
            // 
            this.gridGeometries.AllowUserToAddRows = false;
            this.gridGeometries.AllowUserToDeleteRows = false;
            this.gridGeometries.AllowUserToResizeRows = false;
            this.gridGeometries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridGeometries.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gridGeometries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridGeometries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGeometries.ContextMenuStrip = this.menuGeometryGrid;
            this.gridGeometries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGeometries.Location = new System.Drawing.Point(3, 3);
            this.gridGeometries.MultiSelect = false;
            this.gridGeometries.Name = "gridGeometries";
            this.gridGeometries.ReadOnly = true;
            this.gridGeometries.RowHeadersVisible = false;
            this.gridGeometries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGeometries.Size = new System.Drawing.Size(1025, 504);
            this.gridGeometries.TabIndex = 0;
            // 
            // menuGeometryGrid
            // 
            this.menuGeometryGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewGeometryRule,
            this.menuItemEditGeometryRule,
            this.menuItemDeleteGeometry});
            this.menuGeometryGrid.Name = "menuGeometryGrid";
            this.menuGeometryGrid.Size = new System.Drawing.Size(195, 70);
            // 
            // menuItemNewGeometryRule
            // 
            this.menuItemNewGeometryRule.Name = "menuItemNewGeometryRule";
            this.menuItemNewGeometryRule.Size = new System.Drawing.Size(194, 22);
            this.menuItemNewGeometryRule.Text = "Ny geometri regel";
            this.menuItemNewGeometryRule.Click += new System.EventHandler(this.menuItemNewGeometryRule_Click);
            // 
            // menuItemEditGeometryRule
            // 
            this.menuItemEditGeometryRule.Name = "menuItemEditGeometryRule";
            this.menuItemEditGeometryRule.Size = new System.Drawing.Size(194, 22);
            this.menuItemEditGeometryRule.Text = "Rediger geometri regel";
            this.menuItemEditGeometryRule.Click += new System.EventHandler(this.menuItemEditGeometryRule_Click);
            // 
            // menuItemDeleteGeometry
            // 
            this.menuItemDeleteGeometry.Name = "menuItemDeleteGeometry";
            this.menuItemDeleteGeometry.Size = new System.Drawing.Size(194, 22);
            this.menuItemDeleteGeometry.Text = "Slett geometri regel";
            this.menuItemDeleteGeometry.Click += new System.EventHandler(this.menuItemDeleteGeometry_Click);
            // 
            // pageSettings
            // 
            this.pageSettings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageSettings.Controls.Add(this.tableLayoutPanel2);
            this.pageSettings.Controls.Add(this.panel4);
            this.pageSettings.Location = new System.Drawing.Point(4, 24);
            this.pageSettings.Name = "pageSettings";
            this.pageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.pageSettings.Size = new System.Drawing.Size(1031, 510);
            this.pageSettings.TabIndex = 6;
            this.pageSettings.Text = "Innstillinger";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbSettingsUrl, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1025, 470);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Web Service Url";
            // 
            // tbSettingsUrl
            // 
            this.tbSettingsUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSettingsUrl.Location = new System.Drawing.Point(163, 31);
            this.tbSettingsUrl.Name = "tbSettingsUrl";
            this.tbSettingsUrl.Size = new System.Drawing.Size(859, 21);
            this.tbSettingsUrl.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSettingsCancel);
            this.panel4.Controls.Add(this.btnSettingsOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 473);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1025, 34);
            this.panel4.TabIndex = 0;
            // 
            // btnSettingsCancel
            // 
            this.btnSettingsCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSettingsCancel.Location = new System.Drawing.Point(838, 0);
            this.btnSettingsCancel.Name = "btnSettingsCancel";
            this.btnSettingsCancel.Size = new System.Drawing.Size(93, 34);
            this.btnSettingsCancel.TabIndex = 1;
            this.btnSettingsCancel.Text = "Cancel";
            this.btnSettingsCancel.UseVisualStyleBackColor = true;
            this.btnSettingsCancel.Click += new System.EventHandler(this.btnSettingsCancel_Click);
            // 
            // btnSettingsOk
            // 
            this.btnSettingsOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSettingsOk.Location = new System.Drawing.Point(931, 0);
            this.btnSettingsOk.Name = "btnSettingsOk";
            this.btnSettingsOk.Size = new System.Drawing.Size(94, 34);
            this.btnSettingsOk.TabIndex = 0;
            this.btnSettingsOk.Text = "Ok";
            this.btnSettingsOk.UseVisualStyleBackColor = true;
            this.btnSettingsOk.Click += new System.EventHandler(this.btnSettingsOk_Click);
            // 
            // ofd
            // 
            this.ofd.Filter = "CNF files (*.cnf)|*.cnf|All files (*.*)|*.*";
            this.ofd.Multiselect = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 624);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lorakon spektrum database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            this.tableMain.ResumeLayout(false);
            this.pageSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).EndInit();
            this.menuGrid.ResumeLayout(false);
            this.panelSearchTop.ResumeLayout(false);
            this.tableSearch.ResumeLayout(false);
            this.tableSearch.PerformLayout();
            this.pageEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEditFiles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableEdit.ResumeLayout(false);
            this.tableEdit.PerformLayout();
            this.pageLog.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pageValidation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridValidation)).EndInit();
            this.menuValidationGrid.ResumeLayout(false);
            this.pageGeometries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridGeometries)).EndInit();
            this.menuGeometryGrid.ResumeLayout(false);
            this.pageSettings.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage pageMain;
        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.Button btnMainSearch;
        private System.Windows.Forms.TabPage pageSearch;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripSeparator separatorMain;
        private System.Windows.Forms.Panel panelSearchTop;
        private System.Windows.Forms.DataGridView gridSearch;
        private System.Windows.Forms.TableLayoutPanel tableSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearchSampleType;
        private System.Windows.Forms.ComboBox cboxAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbRejected;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip menuGrid;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowDetails;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenSpectrum;
        private System.Windows.Forms.Button btnMainEdit;
        private System.Windows.Forms.Button btnMainLog;
        private System.Windows.Forms.TabPage pageEdit;
        private System.Windows.Forms.DataGridView gridEditFiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnEditOpen;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.TableLayoutPanel tableEdit;
        private System.Windows.Forms.Button btnEditSave;
        private System.Windows.Forms.ComboBox cboxEditSampleType;
        private System.Windows.Forms.ComboBox cboxEditSampleComponent;
        private System.Windows.Forms.CheckBox cbApproved;
        private System.Windows.Forms.ComboBox cboxEditAccountName;
        private System.Windows.Forms.ToolStripProgressBar progress;
        private System.Windows.Forms.TextBox tbEditAccountID;
        private System.Windows.Forms.TabPage pageLog;
        private System.Windows.Forms.ToolStripLabel lblPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dtLogFrom;
        private System.Windows.Forms.DateTimePicker dtLogTo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbLogMessages;
        private System.Windows.Forms.ComboBox cboxLogSeverity;
        private System.Windows.Forms.Button btnMenuValidation;
        private System.Windows.Forms.Button btnMenuGeometry;
        private System.Windows.Forms.TabPage pageValidation;
        private System.Windows.Forms.TabPage pageGeometries;
        private System.Windows.Forms.DataGridView gridValidation;
        private System.Windows.Forms.ContextMenuStrip menuValidationGrid;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteNuclide;
        private System.Windows.Forms.DataGridView gridGeometries;
        private System.Windows.Forms.ContextMenuStrip menuGeometryGrid;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteGeometry;
        private System.Windows.Forms.ToolStripButton btnValidationTrash;
        private System.Windows.Forms.ToolStripButton btnGeometryTrash;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.TextBox tbEditLab;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLab;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSampleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSampleComponent;
        private System.Windows.Forms.TabPage pageSettings;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSettingsCancel;
        private System.Windows.Forms.Button btnSettingsOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbSettingsUrl;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.ToolStripButton btnValidationAdd;
        private System.Windows.Forms.ToolStripButton btnGeometryAdd;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewValidationRule;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewGeometryRule;
        private System.Windows.Forms.ToolStripMenuItem menuItemEditValidationRule;
        private System.Windows.Forms.ToolStripButton btnValidationEdit;
        private System.Windows.Forms.ToolStripButton btnGeometryEdit;
        private System.Windows.Forms.ToolStripMenuItem menuItemEditGeometryRule;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteSpectrum;
        private System.Windows.Forms.ToolStripButton btnSpectrumDelete;
        private System.Windows.Forms.ToolStripButton btnSpectrumOpenInGenie;
        private System.Windows.Forms.ToolStripButton btnSpectrumDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcquisitionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleComponent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Approved;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApprovedStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Rejected;
    }
}

