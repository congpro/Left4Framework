using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ResolveResXml.Model;

namespace ResolveResXml
{
    public partial class MainForm : Form
    {
        public res_project project { get; set; }
        ResolveResXml.BLL.res_project resprojectBLL = new ResolveResXml.BLL.res_project();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_ChooseResPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                this.txt_ResXmlPath.Text = ofd.FileName;
            }
            

        }

        private void 新建资源文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateResXml createRes = new CreateResXml();
           
            if (createRes.ShowDialog()==DialogResult.OK)
            {
                project = createRes.project;
                res_project resproject = resprojectBLL.GetModelList("id=" + project.id)[0];
            }
        }

        private void dgv_ResXml_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[2].Value = project.project_Name;
        }

        private void btn_Commit_Click(object sender, EventArgs e)
        {

        }
    }
}
