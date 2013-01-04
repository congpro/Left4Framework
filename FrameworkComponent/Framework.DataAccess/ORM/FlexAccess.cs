using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Framework.DataAccess;
using Framework.DataAccess.ORM.FluentData;

namespace Framework.DataAccess.ORM
{
    public  class FlexAccess
    {

        private static IDbContext context;

        public static  IDbContext CreateContext(string connectionName,IDbProvider provider)
        {
            context = new DbContext().ConnectionStringName(connectionName, provider);
            return context;
        }

        public static IDbContext CreateContext(IDbProvider provider)
        {
            context= new DbContext().ConnectionStringName("MasterConnectionString", provider);
            return context;
        }

        
    }
}
