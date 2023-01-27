<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="DATABASEPROJECT.pages.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="style/style.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css"/>
	<style type="text/css">
		.auto-style1 {
			height: 22px;
		}
		.auto-style2 {
			height: 26px;
		}

	</style>
</head>
<body>
    <form id="form1" runat="server">


       <div id="signupview" style="top:40%;">
        <div id="modernSignup">
            <table style="width: 100%;color:wheat;">
                <tr>
                    <td><h1>Sign up</h1></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Name</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
						<asp:TextBox ID="field_fname" runat="server" Width="286px" BackColor="Transparent" CssClass="registrationEntryField" ForeColor="Snow" Font-Size="Large"></asp:TextBox>
					</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td>Surname</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
						<asp:TextBox ID="field_lname" runat="server" Width="286px" BackColor="Transparent" CssClass="registrationEntryField" ForeColor="Snow" Font-Size="Large"></asp:TextBox>
					</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Email address</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
						<asp:TextBox ID="field_mail" runat="server" Width="286px" BackColor="Transparent" CssClass="registrationEntryField" ForeColor="Snow" Font-Size="Large"></asp:TextBox>
					</td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style1">Password</td>
                    <td class="auto-style1"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td>
						<asp:TextBox ID="field_password" runat="server" Width="286px" BackColor="Transparent" CssClass="registrationEntryField" ForeColor="Snow" Font-Size="Large" TextMode="Password"></asp:TextBox>
					</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td>
                 <br /> 
                        <asp:Button ID="btn_signup" runat="server" Text="SIGN UP" Width="294px" CssClass="regbtn" OnClick="btnsignup_Click" />
                         <br /> <br />
                        &nbsp;</td>
                    
                </tr>
            </table>
            <asp:Label ID="lblFailure" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />

            <asp:HyperLink ID="LinkButton1" style="color: salmon;"  runat="server" href="login.aspx">Already have an account? Sign in.</asp:HyperLink>
        </div>
           
    </div>



    </form>
</body>
</html>
