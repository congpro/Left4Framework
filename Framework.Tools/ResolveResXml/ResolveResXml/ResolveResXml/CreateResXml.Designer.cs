namespace ResolveResXml
{
    partial class CreateResXml
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_Country = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CreateResXml = new System.Windows.Forms.Button();
            this.btn_ChoosePath = new System.Windows.Forms.Button();
            this.txt_ResXmlPath = new System.Windows.Forms.TextBox();
            this.lbl_ResXmlPath = new System.Windows.Forms.Label();
            this.txt_ProjectName = new System.Windows.Forms.TextBox();
            this.lbl_ProjectName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmb_Country);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_CreateResXml);
            this.panel1.Controls.Add(this.btn_ChoosePath);
            this.panel1.Controls.Add(this.txt_ResXmlPath);
            this.panel1.Controls.Add(this.lbl_ResXmlPath);
            this.panel1.Controls.Add(this.txt_ProjectName);
            this.panel1.Controls.Add(this.lbl_ProjectName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 136);
            this.panel1.TabIndex = 0;
            // 
            // cmb_Country
            // 
            this.cmb_Country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Country.FormattingEnabled = true;
            this.cmb_Country.Location = new System.Drawing.Point(309, 22);
            this.cmb_Country.Name = "cmb_Country";
            this.cmb_Country.Size = new System.Drawing.Size(133, 20);
            this.cmb_Country.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "国家:";
            // 
            // btn_CreateResXml
            // 
            this.btn_CreateResXml.Location = new System.Drawing.Point(139, 101);
            this.btn_CreateResXml.Name = "btn_CreateResXml";
            this.btn_CreateResXml.Size = new System.Drawing.Size(263, 23);
            this.btn_CreateResXml.TabIndex = 5;
            this.btn_CreateResXml.Text = "生成资源文件";
            this.btn_CreateResXml.UseVisualStyleBackColor = true;
            this.btn_CreateResXml.Click += new System.EventHandler(this.btn_CreateResXml_Click);
            // 
            // btn_ChoosePath
            // 
            this.btn_ChoosePath.Location = new System.Drawing.Point(458, 64);
            this.btn_ChoosePath.Name = "btn_ChoosePath";
            this.btn_ChoosePath.Size = new System.Drawing.Size(75, 23);
            this.btn_ChoosePath.TabIndex = 4;
            this.btn_ChoosePath.Text = "选择路径";
            this.btn_ChoosePath.UseVisualStyleBackColor = true;
            // 
            // txt_ResXmlPath
            // 
            this.txt_ResXmlPath.Location = new System.Drawing.Point(94, 66);
            this.txt_ResXmlPath.Name = "txt_ResXmlPath";
            this.txt_ResXmlPath.Size = new System.Drawing.Size(348, 21);
            this.txt_ResXmlPath.TabIndex = 3;
            // 
            // lbl_ResXmlPath
            // 
            this.lbl_ResXmlPath.AutoSize = true;
            this.lbl_ResXmlPath.Location = new System.Drawing.Point(29, 69);
            this.lbl_ResXmlPath.Name = "lbl_ResXmlPath";
            this.lbl_ResXmlPath.Size = new System.Drawing.Size(59, 12);
            this.lbl_ResXmlPath.TabIndex = 2;
            this.lbl_ResXmlPath.Text = "资源路径:";
            // 
            // txt_ProjectName
            // 
            this.txt_ProjectName.Location = new System.Drawing.Point(94, 22);
            this.txt_ProjectName.Name = "txt_ProjectName";
            this.txt_ProjectName.Size = new System.Drawing.Size(146, 21);
            this.txt_ProjectName.TabIndex = 1;
            // 
            // lbl_ProjectName
            // 
            this.lbl_ProjectName.AutoSize = true;
            this.lbl_ProjectName.Location = new System.Drawing.Point(29, 25);
            this.lbl_ProjectName.Name = "lbl_ProjectName";
            this.lbl_ProjectName.Size = new System.Drawing.Size(59, 12);
            this.lbl_ProjectName.TabIndex = 0;
            this.lbl_ProjectName.Text = "项目名称:";
            // 
            // CreateResXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 136);
            this.Controls.Add(this.panel1);
            this.Name = "CreateResXml";
            this.Text = "新建资源文件";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_ProjectName;
        private System.Windows.Forms.Label lbl_ResXmlPath;
        private System.Windows.Forms.TextBox txt_ProjectName;
        private System.Windows.Forms.TextBox txt_ResXmlPath;
        private System.Windows.Forms.Button btn_ChoosePath;
        private System.Windows.Forms.Button btn_CreateResXml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Country;
    }
}