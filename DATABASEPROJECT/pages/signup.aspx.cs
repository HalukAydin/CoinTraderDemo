using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATABASEPROJECT.pages
{
    public partial class register : System.Web.UI.Page
    {
        const string ConnectionString = null;
        const string IsSelect = "SELECT COUNT(*) FROM USERS WHERE USERMAIL = @user_mail";
        DateTime date =DateTime.Today;
        public int rowExist()
        {

            int rowAffected = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd1 = new SqlCommand(IsSelect, con);
            cmd1.Parameters.AddWithValue("@user_mail", (field_mail.Text));


            cmd1.ExecuteNonQuery();
            rowAffected = (int)cmd1.ExecuteScalar();

            return rowAffected;
        }
        public int A()
        {
            string stmt = "SELECT COUNT(*) FROM USERS";
            int count = 0;

            using (SqlConnection thisConnection = new SqlConnection(null))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                {
                    thisConnection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }
            }
            return count;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }

            lblFailure.Visible=false;
            

        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            if (field_fname.Text == "" || field_lname.Text == "" || field_password.Text == "" || field_mail.Text == "")
            {
                lblFailure.Visible = true;
                lblFailure.Text = "All fields must be filled";
            }
            else
            {
                SqlConnection conn = new SqlConnection(null);
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO USERS (USER_ID,USERNAME,USERSURNAME,USERMAIL,USERPASS,USERACTIVE,DATEOFCREATION) Values('" + A() + "','" + field_fname.Text + "','" + field_lname.Text + "','" + field_mail.Text + "','" + field_password.Text + "','False','"+ date +"')", conn);
                SqlCommand cmd2 = new SqlCommand("INSERT INTO WALLET (USER_ID,COINNAME,COINAMOUNT,BALANCE,COINIMAGE) Values('" + A() + "','USDT',1000000,1000000,'images/USDT.png')", conn);


                int rows = rowExist();
                if (rows == 0)
                {
                    cmd.ExecuteNonQuery();
                    
                    cmd2.ExecuteNonQuery();
                   
                    conn.Close();

                    Response.Redirect("login.aspx");
                }
                else
                {
                    lblFailure.Visible = true;
                    lblFailure.Text = "Email is already taken!!";
                }
            }
        }
        void Clear()
        {
            field_fname.Text = field_lname.Text = field_password.Text = field_mail.Text;
        }
    }
}
