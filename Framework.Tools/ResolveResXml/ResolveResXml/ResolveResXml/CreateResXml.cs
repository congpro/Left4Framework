using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ResolveResXml.DAL;
using ResolveResXml.Model;

namespace ResolveResXml
{
    public partial class CreateResXml : Form
    {
        public CreateResXml()
        {
            InitializeComponent();
            this.cmb_Country.DataSource = CountryManage.GetCountryList();
            this.cmb_Country.DisplayMember = "CountryName";
        }
        public ResolveResXml.Model.res_project project { get; set; }

        ResolveResXml.BLL.res_project rpBll = new ResolveResXml.BLL.res_project();
        private void btn_CreateResXml_Click(object sender, EventArgs e)
        {
            string projectName = this.txt_ProjectName.Text;
            ResolveResXml.Model.Country country = this.cmb_Country.SelectedItem as Country;
            if (country != null)
            {
                List<ResolveResXml.Model.res_project> list = rpBll.GetModelList(" project_name='" + projectName + "' and project_CountryCode='" + country.CountryCode+ "'");
                if (list.Count == 0)
                {
                    ResolveResXml.Model.res_project res_project = new ResolveResXml.Model.res_project();
                    res_project.id = rpBll.GetMaxId();
                    res_project.project_Name = projectName;
                    res_project.project_CountryCode = country.CountryCode;
                    res_project.res_XMLs = new List<res_XML>();
                    bool addresult= rpBll.Add(res_project);
                    project = res_project;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    project = list[0];
                }
               
            }

        }
    }
}
