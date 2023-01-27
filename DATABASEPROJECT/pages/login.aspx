<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="DATABASEPROJECT.pages.signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="style/style.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div id="signupview">
        <div id="modernSignup">
            <table style="width: 100%;color:wheat;">
                 <tr>
                    <td><h1>Login</h1></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Email address</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
						<asp:TextBox ID="field_mail" runat="server" Width="286px" BackColor="Transparent" CssClass="registrationEntryField" ForeColor="Snow" Font-Size="Large"></asp:TextBox>
					</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td>Password</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
						<asp:TextBox ID="field_pswd" runat="server" Width="286px" BackColor="Transparent" CssClass="registrationEntryField" ForeColor="Snow" Font-Size="Large" TextMode="Password"></asp:TextBox>
					</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                
                 <tr>
                    <td>
                 <br />
                        <asp:Button ID="btnlogin" runat="server" Text="LOGIN" Width="294px" CssClass="regbtn" OnClick="btnlogin_Click" />
                         <br /> <br /> <br />
                        &nbsp;</td>
                </tr>
            </table>
            <asp:Label ID="lblFailure" runat="server" Text="" ForeColor="Red"></asp:Label>

            <asp:HyperLink ID="LinkButton1" style="color: salmon;"  runat="server" href="signup.aspx">Don't have an account? Sign up.</asp:HyperLink>


      
            
        </div>
           
    </div>





    </form>
</body>
</html>
