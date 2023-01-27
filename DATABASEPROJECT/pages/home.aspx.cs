using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATABASEPROJECT.pages
{
    public partial class home : System.Web.UI.Page
    {
        const string ConnectionString = null;
        const string IsSelect = "SELECT * FROM USERS WHERE USERACTIVE='True'";
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(ConnectionString);
            sql.Open();
            SqlCommand cmd = new SqlCommand (IsSelect,sql);
            SqlDataReader readuser = cmd.ExecuteReader();
            if (readuser.Read())
            {
                Session["userName"] = readuser["USERNAME"];
                Session["userSurname"] = readuser["USERSURNAME"];
                Session["userMail"] = readuser["USERMAIL"];
                Session["userPass"] = readuser["USERPASS"];
                Session["userID"] = readuser["USER_ID"];
                log.Visible = false;
                sign.Visible = false;
                prof.Text = "" + readuser["USERNAME"]+ readuser["USERSURNAME"];
                trade.Visible = true;
            }
            else 
            {
                trade.Visible = false;
                prof.Visible = false;
            }
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
