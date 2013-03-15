using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Framework.Common.TreeBuilder;

public partial class TreeDemo : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        BuildProductTree();
    }


    public void BuildProductTree()
    {
        var categories = new Category[]{
                new Category { Name ="CPU"},
                new Category { Name ="内存"},
            };
        var products = new Product[]{
                new Product{ Name = "Intel I7", Category = categories[0] },
                new Product{ Name = "Intel I5", Category = categories[0] },
                new Product{ Name = "Kingston 8G", Category = categories[1] },
                new Product{ Name = "Kingston 4G", Category = categories[1] },
            };
        var tree = TreeBuilder.Build("产品")
            .SetItems(categories)
            .SetItems(category => products.Where(p => p.Category == category))
            .SetItems(product => product.Name)
            .Tree;

        
        
        this.TreeView1.DataSource = tree;
        this.TreeView1.DataBind();
    }


    public void BuildEmployeeTree()
    {
        var employees = new Employee[]{
                new Employee{ Name = "鹤冲天" },
                new Employee{ Name = "鹤中天" },
                new Employee{ Name = "鹤微天" }
            };
        employees[0].AddSubordinate(employees[1]);
        employees[1].AddSubordinate(employees[2]);

        var tree = TreeBuilder.Build("员工树")
            .SetItems(employees.Where(e => e.ReportsTo == null))
            .SetRecursiveItems(e => e.Subordinates)
            .Tree;
    }
}