using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATABASEPROJECT.pages
{
    public partial class settings : System.Web.UI.Page
    {
        const string ConnectionString = "Data Source=LAPTOP-R0JTKVLM\\SQLEXPRESS;Initial Catalog=COINDB;Integrated Security=True ";

        protected void Page_Load(object sender, EventArgs e)
        {
            updatepass.Visible = false;
            updatemail.Visible = false;
            btnupdatepass.Visible = false;
            btnupdatemail.Visible = false;
        }

        protected void btnpass_Click(object sender, EventArgs e)
        {
            updatepass.Visible = true;
            btnupdatepass.Visible = true;
            
        }
        protected void btnmail_Click(object sender, EventArgs e)
        {
            updatemail.Visible = true;
            btnupdatemail.Visible = true;
        }

        protected void btnupdatepass_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(ConnectionString);
            sql.Open();
            SqlCommand cmd = new SqlCommand("UPDATE USERS SET USERPASS = @userpass WHERE USER_ID=@userid", sql);
            cmd.Parameters.AddWithValue("@userpass", updatepass.Text.Trim());
            cmd.Parameters.AddWithValue("@userid", Session["userID"]);
            cmd.ExecuteNonQuery();
            updatepass.Visible = false;
            btnupdatepass.Visible = false;
        }


        protected void btnupdatemail_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(ConnectionString);
            sql.Open();
            SqlCommand cmd = new SqlCommand("UPDATE USERS SET USERMAIL = @usermail WHERE USER_ID=@userid", sql);
            cmd.Parameters.AddWithValue("@usermail", updatemail.Text.Trim());
            cmd.Parameters.AddWithValue("@userid", Session["userID"]);
            cmd.ExecuteNonQuery();
            updatemail.Visible = false;
            btnupdatemail.Visible = false;
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("UPDATE USERS SET USERACTIVE='False' Where USER_ID=@userID", sqlCon);
                cmd.Parameters.AddWithValue("@userID", Session["userID"]);
                Session["userName"] = "";
                Session["userSurname"] = "";
                Session["userMail"] = "";
                Session["userPass"] = "";
                Session["userID"] = "";
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("home.aspx");

            
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(ConnectionString);
            sql.Open();
            SqlCommand cmd = new SqlCommand("UPDATE USERS SET USERACTIVE='False' Where USER_ID=@userID", sql);
            cmd.Parameters.AddWithValue("@userID", Session["userID"]);
            cmd.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("DELETE FROM WALLET WHERE USER_ID=@userid", sql);
            cmd2.Parameters.AddWithValue("@userid", Session["userID"]);
            cmd2.ExecuteNonQuery();
            SqlCommand cmd3 = new SqlCommand("DELETE FROM TRANSACTIONS WHERE USER_ID=@userid", sql);
            cmd3.Parameters.AddWithValue("@userid", Session["userID"]);
            cmd3.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("DELETE FROM USERS WHERE USER_ID=@userid", sql);
            cmd1.Parameters.AddWithValue("@userid", Session["userID"]);
            cmd1.ExecuteNonQuery();
            Session["userName"] = "";
            Session["userSurname"] = "";
            Session["userMail"] = "";
            Session["userPass"] = "";
            Session["userID"] = "";

            Response.Redirect("home.aspx");

        }
    }
}