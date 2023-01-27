<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TradePage.aspx.cs" Inherits="dbproj.TradePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
    <link rel="stylesheet" href="style/style.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css"/>
    <link rel="preconnect" href="https://fonts.googleapis.com"><link rel="preconnect" href="https://fonts.gstatic.com" crossorigin><link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300&display=swap" rel="stylesheet">


    <style>


</style>


</head>
<body style="color:white";  display: flex; justify-content: center; align-items: center;>
    <form id="form1" runat="server">
         <div id="logo">
        <img id="imglogo" src="images/logo.png" alt="logo">
        <h2 id="logoname">CoinAbi</h2>
    </div>

    
    <asp:Label ID="lblfailure" runat="server" Text="" ForeColor="Red"></asp:Label>

<div class="centeredRectView">
    
   &nbsp &nbsp &nbsp <asp:Label ID="CoinNameField" runat="server" Text="CoinName" Font-Size="X-Large"></asp:Label>
    &nbsp&nbsp&nbsp
<select name="Coins" id="coins" style="font-size:large">
  <option value="BTC">Bitcoin</option>
  <option value="ETH">Ethereum</option>
  <option value="BNB">BNB</option>
  <option value="DOGE">DogeCoin</option>
  <option value="XRP">XRP</option>
</select>


<div id="tradePriceViewContainer">

    <div id="tradePriceView">
        <asp:Label ID="priceLabel" runat="server" Text="" Font-Size="XX-Large" Font-Bold="False" Font-Names="Segoe UI"></asp:Label>
        <br /> <br />
        
    </div>
   

   


</div>


     <div class="tab">
    <button id="defaultTabLink" class="tablinks" onclick="openTab(event, 'BUY')">BUY</button>
    <button class="tablinks" onclick="openTab(event, 'SELL')">SELL</button>
  </div>
<div id="BUY" class="tabcontent">
    <asp:Label ID="Label1" runat="server" Text="Enter amount you'd like to buy:"></asp:Label>
    <asp:TextBox ID="buyAmountInputField" runat="server" Width="95%" Height="30px" BackColor="Transparent" ForeColor="White" CssClass="tradeInputField" Font-Size="Large" TextMode="Number"></asp:TextBox>
    <asp:Button ID="buyButton" runat="server" Text="BUY" CssClass="tradeBuyButton" OnClick="buyButton_Click" />
  </div>
  
  <div id="SELL" class="tabcontent">
      <asp:Label ID="Label2" runat="server" Text="Enter amount you'd like to sell:"></asp:Label>
 <asp:TextBox ID="sellAmountInputField" runat="server" Width="95%" Height="30px"  BackColor="Transparent" ForeColor="White" CssClass="tradeInputField"  Font-Size="Large" TextMode="Number"></asp:TextBox>
    <asp:Button ID="sellButton" runat="server" Text="SELL" CssClass="tradeBuyButton tradeSellButton" OnClick="sellButton_Click" />


  </div>

</div>
        <a href="Home.aspx" id="btnhome">Home</a>
    </form>
</body>

    
<script>

    function openTab(evt, tabName) {
        evt.preventDefault();
        var i, tabcontent, tablinks;
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        tablinks = document.getElementsByClassName("tablinks");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].className = tablinks[i].className.replace(" active", "");
        }
        document.getElementById(tabName).style.display = "block";
        evt.currentTarget.className += " active";
    }

	document.getElementById("defaultTabLink").click();
</script>

</html>
