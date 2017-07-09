using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace EADProject.Models
{
    public class RecipieDAL
    {
        SqlDataAdapter da;
        DataTable dt;
        public List<Models.RecipieBO> getAllRecipies()
        {
            List<Models.RecipieBO> l = new List<Models.RecipieBO>();
            SqlConnection SecurityDBConnStr = Models.Connection.getConnection();
            string s = "Select * from Recipie ";
            SqlCommand cmd = new SqlCommand(s, SecurityDBConnStr);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            Models.RecipieBO u = new Models.RecipieBO();
            try
            {

                da.Fill(dt);
                foreach (DataRow d in dt.Rows)
                {
                    u = new Models.RecipieBO();
                    u.name = d["Name"].ToString();
                    u.recipie = (d["recipie"].ToString());
                    u.recipieFile = d["recipieFile"].ToString();
                    u.type = (d["Type"].ToString());
                    u.recipieDetail = (d["recipieDetail"].ToString());
                    u.image = (d["image"].ToString());
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
                String query = "Delete from Recipie where Id =" + i;
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
        public static void  Save(){
             
        }
        public static Boolean AddRecipie(Models.RecipieBO b)
        {
            SqlConnection SecurityDBConnStr = Connection.getConnection();
          //  Boolean statusFlag = false;
            string s ="Insert into Recipie (Name,recipie,recipieFile,Type,image,recipieDetail) values ('" + b.name + "','" + b.recipie + "','" + b.recipieFile +"','"+b.type+"','"+b.image+"','"+b.recipieDetail+ "')";
            try
            {
                    SqlCommand cmd = new SqlCommand(s, SecurityDBConnStr);
                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        return true;
                    }
            }
            catch (Exception em)
            {
                return false;
            }
            return false;

        }
        public List<Models.RecipieBO> getAllRecipiesFast_Food()
        {
            List<Models.RecipieBO> l = new List<Models.RecipieBO>();
            SqlConnection SecurityDBConnStr = Models.Connection.getConnection();
            string s = "Select * from Recipie where Type='Fast_Food' ";
            SqlCommand cmd = new SqlCommand(s, SecurityDBConnStr);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            Models.RecipieBO u = new Models.RecipieBO();
            try
            {

                da.Fill(dt);
                foreach (DataRow d in dt.Rows)
                {
                    u = new Models.RecipieBO();
                    u.name = d["Name"].ToString();
                    u.recipie = (d["recipie"].ToString());
                    u.recipieFile = d["recipieFile"].ToString();
                    u.type = (d["Type"].ToString());
                    u.recipieDetail = (d["recipieDetail"].ToString());
                    u.image = (d["image"].ToString());
                    l.Add(u);
                }

            }
            catch (Exception em)
            {
                return l;
            }
            return l;

        }
        public  Models.RecipieBO getRecipiesFast_Food(int i)
        {
            SqlConnection SecurityDBConnStr = Models.Connection.getConnection();
            string s = "Select * from Recipie Where Id="+i;
            SqlCommand cmd = new SqlCommand(s, SecurityDBConnStr);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            Models.RecipieBO u = new Models.RecipieBO();
            try
            {

                da.Fill(dt);
                foreach (DataRow d in dt.Rows)
                {
                    u = new Models.RecipieBO();
                    u.name = d["Name"].ToString();
                    u.recipie = (d["recipie"].ToString());
                    u.recipieFile = d["recipieFile"].ToString();
                    u.type = (d["Type"].ToString());
                    u.recipieDetail = (d["recipieDetail"].ToString());
                    u.image = (d["image"].ToString());
                }

            }
            catch (Exception em)
            {
                return u;
            }
            return u;

        }

    }
}