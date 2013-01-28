using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Linq;
using System.Dynamic;
using System.Data.Common;

using Autofac;
using Framework.DataAccess.ORM;
using Framework.DataAccess.ORM.FluentData;
using Framework.DataAccess;
using Framework.Infrastructure;
using Framework.Infrastructure.DependencyManagement;
using Framework.Common;
using Framework.Config;
using Framework.Cache;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //IDataProvider provider = DataContext.CreateDefaultInstance();
        //IDataProvider provider = DataContext.CreateInstance("sql");

        if (!IsPostBack)
        {
            //System.Linq.Enumerable.

           // IEnumerable able = new ArrayList();
            //IEnumerable<Dynamic> able;
            string conname = @"Connection String";
            //DapperAccess access = new DapperAccess(conname);
            string sql = "SELECT top 1 * FROM  dbo.tblUserSetting";
            //var able = access.Query(sql);
            //DataTable table = ToDataTable(able);

          //  EngineContext.Initialize(true);

          //  IDbProvider provider = new SqlServerProvider();
           
            //ContainerBuilder bulider = new ContainerBuilder();
            //bulider.RegisterType<SqlServerProvider>().As<IDbProvider>();
            //var container = bulider.Build();
      
            //var hander=container.Resolve<IDbProvider>();


            //ioc continer test
            var hander =  EngineContext.Current.Resolve<IDbProvider>();
            //DataTable table =  FlexAccess.CreateContext(conname,DbProviderTypes.SqlServer).Sql("SELECT top 1 * FROM  dbo.tblUserSetting").QueryDataTable();

            DataTable table = FlexAccess.CreateContext(conname, hander)
                                        .Sql("SELECT top 1 * FROM  dbo.tblUserSetting")
                                        .QuerySingle<DataTable>();

           // var cache = EngineContext.Current.Resolve<ICache>();

            var cache = EngineContext.Current.Resolve<ICache>("memory");
            
            //Repeater1.DataSource = table ;
            //Repeater1.DataBind();
            //var result = from p in able select p;
            
            GridView1.DataSource = table;
            //DataSet data = provider.ExecuteDataSet("select * from jcms_normal_user_cart",CommandType.Text);
            //GridView1.DataSource = table;
            GridView1.DataBind();


            SerializeHelper.SerializeObject("redis",new RedisConfigInfo());
            //redis config load test
            //RedisStrategy.Initialize();


        }
    }

    public static DataTable ToDataTable(IEnumerable list)
    {
        //创建属性的集合  
        List<PropertyInfo> pList = new List<PropertyInfo>();
        //获得反射的入口  
        Type type = list.AsQueryable().ElementType;
        DataTable dt = new DataTable();
        //把所有的public属性加入到集合 并添加DataTable的列  
        Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });
        foreach (var item in list)
        {
            //创建一个DataRow实例  
            DataRow row = dt.NewRow();
            //给row 赋值  
            pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
            //加入到DataTable  
            dt.Rows.Add(row);
        }
        return dt;
    }


    public void Test()
    {
        //前面2个int为所需要的参数,第3个int 则为返回值的类型
        Expression<Func<int, int, int>> expression = (a, b) => a + b;
        int result = expression.Compile()(2, 3);

       Expression<Func<int,object>> exp = (c) =>c+10;
    }
}
