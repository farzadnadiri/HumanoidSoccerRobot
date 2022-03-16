namespace Robot.Config
{
    partial class ConfigurationManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationManager));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeViewConfig = new System.Windows.Forms.TreeView();
            this.IconImages = new System.Windows.Forms.ImageList(this.components);
            this.buttonSetDefault = new System.Windows.Forms.Button();
            this.buttonLoadPath = new System.Windows.Forms.Button();
            this.textBoxLoad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.dataGridViewAttributes = new System.Windows.Forms.DataGridView();
            this.AttName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.Panel1 = new System.Windows.Forms.StatusBarPanel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Panel1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeViewConfig);
            this.groupBox1.Controls.Add(this.buttonSetDefault);
            this.groupBox1.Controls.Add(this.buttonLoadPath);
            this.groupBox1.Controls.Add(this.textBoxLoad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 464);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ConfigFile";
            // 
            // treeViewConfig
            // 
            this.treeViewConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewConfig.ImageIndex = 0;
            this.treeViewConfig.ImageList = this.IconImages;
            this.treeViewConfig.Location = new System.Drawing.Point(6, 26);
            this.treeViewConfig.Name = "treeViewConfig";
            this.treeViewConfig.SelectedImageIndex = 2;
            this.treeViewConfig.Size = new System.Drawing.Size(307, 376);
            this.treeViewConfig.TabIndex = 10;
            this.treeViewConfig.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
            this.treeViewConfig.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeViewConfig.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeViewConfig.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewConfig_AfterSelect);
            // 
            // IconImages
            // 
            this.IconImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconImages.ImageStream")));
            this.IconImages.TransparentColor = System.Drawing.Color.Transparent;
            this.IconImages.Images.SetKeyName(0, "Book1.ICO");
            this.IconImages.Images.SetKeyName(1, "Book2.ICO");
            this.IconImages.Images.SetKeyName(2, "Page.ICO");
            // 
            // buttonSetDefault
            // 
            this.buttonSetDefault.Location = new System.Drawing.Point(6, 435);
            this.buttonSetDefault.Name = "buttonSetDefault";
            this.buttonSetDefault.Size = new System.Drawing.Size(307, 23);
            this.buttonSetDefault.TabIndex = 9;
            this.buttonSetDefault.Text = "&Default XML";
            this.buttonSetDefault.UseVisualStyleBackColor = true;
            this.buttonSetDefault.Click += new System.EventHandler(this.buttonSetDefult_Click);
            this.buttonSetDefault.MouseEnter += new System.EventHandler(this.buttonSetDefult_MouseEnter);
            this.buttonSetDefault.MouseLeave += new System.EventHandler(this.buttonLoad_MouseLeave);
            // 
            // buttonLoadPath
            // 
            this.buttonLoadPath.Location = new System.Drawing.Point(276, 408);
            this.buttonLoadPath.Name = "buttonLoadPath";
            this.buttonLoadPath.Size = new System.Drawing.Size(36, 23);
            this.buttonLoadPath.TabIndex = 5;
            this.buttonLoadPath.Text = "...";
            this.buttonLoadPath.UseVisualStyleBackColor = true;
            this.buttonLoadPath.Click += new System.EventHandler(this.buttonLoadPath_Click);
            // 
            // textBoxLoad
            // 
            this.textBoxLoad.Enabled = false;
            this.textBoxLoad.Location = new System.Drawing.Point(44, 409);
            this.textBoxLoad.Name = "textBoxLoad";
            this.textBoxLoad.ReadOnly = true;
            this.textBoxLoad.Size = new System.Drawing.Size(226, 20);
            this.textBoxLoad.TabIndex = 3;
            this.textBoxLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Load";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.buttonApply);
            this.groupBox2.Controls.Add(this.textBoxValue);
            this.groupBox2.Controls.Add(this.dataGridViewAttributes);
            this.groupBox2.Location = new System.Drawing.Point(340, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 464);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Element Attributes";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 435);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(303, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "&Save and Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.buttonLoad_MouseLeave);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(6, 408);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(67, 23);
            this.buttonApply.TabIndex = 9;
            this.buttonApply.Text = "&Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.button2_Click);
            this.buttonApply.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.buttonApply.MouseLeave += new System.EventHandler(this.buttonLoad_MouseLeave);
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(79, 410);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(230, 20);
            this.textBoxValue.TabIndex = 1;
            this.textBoxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValue_KeyPress);
            // 
            // dataGridViewAttributes
            // 
            this.dataGridViewAttributes.AllowUserToAddRows = false;
            this.dataGridViewAttributes.AllowUserToDeleteRows = false;
            this.dataGridViewAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttName,
            this.AttValue});
            this.dataGridViewAttributes.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewAttributes.MultiSelect = false;
            this.dataGridViewAttributes.Name = "dataGridViewAttributes";
            this.dataGridViewAttributes.ReadOnly = true;
            this.dataGridViewAttributes.RowHeadersWidth = 20;
            this.dataGridViewAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAttributes.Size = new System.Drawing.Size(303, 383);
            this.dataGridViewAttributes.TabIndex = 0;
            this.dataGridViewAttributes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAttributes_CellClick);
            // 
            // AttName
            // 
            this.AttName.HeaderText = "Name";
            this.AttName.Name = "AttName";
            this.AttName.ReadOnly = true;
            this.AttName.Width = 150;
            // 
            // AttValue
            // 
            this.AttValue.HeaderText = "Value";
            this.AttValue.Name = "AttValue";
            this.AttValue.ReadOnly = true;
            // 
            // statusBar1
            // 
            this.statusBar1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.statusBar1.Location = new System.Drawing.Point(0, 480);
            this.statusBar1.MinimumSize = new System.Drawing.Size(560, 22);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.Panel1});
            this.statusBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(665, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 9;
            // 
            // Panel1
            // 
            this.Panel1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.Panel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.Panel1.Name = "Panel1";
            this.Panel1.Text = "Ready";
            this.Panel1.Width = 665;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "\"XML Files (*.xml)|*.xml|All Files (*.*)|*.*\"";
            this.openFileDialog.Title = "Load XML";
            // 
            // ConfigurationManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 502);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigurationManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration Management";
            this.Load += new System.EventHandler(this.ConfigurationManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Panel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLoadPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewAttributes;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ImageList IconImages;
        private System.Windows.Forms.Button buttonSetDefault;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel Panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TreeView treeViewConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttValue;
    }
}

