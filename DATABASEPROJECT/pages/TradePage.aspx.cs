using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dbproj
{
    public partial class TradePage : System.Web.UI.Page
    {
        const string ConnectionString = null;
        DateTime date =DateTime.Today;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblfailure.Visible = false;
            string coinname = Request.Form["Coins"];
            if (coinname == null) {
                SqlConnection sql = new SqlConnection(ConnectionString);
                sql.Open();
                SqlCommand cmd = new SqlCommand("SELECT CPRICE FROM COINS WHERE CNAME = 'BTC'", sql);
                SqlDataReader readprice = cmd.ExecuteReader();
                readprice.Read();
                priceLabel.Text = ""+readprice["CPRICE"];

            }
            else
            {
                SqlConnection sql = new SqlConnection(ConnectionString);
                sql.Open();
                SqlCommand cmd = new SqlCommand("SELECT CPRICE FROM COINS WHERE CNAME = @coinname", sql);
                cmd.Parameters.AddWithValue("@coinname", coinname);
                SqlDataReader readprice = cmd.ExecuteReader();
                readprice.Read();
                priceLabel.Text = ""+readprice["CPRICE"];

            }

        }
        protected void sellButton_Click(object sender, EventArgs e)
        {
            int sellamount = Convert.ToInt32(sellAmountInputField.Text);
            string coinname = Request.Form["Coins"];
            SqlConnection sql = new SqlConnection(ConnectionString);
            sql.Open();
            SqlCommand cmdamount = new SqlCommand("SELECT COINAMOUNT FROM WALLET WHERE COINNAME=@coinname AND USER_ID=@userid", sql);
            cmdamount.Parameters.AddWithValue("@userid", Session["userID"]);
            cmdamount.Parameters.AddWithValue("@coinname", coinname);
            SqlCommand cmdusd = new SqlCommand("SELECT COINAMOUNT FROM WALLET WHERE COINNAME='USDT' AND USER_ID=@userid", sql);
            cmdusd.Parameters.AddWithValue("@userid", Session["userID"]);
            SqlDataReader readusd = cmdusd.ExecuteReader();
            readusd.Read();
            int usdt = Convert.ToInt32(readusd["COINAMOUNT"]);
            readusd.Close();
            SqlCommand cmdprice = new SqlCommand("SELECT CPRICE FROM COINS WHERE CNAME = @coinname",sql);
            cmdprice.Parameters.AddWithValue("@coinname", coinname);
            SqlDataReader readprice = cmdprice.ExecuteReader();
            readprice.Read();
                double cprice = Math.Round(Convert.ToDouble(readprice["CPRICE"]),2);
                readprice.Close();           
            SqlDataReader readamount = cmdamount.ExecuteReader();
            if (readamount.Read())
            {
                double command = sellamount / cprice;
                double Coinamount = Math.Round(Convert.ToDouble(readamount["COINAMOUNT"]),2);
                readamount.Close();

                if (command < Coinamount)
                {
                    SqlCommand cmdupdate = new SqlCommand("UPDATE WALLET SET COINAMOUNT = @coinamount - @price WHERE COINNAME=@coinname AND USER_ID=@userid", sql);
                    cmdupdate.Parameters.AddWithValue("@coinamount", Coinamount);
                    cmdupdate.Parameters.AddWithValue("@price", command);
                    cmdupdate.Parameters.AddWithValue("@coinname", coinname);
                    cmdupdate.Parameters.AddWithValue("@userid", Session["userID"]);
                    cmdupdate.ExecuteNonQuery();
                    SqlCommand usdupdate = new SqlCommand("UPDATE WALLET SET COINAMOUNT=@usdamount + @income WHERE COINNAME='USDT' AND USER_ID=@userid", sql);
                    usdupdate.Parameters.AddWithValue("@usdamount", usdt);
                    usdupdate.Parameters.AddWithValue("@income", sellamount);
                    usdupdate.Parameters.AddWithValue("@userid", Session["userID"]);
                    usdupdate.ExecuteNonQuery();
                    SqlCommand transaction = new SqlCommand("INSERT INTO TRANSACTIONS(USER_ID,COINNAME,BUY_SELL,AMOUNT,PRICE,T_DATE) VALUES (@userid,@coinname,'SELL',@amount,@price,'"+ date + "')", sql);
                    transaction.Parameters.AddWithValue("@userid", Session["userID"]);
                    transaction.Parameters.AddWithValue("@coinname", coinname);
                    transaction.Parameters.AddWithValue("@amount", command);
                    transaction.Parameters.AddWithValue("@price", sellamount);
                    transaction.ExecuteNonQuery();
                }
                else
                {
                    lblfailure.Visible = true;
                    lblfailure.Text = "Mevcut bakiyeden fazla miktarda satamazsınız!!";
                }                               
            }
            else
            {
                lblfailure.Visible = true;
                lblfailure.Text = "Cüzdanınızda bu coinden bulunmamaktadır.";
            }
        }
        protected void buyButton_Click(object sender, EventArgs e)
        {
            int buyamount = Convert.ToInt32(buyAmountInputField.Text);
            string coinname = Request.Form["Coins"];
            SqlConnection sql = new SqlConnection(ConnectionString);
            sql.Open();
            SqlCommand cmdbalance = new SqlCommand("SELECT BALANCE FROM WALLET WHERE USER_ID=@userid AND COINNAME='USDT'", sql);
            cmdbalance.Parameters.AddWithValue("@userid", Session["userID"]);
            SqlDataReader readbalance = cmdbalance.ExecuteReader();
            readbalance.Read();
            int balance = Convert.ToInt32(readbalance["BALANCE"]);
            readbalance.Close();
            if (buyamount < balance)
            {

                SqlCommand buyp = new SqlCommand("SELECT CPRICE FROM COINS WHERE CNAME=@coinname", sql);
                buyp.Parameters.AddWithValue("@coinname", coinname);
                SqlDataReader readp = buyp.ExecuteReader();
                readp.Read();
                double coinp = Math.Round(Convert.ToDouble(readp["CPRICE"]), 2);
                readp.Close();
                double amount = Math.Round((buyamount / coinp), 2);

                SqlConnection sql2 = new SqlConnection(ConnectionString);
                SqlCommand walletinfo = new SqlCommand("SELECT COINAMOUNT FROM WALLET WHERE COINNAME=@coinname AND USER_ID=@userid", sql);
                walletinfo.Parameters.AddWithValue("@coinname", coinname);
                walletinfo.Parameters.AddWithValue("@userid", Session["userID"]);
                SqlDataReader readwallet = walletinfo.ExecuteReader();

                if (!readwallet.Read())
                {
                    readwallet.Close();
                    SqlCommand cmdusd = new SqlCommand("SELECT COINAMOUNT FROM WALLET WHERE COINNAME='USDT' AND USER_ID=@userid", sql);
                    cmdusd.Parameters.AddWithValue("@userid", Session["userID"]);
                    SqlDataReader readusd = cmdusd.ExecuteReader();
                    readusd.Read();
                    int usdt = Convert.ToInt32(readusd["COINAMOUNT"]);
                    readusd.Close();
                    SqlCommand insertcmd = new SqlCommand("INSERT INTO WALLET(USER_ID,COINNAME,COINAMOUNT,COINIMAGE) VALUES (@userid,@coinname,@coinamount,'images/" + coinname + ".png')", sql);
                    insertcmd.Parameters.AddWithValue("@userid", Session["userID"]);
                    insertcmd.Parameters.AddWithValue("@coinname", coinname);
                    insertcmd.Parameters.AddWithValue("@coinamount", amount);
                    insertcmd.ExecuteNonQuery();
                    SqlCommand usdupdate = new SqlCommand("UPDATE WALLET SET COINAMOUNT= @usdamount - @expense WHERE COINNAME='USDT' AND USER_ID=@userid", sql);
                    usdupdate.Parameters.AddWithValue("@usdamount", usdt);
                    usdupdate.Parameters.AddWithValue("@expense", buyamount);
                    usdupdate.Parameters.AddWithValue("@userid", Session["userID"]);
                    usdupdate.ExecuteNonQuery();
                }
                else
                {
                    int walletamount = Convert.ToInt32(readwallet["COINAMOUNT"]);
                    readwallet.Close();
                    SqlCommand cmdusd = new SqlCommand("SELECT COINAMOUNT FROM WALLET WHERE COINNAME='USDT' AND USER_ID=@userid", sql);
                    cmdusd.Parameters.AddWithValue("@userid", Session["userID"]);
                    SqlDataReader readusd = cmdusd.ExecuteReader();
                    readusd.Read();
                    int usdt = Convert.ToInt32(readusd["COINAMOUNT"]);
                    readusd.Close();
                    SqlCommand updatecmd = new SqlCommand("UPDATE WALLET SET COINAMOUNT = @walletamount + @amount WHERE COINNAME=@coinname AND USER_ID=@userid ", sql);
                    updatecmd.Parameters.AddWithValue("@walletamount", walletamount);
                    updatecmd.Parameters.AddWithValue("@amount", amount);
                    updatecmd.Parameters.AddWithValue("@coinname", coinname);
                    updatecmd.Parameters.AddWithValue("@userid", Session["userID"]);
                    updatecmd.ExecuteNonQuery();
                    SqlCommand usdupdate = new SqlCommand("UPDATE WALLET SET COINAMOUNT= @usdamount - @expense WHERE COINNAME='USDT' AND USER_ID=@userid", sql);
                    usdupdate.Parameters.AddWithValue("@usdamount", usdt);
                    usdupdate.Parameters.AddWithValue("@expense", buyamount);
                    usdupdate.Parameters.AddWithValue("@userid", Session["userID"]);
                    usdupdate.ExecuteNonQuery();
                }
                SqlCommand transaction = new SqlCommand("INSERT INTO TRANSACTIONS(USER_ID,COINNAME,BUY_SELL,AMOUNT,PRICE,T_DATE) VALUES (@userid,@coinname,'BUY',@amount,@price,'"+ date +"')", sql);
                transaction.Parameters.AddWithValue("@userid", Session["userID"]);
                transaction.Parameters.AddWithValue("@coinname",coinname);
                transaction.Parameters.AddWithValue("@amount",amount);
                transaction.Parameters.AddWithValue("@price",buyamount);
                transaction.ExecuteNonQuery();
            }
            else
            {
                lblfailure.Visible = true;
                lblfailure.Text = ("YETERSİZ BAKİYE");
            }


        }
    }
}
