<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="DATABASEPROJECT.pages.profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="style/style.css">
</head>
<body>
    <div id="logo">
        <a href="home.aspx">
            <img id="imglogo" src="images/logo.png" alt="logo">
        </a>
        <h2 id="logoname">CoinAbi</h2>
    </div>
    <form id="form1" runat="server">    

        <div id="divuser">                         
           <asp:Label ID="lbluser" runat="server" Text="" ></asp:Label>
           <asp:Label ID="lblusers" runat="server" Text="" ></asp:Label>
           <br />
           <asp:Label ID="lblmail" runat="server" Text="" ></asp:Label>
           <br />
           <asp:Label ID="lblbalance" runat="server" Text="" ></asp:Label>

       </div>
        <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlWalletTable" CssClass="walletList">
            <ItemTemplate>
                <table id="cointable" cellpadding="2"   style="width: 80em; height: 3em";>
                <tbody> 
           <tr>
                <td><asp:Image ID="productimg" runat="server" ImageUrl='<%#Eval("COINIMAGE") %>'  CssClass="proimg"/></td>
                <td style="width:15em"><%# Eval("COINNAME") %></td>
                <td style="width:15em"><%# Eval("COINAMOUNT") %> </td>
                <td style="width:15em"><%# Eval("BALANCE") %> $</td>
                <td style="width:5em"><asp:Button ID="btntrade" runat="server" Text=">" CssClass="btntrade" OnClick="btntrade_Click" /></td>
            </tr>
                </tbody>
               </table>
                
                
                
<br />
                <br />
            </ItemTemplate>

        </asp:DataList>
        <asp:SqlDataSource ID="SqlWalletTable" runat="server" ConnectionString="<%$ ConnectionStrings:COINDBConnectionString %>" SelectCommand="SELECT [COINNAME], [COINAMOUNT], [BALANCE], [COINIMAGE] FROM [WALLET] WHERE ([USER_ID] = @USER_ID)">
            <SelectParameters>
                <asp:SessionParameter Name="USER_ID" SessionField="userID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
               <table id="cointable" cellpadding="2"   style="width: 80em; height: 3em";>
                <tbody> 
           <tr>
                
                <td style="width:15em"><%# Eval("COINNAME") %></td>
                <td style="width:15em"><%# Eval("BUY_SELL") %></td>
                <td style="width:15em"><%# Eval("AMOUNT") %></td>
                <td style="width:15em"><%# Eval("PRICE") %> $</td>
                <td style="width:15em"><%# Eval("T_DATE") %></td>
                
            </tr>
                </tbody>
               </table>
                
                
                
<br />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:COINDBConnectionString %>" SelectCommand="SELECT [COINNAME], [BUY_SELL], [AMOUNT], [PRICE], [T_DATE] FROM [TRANSACTIONS] WHERE ([USER_ID] = @USER_ID)">
            <SelectParameters>
                <asp:SessionParameter Name="USER_ID" SessionField="userID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <a href="settings.aspx" id="btnset">Settings</a>
        <a href="home.aspx" id="btnhome">Home</a>


    </form>
</body>
</html>
