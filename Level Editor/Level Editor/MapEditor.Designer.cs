namespace Level_Editor
{
    partial class MapEditor
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
            this.pctSurface = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interactiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foregroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rpgListTiles = new System.Windows.Forms.ImageList(this.components);
            this.listTiles = new System.Windows.Forms.ListView();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.groupBoxRightClick = new System.Windows.Forms.GroupBox();
            this.radioUnpassable = new System.Windows.Forms.RadioButton();
            this.cboCodeValues = new System.Windows.Forms.ComboBox();
            this.lblCurrentCode = new System.Windows.Forms.Label();
            this.txtNewCode = new System.Windows.Forms.TextBox();
            this.radioCode = new System.Windows.Forms.RadioButton();
            this.radioPassable = new System.Windows.Forms.RadioButton();
            this.lblMapNumber = new System.Windows.Forms.Label();
            this.cboMapNumber = new System.Windows.Forms.ComboBox();
            this.timerGameUpdate = new System.Windows.Forms.Timer(this.components);
            this.cwdButton = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.cwdLabel = new System.Windows.Forms.Label();
            this.startGameButton = new System.Windows.Forms.Button();
            this.tileIndexLabel = new System.Windows.Forms.Label();
            this.tileMapWidthInput = new System.Windows.Forms.TextBox();
            this.tileMapHeightInput = new System.Windows.Forms.TextBox();
            this.tileMapWidthLabel = new System.Windows.Forms.Label();
            this.tileMapHeightLabel = new System.Windows.Forms.Label();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.platformListTiles = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.transparentTileRadioButton = new System.Windows.Forms.RadioButton();
            this.whiteTileRadioButton = new System.Windows.Forms.RadioButton();
            this.defaultTileRadioButton = new System.Windows.Forms.RadioButton();
            this.layerSelectGroupBox = new System.Windows.Forms.GroupBox();
            this.foregroundRadioButton = new System.Windows.Forms.RadioButton();
            this.interactiveRadioButton = new System.Windows.Forms.RadioButton();
            this.backgroundRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pctSurface)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBoxRightClick.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.layerSelectGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctSurface
            // 
            this.pctSurface.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctSurface.Location = new System.Drawing.Point(758, 27);
            this.pctSurface.Name = "pctSurface";
            this.pctSurface.Size = new System.Drawing.Size(800, 600);
            this.pctSurface.TabIndex = 0;
            this.pctSurface.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.layerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1584, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMapToolStripMenuItem,
            this.saveMapToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadMapToolStripMenuItem
            // 
            this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.loadMapToolStripMenuItem.Text = "&Load Map";
            this.loadMapToolStripMenuItem.Click += new System.EventHandler(this.loadMapToolStripMenuItem_Click);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.saveMapToolStripMenuItem.Text = "&Save Map";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearMapToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // clearMapToolStripMenuItem
            // 
            this.clearMapToolStripMenuItem.Name = "clearMapToolStripMenuItem";
            this.clearMapToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.clearMapToolStripMenuItem.Text = "&Clear Map";
            this.clearMapToolStripMenuItem.Click += new System.EventHandler(this.clearMapToolStripMenuItem_Click);
            // 
            // layerToolStripMenuItem
            // 
            this.layerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundToolStripMenuItem,
            this.interactiveToolStripMenuItem,
            this.foregroundToolStripMenuItem});
            this.layerToolStripMenuItem.Name = "layerToolStripMenuItem";
            this.layerToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.layerToolStripMenuItem.Text = "&Layer";
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.backgroundToolStripMenuItem.Text = "&Background";
            this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.backgroundToolStripMenuItem_Click);
            // 
            // interactiveToolStripMenuItem
            // 
            this.interactiveToolStripMenuItem.Name = "interactiveToolStripMenuItem";
            this.interactiveToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.interactiveToolStripMenuItem.Text = "&Interactive";
            this.interactiveToolStripMenuItem.Click += new System.EventHandler(this.interactiveToolStripMenuItem_Click);
            // 
            // foregroundToolStripMenuItem
            // 
            this.foregroundToolStripMenuItem.Name = "foregroundToolStripMenuItem";
            this.foregroundToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.foregroundToolStripMenuItem.Text = "&Foreground";
            this.foregroundToolStripMenuItem.Click += new System.EventHandler(this.foregroundToolStripMenuItem_Click);
            // 
            // rpgListTiles
            // 
            this.rpgListTiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.rpgListTiles.ImageSize = new System.Drawing.Size(28, 28);
            this.rpgListTiles.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listTiles
            // 
            this.listTiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listTiles.AutoArrange = false;
            this.listTiles.HideSelection = false;
            this.listTiles.LabelWrap = false;
            this.listTiles.Location = new System.Drawing.Point(193, 27);
            this.listTiles.MultiSelect = false;
            this.listTiles.Name = "listTiles";
            this.listTiles.Size = new System.Drawing.Size(554, 787);
            this.listTiles.TabIndex = 2;
            this.listTiles.TileSize = new System.Drawing.Size(16, 16);
            this.listTiles.UseCompatibleStateImageBehavior = false;
            this.listTiles.View = System.Windows.Forms.View.SmallIcon;
            this.listTiles.SelectedIndexChanged += new System.EventHandler(this.listTiles_SelectedIndexChanged);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.LargeChange = 48;
            this.vScrollBar1.Location = new System.Drawing.Point(1558, 27);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 603);
            this.vScrollBar1.TabIndex = 3;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.LargeChange = 48;
            this.hScrollBar1.Location = new System.Drawing.Point(758, 630);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(800, 20);
            this.hScrollBar1.TabIndex = 4;
            // 
            // groupBoxRightClick
            // 
            this.groupBoxRightClick.Controls.Add(this.radioUnpassable);
            this.groupBoxRightClick.Controls.Add(this.cboCodeValues);
            this.groupBoxRightClick.Controls.Add(this.txtNewCode);
            this.groupBoxRightClick.Controls.Add(this.radioCode);
            this.groupBoxRightClick.Controls.Add(this.radioPassable);
            this.groupBoxRightClick.Location = new System.Drawing.Point(758, 653);
            this.groupBoxRightClick.Name = "groupBoxRightClick";
            this.groupBoxRightClick.Size = new System.Drawing.Size(173, 103);
            this.groupBoxRightClick.TabIndex = 5;
            this.groupBoxRightClick.TabStop = false;
            this.groupBoxRightClick.Text = "Right Click Mode";
            // 
            // radioUnpassable
            // 
            this.radioUnpassable.AutoSize = true;
            this.radioUnpassable.Location = new System.Drawing.Point(74, 17);
            this.radioUnpassable.Name = "radioUnpassable";
            this.radioUnpassable.Size = new System.Drawing.Size(81, 17);
            this.radioUnpassable.TabIndex = 8;
            this.radioUnpassable.TabStop = true;
            this.radioUnpassable.Text = "Unpassable";
            this.radioUnpassable.UseVisualStyleBackColor = true;
            this.radioUnpassable.CheckedChanged += new System.EventHandler(this.radioUnpassable_CheckedChanged);
            // 
            // cboCodeValues
            // 
            this.cboCodeValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCodeValues.FormattingEnabled = true;
            this.cboCodeValues.Location = new System.Drawing.Point(5, 75);
            this.cboCodeValues.Name = "cboCodeValues";
            this.cboCodeValues.Size = new System.Drawing.Size(160, 21);
            this.cboCodeValues.TabIndex = 4;
            this.cboCodeValues.SelectedIndexChanged += new System.EventHandler(this.cboCodeValues_SelectedIndexChanged);
            // 
            // lblCurrentCode
            // 
            this.lblCurrentCode.AutoSize = true;
            this.lblCurrentCode.Location = new System.Drawing.Point(761, 759);
            this.lblCurrentCode.Name = "lblCurrentCode";
            this.lblCurrentCode.Size = new System.Drawing.Size(16, 13);
            this.lblCurrentCode.TabIndex = 3;
            this.lblCurrentCode.Text = "---";
            // 
            // txtNewCode
            // 
            this.txtNewCode.Location = new System.Drawing.Point(62, 36);
            this.txtNewCode.Name = "txtNewCode";
            this.txtNewCode.Size = new System.Drawing.Size(103, 20);
            this.txtNewCode.TabIndex = 2;
            this.txtNewCode.TextChanged += new System.EventHandler(this.txtNewCode_TextChanged);
            // 
            // radioCode
            // 
            this.radioCode.AutoSize = true;
            this.radioCode.Location = new System.Drawing.Point(6, 35);
            this.radioCode.Name = "radioCode";
            this.radioCode.Size = new System.Drawing.Size(50, 17);
            this.radioCode.TabIndex = 1;
            this.radioCode.TabStop = true;
            this.radioCode.Text = "Code";
            this.radioCode.UseVisualStyleBackColor = true;
            this.radioCode.CheckedChanged += new System.EventHandler(this.radioCode_CheckedChanged);
            // 
            // radioPassable
            // 
            this.radioPassable.AutoSize = true;
            this.radioPassable.Checked = true;
            this.radioPassable.Location = new System.Drawing.Point(6, 17);
            this.radioPassable.Name = "radioPassable";
            this.radioPassable.Size = new System.Drawing.Size(68, 17);
            this.radioPassable.TabIndex = 0;
            this.radioPassable.TabStop = true;
            this.radioPassable.Text = "Passable";
            this.radioPassable.UseVisualStyleBackColor = true;
            this.radioPassable.CheckedChanged += new System.EventHandler(this.radioPassable_CheckedChanged);
            // 
            // lblMapNumber
            // 
            this.lblMapNumber.AutoSize = true;
            this.lblMapNumber.Location = new System.Drawing.Point(11, 27);
            this.lblMapNumber.Name = "lblMapNumber";
            this.lblMapNumber.Size = new System.Drawing.Size(71, 13);
            this.lblMapNumber.TabIndex = 6;
            this.lblMapNumber.Text = "Map Number:";
            // 
            // cboMapNumber
            // 
            this.cboMapNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMapNumber.FormattingEnabled = true;
            this.cboMapNumber.Location = new System.Drawing.Point(83, 27);
            this.cboMapNumber.Name = "cboMapNumber";
            this.cboMapNumber.Size = new System.Drawing.Size(94, 21);
            this.cboMapNumber.TabIndex = 7;
            // 
            // timerGameUpdate
            // 
            this.timerGameUpdate.Enabled = true;
            this.timerGameUpdate.Interval = 20;
            this.timerGameUpdate.Tick += new System.EventHandler(this.timerGameUpdate_Tick);
            // 
            // cwdButton
            // 
            this.cwdButton.Location = new System.Drawing.Point(12, 84);
            this.cwdButton.Name = "cwdButton";
            this.cwdButton.Size = new System.Drawing.Size(159, 23);
            this.cwdButton.TabIndex = 8;
            this.cwdButton.Text = "Change working directory";
            this.cwdButton.UseVisualStyleBackColor = true;
            this.cwdButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // folderBrowser
            // 
            this.folderBrowser.Description = "Select working directory";
            // 
            // cwdLabel
            // 
            this.cwdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cwdLabel.AutoSize = true;
            this.cwdLabel.Location = new System.Drawing.Point(13, 840);
            this.cwdLabel.Name = "cwdLabel";
            this.cwdLabel.Size = new System.Drawing.Size(0, 13);
            this.cwdLabel.TabIndex = 9;
            // 
            // startGameButton
            // 
            this.startGameButton.Location = new System.Drawing.Point(12, 113);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(159, 23);
            this.startGameButton.TabIndex = 10;
            this.startGameButton.Text = "Start Game";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // tileIndexLabel
            // 
            this.tileIndexLabel.AutoSize = true;
            this.tileIndexLabel.Location = new System.Drawing.Point(11, 199);
            this.tileIndexLabel.Name = "tileIndexLabel";
            this.tileIndexLabel.Size = new System.Drawing.Size(0, 13);
            this.tileIndexLabel.TabIndex = 11;
            // 
            // tileMapWidthInput
            // 
            this.tileMapWidthInput.Location = new System.Drawing.Point(69, 146);
            this.tileMapWidthInput.Name = "tileMapWidthInput";
            this.tileMapWidthInput.Size = new System.Drawing.Size(100, 20);
            this.tileMapWidthInput.TabIndex = 12;
            this.tileMapWidthInput.Leave += new System.EventHandler(this.tileMapWidthInput_Leave);
            // 
            // tileMapHeightInput
            // 
            this.tileMapHeightInput.Location = new System.Drawing.Point(69, 172);
            this.tileMapHeightInput.Name = "tileMapHeightInput";
            this.tileMapHeightInput.Size = new System.Drawing.Size(100, 20);
            this.tileMapHeightInput.TabIndex = 13;
            this.tileMapHeightInput.Leave += new System.EventHandler(this.tileMapHeightInput_Leave);
            // 
            // tileMapWidthLabel
            // 
            this.tileMapWidthLabel.AutoSize = true;
            this.tileMapWidthLabel.Location = new System.Drawing.Point(11, 149);
            this.tileMapWidthLabel.Name = "tileMapWidthLabel";
            this.tileMapWidthLabel.Size = new System.Drawing.Size(56, 13);
            this.tileMapWidthLabel.TabIndex = 14;
            this.tileMapWidthLabel.Text = "MapWidth";
            // 
            // tileMapHeightLabel
            // 
            this.tileMapHeightLabel.AutoSize = true;
            this.tileMapHeightLabel.Location = new System.Drawing.Point(11, 175);
            this.tileMapHeightLabel.Name = "tileMapHeightLabel";
            this.tileMapHeightLabel.Size = new System.Drawing.Size(59, 13);
            this.tileMapHeightLabel.TabIndex = 15;
            this.tileMapHeightLabel.Text = "MapHeight";
            // 
            // modeComboBox
            // 
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.Items.AddRange(new object[] {
            "RPG",
            "Platform"});
            this.modeComboBox.Location = new System.Drawing.Point(48, 54);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(125, 21);
            this.modeComboBox.TabIndex = 16;
            this.modeComboBox.SelectedIndexChanged += new System.EventHandler(this.modeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Mode:";
            // 
            // platformListTiles
            // 
            this.platformListTiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.platformListTiles.ImageSize = new System.Drawing.Size(28, 28);
            this.platformListTiles.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.transparentTileRadioButton);
            this.groupBox1.Controls.Add(this.whiteTileRadioButton);
            this.groupBox1.Controls.Add(this.defaultTileRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(937, 653);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 103);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fast Tile Select";
            // 
            // transparentTileRadioButton
            // 
            this.transparentTileRadioButton.AutoSize = true;
            this.transparentTileRadioButton.Location = new System.Drawing.Point(7, 66);
            this.transparentTileRadioButton.Name = "transparentTileRadioButton";
            this.transparentTileRadioButton.Size = new System.Drawing.Size(102, 17);
            this.transparentTileRadioButton.TabIndex = 2;
            this.transparentTileRadioButton.TabStop = true;
            this.transparentTileRadioButton.Text = "Transparent Tile";
            this.transparentTileRadioButton.UseVisualStyleBackColor = true;
            this.transparentTileRadioButton.CheckedChanged += new System.EventHandler(this.transparentTileRadioButton_CheckedChanged);
            // 
            // whiteTileRadioButton
            // 
            this.whiteTileRadioButton.AutoSize = true;
            this.whiteTileRadioButton.Location = new System.Drawing.Point(7, 43);
            this.whiteTileRadioButton.Name = "whiteTileRadioButton";
            this.whiteTileRadioButton.Size = new System.Drawing.Size(73, 17);
            this.whiteTileRadioButton.TabIndex = 1;
            this.whiteTileRadioButton.TabStop = true;
            this.whiteTileRadioButton.Text = "White Tile";
            this.whiteTileRadioButton.UseVisualStyleBackColor = true;
            this.whiteTileRadioButton.CheckedChanged += new System.EventHandler(this.whiteTileRadioButton_CheckedChanged);
            // 
            // defaultTileRadioButton
            // 
            this.defaultTileRadioButton.AutoSize = true;
            this.defaultTileRadioButton.Location = new System.Drawing.Point(7, 20);
            this.defaultTileRadioButton.Name = "defaultTileRadioButton";
            this.defaultTileRadioButton.Size = new System.Drawing.Size(79, 17);
            this.defaultTileRadioButton.TabIndex = 0;
            this.defaultTileRadioButton.TabStop = true;
            this.defaultTileRadioButton.Text = "Default Tile";
            this.defaultTileRadioButton.UseVisualStyleBackColor = true;
            this.defaultTileRadioButton.CheckedChanged += new System.EventHandler(this.defaultTileRadioButton_CheckedChanged);
            // 
            // layerSelectGroupBox
            // 
            this.layerSelectGroupBox.Controls.Add(this.foregroundRadioButton);
            this.layerSelectGroupBox.Controls.Add(this.interactiveRadioButton);
            this.layerSelectGroupBox.Controls.Add(this.backgroundRadioButton);
            this.layerSelectGroupBox.Location = new System.Drawing.Point(1116, 653);
            this.layerSelectGroupBox.Name = "layerSelectGroupBox";
            this.layerSelectGroupBox.Size = new System.Drawing.Size(173, 103);
            this.layerSelectGroupBox.TabIndex = 19;
            this.layerSelectGroupBox.TabStop = false;
            this.layerSelectGroupBox.Text = "Fast Layer Select";
            // 
            // foregroundRadioButton
            // 
            this.foregroundRadioButton.AutoSize = true;
            this.foregroundRadioButton.Location = new System.Drawing.Point(6, 66);
            this.foregroundRadioButton.Name = "foregroundRadioButton";
            this.foregroundRadioButton.Size = new System.Drawing.Size(79, 17);
            this.foregroundRadioButton.TabIndex = 2;
            this.foregroundRadioButton.TabStop = true;
            this.foregroundRadioButton.Text = "Foreground";
            this.foregroundRadioButton.UseVisualStyleBackColor = true;
            this.foregroundRadioButton.CheckedChanged += new System.EventHandler(this.foregroundRadioButton_CheckedChanged);
            // 
            // interactiveRadioButton
            // 
            this.interactiveRadioButton.AutoSize = true;
            this.interactiveRadioButton.Location = new System.Drawing.Point(6, 43);
            this.interactiveRadioButton.Name = "interactiveRadioButton";
            this.interactiveRadioButton.Size = new System.Drawing.Size(75, 17);
            this.interactiveRadioButton.TabIndex = 1;
            this.interactiveRadioButton.TabStop = true;
            this.interactiveRadioButton.Text = "Interactive";
            this.interactiveRadioButton.UseVisualStyleBackColor = true;
            this.interactiveRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // backgroundRadioButton
            // 
            this.backgroundRadioButton.AutoSize = true;
            this.backgroundRadioButton.Location = new System.Drawing.Point(6, 20);
            this.backgroundRadioButton.Name = "backgroundRadioButton";
            this.backgroundRadioButton.Size = new System.Drawing.Size(83, 17);
            this.backgroundRadioButton.TabIndex = 0;
            this.backgroundRadioButton.TabStop = true;
            this.backgroundRadioButton.Text = "Background";
            this.backgroundRadioButton.UseVisualStyleBackColor = true;
            this.backgroundRadioButton.CheckedChanged += new System.EventHandler(this.backgroundRadioButton_CheckedChanged);
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 862);
            this.Controls.Add(this.layerSelectGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCurrentCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modeComboBox);
            this.Controls.Add(this.tileMapHeightLabel);
            this.Controls.Add(this.tileMapWidthLabel);
            this.Controls.Add(this.tileMapHeightInput);
            this.Controls.Add(this.tileMapWidthInput);
            this.Controls.Add(this.tileIndexLabel);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.cwdLabel);
            this.Controls.Add(this.cwdButton);
            this.Controls.Add(this.cboMapNumber);
            this.Controls.Add(this.lblMapNumber);
            this.Controls.Add(this.groupBoxRightClick);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.listTiles);
            this.Controls.Add(this.pctSurface);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MapEditor";
            this.Text = "MapEditor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapEditor_FormClosed);
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.Shown += new System.EventHandler(this.MapEditor_Shown);
            this.Resize += new System.EventHandler(this.MapEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pctSurface)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxRightClick.ResumeLayout(false);
            this.groupBoxRightClick.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.layerSelectGroupBox.ResumeLayout(false);
            this.layerSelectGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pctSurface;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interactiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foregroundToolStripMenuItem;
        private System.Windows.Forms.ImageList rpgListTiles;
        private System.Windows.Forms.ListView listTiles;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.GroupBox groupBoxRightClick;
        private System.Windows.Forms.ComboBox cboCodeValues;
        private System.Windows.Forms.Label lblCurrentCode;
        private System.Windows.Forms.TextBox txtNewCode;
        private System.Windows.Forms.RadioButton radioCode;
        private System.Windows.Forms.RadioButton radioPassable;
        private System.Windows.Forms.Label lblMapNumber;
        private System.Windows.Forms.ComboBox cboMapNumber;
        private System.Windows.Forms.Timer timerGameUpdate;
        private System.Windows.Forms.RadioButton radioUnpassable;
        private System.Windows.Forms.Button cwdButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Label cwdLabel;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Label tileIndexLabel;
        private System.Windows.Forms.TextBox tileMapWidthInput;
        private System.Windows.Forms.TextBox tileMapHeightInput;
        private System.Windows.Forms.Label tileMapWidthLabel;
        private System.Windows.Forms.Label tileMapHeightLabel;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList platformListTiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton transparentTileRadioButton;
        private System.Windows.Forms.RadioButton whiteTileRadioButton;
        private System.Windows.Forms.RadioButton defaultTileRadioButton;
        private System.Windows.Forms.GroupBox layerSelectGroupBox;
        private System.Windows.Forms.RadioButton foregroundRadioButton;
        private System.Windows.Forms.RadioButton interactiveRadioButton;
        private System.Windows.Forms.RadioButton backgroundRadioButton;
    }
}