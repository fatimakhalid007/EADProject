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

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-378F8FV\SQLEXPRESS2012;Initial Catalog=EADProject;Integrated Security=True;Pooling=False");
            con.Open();
            return con;
        }
    }
}