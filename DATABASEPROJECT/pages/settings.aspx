<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="DATABASEPROJECT.pages.settings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <title>Settings</title>
    <link rel="stylesheet" href="style/style.css">
</head>
<body>
      <form runat="server">
          <div id="logo" style="position:fixed">
        <img id="imglogo"  src="images/logo.png" alt="logo">
        <h2 id="logoname">CoinAbi</h2>
    </div>
    <a href="profile.aspx" id="btnprof">Profile</a>
    
    <div id="btndiv" >
        <asp:Button ID="btnpass" runat="server" onclick="btnpass_Click" Text="Change Password"></asp:Button>
        <br />
        <br />
        <asp:Button ID="btnmail" runat="server" Text="Change Mail" OnClick="btnmail_Click"  ></asp:Button>
        <br />
        <br />
        <asp:Button ID="btndelete" runat="server" Text="Delete Account" OnClick="btndelete_Click"  ></asp:Button>
        <br />
        <br />
        <asp:Button ID="btnlogout" runat="server" Text="Logout" OnClick="btnlogout_Click" />
    
    </div>
    <br />
   <div id="formupdate" style="color:white; ">
        
        <br />
        <asp:TextBox ID="updatepass" runat="server" Width="13em" Height="2em"  BackColor="Transparent" BorderColor="#9340ff" BorderStyle="Double"  ></asp:TextBox> 
       <asp:Button ID="btnupdatepass" runat="server" Text="Update" BackColor="#9340ff" BorderColor="Transparent" Height="2.5em" Width="5em" OnClick="btnupdatepass_Click"   />
        <br />
        <br />
        <br />
        <br />
        <br />
        
        <br />
        <asp:TextBox ID="updatemail" runat="server" Width="13em" Height="2em"  BackColor="Transparent" BorderColor="#9340ff" BorderStyle="Double"    ></asp:TextBox> 
       <asp:Button ID="btnupdatemail" runat="server" OnClick="btnupdatemail_Click" Text="Update" BackColor="#9340ff" BorderColor="Transparent" Height="2.5em" Width="5em"  />
        <br />
        <br />
   </div>
      </form>
    
</body>
</html>
