<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="DATABASEPROJECT.pages.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link rel="stylesheet" href="style/style.css">
</head>
<body>
    <form id="form1" runat="server">
    <div id="logo">
        <img id="imglogo" src="images/logo.png" alt="logo">
        <h2 id="logoname">CoinAbi</h2>
    </div>
    <div class="container">
    <h1 id="prjhead">Future's Blockchain EcoSystem</h1>
    <p style="text-align: center; color: white; padding-left: 6em; padding-top: 3em; word-spacing: 0.3em; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;font-size: large;" >A cryptocurrency, crypto-currency, or crypto is a digital currency designed to work as a medium of exchange through a computer network that is not reliant on any central authority, such as a government or bank, to uphold or maintain it.</p>
</div>  
    <div class="btn-group">
        <asp:HyperLink ID="sign" runat="server" href="signup.aspx">Sign in</asp:HyperLink>  
        <asp:HyperLink ID="prof" runat="server" href="profile.aspx" Text=""></asp:HyperLink>
        <asp:HyperLink ID="trade" runat="server" href="TradePage.aspx" Text="">Trader</asp:HyperLink>
        <asp:HyperLink ID="log" runat="server" href="login.aspx">Login</asp:HyperLink>
        
    </div>  
    <asp:DataList ID="DataList1" runat="server" BackColor="#182137"  DataKeyField="CNAME" DataSourceID="SqlCoinTable">
        <ItemTemplate>
           <table id="cointable" cellpadding="2"   style="width: 80em; height: 10em";>
            <thead>
                <tr>
                    <th>Symbol</th>
                    <th>Name</th>
                    <th>Last</th>
                    <th></th>
                </tr>
            </thead>
                <tbody> 
           <tr>
                <td><asp:Image ID="productimg" runat="server" ImageUrl='<%#Eval("COINIMAGE") %>'  CssClass="proimg"/></td>
                <td><%# Eval("CNAME") %></td>
                <td><%# Eval("CPRICE") %> $</td>
                <td><a href="TradePage.aspx">Buy</a></td>
            </tr>
            <tr>
                </tbody>
               </table>
            
        </ItemTemplate>
        </asp:DataList>
     
        <asp:SqlDataSource ID="SqlCoinTable" runat="server" ConnectionString="<%$ ConnectionStrings:COINDBConnectionString %>" SelectCommand="SELECT [CNAME], [CPRICE], [FULLCOINNAME], [COINIMAGE] FROM [COINS] ORDER BY [CNAME]"></asp:SqlDataSource>
    </form>
     
</body>
</html>
