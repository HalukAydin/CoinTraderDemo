using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATABASEPROJECT.pages
{
    public partial class signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }
            lblFailure.Visible = false;
        }
        void Clear()
        {
            field_mail.Text = field_pswd.Text;
        }
        protected void btnlogin_Click (object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-R0JTKVLM\SQLEXPRESS;Initial Catalog=COINDB;Integrated Security=True"))
            {
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM USERS WHERE USERMAIL=@user_mail AND USERPASS=@userpass", sqlCon);
                SqlCommand cmd = new SqlCommand("UPDATE USERS SET USERACTIVE='True' Where USERMAIL=@userMail", sqlCon);
                cmd.Parameters.AddWithValue("@userMail",field_mail.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@user_mail", field_mail.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@userpass", field_pswd.Text.Trim());
                SqlDataReader readuser = sqlCmd.ExecuteReader();
                if (readuser.Read())
                {
                    Session["userName"] = readuser["USERNAME"];
                    Session["userSurname"] = readuser["USERSURNAME"];
                    Session["userMail"] = readuser["USERMAIL"];
                    Session["userPass"] = readuser["USERPASS"];
                    Session["userID"] = readuser["USER_ID"];
                    readuser.Close();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("home.aspx");
                    
                }
                else
                {
                    lblFailure.Visible = true;
                    lblFailure.Text = "Invalid User Credentials";
                }

               
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

    }
}