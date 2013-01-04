namespace ResolveResXml
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建资源文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbx_Command = new System.Windows.Forms.GroupBox();
            this.btn_LoadXml = new System.Windows.Forms.Button();
            this.btn_OutputXml = new System.Windows.Forms.Button();
            this.btn_Commit = new System.Windows.Forms.Button();
            this.btn_ChooseResPath = new System.Windows.Forms.Button();
            this.txt_ResXmlPath = new System.Windows.Forms.TextBox();
            this.lbl_ResXmlPath = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_ResXml = new System.Windows.Forms.DataGridView();
            this.col_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_projectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.gbx_Command.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ResXml)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(742, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建资源文件ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建资源文件ToolStripMenuItem
            // 
            this.新建资源文件ToolStripMenuItem.Name = "新建资源文件ToolStripMenuItem";
            this.新建资源文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.新建资源文件ToolStripMenuItem.Text = "新建资源文件";
            this.新建资源文件ToolStripMenuItem.Click += new System.EventHandler(this.新建资源文件ToolStripMenuItem_Click);
            // 
            // gbx_Command
            // 
            this.gbx_Command.Controls.Add(this.btn_LoadXml);
            this.gbx_Command.Controls.Add(this.btn_OutputXml);
            this.gbx_Command.Controls.Add(this.btn_Commit);
            this.gbx_Command.Controls.Add(this.btn_ChooseResPath);
            this.gbx_Command.Controls.Add(this.txt_ResXmlPath);
            this.gbx_Command.Controls.Add(this.lbl_ResXmlPath);
            this.gbx_Command.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbx_Command.Location = new System.Drawing.Point(0, 25);
            this.gbx_Command.Name = "gbx_Command";
            this.gbx_Command.Size = new System.Drawing.Size(742, 115);
            this.gbx_Command.TabIndex = 1;
            this.gbx_Command.TabStop = false;
            this.gbx_Command.Text = "控制";
            // 
            // btn_LoadXml
            // 
            this.btn_LoadXml.Location = new System.Drawing.Point(107, 74);
            this.btn_LoadXml.Name = "btn_LoadXml";
            this.btn_LoadXml.Size = new System.Drawing.Size(75, 23);
            this.btn_LoadXml.TabIndex = 5;
            this.btn_LoadXml.Text = "加载XML";
            this.btn_LoadXml.UseVisualStyleBackColor = true;
            // 
            // btn_OutputXml
            // 
            this.btn_OutputXml.Location = new System.Drawing.Point(328, 74);
            this.btn_OutputXml.Name = "btn_OutputXml";
            this.btn_OutputXml.Size = new System.Drawing.Size(75, 23);
            this.btn_OutputXml.TabIndex = 4;
            this.btn_OutputXml.Text = "导出XML";
            this.btn_OutputXml.UseVisualStyleBackColor = true;
            // 
            // btn_Commit
            // 
            this.btn_Commit.Location = new System.Drawing.Point(512, 74);
            this.btn_Commit.Name = "btn_Commit";
            this.btn_Commit.Size = new System.Drawing.Size(75, 23);
            this.btn_Commit.TabIndex = 3;
            this.btn_Commit.Text = "提交更改";
            this.btn_Commit.UseVisualStyleBackColor = true;
            this.btn_Commit.Click += new System.EventHandler(this.btn_Commit_Click);
            // 
            // btn_ChooseResPath
            // 
            this.btn_ChooseResPath.Location = new System.Drawing.Point(605, 30);
            this.btn_ChooseResPath.Name = "btn_ChooseResPath";
            this.btn_ChooseResPath.Size = new System.Drawing.Size(75, 23);
            this.btn_ChooseResPath.TabIndex = 2;
            this.btn_ChooseResPath.Text = "选择路径";
            this.btn_ChooseResPath.UseVisualStyleBackColor = true;
            this.btn_ChooseResPath.Click += new System.EventHandler(this.btn_ChooseResPath_Click);
            // 
            // txt_ResXmlPath
            // 
            this.txt_ResXmlPath.Location = new System.Drawing.Point(107, 32);
            this.txt_ResXmlPath.Name = "txt_ResXmlPath";
            this.txt_ResXmlPath.Size = new System.Drawing.Size(480, 21);
            this.txt_ResXmlPath.TabIndex = 1;
            // 
            // lbl_ResXmlPath
            // 
            this.lbl_ResXmlPath.AutoSize = true;
            this.lbl_ResXmlPath.Location = new System.Drawing.Point(24, 35);
            this.lbl_ResXmlPath.Name = "lbl_ResXmlPath";
            this.lbl_ResXmlPath.Size = new System.Drawing.Size(77, 12);
            this.lbl_ResXmlPath.TabIndex = 0;
            this.lbl_ResXmlPath.Text = "资源XML路径:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_ResXml);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 274);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据";
            // 
            // dgv_ResXml
            // 
            this.dgv_ResXml.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ResXml.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ResXml.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_key,
            this.col_value,
            this.col_projectId});
            this.dgv_ResXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ResXml.Location = new System.Drawing.Point(3, 17);
            this.dgv_ResXml.Name = "dgv_ResXml";
            this.dgv_ResXml.RowTemplate.Height = 23;
            this.dgv_ResXml.Size = new System.Drawing.Size(736, 254);
            this.dgv_ResXml.TabIndex = 0;
            this.dgv_ResXml.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_ResXml_DefaultValuesNeeded);
            // 
            // col_key
            // 
            this.col_key.DataPropertyName = "key";
            this.col_key.HeaderText = "key";
            this.col_key.Name = "col_key";
            // 
            // col_value
            // 
            this.col_value.DataPropertyName = "value";
            this.col_value.HeaderText = "value";
            this.col_value.Name = "col_value";
            // 
            // col_projectId
            // 
            this.col_projectId.HeaderText = "projectID";
            this.col_projectId.Name = "col_projectId";
            this.col_projectId.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 414);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbx_Command);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "资源文件编辑器";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbx_Command.ResumeLayout(false);
            this.gbx_Command.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ResXml)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建资源文件ToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbx_Command;
        private System.Windows.Forms.Button btn_ChooseResPath;
        private System.Windows.Forms.TextBox txt_ResXmlPath;
        private System.Windows.Forms.Label lbl_ResXmlPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_LoadXml;
        private System.Windows.Forms.Button btn_OutputXml;
        private System.Windows.Forms.Button btn_Commit;
        private System.Windows.Forms.DataGridView dgv_ResXml;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_value;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_projectId;

    }
}

