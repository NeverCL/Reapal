<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="certificateTo.aspx.cs" Inherits="ReapalFastApiDemo.certificateTo" %>
<!DOCTYPE html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<meta name="apple-mobile-web-app-title" content="融宝支付"/>
	<meta name="apple-mobile-web-app-capable" content="yes" />
	<meta name="apple-mobile-web-app-status-bar-style" content="black" />
	<meta content="telephone=no" name="format-detection" />
    <title>融宝支付</title>
    <link href="css/style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="rongpaysubmit" name="rongpaysubmit" action="http://testapi.reapal.com/fast/certificate" method="post">
    <div class="w">
        <header id="top" class="header">
	        <h2>荣程商城</h2>
	        <a class="back" onclick="window.history.back()">返回</a>
	    </header>
	
  	    <section class="cashier c">
	        <p class="t">
	            <label for="subject">商户号</label>
                <span><%=Request.QueryString["merchant_id"]%></span>
                <input type="hidden" name="merchant_id" value="<%=Request.QueryString["merchant_id"]%>" />
              
	        </p>
	        
	        <p class="t">
	            <label for="body">商户订单号</label>
                <span><%=Request.QueryString["order_no"]%></span>
                <input type="hidden" name="data" value="<%=Request.QueryString["data"]%>" />
                
	        </p>
	        
	         <p class="t">
                 <label for="body">终端类型</label>
                <span><%=Request.QueryString["terminal_type"]%></span>
                <input type="hidden" name="encryptkey" value="<%=Request.QueryString["encryptkey"]%>" />
             </p>
            <input type="submit" class="button" value="融宝支付确认付款">
        </section>
	    <footer>
		    <div class="copyright">Copyright &copy; 2015 融宝支付</div>	
	    </footer>
    </div>
    </form>

</body>
</html>
