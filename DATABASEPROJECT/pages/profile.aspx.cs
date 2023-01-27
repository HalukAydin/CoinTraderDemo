using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATABASEPROJECT.pages
{
    
    public partial class profile : System.Web.UI.Page
    {
        const string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=COINDB;Integrated Security=True ";
        const string IsSelect = "SELECT * FROM USERS WHERE USERACTIVE='True'";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand usercmd = new SqlCommand(IsSelect, con);
            SqlCommand cmd = new SqlCommand("SELECT SUM(BALANCE) AS TOTALSUM FROM WALLET WHERE USER_ID IN(SELECT USER_ID FROM USERS WHERE USERACTIVE='True')", con);
            SqlDataReader readbalance = cmd.ExecuteReader();
            if (readbalance.Read())
            {
                    Session["balance"] = Convert.ToInt32(readbalance["TOTALSUM"]);
                    readbalance.Close();

                
            }
            else
            {
                DataList2.Visible = false;
                Session["balance"] = 0;
                readbalance.Close();
            }
            SqlDataReader readuser = usercmd.ExecuteReader();
            if (readuser.Read())
            {
                lbluser.Text = "" + readuser["USERNAME"];
                lblusers.Text = " " + readuser["USERSURNAME"];
                lblmail.Text = "" + readuser["USERMAIL"];
                lblbalance.Text = "Balance: " + Session["balance"] + "$";
            }
  
        }

        protected void btntrade_Click(object sender, EventArgs e)
        {
            Response.Redirect("TradePage.aspx");
        }
    }
}