using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication_Practice.IService;
using WebApplication_Practice.Models;

namespace WebApplication_Practice.Service
{
    public class LoginService : ILogin
    {
        public string Save(LoginModel loginModel)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OVINNPG;Database=Project;Integrated Security=true");
            con.Open();
            string query = "insert into Login values('" + loginModel.UserName + "','" + loginModel.Password + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            var save = cmd.ExecuteNonQuery();
            con.Close();
            if (save == 1)
            {
                return "saved";
            }
            else
            {
                return "Not Saved";
            }
        }
        public List<LoginModel> List()
        {
            var Loginlist = new List<LoginModel>();

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OVINNPG;Database=Project;Integrated Security=true");
            con.Open();
            string query = "select*from Login";
            SqlCommand cmd = new SqlCommand(query, con);
            var data = cmd.ExecuteReader();
            while (data.Read())
            {
                var LoginModel = new LoginModel();
                LoginModel.Id = Convert.ToInt32(data["Id"].ToString());
                LoginModel.UserName = data["UserName"].ToString();
                LoginModel.Password = Convert.ToInt32(data["Password"].ToString());
                Loginlist.Add(LoginModel);
            }
            con.Close();
            return Loginlist;

        }
        public string Delete(int id)
        {
            var Login_Model = new LoginModel();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OVINNPG;Database=Project;Integrated Security=true");
            con.Open();
            string query = "delete from Login where Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            return "deleted";
        }
       
        public string Edit(LoginModel dpt)
        {
            //var Login_Model = new LoginModel();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OVINNPG;Database=Project;Integrated Security=true");
            con.Open();
            string query = "update Login set Password='" + dpt.Password + "',Username='" + dpt.UserName + "' where id='" + dpt.Id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();
            return "Updated";
        }
        public LoginModel  DetailsByid(int id)
        {
            var Login_Model = new LoginModel();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OVINNPG;Database=Project;Integrated Security=true");
            con.Open();
            string query = "select * from Login where Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            var data = cmd.ExecuteReader();
            while (data.Read())
            {
                Login_Model.Id = Convert.ToInt32(data["Id"].ToString());
                Login_Model.UserName = data["UserName"].ToString();
                Login_Model.Password = Convert.ToInt32(data["Password"].ToString());
            }
            con.Close();
            return Login_Model;
        }
    }
}