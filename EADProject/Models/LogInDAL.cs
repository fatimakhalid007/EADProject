using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace EADProject.Models
{
    public class LogInDAL
    {
        SqlDataAdapter da;
        DataTable dt;
        public List<Models.LogInBO> getUsers()
        {
           List<Models.LogInBO> l = new List<Models.LogInBO>();
            SqlConnection SecurityDBConnStr = Models.Connection.getConnection();
            string s = "Select * from SignUp ";
            SqlCommand cmd = new SqlCommand(s, SecurityDBConnStr);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            Models.LogInBO u = new Models.LogInBO();
            try
            {

                da.Fill(dt);
                foreach (DataRow d in dt.Rows)
                {
                    u = new Models.LogInBO();
                    u.setemail(d["Email"].ToString());
                    u.setpass(d["Password"].ToString());
                    l.Add(u);
                }

            }
            catch (Exception em)
            {
                return l;
            }
            return l;

        }
        public List<Models.SignUpBO> getAllUsers()
        {
            List<Models.SignUpBO> l = new List<Models.SignUpBO>();
            SqlConnection SecurityDBConnStr = Models.Connection.getConnection();
            string s = "Select * from SignUp ";
            SqlCommand cmd = new SqlCommand(s, SecurityDBConnStr);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            Models.SignUpBO u = new Models.SignUpBO();
            try
            {

                da.Fill(dt);
                foreach (DataRow d in dt.Rows)
                {
                    u = new Models.SignUpBO();
                    u.username=d["UserName"].ToString();
                    u.email=(d["Email"].ToString());
                    u.pass=(d["Password"].ToString());
                    l.Add(u);
                }

            }
            catch (Exception em)
            {
                return l;
            }
            return l;

        }
        public static void delete(int i)
        {
            try
            {
                SqlConnection SecurityDBConnStr = Connection.getConnection();
                String query = "Delete from SignUp where Id =" + i ;
                SqlCommand comm = new SqlCommand(query, SecurityDBConnStr);

                int r = comm.ExecuteNonQuery();
                if (r > 0)
                {
                   // return true;
                }

            }
            catch (Exception e)
            {
              //  return false;
            }
            //return false;
        }
        public static Boolean validateUser(LogInBO u){
            List<Models.LogInBO> l = new List<Models.LogInBO>();
            LogInDAL d = new LogInDAL();
            l = d.getUsers();
            Boolean statusFlag = false;
            if (u.email.Contains("@") && u.email.Contains("."))
            {
                statusFlag = true;
            }
            if (statusFlag)
            {
                for (int i = 0; i < l.Capacity; i++)
                {
                    if (l[i].email.Equals(u.email) && l[i].pass.Equals(u.pass))
                    {
                        return true;
                    }

                }
            }
            return false;
           
        }
        public static Boolean AddUser(Models.SignUpBO b)
        {
            SqlConnection SecurityDBConnStr = Connection.getConnection();
            Boolean statusFlag = false;
            if (b.email.Contains("@") && b.email.Contains("."))
            {
                statusFlag = true;
            }
            if (!b.pass.Equals(b.repass))
            {
                return false;
            }
            string s = "Insert into SignUp (UserName,Email,Password) values ('" + b.username + "','" + b.email + "','"+b.pass+"')";
            try
            {
                if (statusFlag)
                {
                    SqlCommand cmd = new SqlCommand(s, SecurityDBConnStr);
                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception em)
            {
                return false;
            }
            return false;

        }
    }

}