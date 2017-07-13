using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace EADProject.Models
{
    public class Connection
    {
        public static SqlConnection getConnection()
        {
            //String System=System.Confi
//            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-378F8FV\SQLEXPRESS2012;Initial Catalog=EADProject;Integrated Security=True;Pooling=False");
            SqlConnection con = new SqlConnection(@"Server=d84944bc-86ec-4b37-9b43-a7ad010dfeff.sqlserver.sequelizer.com;Database=dbd84944bc86ec4b379b43a7ad010dfeff;User ID=wuqlqaeghliccray;Password=yiyUzcvyJnpKkpi8ATABDHGafi7z2mBWkZJnfqgpKgCjqncceNMNjnYYJyNqd4Fw;");

con.Open();
            return con;
        }
    }
}