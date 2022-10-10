using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace BugTracker.Models
{
    public class db
    {
        SqlConnection con= new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BugTrackerContext-cfcf2e63-8adf-4ae6-9b36-cffd5f90d5de;Integrated Security=True");

        public db(string c)
        {
            con = new SqlConnection(c);
        }
         
        public int LoginCheck(Ad_login ad)
        {

            
            SqlCommand com = new SqlCommand("Sp_Login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Admin_id", ad.Admin_id);
            com.Parameters.AddWithValue("@Password", ad.Ad_Password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();

            var k = GetUser();
            return res;
       

       
        }

        public List<String> GetUser()
        {
            SqlCommand com = new SqlCommand("select admin_id, admin_id from [User]", con);
            com.CommandType = CommandType.Text;
            con.Open();
           
            List<String> c = new List<string>();
            using (SqlDataReader sdr = com.ExecuteReader())
            {
                while (sdr.Read())
                {
                    c.Add(sdr["admin_id"].ToString());
                }
            }
            con.Close();

            return c;
        }
    }
}
